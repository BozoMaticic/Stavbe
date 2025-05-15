using System;
using API.Data.Enums;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace API.Data.SeedData;

public class SeedOdcitki
{
    public static async Task ImportElektro(DataContext context)
    {
        if (await context.Odcitki.AnyAsync()) return;

        var path = "Data/Source/En_Kamnik_Elektrika_2020_2022_v3.xlsx";

        using var stream = System.IO.File.OpenRead(path);
        using var excelPackage = new ExcelPackage(stream);

        // get the first worksheet 
        var worksheet = excelPackage.Workbook.Worksheets[0];

        // define how many rows we want to process 
        var nEndRow = worksheet.Dimension.End.Row;

        // initialize the record counters 
        var steviloDodanihOdcitkov = 0;
        int steviloNeuspelih = 0;

        // kreiram dictionary prve vrste excla - imena polj
        var koloneDict = new Dictionary<string, int>();
        var prvaVrsta = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
        for (var i = 1; i <= worksheet.Dimension.End.Column; i++)
        {
            koloneDict.Add(prvaVrsta[1, i].GetValue<string>(), i);
        }

        var meseciDict = new Dictionary<string, int>();
        int indeksKolone = 1;
        meseciDict.Add("Januar", indeksKolone++);
        meseciDict.Add("Februar", indeksKolone++);
        meseciDict.Add("Marec", indeksKolone++);
        meseciDict.Add("April", indeksKolone++);
        meseciDict.Add("Maj", indeksKolone++);
        meseciDict.Add("Junij", indeksKolone++);
        meseciDict.Add("Julij", indeksKolone++);
        meseciDict.Add("Avgust", indeksKolone++);
        meseciDict.Add("September", indeksKolone++);
        meseciDict.Add("Oktober", indeksKolone++);
        meseciDict.Add("November", indeksKolone++);
        meseciDict.Add("December", indeksKolone++);

        Dictionary<string, int> seznamNeuvrscenihMerilnihMest = new Dictionary<string, int>();
        int steviloNeuspelihMerilnihMest = 0;

        Dictionary<string, int> seznamMerMest = new Dictionary<string, int>();
        Dictionary<string, string> seznamDobaviteljiMerMesta = new Dictionary<string, string>();

        foreach (MerilnoMesto mermesto in context.MerilnaMesta)
        {
            try
            {
                seznamMerMest.Add(mermesto.StMerilnegaMesta, mermesto.Id);
                seznamDobaviteljiMerMesta.Add(mermesto.Dobavitelj, mermesto.StMerilnegaMesta);
            }
            catch
            {
                Console.WriteLine("napaka dict");
            }
        }

        for (int nRow = 2; nRow <= nEndRow; nRow++)
        {
            var row = worksheet.Cells[
                nRow, 1, nRow, worksheet.Dimension.End.Column];

            var _odc = new Odcitek();

            _odc.Type = Convert.ToInt16(OdcitekTypeEnum.ELEKTRIKA);
            _odc.EnergentTip = "ELEKTRIKA";



            var pom = row[nRow, koloneDict["Merilno_mesto"]].GetValue<string>();
            if (seznamDobaviteljiMerMesta.ContainsKey(pom))
            {
                var _sifraMerMesta = seznamDobaviteljiMerMesta[pom];
                _odc.StMerilnegaMesta = _sifraMerMesta;
            }
            else
            {
                Console.WriteLine("sifra mermesta ne obstaja:" + pom);                                  // tukaj lovimo nova merilna mesta !!!!!!!!!!!!!!!
                break;
            }


            _odc.NazivMerilnegaMesta = row[nRow, koloneDict["Merilno_mesto"]].GetValue<string>();     // naziv merilnega mesta uporabimo za dobavitelja


            if (seznamMerMest[_odc.StMerilnegaMesta] > 0)
                _odc.IdMerilnegaMesta = seznamMerMest[_odc.StMerilnegaMesta];
            else
            {
                _odc.IdMerilnegaMesta = 0;
                Console.WriteLine("ele odcitek brez mer mesta" + _odc.NazivMerilnegaMesta);
            }



            var leto = row[nRow, koloneDict["Leto"]].GetValue<string>();
            var letoNum = Convert.ToInt16(leto);
            var mesec = row[nRow, koloneDict["Mesec"]].GetValue<string>();
            var mesecNumeric = meseciDict[mesec].ToString("00");
            _odc.LetoMesec = leto + meseciDict[mesec].ToString("00");

            _odc.StevilkaRacuna = row[nRow, koloneDict["Št. Računa"]].GetValue<string>();

            var pomDate = new DateTime(letoNum, meseciDict[mesec], 1);
            _odc.DatumOdcitka = pomDate;

            // ele

            _odc.EleenergijaVt = row[nRow, koloneDict["Energija VT (kWh)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija VT (kWh)"]].GetValue<decimal>();
            _odc.EleenergijaMt = row[nRow, koloneDict["Energija MT (kWh)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija MT (kWh)"]].GetValue<decimal>();
            _odc.EleenergijaET = row[nRow, koloneDict["Energija ET (kWh)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija ET (kWh)"]].GetValue<decimal>();
            _odc.Energija = (_odc.EleenergijaMt ?? 0) + (_odc.EleenergijaVt ?? 0) + (_odc.EleenergijaET ?? 0);


            _odc.EleJalovaEnergija = row[nRow, koloneDict["Jalova energija (kVArh)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Jalova energija (kVArh)"]].GetValue<decimal>();

            _odc.EleobracunskaMoc = row[nRow, koloneDict["Obračunska moč (kW)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Obračunska moč (kW)"]].GetValue<decimal>();
            _odc.ELEEnergijaEUR = row[nRow, koloneDict["Energija (EUR)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija (EUR)"]].GetValue<decimal>();
            _odc.ELEOmreznina = row[nRow, koloneDict["Omrežnina (EUR)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Omrežnina (EUR)"]].GetValue<decimal>();
            _odc.ELEPrispevki = row[nRow, koloneDict["Prispevki (EUR)"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Prispevki (EUR)"]].GetValue<decimal>();
            _odc.Znesek = row[nRow, koloneDict["Skupaj z DDV"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Skupaj z DDV"]].GetValue<decimal>();

            _odc.CreatedDate = DateTime.Now;
            _odc.UpdatedDate = DateTime.Now;

            if (seznamMerMest.ContainsKey(_odc.StMerilnegaMesta))
            {
                _odc.IdMerilnegaMesta = seznamMerMest[_odc.StMerilnegaMesta];

                var mmesto = await context.MerilnaMesta.FindAsync(_odc.IdMerilnegaMesta);
                if (mmesto == null)
                {
                    Console.WriteLine($"MerilnoMesto with Id {_odc.IdMerilnegaMesta} not found.");
                    continue;
                }

                _odc.MerilnoMesto = mmesto;
                _odc.StMerilnegaMesta = mmesto.StMerilnegaMesta;

                _odc.IdJavnegaObjekta = mmesto.IdJavnegaZavoda;


                // za debug

                if (_odc.IdJavnegaObjekta == 8)
                    Console.WriteLine("ttt");



            }
            else
            {
                if (!seznamNeuvrscenihMerilnihMest.ContainsKey(_odc.StMerilnegaMesta))
                {
                    seznamNeuvrscenihMerilnihMest.Add(_odc.StMerilnegaMesta, steviloNeuspelihMerilnihMest++);
                }
                steviloNeuspelih++;
            }
            await context.Odcitki.AddAsync(_odc);
            steviloDodanihOdcitkov++;
        }
        if (steviloDodanihOdcitkov > 0)
            await context.SaveChangesAsync();

        Console.WriteLine($"Dodano {steviloDodanihOdcitkov} steviloDodanihMeritev");
        Console.WriteLine($"Neuspešno dodanih {steviloNeuspelih} steviloNeuspelih.");

    }

}
