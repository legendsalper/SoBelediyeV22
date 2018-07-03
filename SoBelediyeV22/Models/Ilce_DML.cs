using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Ilce_DMS
    {
        public bool ilce_Insert(Ilce usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Ilce ilce = new Ilce();
                        ilce.Ilce1 = usr.Ilce1;
                        ilce.IlID = usr.IlID;
                        ilce.Ilce_ID = usr.Ilce_ID;
                        sb.Ilce.Add(ilce);
                        sb.SaveChanges();
                        ts.Complete();

                    }
                }
            }
            catch (SystemException ex)
            {
                return false;
            }
            return true;
        }

        public bool ilce_Delete(Ilce usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Ilce ilce = sb.Ilce.FirstOrDefault(x => x.Ilce_ID == usr.Ilce_ID);
                        sb.Ilce.Remove(ilce);
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

        public bool ilce_Update(Ilce usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Ilce ilce = sb.Ilce.First(x => x.Ilce_ID == usr.Ilce_ID);
                        ilce.Ilce1 = "degisik";
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

        public List<Ilce> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Ilce> getir = (from x in sb.Ilce
                                    select x).ToList();
                return getir;
            }
        }

        public List<Ilce> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Ilce> getir = (from x in sb.Ilce
                                    where x.Ilce_ID == y
                                    select x).ToList();
                return getir;
            }
        }

    }
}