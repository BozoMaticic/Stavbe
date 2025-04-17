using System;
using API.Data.Enums;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace API.Data.SeedData;

public class SeedMerilnaMesta
{
    private class OsnovaZaMerMesta
    {
        public int IdJavnegaObjekta { get; set; }
        public string Tip { get; set; } = "";    // Polje za MerilnoMestoTypeEnum
        public int TipID { get; set; }      // Polje za MerilnoMestoTypeEnum Int
        public string OdjemnoMesto { get; set; } = "";
        public string Ozn_obj { get; set; } = "";        // šifra objekta
        public string NazivJobjekta { get; set; } = "";
        public string NovaSifra { get; set; } = "";        // nova šifra merilnega mesta

        public string Ogrevanje { get; set; } = "";
        public int OgrevanjeId { get; set; }
        public string OgrevanjeOznaka { get; set; } = "";
    }


    public static async Task ImportMM(DataContext context)
    {
        if (await context.MerilnaMesta.AnyAsync()) return;

        // var steviloDodanihMerMest = 0;
        List<OsnovaZaMerMesta> ListaOsnov = new List<OsnovaZaMerMesta>();


        var path = "Data/Source/JObjektiInMerilnaMesta.xlsx";

        using var stream = System.IO.File.OpenRead(path);
        using var excelPackage = new ExcelPackage(stream);

        // get the first worksheet 
        var worksheet = excelPackage.Workbook.Worksheets[0];

        // define how many rows we want to process 
        var nEndRow = worksheet.Dimension.End.Row;


        // initialize the record counters 
        int steviloDodanihMerilnihMest = 0;
        int steviloNeuspelih = 0;

        // kreiram dictionary prve vrste excla - imena polj

        var koloneDict = new Dictionary<string, int>();

        var prvaVrsta = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];

        for (var i = 1; i <= worksheet.Dimension.End.Column; i++)
        {
            koloneDict.Add(prvaVrsta[1, i].GetValue<string>(), i);
        }

        // create a lookup dictionary 
        // containing all the Merilna mesta already existing 
        // into the Database (it will be empty on first run).
        var merilnaMestaPoSifri = await context.MerilnaMesta
            .ToDictionaryAsync(x => x.StMerilnegaMesta, StringComparer.OrdinalIgnoreCase);



