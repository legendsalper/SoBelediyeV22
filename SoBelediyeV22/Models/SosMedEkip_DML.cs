using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class SosMedEkip_DML
    {
        public bool SosMedEkip_Insert(SosyalMedyaEkibi a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        SosyalMedyaEkibi sme = new SosyalMedyaEkibi();
                        sme.YetkiliID = a.YetkiliID;
                        sme.Ad = a.Ad;
                        sme.Soyad = a.Soyad;
                        sme.Email = a.Email;
                        sme.Telefon = a.Telefon;
                        sme.Nick = a.Nick;
                        sme.Cevap = a.Cevap;
                        sme.Yon_ID = a.Yon_ID;
                        sme.Evrak_ID = a.Evrak_ID;
                        sb.SosyalMedyaEkibi.Add(sme);
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

        public bool SosMedEkip_Delete(SosyalMedyaEkibi a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        SosyalMedyaEkibi ss = sb.SosyalMedyaEkibi.FirstOrDefault(x => x.YetkiliID == a.YetkiliID);
                        sb.SosyalMedyaEkibi.Remove(ss);
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

        public bool SosMedEkip_Update(SosyalMedyaEkibi a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        SosyalMedyaEkibi sme = sb.SosyalMedyaEkibi.FirstOrDefault(x => x.YetkiliID == a.YetkiliID);
                        sme.YetkiliID = a.YetkiliID;
                        sme.Ad = a.Ad;
                        sme.Soyad = a.Soyad;
                        sme.Email = a.Email;
                        sme.Telefon = a.Telefon;
                        sme.Nick = a.Nick;
                        sme.Cevap = a.Cevap;
                        sme.Yon_ID = a.Yon_ID;
                        sme.Evrak_ID = a.Evrak_ID;
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

        public List<SosyalMedyaEkibi> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<SosyalMedyaEkibi> getir = (from x in sb.SosyalMedyaEkibi
                                                select x).ToList();
                return getir;
            }
        }

        public List<SosyalMedyaEkibi> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<SosyalMedyaEkibi> getir = (from x in sb.SosyalMedyaEkibi
                                                where x.YetkiliID == y
                                                select x).ToList();
                return getir;
            }
        }
    }
}