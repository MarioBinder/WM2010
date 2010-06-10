using System;
using System.Linq;
using System.Data.Objects;
using System.Data;
using System.Collections.Generic;

namespace WM2010Management
{
    /// <summary>
    /// WM2010Manager-Klasse stellt die CRUD Operationen für WM2010 bereit
    /// </summary>
    public class WM2010Manager
    {
        #region FussballWM
        /// <summary>
        /// CompiledQuery zum Ermitteln einer FussbalWM
        /// </summary>
        private static Func<WM2010Entities, int, FussballWM> _cqFussballWM;
        private static Func<WM2010Entities, int, FussballWM> CqFussballWM
        {
            get
            {
                if (_cqFussballWM == null)
                {
                    _cqFussballWM = CompiledQuery.Compile<WM2010Entities, int, FussballWM>((context, id)
                        => (from wm in context.FussballWM
                            where wm.FussballWMId == id
                            select wm).FirstOrDefault());
                }
                return _cqFussballWM;
            }
        }

        /// <summary>
        /// Methode zum Erstellen einer FussballWM
        /// </summary>
        public static FussballWM CreateWM(FussballWM wm)
        {
            if (wm == null)
                throw new ArgumentNullException("wm");

            using (var context = new WM2010Entities())
            {
                context.AddToFussballWM(wm);
                context.SaveChanges();

                context.Refresh(RefreshMode.StoreWins, wm);
                return wm;
            }

        }

        /// <summary>
        /// Methode zum Ermitteln einer FussbalWM
        /// </summary>
        public static FussballWM GetWM()
        {
            using (var context = new WM2010Entities())
            {
                var wm = (from w in context.FussballWM
                          select w).First();

                if (wm == null)
                    throw new ObjectNotFoundException("wm");

                return wm;
            }
        }


        /// <summary>
        /// Methode zum Aendern einer FussballWM
        /// </summary>
        public static FussballWM UpdateWM(FussballWM wm)
        {
            if (wm == null)
                throw new ArgumentNullException("wm");

            using (var context = new WM2010Entities())
            {
                var update = CqFussballWM.Invoke(context, wm.FussballWMId);
                if (update == null)
                    throw new ObjectNotFoundException("FussballWM not found");

                context.ApplyPropertyChanges(update.EntityKey.EntitySetName, wm);
                context.SaveChanges();

                context.Refresh(RefreshMode.StoreWins, wm);
                return wm;
            }
        }
        #endregion

        #region Mannschaft
        /// <summary>
        /// CompiledQuery zum Ermitteln einer FussbalWM
        /// </summary>
        private static Func<WM2010Entities, int, Mannschaft> _cqMannschaft;
        private static Func<WM2010Entities, int, Mannschaft> CqMannschaft
        {
            get
            {
                if (_cqMannschaft == null)
                {
                    _cqMannschaft = CompiledQuery.Compile<WM2010Entities, int, Mannschaft>((context, id)
                        => (from m in context.Mannschaft
                            where m.MannschaftId == id
                            select m).FirstOrDefault());
                }
                return _cqMannschaft;
            }
        }

        /// <summary>
        /// Methode zum Erstellen einer Mannschaft
        /// </summary>
        public static Mannschaft CreateMannschaft(Mannschaft mannschaft)
        {
            if (mannschaft == null)
                throw new ArgumentNullException("mannschaft");


            using (var context = new WM2010Entities())
            {
                context.AddToMannschaft(mannschaft);
                //context.Detach(mannschaft.Gruppe);

                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, mannschaft);
            }

            return mannschaft;
        }


        /// <summary>
        /// Methode zum Ermitteln einer Mannschaft
        /// </summary>
        public static Mannschaft GetMannschaft(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            using (var context = new WM2010Entities())
            {
                var mannschaft = CqMannschaft.Invoke(context, id);

                if (mannschaft == null)
                    throw new ObjectNotFoundException("mannschaft");

                return mannschaft;
            }
        }

        /// <summary>
        /// Methode zum Ermitteln von  Mannschaften
        /// </summary>
        public static Mannschaft[] GetMannschaften()
        {
            using (var context = new WM2010Entities())
            {
                var result = (from m in context.Mannschaft
                              select m).ToArray();

                return result;
            }
        }



