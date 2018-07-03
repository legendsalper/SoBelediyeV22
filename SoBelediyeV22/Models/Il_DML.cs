using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace SoBelediyeV22.Models
{
    public class Il_DMS
    {

        public bool il_Insert(Il usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Il il = new Il();
                        il.Il_ID = usr.Il_ID;
                        il.Il1 = usr.Il1;
                        sb.Il.Add(il);
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

        public bool il_Delete(Il usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Il il = sb.Il.FirstOrDefault(x => x.Il_ID == usr.Il_ID);
                        sb.Il.Remove(il);
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

        public bool il_Update(Il usr)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SobelediyeEntities sb = new SobelediyeEntities())
                    {
                        Il il = sb.Il.First(x => x.Il_ID == usr.Il_ID);
                        il.Il_ID = usr.Il_ID;
                        il.Il1 = usr.Il1;
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

        public List<Il> Getir()
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {
                List<Il> getir = (from x in sb.Il
                                  select x).ToList();
                return getir;
            }
        }

        public List<Il> PriGetir(int y) // primary key'leri çağır
        {
            using (SobelediyeEntities sb = new SobelediyeEntities())
            {

                List<Il> getir = (from x in sb.Il
                                  where x.Il_ID == y
                                  select x).ToList();
                return getir;
            }
        }
    }
}