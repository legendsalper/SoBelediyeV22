using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Birim_DML
    {
        public bool Birim_Insert(Birim a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Birim bb = new Birim();
                        bb.Birim_ID = a.Birim_ID;
                        bb.Info = a.Info;
                        bb.Cevap = a.Cevap;
                        bb.Yon_ID = a.Yon_ID;
                        bb.SosMedyaYet_ID = a.SosMedyaYet_ID;
                        sb.Birim.Add(bb);
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

        public bool Birim_Delete(Birim a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Birim bb = sb.Birim.FirstOrDefault(x => x.Birim_ID == a.Birim_ID);
                        sb.Birim.Remove(bb);
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

        public bool Birim_Update(Birim a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Birim bb = sb.Birim.FirstOrDefault(x => x.Birim_ID == a.Birim_ID);
                        bb.Birim_ID = a.Birim_ID;
                        bb.Info = a.Info;
                        bb.Cevap = a.Cevap;
                        bb.Yon_ID = a.Yon_ID;
                        bb.SosMedyaYet_ID = a.SosMedyaYet_ID;
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

        public List<Birim> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Birim> getir = (from x in sb.Birim
                                     select x).ToList();
                return getir;
            }
        }

        public List<Birim> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Birim> getir = (from x in sb.Birim
                                     where x.Birim_ID == y
                                     select x).ToList();
                return getir;
            }
        }
    }
}