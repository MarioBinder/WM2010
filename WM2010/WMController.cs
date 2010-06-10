using System;
using System.Collections.Generic;
using System.Linq;
using WM2010Management;
using WM2010.Common;

namespace WM2010
{
    /// <summary>
    /// Ermoeglicht den Zugriff auf die Datenschicht WM2010Management
    /// </summary>
    public class WMController
    {
        /// <summary>
        /// Ermittelt alle Mannschaften einer Gruppe
        /// </summary>
        /// <param name="gruppeId"></param>
        /// <returns></returns>
        public Mannschaft[] GetMannschaften(int gruppeId)
        {
            var response = from a in WM2010Manager.GetMannschaften()
                           where a.GruppeID == gruppeId
                           select a;

            List<Mannschaft> mannschaften = response.ToList();
            return mannschaften.ToArray();
        }


        /// <summary>
        /// Ermittelt das Spiel anhand der beiden Mannschaften
        /// </summary>
        /// <param name="mannschaft1Id"></param>
        /// <param name="mannschaft2Id"></param>
        /// <returns></returns>
        public Spiel GetSpiel(int mannschaft1Id, int mannschaft2Id)
        {
            return WM2010Manager.GetSpiel(mannschaft1Id, mannschaft2Id);
        }


        /// <summary>
        /// Speichert das Spiel
        /// </summary>
        /// <returns></returns>
        public Spiel SaveSpiel(Spiel spiel)
        {
            return WM2010Manager.UpdateSpiel(spiel);
        }

        /// <summary>
        /// Speichert die Mannschaft
        /// </summary>
        /// <returns></returns>
        public Mannschaft SaveMannschaft(Mannschaft mannschaft)
        {
            return WM2010Manager.UpdateMannschaft(mannschaft);
        }

        /// <summary>
        /// Ermitteln der Mannschaft
        /// </summary>
        /// <returns></returns>
        public Mannschaft GetMannschaft(int id)
        {
            return WM2010Manager.GetMannschaft(id);
        }

        /// <summary>
        /// Ermittelt alle Begegnungen einer Gruppe
        /// </summary>
        /// <returns></returns>
        public Begegnung[] GetBegegnungen(int gruppenId)
        {
            var games = new List<Spiel>();
            var begegnungen = new List<Begegnung>();

            using (var context = new WM2010Entities())
            {
                var mannschaften = GetMannschaften(gruppenId);

                foreach (var m in mannschaften)
                {
                    var spiele = (from s in context.Spiel
                                  where s.Mannschaft1Id == m.MannschaftId || s.Mannschaft2Id == m.MannschaftId
                                  select s).ToList();
                    foreach (var spiel in spiele)
                    {
                        if (!games.Contains(spiel))
                        {
                            spiel.SpielOrtReference.Load();
                            games.Add(spiel);
                        }
                    }
                }

                foreach (var game in games)
                {
                    var begegnung = new Begegnung();

                    var m1 = (from m in mannschaften
                              where game.Mannschaft1Id == m.MannschaftId
                              select m).FirstOrDefault();
                    var m2 = (from m in mannschaften
                              where game.Mannschaft2Id == m.MannschaftId
                              select m).FirstOrDefault();

                    if (m1 != null && m2 != null)
                    {
                        begegnung.Spiel = game;
                        begegnung.Mannschaft1Fahne = m1.Fahne;
                        begegnung.Mannschaft1Name = m1.Land;

                        begegnung.Mannschaft2Fahne = m2.Fahne;
                        begegnung.Mannschaft2Name = m2.Land;

                        begegnungen.Add(begegnung);
                    }
                }

                return begegnungen.ToArray();
            }
        }


        /// <summary>
        /// Ermittelt Finalrundenspiel anhand des Datums
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public Spiel GetFinalrundenSpiel(DateTime dateTime)
        {
            using (var context = new WM2010Entities())
            {
                var result = (from g in context.Spiel
                              where g.DatumUhrzeit == dateTime
                              select g).FirstOrDefault();
                if (result == null)
                    return null;

                result.SpielOrtReference.Load();

                return result;
            }
        }




        /// <summary>
        /// Ermittelt alle Begegnungen aus einem Zeitraum fuer die Finalrunden
        /// </summary>
        /// <returns></returns>
        public Spiel[] GetFinalrundenSpiele(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);

