using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Mesajlar_DML
    {
        public bool Mesajlar_Insert(Mesajlar a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Mesajlar ms = new Mesajlar();
                        ms.Mesaj_ID = a.Mesaj_ID;
                        ms.Kullanici_ID = a.Kullanici_ID;
                        ms.SosMedyaYetkili_ID = a.SosMedyaYetkili_ID;
                        ms.Konu = a.Konu;
                        ms.Desc = a.Desc;
                        ms.Tarih = a.Tarih;
                        sb.Mesajlar.Add(ms);
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

        public bool Yorum_Delete(Mesajlar a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Mesajlar ss = sb.Mesajlar.FirstOrDefault(x => x.Mesaj_ID == a.Mesaj_ID);
                        sb.Mesajlar.Remove(ss);
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

        public bool Yorum_Update(Mesajlar a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Mesajlar ms = sb.Mesajlar.First(x => x.Mesaj_ID == a.Mesaj_ID);
                        ms.Mesaj_ID = a.Mesaj_ID;
                        ms.Kullanici_ID = a.Kullanici_ID;
                        ms.SosMedyaYetkili_ID = a.SosMedyaYetkili_ID;
                        ms.Konu = a.Konu;
                        ms.Desc = a.Desc;
                        ms.Tarih = a.Tarih;
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

        public List<Mesajlar> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Mesajlar> getir = (from x in sb.Mesajlar
                                        select x).ToList();
                return getir;
            }
        }

        public List<Mesajlar> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Mesajlar> getir = (from x in sb.Mesajlar
                                        where x.Mesaj_ID == y
                                        select x).ToList();
                return getir;
            }
        }
    }
}