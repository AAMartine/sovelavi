using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VulnerabilteBs
    {
        private Vulnerabiltedb objDB;

        public VulnerabilteBs()
        {
            objDB = new Vulnerabiltedb();
        }
        public IEnumerable<tbl_VULNERABILITE> GetALL()
        {
            return objDB.GetALL();
        }
        public tbl_VULNERABILITE GetByID(int Id)
        {
            return objDB.GetByID(Id);
        }
        public void Insert(tbl_VULNERABILITE tbl_VULNERABILITE)
        {
            objDB.Insert(tbl_VULNERABILITE);
        }
        public void Delete(int Id)
        {
            objDB.Delete(Id);
        }
        public void Update(tbl_VULNERABILITE tbl_VULNERABILITE)
        {
            objDB.Update(tbl_VULNERABILITE);
        }
    }
}
