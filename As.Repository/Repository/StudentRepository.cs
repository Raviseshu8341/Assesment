using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using As.Core.IRepository;
using As.Core.Model;
using As.Entity;

namespace As.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _datacontext;

        public StudentRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public void CreateDetails(Details ap)
        {
            if (ap != null)
            {
                if (ap.StudentId == 0)
                {
                    Student app = new Student();
                    app.FirstName = ap.FirstName;
                    app.LastName = ap.LastName;
                    app.Department = ap.Department;
                    app.Age = ap.Age;
                    app.Class = ap.Class;
                    app.Gender = ap.Gender;
                    app.YearOfJoining = ap.YearOfJoining;
                    app.LocationId = ap.LocationId;
                    app.Create_Time_Stamp = DateTime.Now;
                    app.Update_Time_Stamp = DateTime.Now;
                    _datacontext.Add(app);
                    _datacontext.SaveChanges();
                }
                else
                {
                    var item = _datacontext.Student.Where(a => a.StudentId == ap.StudentId).SingleOrDefault();
                    if (item != null)
                    {
                        item.FirstName = ap.FirstName;
                        item.LastName = ap.LastName;
                        item.Department = ap.Department;
                        item.Age = ap.Age;
                        item.Class = ap.Class;
                        item.Gender = ap.Gender;
                        item.YearOfJoining = ap.YearOfJoining;
                        item.LocationId = ap.LocationId;
                        _datacontext.SaveChanges();
                    }
                }
            }
        }
        public List<Details> Readlist()
        {
            List<Details> model = new List<Details>();
            var data = _datacontext.Student.Where(a => a.Is_Deleted == false).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    Details app = new Details();
                    app.StudentId = item.StudentId;
                    app.FirstName = item.FirstName;
                    app.LastName = item.LastName;
                    app.Department = item.Department;
                    app.Age = item.Age;
                    app.Class = item.Class;
                    app.Gender = item.Gender;
                    app.YearOfJoining = item.YearOfJoining;
                    var section = _datacontext.Location.Where(x => x.LocationId == item.LocationId).SingleOrDefault();
                    app.Location = section.Location1;
                    model.Add(app);
                }
            }
            return model;
        }
        public List<Details> Search(string search)
        {
            List<Details> model = new List<Details>();

            var data = _datacontext.Student.Where(a => a.FirstName.Contains(search) && a.Is_Deleted == false).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    Details app = new Details();
                    app.StudentId = item.StudentId;
                    app.FirstName = item.FirstName;
                    app.LastName = item.LastName;
                    app.Department = item.Department;
                    app.Age = item.Age;
                    app.Class = item.Class;
                    app.Gender = item.Gender;
                    app.YearOfJoining = item.YearOfJoining;
                    app.LocationId = item.LocationId;
                    model.Add(app);
                }
            }
            return model;
        }
        public Details Update(int id)
        {
            Details app = new Details();
            var item = _datacontext.Student.Where(a => a.StudentId == id && !a.Is_Deleted).SingleOrDefault();
            if (item != null)
            {
                app.StudentId = item.StudentId;
                    app.FirstName = item.FirstName;
                    app.LastName = item.LastName;
                    app.Department = item.Department;
                    app.Age = item.Age;
                    app.Class = item.Class;
                    app.Gender = item.Gender;
                    app.YearOfJoining = item.YearOfJoining;
                    var section = _datacontext.Location.Where(x => x.LocationId == item.LocationId).SingleOrDefault();
                    app.Location = section.Location1;
                    app.LocationId = section.LocationId;
                    
            }
            return app;
        }
        public void DeleteDone(int id)
        {
            var item = _datacontext.Student.Where(a => a.StudentId == id).SingleOrDefault();
            if (item != null)
            {
                item.Is_Deleted = true;
                _datacontext.SaveChanges();
            }
        }
        public Details Details(int id)
        {
            Details studdetails = new Details();
            var item = _datacontext.Student.Where(a => a.StudentId == id).SingleOrDefault();
            studdetails.StudentId = item.StudentId;
            studdetails.FirstName = item.FirstName;
            studdetails.LastName = item.LastName;
            studdetails.Department = item.Department;
            studdetails.Age = item.Age;
            studdetails.Class = item.Class;
            studdetails.Gender = item.Gender;
            studdetails.YearOfJoining = item.YearOfJoining;
            var section=_datacontext.Location.Where(x=>x.LocationId==item.LocationId).SingleOrDefault();
            studdetails.Location = section.Location1;
            studdetails.LocationId=section.LocationId;
            return studdetails;
        }
        public List<StudentLocation> Dropdown()
        {
            List<StudentLocation> stdModel = new List<StudentLocation>();
            var task = _datacontext.Location.Where(x => !x.Is_Deleted).ToList();
            if (task != null)
            {
                foreach (var item in task)
                {
                    StudentLocation location = new StudentLocation();
                    location.LocationId = item.LocationId;
                    location.Location = item.Location1;
                    stdModel.Add(location);
                }
            }
            return stdModel;
        }
    }
}
