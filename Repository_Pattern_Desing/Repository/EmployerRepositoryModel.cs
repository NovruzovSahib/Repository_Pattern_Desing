using Repository_Pattern_Desing.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repository_Pattern_Desing.Repository
{
    internal class EmployerRepositoryModel : IEmployer
    {
        private MYDATABASEEntities dbcontext;

        public EmployerRepositoryModel()
        {
            dbcontext = new MYDATABASEEntities();
        }

        #region SELECTEMPLOYER
        public List<EMPLOYER> GetAllEmployers()
        {
            var list = dbcontext.EMPLOYERs.ToList();
            return list;
        }
        #endregion

        #region ADDEMPLOYER
        public bool AddEmployer(EMPLOYER employer)
        {
            if (employer == null)
            {
                return false;
            }
            else
            {
                dbcontext.EMPLOYERs.Add(employer);
                dbcontext.SaveChanges();
                return true;
            }
        }
        #endregion

        #region UPDATEEMPLOYER
        public void UpdateEmployer(int empID, EMPLOYER newemployer)
        {
            var employer = dbcontext.EMPLOYERs.FirstOrDefault(s => s.ID == empID);

            if (employer != null)
            {
                employer.FName = newemployer.FName;
                employer.SName = newemployer.SName;
                employer.Age = newemployer.Age;
                dbcontext.SaveChanges();
            }
        }
        #endregion

        #region SEARCHEMPLOYER
        public EMPLOYER SearchEmployer(int empID)
        {
            var employer = dbcontext.EMPLOYERs.FirstOrDefault(s => s.ID == empID);
            return employer;
        }
        #endregion

        #region DELETEEMPLOYER

        public bool DeleteEmployer(int empID)
        {
            var employer = dbcontext.EMPLOYERs.FirstOrDefault(s => s.ID == empID);

            if (employer != null)
            {
                dbcontext.EMPLOYERs.Remove(employer);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