        /// <summary>
        /// Methode zum Aendern einer Mannschaft
        /// </summary>
        public static Mannschaft UpdateMannschaft(Mannschaft mannschaft)
        {
            if (mannschaft == null)
                throw new ArgumentNullException("mannschaft");


            using (var context = new WM2010Entities())
            {
                var m = CqMannschaft.Invoke(context, mannschaft.MannschaftId);
                

                context.ApplyPropertyChanges(m.EntityKey.EntitySetName, mannschaft);
                context.SaveChanges();

                context.Refresh(RefreshMode.StoreWins, m);

                return m;
            }
        }





        #endregion

        #region Gruppe
        /// <summary>
        /// CompiledQuery zum Ermitteln einer Gruppe
        /// </summary>
        private static Func<WM2010Entities, int, Gruppe> _cqGruppe;
        private static Func<WM2010Entities, int, Gruppe> CqGruppe
        {
            get
            {
                if (_cqGruppe == null)
                {
                    _cqGruppe = CompiledQuery.Compile<WM2010Entities, int, Gruppe>((context, id)
                        => (from g in context.Gruppe
                            where g.GruppeId == id
                            select g).FirstOrDefault());
                }
                return _cqGruppe;
            }
        }


        /// <summary>
        /// Methode zum Erstellen einer Gruppe
        /// </summary>
        public static Gruppe CreateGruppe(Gruppe gruppe)
        {
            if (gruppe == null)
                throw new ArgumentNullException("gruppe");

            using (var context = new WM2010Entities())
            {
                context.AddToGruppe(gruppe);
                context.SaveChanges();

                context.Refresh(RefreshMode.StoreWins, gruppe);
            }
            return gruppe;
        }

