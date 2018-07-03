using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Video_DML
    {
        public bool Video_Insert(Video vd)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Video vv = new Video();
                        vv.Video_ID = vd.Video_ID;
                        vv.Video_Location = vd.Video_Location;
                        vv.IstekSikayet_ID = vd.IstekSikayet_ID;
                        vv.Video_Link = vd.Video_Link;
                        vv.Kullanici_ID = vd.Kullanici_ID;
                        vv.SosMedya_ID = vd.SosMedya_ID;
                        vv.OnayDurum = vd.OnayDurum;
                        sb.Video.Add(vv);
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

        public bool Video_Delete(Video vd)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Video ss = sb.Video.FirstOrDefault(x => x.Video_ID == vd.Video_ID);
                        sb.Video.Remove(ss);
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

        public bool Video_Update(Video vd)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Video vv = sb.Video.First(x => x.Video_ID == vd.Video_ID);
                        vv.Video_ID = vd.Video_ID;
                        vv.Video_Location = vd.Video_Location;
                        vv.IstekSikayet_ID = vd.IstekSikayet_ID;
                        vv.Video_Link = vd.Video_Link;
                        vv.Kullanici_ID = vd.Kullanici_ID;
                        vv.SosMedya_ID = vd.SosMedya_ID;
                        vv.OnayDurum = vd.OnayDurum;
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

        public List<Video> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Video> getir = (from x in sb.Video
                                     select x).ToList();
                return getir;
            }
        }

        public List<Video> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Video> getir = (from x in sb.Video
                                     where x.Video_ID == y
                                     select x).ToList();
                return getir;
            }
        }
    }
}