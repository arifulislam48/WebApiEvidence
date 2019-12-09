using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evidence_10.Models
{
    public class RepositoryStudent : IRepository<StudentVM>
    {
        StudentDbContext db = new StudentDbContext();
        public StudentVM create(StudentVM vm)
        {
            Student student = new Student()
            {
                Name = vm.Name,
                Email = vm.Email,
                Age = vm.Age,
                Gender = vm.Gender
            };
            db.Student.Add(student);
            db.SaveChanges();
            vm.ID = student.ID;
            return vm;
        }

        public StudentVM get(int id)
        {
            Student st = db.Student.Find(id);
            StudentVM vm = new StudentVM()
            {
                ID = st.ID,
                Name = st.Name,
                Email = st.Email,
                Age = st.Age,
                Gender = st.Gender
            };
            return vm;
        }

        public IEnumerable<StudentVM> getAll()
        {
            IEnumerable<StudentVM> StList = db.Student.Select(st => new StudentVM()
            {
                ID = st.ID,
                Name = st.Name,
                Email = st.Email,
                Age = st.Age,
                Gender = st.Gender
            });
            return StList;
        }

        public bool remove(int id)
        {
            Student st = db.Student.Find(id);
            db.Student.Remove(st);
            db.SaveChanges();
            return true;
        }

        public StudentVM update(StudentVM vm)
        {
            Student student = new Student()
            {
                ID = vm.ID,
                Name = vm.Name,
                Email = vm.Email,
                Age = vm.Age,
                Gender = vm.Gender
            };
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return vm;
        }
    }
}