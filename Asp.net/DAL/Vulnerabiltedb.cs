using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Vulnerabiltedb
    {
        private SOVELAVIDBEntities db;

        public Vulnerabiltedb()
        {
            db = new SOVELAVIDBEntities();
        }
        public IEnumerable<tbl_VULNERABILITE> GetALL()
        {
            return db.tbl_VULNERABILITE.ToList();
        }
        public tbl_VULNERABILITE GetByID(int Id)
        {
            return db.tbl_VULNERABILITE.Find(Id);
        }
        public void Insert(tbl_VULNERABILITE tbl_VULNERABILITE)
        {
            db.tbl_VULNERABILITE.Add(tbl_VULNERABILITE);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_VULNERABILITE tbl_VULNERABILITE = db.tbl_VULNERABILITE.Find(Id);
            db.tbl_VULNERABILITE.Remove(tbl_VULNERABILITE);
            Save();
        }
        public void Update(tbl_VULNERABILITE tbl_VULNERABILITE)
        {
            db.Entry(tbl_VULNERABILITE).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