            using (var context = new WM2010Entities())
            {
                var result = (from g in context.Spiel
                              where g.DatumUhrzeit >= startDate && g.DatumUhrzeit <= endDate
                              select g).ToArray();

                foreach (var r in result)
                {
                    r.SpielOrtReference.Load();
                }

                return result;
            }
        }

        /// <summary>
        /// Prueft und speichert eine Begegnung
        /// </summary>
        public void SaveBegegnung(Begegnung begegnung)
        {

            //mannschaften holen
            var m1 = GetMannschaft((int)begegnung.Spiel.Mannschaft1Id);
            var m2 = GetMannschaft((int)begegnung.Spiel.Mannschaft2Id);

            var gruppenId = m1.GruppeID;

            //spiel holen
            var spiel = GetSpiel(m1.MannschaftId, m2.MannschaftId);

            //pruefen ob begegnung schon statt fand, wenn ja dann das alte Ergebnis subtrahieren
            if (spiel.ToreMannschaft1 != null && spiel.ToreMannschaft2 != null)
            {
                //tore an der Mannschaft um das alte Ergebnis subtrahieren
                m1.Tore -= spiel.ToreMannschaft1;
                m2.Tore -= spiel.ToreMannschaft2;

                //gegentore um das alte ergebnis subtrahieren
                m1.GegenTore -= spiel.ToreMannschaft2;
                m2.GegenTore -= spiel.ToreMannschaft1;

                //punkte an der Mannschaft um das alte ergebnis subtrahieren
                if (spiel.ToreMannschaft1 != spiel.ToreMannschaft2)
                {
                    if (spiel.ToreMannschaft1 > spiel.ToreMannschaft2)
                    {
                        m1.Punkte -= 3;
                    }
                    else if (spiel.ToreMannschaft1 < spiel.ToreMannschaft2)
                    {
                        m2.Punkte -= 3;
                    }
                }
                else
                {
                    m1.Punkte -= 1;
                    m2.Punkte -= 1;
                }
            }


            //tore schreiben
            m1.Tore += begegnung.Spiel.ToreMannschaft1;
            m2.Tore += begegnung.Spiel.ToreMannschaft2;

            m1.GegenTore += begegnung.Spiel.ToreMannschaft2;
            m2.GegenTore += begegnung.Spiel.ToreMannschaft1;

            //punkte verteilen
            if (begegnung.Spiel.ToreMannschaft1 != begegnung.Spiel.ToreMannschaft2)
            {
                if (begegnung.Spiel.ToreMannschaft1 > begegnung.Spiel.ToreMannschaft2)
                {
                    m1.Punkte += 3;
                }
                else if (begegnung.Spiel.ToreMannschaft1 < begegnung.Spiel.ToreMannschaft2)
                {
                    m2.Punkte += 3;
                }
            }
            else
            {
                m1.Punkte += 1;
                m2.Punkte += 1;
            }


            //speichern
            SaveSpiel(begegnung.Spiel);
            SaveMannschaft(m1);
            SaveMannschaft(m2);


            //TODO
            //Finalrunden "bestuecken"

            //wenn in einer Gruppe alle Spiele gespeichert, dann den erst und zweitplazierten einsortieren
            var begegnungen = GetBegegnungen(m1.GruppeID);


            if (Array.TrueForAll(begegnungen, b => b.Spiel.Mannschaft1Id.HasValue && b.Spiel.ToreMannschaft2.HasValue))
            {
                var sieger = GetGruppenErster(gruppenId);
                var zweiter = GetGruppenZweiter(gruppenId);
                Spiel s1 = new Spiel();
                Spiel s2 = new Spiel();

                switch (gruppenId)
                {
                    case 1://Gruppe A

                        //Sieger Gruppe A spielt am 26. Juni 2010, 16:00 Uhr als M1
                        s1 = GetFinalrundenSpiel(new DateTime(634131648000000000));
                        s1.Mannschaft1Id = sieger.MannschaftId;

                        //Sieger Gruppe A spielt am 27. Juni 2010, 20:30 Uhr als M2
                        s2 = GetFinalrundenSpiel(new DateTime(634132674000000000));
                        s2.Mannschaft2Id = zweiter.MannschaftId;
                        break;

                    case 2://Gruppe B
                        //Zweiter Gruppe A am 26. Juni 2010, 16:00 Uhr als M2
                        s1 = GetFinalrundenSpiel(new DateTime(634131648000000000));
                        s1.Mannschaft2Id = zweiter.MannschaftId;

                        //Zweiter Gruppe A am 27. Juni 2010, 20:30 Uhr als M1
                        s2 = GetFinalrundenSpiel(new DateTime(634132674000000000));
                        s2.Mannschaft1Id = sieger.MannschaftId;
                        break;

                    case 3://Gruppe C
                        //Sieger Gruppe C 26. Juni 2010, 20:30 Uhr als M1
                        s1 = GetFinalrundenSpiel(new DateTime(634131810000000000));
                        s1.Mannschaft1Id = sieger.MannschaftId;

                        //Sieger 27. Juni 2010, 16:00 Uhr als M1
                        s2 = GetFinalrundenSpiel(new DateTime(634132512000000000));
                        s2.Mannschaft2Id = zweiter.MannschaftId;


                        break;

                    case 4: //GruppeD
                        //Zweiter Gruppe D 26. Juni 2010, 20:30 Uhr als M2
                        s1 = GetFinalrundenSpiel(new DateTime(634131810000000000));
                        s1.Mannschaft2Id = zweiter.MannschaftId;

                        //Zweiter D 27. Juni 2010, 16:00 Uhr als M1    
                        s2 = GetFinalrundenSpiel(new DateTime(634132512000000000));
                        s2.Mannschaft1Id = sieger.MannschaftId;

                        break;

                    case 5: //Gruppe E
                        //Sieger E 28. Juni 2010, 16:00 Uhr als M1
                        s1 = GetFinalrundenSpiel(new DateTime(634133376000000000));
                        s1.Mannschaft1Id = sieger.MannschaftId;


                        //Sieger E 29. Juni 2010, 16:00 Uhr als M2
                        s2 = GetFinalrundenSpiel(new DateTime(634134240000000000));
                        s2.Mannschaft2Id = zweiter.MannschaftId;


                        break;

                    case 6: //Gruppe F
                        //Zweiter F 28. Juni 2010, 16:00 Uhr als M2
                        s1 = GetFinalrundenSpiel(new DateTime(634133376000000000));
                        s1.Mannschaft2Id = zweiter.MannschaftId;


                        //Zweiter F 29. Juni 2010, 16:00 Uhr als M1
                        s2 = GetFinalrundenSpiel(new DateTime(634134240000000000));
                        s2.Mannschaft1Id = sieger.MannschaftId;

                        break;

                    case 7: //Gruppe G
                        //Sieger G 28. Juni 2010, 20:30 Uhr als M1
                        s1 = GetFinalrundenSpiel(new DateTime(634133538000000000));
                        s1.Mannschaft1Id = sieger.MannschaftId;

                        // Sieger G 29. Juni 2010, 20:30 Uhr als M2
                        s2 = GetFinalrundenSpiel(new DateTime(634134402000000000));
                        s2.Mannschaft2Id = zweiter.MannschaftId;

                        break;

                    case 8: //Gruppe H
                        //Zweiter H 28. Juni 2010, 20:30 Uhr als M2
                        s1 = GetFinalrundenSpiel(new DateTime(634133538000000000));
                        s1.Mannschaft2Id = zweiter.MannschaftId;

                        //Zweiter H 29. Juni 2010, 20:30 Uhr als M1
                        s2 = GetFinalrundenSpiel(new DateTime(634134402000000000));
                        s2.Mannschaft1Id = sieger.MannschaftId;
                        break;

                    default:
                        break;
                }

                SaveSpiel(s1);
                SaveSpiel(s2);
            }
        }


