using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MembreBs
    {
        private Membredb objDB;

        public MembreBs()
        {
            objDB = new Membredb();
        }
        public IEnumerable<tbl_MEMBRE> GetALL()
        {
            return objDB.GetALL();
        }
        public tbl_MEMBRE GetByID(int Id)
        {
            return objDB.GetByID(Id);
        }
        public void Insert(tbl_MEMBRE tbl_MEMBRE)
        {
            objDB.Insert(tbl_MEMBRE);
        }
        public void Delete(int Id)
        {
            objDB.Delete(Id);
        }
        public void Update(tbl_MEMBRE tbl_MEMBRE)
        {
            objDB.Update(tbl_MEMBRE);
        }
    }
}
