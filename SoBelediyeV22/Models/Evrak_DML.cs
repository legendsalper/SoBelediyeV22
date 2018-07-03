using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Evrak_DML
    {
        public bool Evrak_Insert(Evrak a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak edm = new Evrak();
                        edm.EvrakID = a.EvrakID;
                        edm.Desc = a.Desc;
                        edm.Baslik = a.Baslik;
                        edm.Tur = a.Tur;
                        edm.Tarih = a.Tarih;
                        edm.Kullanici_ID = a.Kullanici_ID;
                        edm.Adres_ID = a.Adres_ID;
                        edm.Istek_ID = a.Istek_ID;
                        edm.Foto_ID = a.Foto_ID;
                        edm.Video_ID = a.Video_ID;
                        edm.Yon_ID = a.Yon_ID;
                        edm.Durum_ID = a.Durum_ID;
                        sb.Evrak.Add(edm);
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

        public bool Evrak_Delete(Evrak a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak edm = sb.Evrak.FirstOrDefault(x => x.EvrakID == a.EvrakID);
                        sb.Evrak.Remove(edm);
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

        public bool Evrak_Update(Evrak a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Evrak edm = sb.Evrak.FirstOrDefault(x => x.EvrakID == a.EvrakID);
                        edm.EvrakID = a.EvrakID;
                        edm.Desc = a.Desc;
                        edm.Baslik = a.Baslik;
                        edm.Tur = a.Tur;
                        edm.Tarih = a.Tarih;
                        edm.Kullanici_ID = a.Kullanici_ID;
                        edm.Adres_ID = a.Adres_ID;
                        edm.Istek_ID = a.Istek_ID;
                        edm.Foto_ID = a.Foto_ID;
                        edm.Video_ID = a.Video_ID;
                        edm.Yon_ID = a.Yon_ID;
                        edm.Durum_ID = a.Durum_ID;
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

        public List<Evrak> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Evrak> getir = (from x in sb.Evrak
                                     select x).ToList();
                return getir;
            }
        }

        public List<Evrak> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Evrak> getir = (from x in sb.Evrak
                                     where x.EvrakID == y
                                     select x).ToList();
                return getir;
            }
        }
    }
}