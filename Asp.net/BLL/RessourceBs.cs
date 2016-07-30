using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RessourceBs
    {
        private Ressourcedb objDB;

        public RessourceBs()
        {
            objDB = new Ressourcedb();
        }
        public IEnumerable<tbl_RESSOURCE> GetALL()
        {
            return objDB.GetALL();
        }
        public tbl_RESSOURCE GetByID(int Id)
        {
            return objDB.GetByID(Id);
        }
        public void Insert(tbl_RESSOURCE tbl_RESSOURCE)
        {
            objDB.Insert(tbl_RESSOURCE);
        }
        public void Delete(int Id)
        {
            objDB.Delete(Id);
        }
        public void Update(tbl_RESSOURCE tbl_RESSOURCE)
        {
            objDB.Update(tbl_RESSOURCE);
        }
    }
}
