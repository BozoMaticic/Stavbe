using System;
using System.Globalization;
using API.Entities.MojElektro;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace API.Data.SeedData;

public class SeedMojElektro15minMeritve
{
    public static async Task Import15minMeritve(DataContext context)
    {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

        if (await context.MojElektro15MinMeritve.AnyAsync()) return;

        Calendar koledar = currentCulture.Calendar; // System.Globalization.GregorianCalendar

        Dictionary<string, int> seznamMerMest = new Dictionary<string, int>();
        foreach (MojElektroMerilnoMesto mermesto in context.MojElektroMerilnaMesta)
        {
            try
            {
                if (mermesto.EnotniIdentifikator != null)
                {
                    seznamMerMest.Add(mermesto.EnotniIdentifikator, mermesto.Id);
                }
                else
                {
                    Console.WriteLine("EnotniIdentifikator is null for merilno mesto with Id: " + mermesto.Id);
                }
            }
            catch
            {
                Console.WriteLine("napaka dict");
            }
        }
        Dictionary<string, int> seznamNeuvrscenihMerilnihMest = new Dictionary<string, int>();

        var path = "Data/Source/MojElektro/15minMeritve2022-2023.xlsx";

        using var stream = System.IO.File.OpenRead(path);
        using var excelPackage = new ExcelPackage(stream);

        // get the first worksheet 
        var worksheet = excelPackage.Workbook.Worksheets[0];

        // define how many rows we want to process 
        var nEndRow = worksheet.Dimension.End.Row;

        // initialize the record counters 
        var steviloDodanihMeritev = 0;
        int steviloNeuspelih = 0;

        // kreiram dictionary prve vrste excla - imena polj
        var koloneDict = new Dictionary<string, int>();
        var prvaVrsta = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
        for (var i = 1; i <= worksheet.Dimension.End.Column; i++)
        {
            koloneDict.Add(prvaVrsta[1, i].GetValue<string>(), i);
        }

        // za testiranje
        int testniI = 0;

        for (int nRow = 2; nRow <= nEndRow; nRow++)
        {
            var row = worksheet.Cells[
                nRow, 1, nRow, worksheet.Dimension.End.Column];

            if (row[nRow, koloneDict["Status odčitka A+"]].GetValue<string>() != null)
                continue;


            var _meritev = new MojElektro15MinMeritev();

            var pom = row[nRow, koloneDict["Merilno mesto"]].GetValue<string>();
            if (seznamMerMest.ContainsKey(pom))
            {
                _meritev.StMerilnegaMesta = pom;
            }
            else
            {
                Console.WriteLine("Merilno mesto ne obstaja: " + pom);
                continue;
            }
            _meritev.IdMerilnegaMesta = seznamMerMest[_meritev.StMerilnegaMesta];
            _meritev.IdMerilnegaMestaMojElektro = _meritev.IdMerilnegaMesta;

            _meritev.TimeStamp = row[nRow, koloneDict["Časovna značka"]].GetValue<DateTime>();
            _meritev.Leto = row[nRow, koloneDict["Leto"]].GetValue<int>();
            _meritev.Mesec = row[nRow, koloneDict["Mesec"]].GetValue<int>();

            if (_meritev.TimeStamp.Year != _meritev.Leto)    // prva meritev v novem letu ob 24:00    
            {
                _meritev.Leto = _meritev.Leto + 1;
                _meritev.Mesec = 1;
            }


            _meritev.LetoMesec = _meritev.Leto.ToString("0000") + _meritev.Mesec.ToString("00");

            _meritev.Blok = row[nRow, koloneDict["Blok"]].GetValue<int>();
            _meritev.LetoMesecBlok = _meritev.LetoMesec + _meritev.Blok.ToString("00");

            int week = koledar.GetWeekOfYear(_meritev.TimeStamp, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            // var danVTednu = koledar.GetDayOfWeek(_meritev.TimeStamp);

            int steviloDniVLetu = koledar.GetDaysInYear(_meritev.Leto);
            int stevilkaDnevaVLetu = koledar.GetDayOfYear(_meritev.TimeStamp);

            var danVTednu = (int)_meritev.TimeStamp.DayOfWeek;

            _meritev.LetoTedenDan = _meritev.Leto.ToString("0000") + week.ToString("00") + danVTednu.ToString("00");
            _meritev.LetoTedenDanUra = _meritev.LetoTedenDan + _meritev.TimeStamp.Hour.ToString("00");
            _meritev.LetoDanUra = _meritev.Leto.ToString("0000") + stevilkaDnevaVLetu.ToString("0000") + _meritev.TimeStamp.Hour.ToString("00");

            _meritev.Energija_A_plus = row[nRow, koloneDict["Energija A+"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija A+"]].GetValue<decimal>();
            //       _meritev.Energija_A_plus = row[nRow, koloneDict["Energija A+"]].GetValue<decimal>();

            _meritev.Energija_A_minus = row[nRow, koloneDict["Energija A-"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija A-"]].GetValue<decimal>();
            _meritev.Energija_R_plus = row[nRow, koloneDict["Energija R+"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija R+"]].GetValue<decimal>();
            _meritev.Energija_R_minus = row[nRow, koloneDict["Energija R-"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Energija R-"]].GetValue<decimal>();
            _meritev.PrejetaDelovnaMoc = row[nRow, koloneDict["P+ Prejeta delovna moč"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["P+ Prejeta delovna moč"]].GetValue<decimal>();
            _meritev.OddanaDelovnaMoc = row[nRow, koloneDict["P- Oddana delovna moč"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["P- Oddana delovna moč"]].GetValue<decimal>();
            _meritev.PrejetaJalovaMoc = row[nRow, koloneDict["Q+ Prejeta jalova moč"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Q+ Prejeta jalova moč"]].GetValue<decimal>();
            _meritev.OddanaJalovaMoc = row[nRow, koloneDict["Q- Oddana jalova moč"]].GetValue<string>() == "" ? 0 : row[nRow, koloneDict["Q- Oddana jalova moč"]].GetValue<decimal>();


            await context.MojElektro15MinMeritve.AddAsync(_meritev);

            // za test !!!!!!
            if (testniI > 30000)
            {
                await context.SaveChangesAsync();
                testniI = 0;
            }
            else testniI++;

            steviloDodanihMeritev++;
            //   Console.WriteLine("dodan record " + steviloDodanihMeritev.ToString("0000") + " " + _meritev.LetoTedenDan);
        }
        if (steviloDodanihMeritev > 0)
            await context.SaveChangesAsync();

        Console.WriteLine($"Dodano {steviloDodanihMeritev} steviloDodanihMeritev");
        Console.WriteLine($"Neuspešno dodanih {steviloNeuspelih} steviloNeuspelih.");

    }
}