        public static Gruppe UpdateGruppe(Gruppe gruppe)
        {
            if (gruppe == null)
                throw new ArgumentNullException("gruppe");

            using (var context = new WM2010Entities())
            {
                var g = CqGruppe.Invoke(context, gruppe.GruppeId);
                context.ApplyPropertyChanges(g.EntityKey.EntitySetName, gruppe);
                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, gruppe);
                return gruppe;
            }
        }

        /// <summary>
        /// Methode zum Ermitteln einer Gruppe
        /// </summary>
        public static Gruppe GetGruppe(int id)
        {
            if (id < 0)
                throw new ArgumentNullException("id");

            using (var context = new WM2010Entities())
            {
                var result = CqGruppe(context, id);

                if (result == null)
                    throw new ObjectNotFoundException("gruppe");

                return result;
            }
        }

        /// <summary>
        /// Methode zum Ermitteln von Gruppen
        /// </summary>
        public static Gruppe[] GetGruppen()
        {

            using (var context = new WM2010Entities())
            {
                var gruppen = (from g in context.Gruppe
                               select g).ToArray();

                return gruppen;
            }
        }
        #endregion

        #region Spieler
        /// <summary>
        /// CompiledQuery zum Ermitteln eines Spielers
        /// </summary>
        private static Func<WM2010Entities, int, Spieler> _cqSpieler;
        private static Func<WM2010Entities, int, Spieler> CqSpieler
        {
            get
            {
                if (_cqSpieler == null)
                {
                    _cqSpieler = CompiledQuery.Compile<WM2010Entities, int, Spieler>((context, id)
                        => (from s in context.Spieler
                            where s.SpielerId == id
                            select s).FirstOrDefault());
                }
                return _cqSpieler;
            }
        }

        /// <summary>
        /// Methode zum Erstellen eines Spielers
        /// </summary>
        public static Spieler CreateSpieler(Spieler spieler)
        {
            if (spieler == null)
                throw new ArgumentNullException("spieler");

            using (var context = new WM2010Entities())
            {
                context.AddToSpieler(spieler);
                context.SaveChanges();

                context.Refresh(RefreshMode.StoreWins, spieler);
            }
            return spieler;
        }

        /// <summary>
        /// Ermittelt einen Spieler anhand der Id
        /// </summary>
        public static Spieler GetSpieler(int spielerId)
        {
            if (spielerId < 0)
                throw new ArgumentNullException("spielerId");

            using (var context = new WM2010Entities())
            {
                var spieler = CqSpieler.Invoke(context, spielerId);

                if (spieler == null)
                    throw new ObjectNotFoundException("spieler");

                return spieler;
            }
        }


        /// <summary>
        /// Ermittelt Spieler aus einer Mannschaft
        /// </summary>
        public static Spieler[] GetSpielerFromMannschaft(int mannschaftsId)
        {
            if (mannschaftsId < 0)
                throw new ArgumentNullException("mannschaftsId");

            using (var context = new WM2010Entities())
            {
                var spieler = (from s in context.Spieler
                               where s.Mannschaft.MannschaftId == mannschaftsId
                               select s).ToArray();

                return spieler;
            }
        }

        /// <summary>
        /// Aendert einen Spieler
        /// </summary>
        public static Spieler UpdateSpieler(Spieler spieler)
        {
            if (spieler == null)
                throw new ArgumentNullException("spieler");

            using (var context = new WM2010Entities())
            {
                var s = CqSpieler.Invoke(context, spieler.SpielerId);
                if (s == null)
                    throw new ObjectNotFoundException("spieler");

                context.ApplyPropertyChanges(s.EntityKey.EntitySetName, spieler);
                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, spieler);

                return spieler;
            }
        }
        #endregion

        #region SpielPosition
        /// <summary>
        /// CompiledQuery zum Ermitteln eines Spielers
        /// </summary>
        private static Func<WM2010Entities, int, SpielPosition> _cqSpielPosition;
        private static Func<WM2010Entities, int, SpielPosition> CqSpielPosition
        {
            get
            {
                if (_cqSpielPosition == null)
                {
                    _cqSpielPosition = CompiledQuery.Compile<WM2010Entities, int, SpielPosition>((context, id)
                        => (from sp in context.SpielPosition
                            where sp.SpielPositionId == id
                            select sp).FirstOrDefault());
                }
                return _cqSpielPosition;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static SpielPosition CreateSpielPosition(SpielPosition position)
        {
            if (position == null)
                throw new ArgumentNullException("position");

            using (var context = new WM2010Entities())
            {
                context.AddToSpielPosition(position);
                context.SaveChanges();
            }
            return position;

        }

        /// <summary>
        /// Ermittelt die Spielposition eines Spielers
        /// </summary>
        public static SpielPosition GetSpielPosition(int positionId)
        {
            if (positionId < 0)
                throw new ArgumentNullException("positionId");

            using (var context = new WM2010Entities())
            {
                var position = CqSpielPosition.Invoke(context, positionId);
                if (position == null)
                    throw new ObjectNotFoundException("spielposition");

                return position;
            }
        }

        /// <summary>
        /// Aendert eine Spielposition 
        /// </summary>
        public static SpielPosition UpdateSpielPosition(SpielPosition position)
        {
            if (position == null)
                throw new ArgumentNullException("position");

            using (var context = new WM2010Entities())
            {
                var sp = CqSpielPosition.Invoke(context, position.SpielPositionId);
                if (sp == null)
                    throw new ObjectNotFoundException("spielposition");

                context.ApplyPropertyChanges(sp.EntityKey.EntitySetName, position);
                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, position);
                return position;
            }
        }


        #endregion

        #region SpielOrt
        /// <summary>
        /// CompiledQuery zum Ermitteln eines SpielOrtes
        /// </summary>
        private static Func<WM2010Entities, int, SpielOrt> _cqSpielOrt;
        private static Func<WM2010Entities, int, SpielOrt> CqSpielOrt
        {
            get
            {
                if (_cqSpielOrt == null)
                {
                    _cqSpielOrt = CompiledQuery.Compile<WM2010Entities, int, SpielOrt>((context, id)
                        => (from sp in context.SpielOrt
                            where sp.SpielOrtId == id
                            select sp).FirstOrDefault());
                }
                return _cqSpielOrt;
            }
        }
        /// <summary>
        /// Methode zum Erstellen eines SpielOrtes
        /// </summary>
        public static SpielOrt CreateSpielOrt(SpielOrt spielOrt)
        {
            if (spielOrt == null)
                throw new ArgumentNullException("spielOrt");

            using (var context = new WM2010Entities())
            {
                context.AddToSpielOrt(spielOrt);
                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, spielOrt);

                return spielOrt;
            }
        }

        /// <summary>
        /// Methode zum Aendern eines SpielOrtes
        /// </summary>
        public static SpielOrt UpdateSpielOrt(SpielOrt spielOrt)
        {
            if (spielOrt == null)
                throw new ArgumentNullException("spielOrt");

            using (var context = new WM2010Entities())
            {
                var so = CqSpielOrt.Invoke(context, spielOrt.SpielOrtId);

                context.ApplyPropertyChanges(so.EntityKey.EntitySetName, spielOrt);
                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, spielOrt);
                return spielOrt;
            }
        }


        /// <summary>
        /// Methode zum Ermitteln eines SpielOrtes
        /// </summary>
        public static SpielOrt GetSpielOrt(int spielOrtId)
        {
            if (spielOrtId < 0)
                throw new ArgumentNullException("spielOrtId");

            using (var context = new WM2010Entities())
            {
                var so = CqSpielOrt.Invoke(context, spielOrtId);
                if (so == null)
                    throw new ObjectNotFoundException("SpielOrt");

                return so;
            }
        }

        /// <summary>
        /// Methode zum Loeschen eines SpielOrtes
        /// </summary>
        public static void DeleteSpielOrt(int spielOrtId)
        {
            if (spielOrtId < 0)
                throw new ArgumentNullException("spielOrtId");

            using (var context = new WM2010Entities())
            {
                var so = CqSpielOrt.Invoke(context, spielOrtId);
                if (so == null)
                    throw new ObjectNotFoundException("SpielOrt");

                context.DeleteObject(so);
                context.SaveChanges();
            }
        }

        #endregion

        #region Spiel
        /// <summary>
        /// CompiledQuery zum Ermitteln eines Spiels
        /// </summary>
        private static Func<WM2010Entities, int, Spiel> _cqSpiel;
        private static Func<WM2010Entities, int, Spiel> CqSpiel
        {
            get
            {
                if (_cqSpiel == null)
                {
                    _cqSpiel = CompiledQuery.Compile<WM2010Entities, int, Spiel>((context, id)
                        => (from sp in context.Spiel
                            where sp.Id == id
                            select sp).FirstOrDefault());
                }
                return _cqSpiel;
            }
        }

        /// <summary>
        /// Methode zum Ermitteln eines Spiel
        /// </summary>
        public static Spiel GetSpiel(int mannschaft1Id, int mannschaft2Id)
        {
            using (var context = new WM2010Entities())
            {
                var game = (from s in context.Spiel
                            where s.Mannschaft1Id == mannschaft1Id && s.Mannschaft2Id == mannschaft2Id
                            select s).FirstOrDefault();
                game.SpielOrtReference.Load();

                return game;
            }
        }

        /// <summary>
        /// Methode zum Aendern eines Spiels
        /// </summary>
        public static Spiel UpdateSpiel(Spiel spiel)
        {
            if (spiel == null)
                throw new ArgumentNullException("spiel");

            using (var context = new WM2010Entities())
            {
                var so = CqSpiel.Invoke(context, spiel.Id);

                if (so == null)
                    return null;

                context.ApplyPropertyChanges(so.EntityKey.EntitySetName, spiel);
                context.SaveChanges();
                context.Refresh(RefreshMode.StoreWins, so);

                so.SpielOrtReference.Load();
                return so;
            }
        }

        /// <summary>
        /// Methode zum Loeschen eines Spiels
        /// </summary>
        public static void DeleteSpiel(int spielId)
        {
            if (spielId < 0)
                throw new ArgumentNullException("spielId");

            using (var context = new WM2010Entities())
            {
                var so = CqSpiel.Invoke(context, spielId);
                if (so == null)
                    throw new ObjectNotFoundException("Spiel");

                context.DeleteObject(so);
                context.SaveChanges();
            }
        }

        #endregion

    }
}
