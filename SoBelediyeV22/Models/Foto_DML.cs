using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Foto_DML
    {
        public bool Foto_Insert(Foto a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Foto pic = new Foto();
                        pic.Foto_ID = a.Foto_ID;
                        pic.Foto_Location_ID = a.Foto_Location_ID;
                        pic.Kullanici_ID = a.Kullanici_ID;
                        pic.SosMedyaEkip_ID = a.SosMedyaEkip_ID;
                        pic.IstekSikayet_ID = a.IstekSikayet_ID;
                        pic.Foto_Link = a.Foto_Link;
                        pic.OnayDurum = a.OnayDurum;
                        sb.Foto.Add(pic);
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

        public bool Foto_Delete(Foto a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Foto pp = sb.Foto.FirstOrDefault(x => x.Foto_ID == a.Foto_ID);
                        sb.Foto.Remove(pp);
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

        public bool Foto_Update(Foto a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) //linq ile where primary key'de sql transaction (türleri) scope transaction türleri read commit dirty data darboğaz nedir kullandığın transaction scope'u bil   
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Foto pic = sb.Foto.FirstOrDefault(x => x.Foto_ID == a.Foto_ID);
                        pic.Foto_ID = a.Foto_ID;
                        pic.Foto_Location_ID = a.Foto_Location_ID;
                        pic.Kullanici_ID = a.Kullanici_ID;
                        pic.SosMedyaEkip_ID = a.SosMedyaEkip_ID;
                        pic.IstekSikayet_ID = a.IstekSikayet_ID;
                        pic.Foto_Link = a.Foto_Link;
                        pic.OnayDurum = a.OnayDurum;
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

        public List<Foto> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Foto> getir = (from x in sb.Foto
                                    select x).ToList();
                return getir;
            }
        }

        public List<Foto> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Foto> getir = (from x in sb.Foto
                                    where x.Foto_ID == y
                                    select x).ToList();
                return getir;
            }
        }
    }
}