using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Evrak_Yon_DML
    {
        public bool EvrakYon_Insert(Evrak_Yon a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak_Yon ey = new Evrak_Yon();
                        ey.Yon_ID = a.Yon_ID;
                        ey.Evrak_ID = a.Evrak_ID;
                        ey.DurumID = a.DurumID;
                        ey.Aciklama = a.Aciklama;
                        ey.Tarih = a.Tarih;
                        sb.Evrak_Yon.Add(ey);
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

        public bool EvrakYon_Delete(Evrak_Yon a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak_Yon ey = sb.Evrak_Yon.FirstOrDefault(x => x.Yon_ID == a.Yon_ID);
                        sb.Evrak_Yon.Remove(ey);
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

        public bool EvrakYon_Update(Evrak_Yon a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak_Yon ey = sb.Evrak_Yon.FirstOrDefault(x => x.Yon_ID == a.Yon_ID);
                        ey.Yon_ID = a.Yon_ID;
                        ey.Evrak_ID = a.Evrak_ID;
                        ey.DurumID = a.DurumID;
                        ey.Aciklama = a.Aciklama;
                        ey.Tarih = a.Tarih;
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

        public List<Evrak_Yon> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Evrak_Yon> getir = (from x in sb.Evrak_Yon
                                         select x).ToList();
                return getir;
            }
        }

        public List<Evrak_Yon> PriGetir(int y)
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Evrak_Yon> getir = (from x in sb.Evrak_Yon
                                         where x.Evrak_ID == y
                                         select x).ToList();
                return getir;
            }
        }
    }
}