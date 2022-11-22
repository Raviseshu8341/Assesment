using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using As.Core.IRepository;
using As.Core.IService;
using As.Core.Model;

namespace As.Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void CreateDetails(Details app)
        {
            _studentRepository.CreateDetails(app);
        }
        public List<Details> Readlist()
        {
            return _studentRepository.Readlist();
        }
        public List<Details> Search(string search)
        {
            return _studentRepository.Search(search);
        }
        public Details Update(int id)
        {
             return _studentRepository.Update(id);
        }
        public Details Details(int id)
        {
            return _studentRepository.Details(id);
        }
        public void DeleteDone(int id)
        {
            _studentRepository.DeleteDone(id);
        }
        public List<StudentLocation> Dropdown()
        {
            return _studentRepository.Dropdown();
        }
    }
}