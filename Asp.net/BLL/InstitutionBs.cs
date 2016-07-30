using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InstitutionBs
    {
        private Institutiondb objDB;

        public InstitutionBs()
        {
            objDB = new Institutiondb();
        }
        public IEnumerable<tbl_INSTITUTION> GetALL()
        {
            return objDB.GetALL();
        }
        public tbl_INSTITUTION GetByID(int Id)
        {
            return objDB.GetByID(Id);
        }
        public void Insert(tbl_INSTITUTION tbl_INSTITUTION)
        {
            objDB.Insert(tbl_INSTITUTION);
        }
        public void Delete(int Id)
        {
            objDB.Delete(Id);
        }
        public void Update(tbl_INSTITUTION tbl_INSTITUTION)
        {
            objDB.Update(tbl_INSTITUTION);
        }
    }
}
