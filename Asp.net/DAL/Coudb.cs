using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Coudb
    {
        private SOVELAVIDBEntities db;

        public Coudb()
        {
            db = new SOVELAVIDBEntities();
        }
        public IEnumerable<tbl_COU> GetALL()
        {
            return db.tbl_COU.ToList();
        }
        public tbl_COU GetByID(int Id)
        {
            return db.tbl_COU.Find(Id);
        }
        public void Insert(tbl_COU tbl_COU)
        {
            db.tbl_COU.Add(tbl_COU);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_COU tbl_COU = db.tbl_COU.Find(Id);
            db.tbl_COU.Remove(tbl_COU);
            Save();
        }
        public void Update(tbl_COU tbl_COU)
        {
            db.Entry(tbl_COU).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
