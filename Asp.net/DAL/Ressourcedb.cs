using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ressourcedb
    {
        private SOVELAVIDBEntities db;

        public Ressourcedb()
        {
            db = new SOVELAVIDBEntities();
        }
        public IEnumerable<tbl_RESSOURCE> GetALL()
        {
            return db.tbl_RESSOURCE.ToList();
        }
        public tbl_RESSOURCE GetByID(int Id)
        {
            return db.tbl_RESSOURCE.Find(Id);
        }
        public void Insert(tbl_RESSOURCE tbl_RESSOURCE)
        {
            db.tbl_RESSOURCE.Add(tbl_RESSOURCE);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_RESSOURCE tbl_RESSOURCE = db.tbl_RESSOURCE.Find(Id);
            db.tbl_RESSOURCE.Remove(tbl_RESSOURCE);
            Save();
        }
        public void Update(tbl_RESSOURCE tbl_RESSOURCE)
        {
            db.Entry(tbl_RESSOURCE).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
