using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Adres_DML
    {
        public bool adres_Insert(Adres usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Adres adres = new Adres();
                        adres.AdresID = usr.AdresID;
                        adres.Kullanici_ID = usr.Kullanici_ID;
                        adres.Il_ID = usr.Il_ID;
                        adres.AcikAdres = usr.AcikAdres;
                        adres.IlceID = usr.IlceID;
                        sb.Adres.Add(adres);
                        sb.SaveChanges();
                        ts.Complete();
                    }
                }
            }
            catch (SystemException)
            {
                return false;
            }
            return true;
        }

        public bool adres_Delete(Adres usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Adres adres = sb.Adres.FirstOrDefault(ad => ad.AdresID == usr.AdresID);
                        sb.Adres.Remove(adres);
                        sb.SaveChanges();
                        ts.Complete();//commit etti

                    }
                }
            }
            catch
            { //rollback

                using (TransactionScope ts = new TransactionScope())
                { ts.Dispose(); }
                return false;
            }
            return true;
        }

        public bool adres_Update(Adres usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Adres adres = sb.Adres.First(x => x.AdresID == usr.AdresID);
                        adres.AdresID = usr.AdresID;
                        adres.Kullanici_ID = usr.Kullanici_ID;
                        adres.Il_ID = usr.Il_ID;
                        adres.AcikAdres = usr.AcikAdres;
                        adres.IlceID = usr.IlceID;
                        sb.SaveChanges();
                        ts.Complete();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Adres> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Adres> getir = (from x in sb.Adres
                                     select x).ToList();
                return getir;
            }
        }

        public List<Adres> PriGetir(int y)
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Adres> getir = (from x in sb.Adres
                                     where x.AdresID == y
                                     select x).ToList();
                return getir;
            }
        }
    }
}