using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class COUBs
    {
        private Coudb objDB;

        public COUBs()
        {
            objDB = new Coudb();
        }
        public IEnumerable<tbl_COU> GetALL()
        {
            return objDB.GetALL();
        }
        public tbl_COU GetByID(int Id)
        {
            return objDB.GetByID(Id);
        }
        public void Insert(tbl_COU tbl_COU)
        {
            objDB.Insert(tbl_COU);
        }
        public void Delete(int Id)
        {
            objDB.Delete(Id);
        }
        public void Update(tbl_COU tbl_COU)
        {
            objDB.Update(tbl_COU);
        }
    }
}