        public string SaveAndSetFinalrunden(Begegnung begegnung)
        {
            if (begegnung == null || begegnung.Spiel == null)
                throw new ArgumentNullException("begegnung");

            if (begegnung.Spiel.ToreMannschaft1 == begegnung.Spiel.ToreMannschaft2)
                throw new ArgumentException("In den Finalrunden muss das Ergebnis eindeutig sein");


            var result = WM2010Manager.UpdateSpiel(begegnung.Spiel);

            if (result == null)
                throw new Exception("Fehler beim Speichern des Spiels");


            //sieger und verlierer aus der Partie ermitteln:
            var siegerMannschaftId = (result.ToreMannschaft1 > result.ToreMannschaft2) ? result.Mannschaft1Id.Value : result.Mannschaft2Id.Value;
            var verliererMannschaftId = (result.ToreMannschaft1 < result.ToreMannschaft2) ? result.Mannschaft1Id.Value : result.Mannschaft2Id.Value;


            Spiel spiel = new Spiel();
            Spiel verliererspiel = new Spiel();
            
            //switche das Spieldatum und lege die neuen spiele fest
            switch (result.DatumUhrzeit.Value.Ticks)
            {
                //achtelfinalgewinner ziehen ins viertelfinale
                case 634131648000000000:
                    //Sieger  als ma1 am 634136832000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634136832000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;

                case 634131810000000000:
                    //Sieger als ma2 am 634136832000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634136832000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;

                case 634132512000000000:
                    //Sieger als ma1 am 634137696000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634137696000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;

                case 634132674000000000:
                    //Sieger als ma2 am 634137696000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634137696000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;

                case 634133376000000000:
                    //Sieger als ma1 am 634136994000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634136994000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;

                case 634133538000000000:
                    //Sieger als ma2 am 634136994000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634136994000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;

                case 634134240000000000:
                    //Sieger als ma1 am 634137858000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634137858000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;


                case 634134402000000000:
                    //Sieger als ma2 am 634137858000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634137858000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;


                //viertelfinalgewinner ziehen ins Halbfinale
                case 634136832000000000:
                    //sieger als m1 am 634140450000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634140450000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;

                case 634136994000000000:
                    //sieger als m2 am 634140450000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634140450000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;

                case 634137696000000000:
                    //sieger als m1 am 634141314000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634141314000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;

                case 634137858000000000:
                    //sieger als m2 am 634141314000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634141314000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;



                case 634140450000000000:
                    //halbfinalverlierer
                    //verlierer als m1 am 634143906000000000
                    verliererspiel = GetFinalrundenSpiel(new DateTime(634143906000000000));
                    verliererspiel.Mannschaft1Id = verliererMannschaftId;
                    SaveSpiel(verliererspiel);

                    //halbfinalgewinner
                    //sieger als m1 am 634144770000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634144770000000000));
                    spiel.Mannschaft1Id = siegerMannschaftId;
                    break;


                case 634141314000000000:
                    //halbfinalverlierer
                    //verlierer als m2 am 634143906000000000
                    verliererspiel = GetFinalrundenSpiel(new DateTime(634143906000000000));
                    verliererspiel.Mannschaft2Id = verliererMannschaftId;
                    SaveSpiel(verliererspiel);


                    //halbfinalgewinner
                    //Sieger als m2 am 634144770000000000
                    spiel = GetFinalrundenSpiel(new DateTime(634144770000000000));
                    spiel.Mannschaft2Id = siegerMannschaftId;
                    break;



                default:
                    break;
            }

            SaveSpiel(spiel);
            return String.Empty;
        }

