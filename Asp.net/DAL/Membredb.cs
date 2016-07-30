using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Membredb
    {
        private SOVELAVIDBEntities db;

        public Membredb()
        {
            db = new SOVELAVIDBEntities();
        }
        public IEnumerable<tbl_MEMBRE> GetALL()
        {
            return db.tbl_MEMBRE.ToList();
        }
        public tbl_MEMBRE GetByID(int Id)
        {
            return db.tbl_MEMBRE.Find(Id);
        }
        public void Insert(tbl_MEMBRE tbl_MEMBRE)
        {
            db.tbl_MEMBRE.Add(tbl_MEMBRE);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_MEMBRE tbl_MEMBRE = db.tbl_MEMBRE.Find(Id);
            db.tbl_MEMBRE.Remove(tbl_MEMBRE);
            Save();
        }
        public void Update(tbl_MEMBRE tbl_MEMBRE)
        {
            db.Entry(tbl_MEMBRE).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
