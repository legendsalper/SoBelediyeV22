using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Istek_Sikayet_DML
    {
        public bool IstekSikayet_Insert(IstekSikayet a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        IstekSikayet ist = new IstekSikayet();
                        ist.Istek_ID = a.Istek_ID;
                        ist.SosYetkili_ID = a.SosYetkili_ID;
                        ist.Kullanıcı_ID = a.Kullanıcı_ID;
                        ist.Konu = a.Konu;
                        ist.Desc = a.Desc;
                        ist.Tarih = a.Tarih;
                        ist.Turu = a.Turu;
                        ist.Yayinlansinmi = a.Yayinlansinmi;
                        ist.Onay_Durum = a.Onay_Durum;
                        ist.Adres_ID = a.Adres_ID;
                        sb.IstekSikayet.Add(ist);
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

        public bool IstekSikayet_Delete(IstekSikayet a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        IstekSikayet ist = sb.IstekSikayet.FirstOrDefault(x => x.Istek_ID == a.Istek_ID);
                        sb.IstekSikayet.Remove(ist);
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

        public bool IstekSikayet_Update(IstekSikayet a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        IstekSikayet ist = sb.IstekSikayet.FirstOrDefault(x => x.Istek_ID == a.Istek_ID);
                        ist.Istek_ID = a.Istek_ID;
                        ist.SosYetkili_ID = a.SosYetkili_ID;
                        ist.Kullanıcı_ID = a.Kullanıcı_ID;
                        ist.Konu = a.Konu;
                        ist.Desc = a.Desc;
                        ist.Tarih = a.Tarih;
                        ist.Turu = a.Turu;
                        ist.Yayinlansinmi = a.Yayinlansinmi;
                        ist.Onay_Durum = a.Onay_Durum;
                        ist.Adres_ID = a.Adres_ID;
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

        public List<IstekSikayet> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<IstekSikayet> getir = (from x in sb.IstekSikayet
                                            select x).ToList();
                return getir;
            }
        }

        public List<IstekSikayet> PriGetir(int y)
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<IstekSikayet> getir = (from x in sb.IstekSikayet
                                            where x.Istek_ID == y
                                            select x).ToList();
                return getir;
            }
        }
    }
}