using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Institutiondb
    {
        private SOVELAVIDBEntities db;

        public Institutiondb()
        {
            db = new SOVELAVIDBEntities();
        }
        public IEnumerable<tbl_INSTITUTION> GetALL()
        {
            return db.tbl_INSTITUTION.ToList();
        }
        public tbl_INSTITUTION GetByID(int Id)
        {
            return db.tbl_INSTITUTION.Find(Id);
        }
        public void Insert(tbl_INSTITUTION tbl_INSTITUTION)
        {
            db.tbl_INSTITUTION.Add(tbl_INSTITUTION);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_INSTITUTION tbl_INSTITUTION = db.tbl_INSTITUTION.Find(Id);
            db.tbl_INSTITUTION.Remove(tbl_INSTITUTION);
            Save();
        }
        public void Update(tbl_INSTITUTION tbl_INSTITUTION)
        {
            db.Entry(tbl_INSTITUTION).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