        /// <summary>
        /// Sortieren der Reihenfolge einer Gruppe
        /// Anzahl Punkte aus allen Gruppenspielen (Sieg: 3 Punkte; Unentschieden: 1 Punkt; Niederlage: 0 Punkte);
        /// Tordifferenz aus allen drei Spielen;
        /// Anzahl der in allen drei Gruppenspielen erzielten Tore;
        /// </summary>
        /// <returns></returns>
        public static List<Mannschaft> SortMannschaften(List<Mannschaft> mannschaften)
        {
            return (from m in mannschaften
                    orderby m.Punkte descending
                    orderby m.Tore descending
                    orderby m.Tore - m.GegenTore descending
                    select m).ToList();
        }

        /// <summary>
        /// Ermittelt den erstplazierten einer Gruppe
        /// </summary>
        /// <param name="gruppenId"></param>
        /// <returns></returns>
        public Mannschaft GetGruppenErster(int gruppenId)
        {
            return (from m in SortMannschaften(new List<Mannschaft>(GetMannschaften(gruppenId)))
                    select m).FirstOrDefault();
        }

        /// <summary>
        /// Ermittelt den zweitplazierten einer Gruppe
        /// </summary>
        /// <param name="gruppenId"></param>
        /// <returns></returns>
        public Mannschaft GetGruppenZweiter(int gruppenId)
        {
            return (from m in SortMannschaften(new List<Mannschaft>(GetMannschaften(gruppenId)))
                    select m).Skip(1).FirstOrDefault();
        }

    }
}
