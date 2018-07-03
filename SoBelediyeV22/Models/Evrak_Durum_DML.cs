using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Evrak_Durum_DML
    {
        public bool EvrakDurum_Insert(Evrak_Durum a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak_Durum ed = new Evrak_Durum();
                        ed.Durum_ID = a.Durum_ID;
                        ed.Durumu = a.Durumu;
                        sb.Evrak_Durum.Add(ed);
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


        public bool Evrk_Durum_Delete(Evrak_Durum a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak_Durum ed = sb.Evrak_Durum.FirstOrDefault(x => x.Durum_ID == a.Durum_ID);
                        sb.Evrak_Durum.Remove(ed);
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

        public bool EvrakDurum_Update(Evrak_Durum a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak_Durum ed = sb.Evrak_Durum.FirstOrDefault(x => x.Durum_ID == a.Durum_ID);
                        ed.Durum_ID = a.Durum_ID;
                        ed.Durumu = a.Durumu;
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

        public List<Evrak_Durum> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Evrak_Durum> getir = (from x in sb.Evrak_Durum
                                           select x).ToList();
                return getir;
            }
        }

        public List<Evrak_Durum> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Evrak_Durum> getir = (from x in sb.Evrak_Durum
                                           where x.Durum_ID == y
                                           select x).ToList();
                return getir;
            }
        }
    }
}