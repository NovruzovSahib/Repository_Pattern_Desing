using Repository_Pattern_Desing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern_Desing.Repository
{
    internal interface IEmployer
    {
        List<EMPLOYER> GetAllEmployers();
        bool AddEmployer(EMPLOYER employer);
        void UpdateEmployer(int empID,EMPLOYER employer);
        EMPLOYER SearchEmployer(int empID);
        bool DeleteEmployer(int empID);

    }
}