        // iterates through all rows, skipping the first one 
        for (int nRow = 2; nRow <= nEndRow; nRow++)
        {
            var row = worksheet.Cells[
                nRow, 1, nRow, worksheet.Dimension.End.Column];

            // var sifraJavnegaObjekta = row[nRow, koloneDict["OZN_obj"]].GetValue<string>();

            var nazivObjekta = row[nRow, koloneDict["Naziv"]].GetValue<string>();
            var oznObjekta = row[nRow, koloneDict["OZN_obj"]].GetValue<string>();

            var jObj = await context.Stavbe.Where(a => a.SifraJavnegaObjekta == oznObjekta).FirstOrDefaultAsync();

            if (jObj == null) continue;


            // ogrevanje
            if (row[nRow, koloneDict["Ogr_kraj1"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.IdJavnegaObjekta = jObj.Id;

                _osnova.Tip = "OGREVANJE";
                _osnova.TipID = 2;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Odjemno_M1"]].GetValue<string>();



                var value = row[nRow, koloneDict["Ogr_kraj1"]].GetValue<string>();

                foreach (TipOgrevanjaOznakaEnum _tipOgrevanjaOznaka in Enum.GetValues(typeof(TipOgrevanjaOznakaEnum)))
                {
                    if (_tipOgrevanjaOznaka.ToString() == value)
                    {
                        _osnova.OgrevanjeOznaka = _tipOgrevanjaOznaka.ToString();
                        _osnova.OgrevanjeId = (int)_tipOgrevanjaOznaka;

                        TipOgrevanjaEnum mojTip = (TipOgrevanjaEnum)((int)_tipOgrevanjaOznaka);
                        _osnova.Ogrevanje = mojTip.ToString();
                        _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.OgrevanjeOznaka + "-" + _osnova.Ozn_obj + "-1";

                    }
                }
                ListaOsnov.Add(_osnova);


            }
            if (row[nRow, koloneDict["Ogr_kraj2"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.IdJavnegaObjekta = jObj.Id;


                _osnova.Tip = "OGREVANJE";
                _osnova.TipID = 2;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Odjemno_M2"]].GetValue<string>();



                var value = row[nRow, koloneDict["Ogr_kraj2"]].GetValue<string>();

                foreach (TipOgrevanjaOznakaEnum _tipOgrevanjaOznaka in Enum.GetValues(typeof(TipOgrevanjaOznakaEnum)))
                {
                    if (_tipOgrevanjaOznaka.ToString() == value)
                    {
                        _osnova.OgrevanjeOznaka = _tipOgrevanjaOznaka.ToString();
                        _osnova.OgrevanjeId = (int)_tipOgrevanjaOznaka;
                        _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.OgrevanjeOznaka + "-" + _osnova.Ozn_obj + "-2";


                        TipOgrevanjaEnum mojTip = (TipOgrevanjaEnum)((int)_tipOgrevanjaOznaka);
                        _osnova.Ogrevanje = mojTip.ToString();
                    }
                }
                ListaOsnov.Add(_osnova);
            }


            if (row[nRow, koloneDict["Ogr_kraj3"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "OGREVANJE";
                _osnova.TipID = 2;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Odjemno_M3"]].GetValue<string>();

                var value = row[nRow, koloneDict["Ogr_kraj3"]].GetValue<string>();


                foreach (TipOgrevanjaOznakaEnum _tipOgrevanjaOznaka in Enum.GetValues(typeof(TipOgrevanjaOznakaEnum)))
                {
                    if (_tipOgrevanjaOznaka.ToString() == value)
                    {
                        _osnova.OgrevanjeOznaka = _tipOgrevanjaOznaka.ToString();
                        _osnova.OgrevanjeId = (int)_tipOgrevanjaOznaka;
                        _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.OgrevanjeOznaka + "-" + _osnova.Ozn_obj + "-3";


                        TipOgrevanjaEnum mojTip = (TipOgrevanjaEnum)((int)_tipOgrevanjaOznaka);
                        _osnova.Ogrevanje = mojTip.ToString();
                    }
                }
                ListaOsnov.Add(_osnova);
            }

            // elektrika
            if (row[nRow, koloneDict["Elektrika_1"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "ELEKTRIKA";
                _osnova.TipID = 1;

                _osnova.OdjemnoMesto = row[nRow, koloneDict["Elektrika_1"]].GetValue<string>();

                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-1";
                ListaOsnov.Add(_osnova);
            }
            if (row[nRow, koloneDict["Elektrika_2"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "ELEKTRIKA";
                _osnova.TipID = 1;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Elektrika_2"]].GetValue<string>();
                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-2";
                ListaOsnov.Add(_osnova);
            }
            if (row[nRow, koloneDict["Elektrika_3"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "ELEKTRIKA";
                _osnova.TipID = 1;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Elektrika_3"]].GetValue<string>();
                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-3";
                ListaOsnov.Add(_osnova);
            }
            if (row[nRow, koloneDict["Elektrika_4"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "ELEKTRIKA";
                _osnova.TipID = 1;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Elektrika_4"]].GetValue<string>();
                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-4";
                ListaOsnov.Add(_osnova);
            }

            // komunala
            if (row[nRow, koloneDict["Komunala_1"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "KOMUNALA";
                _osnova.TipID = 3;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Komunala_1"]].GetValue<string>();

                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-1";
                ListaOsnov.Add(_osnova);
            }
            if (row[nRow, koloneDict["Komunala_2"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "KOMUNALA";
                _osnova.TipID = 3;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Komunala_2"]].GetValue<string>();
                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-2";
                ListaOsnov.Add(_osnova);
            }
            if (row[nRow, koloneDict["Komunala_3"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "KOMUNALA";
                _osnova.TipID = 3;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Komunala_3"]].GetValue<string>();
                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-3";
                ListaOsnov.Add(_osnova);
            }

            // odpadki
            if (row[nRow, koloneDict["Odpadki_1"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "SMETI";
                _osnova.TipID = 5;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Odpadki_1"]].GetValue<string>();

                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-1";
                ListaOsnov.Add(_osnova);
            }
            if (row[nRow, koloneDict["Odpadki_2"]].GetValue<string>() != null)
            {
                var _osnova = new OsnovaZaMerMesta();
                _osnova.IdJavnegaObjekta = jObj.Id;
                _osnova.Ozn_obj = oznObjekta;
                _osnova.NazivJobjekta = nazivObjekta;
                _osnova.Tip = "SMETI";
                _osnova.TipID = 5;
                _osnova.OdjemnoMesto = row[nRow, koloneDict["Odpadki_2"]].GetValue<string>();
                _osnova.NovaSifra = _osnova.Tip + "-" + _osnova.Ozn_obj + "-2";
                ListaOsnov.Add(_osnova);
            }


        }

        foreach (var _osnova in ListaOsnov)
        {
            var merMesto = new MerilnoMesto();

            try
            {
                merMesto.IdJavnegaZavoda = _osnova.IdJavnegaObjekta;
                merMesto.IdStavbe = _osnova.IdJavnegaObjekta;

                merMesto.SifraJavnegaObjekta = _osnova.Ozn_obj;
                merMesto.StMerilnegaMesta = _osnova.NovaSifra;
                merMesto.NickName = "";
                merMesto.NazivJavnegaObjekta = _osnova.NazivJobjekta;

                merMesto.Energent = _osnova.TipID;
                merMesto.EnergentTip = _osnova.Tip;


                merMesto.Ogrevanje = _osnova.Ogrevanje;
                merMesto.OgrevanjeId = _osnova.OgrevanjeId;
                merMesto.OgrevanjeOznaka = _osnova.OgrevanjeOznaka;


                merMesto.Dobavitelj = _osnova.OdjemnoMesto;
                merMesto.ObracunskaMoc = 0;

                // koordinate dodamo kasneje
                merMesto.ZemljepisnaSirina = 0;
                merMesto.ZemljepisnaDolzina = 0;
                merMesto.NadmorskaVisina = 0;

                merMesto.CreatedDate = DateTime.UtcNow;
                merMesto.UpdatedDate = DateTime.UtcNow;

                try
                {
                    await context.AddAsync(merMesto);
                    //        context.SaveChanges();
                    steviloDodanihMerilnihMest++;
                }
                catch { steviloNeuspelih++; }
                ;
            }
            catch { steviloNeuspelih++; }
        }
        await context.SaveChangesAsync();

        Console.WriteLine("Stevilo dodanih merilnih mest: " + steviloDodanihMerilnihMest);
        Console.WriteLine("Stevilo neuspelih: " + steviloNeuspelih);

        return;
    }




}


