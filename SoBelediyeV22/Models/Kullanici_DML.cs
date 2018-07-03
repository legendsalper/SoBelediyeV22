using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace SoBelediyeV22.Models
{
    public class Kullanici_DML
    {

        public bool Kullanici_Insert(Kullanici usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Kullanici kl = new Kullanici();
                        kl.Kullanici_ID = usr.Kullanici_ID;
                        kl.Ad = usr.Ad;
                        kl.Soyad = usr.Soyad;
                        kl.Sifre = usr.Sifre;
                        kl.Email = usr.Email;
                        kl.Telefon = usr.Telefon;
                        kl.Adres_id = usr.Adres_id;
                        kl.EvrakID = usr.EvrakID;
                        kl.Istek_ID = usr.Istek_ID;
                        sb.Kullanici.Add(kl);
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

        public bool Kullanici_Delete(Kullanici usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Kullanici ss = sb.Kullanici.FirstOrDefault(kl => kl.Kullanici_ID == usr.Kullanici_ID);
                        sb.Kullanici.Remove(ss);
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

        public bool Kullanici_Update(Kullanici usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Kullanici kl = sb.Kullanici.First(x => x.Kullanici_ID == usr.Kullanici_ID);
                        kl.Kullanici_ID = usr.Kullanici_ID;
                        kl.Ad = usr.Ad;
                        kl.Soyad = usr.Soyad;
                        kl.Sifre = usr.Sifre;
                        kl.Email = usr.Email;
                        kl.Telefon = usr.Telefon;
                        kl.Adres_id = usr.Adres_id;
                        kl.EvrakID = usr.EvrakID;
                        kl.Istek_ID = usr.Istek_ID;
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

        public List<Kullanici> KullaniciGetir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Kullanici> getir = (from x in sb.Kullanici
                                         select x).ToList();
                return getir;
            }
        }

        public List<Kullanici> PriKullanici(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Kullanici> getir = (from x in sb.Kullanici
                                         where x.Kullanici_ID == y
                                         select x).ToList();
                return getir;
            }
        }
    }
}