using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using As.Core.Model;

namespace As.Core.IService
{
    public interface IStudentService
    {
        void CreateDetails(Details app);
        List<Details> Readlist();
        Details Update(int id);
        void DeleteDone(int id);
        List<Details> Search(string search);
        Details Details(int id);
        List<StudentLocation> Dropdown();
    }
}
