using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Yorumlar_DML
    {
        public bool Yorum_Insert(Yorumlar a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Yorumlar yy = new Yorumlar();
                        yy.Yorum_ID = a.Yorum_ID;
                        yy.Kullanici_ID = a.Kullanici_ID;
                        yy.Yetkili_ID = a.Yetkili_ID;
                        yy.YorumDesc = a.YorumDesc;
                        yy.Likee = a.Likee;
                        yy.Tarih = a.Tarih;
                        yy.Adres_ID = a.Adres_ID;
                        yy.IstekSikayet_ID = a.IstekSikayet_ID;
                        yy.foto_id = a.foto_id;
                        yy.video_id = a.video_id;
                        yy.SosMedyaEkip_ID = a.SosMedyaEkip_ID;
                        yy.Onay_Durum = a.Onay_Durum;
                        sb.Yorumlar.Add(yy);
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

        public bool Yorum_Delete(Yorumlar a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Yorumlar ss = sb.Yorumlar.FirstOrDefault(x => x.Yorum_ID == a.Yorum_ID);
                        sb.Yorumlar.Remove(ss);
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

        public bool Yorum_Update(Yorumlar a)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Yorumlar yy = sb.Yorumlar.First(x => x.Yorum_ID == a.Yorum_ID);
                        yy.Yorum_ID = a.Yorum_ID;
                        yy.Kullanici_ID = a.Kullanici_ID;
                        yy.Yetkili_ID = a.Yetkili_ID;
                        yy.YorumDesc = a.YorumDesc;
                        yy.Likee = a.Likee;
                        yy.Tarih = a.Tarih;
                        yy.Adres_ID = a.Adres_ID;
                        yy.IstekSikayet_ID = a.IstekSikayet_ID;
                        yy.foto_id = a.foto_id;
                        yy.video_id = a.video_id;
                        yy.SosMedyaEkip_ID = a.SosMedyaEkip_ID;
                        yy.Onay_Durum = a.Onay_Durum;
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

        public List<Yorumlar> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Yorumlar> getir = (from x in sb.Yorumlar
                                        select x).ToList();
                return getir;
            }
        }

        public List<Yorumlar> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Yorumlar> getir = (from x in sb.Yorumlar
                                        where x.Yorum_ID == y
                                        select x).ToList();
                return getir;
            }
        }


    }
}