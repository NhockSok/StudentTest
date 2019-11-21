using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FameWork_Test
{
    class StudentManagement
    {
        public PM20530[] GetStudent()
        {
            var db = new OOPCSEntities();
            return db.PM20530.ToArray();
        }
        public void CreateStudent(string code, string name, string hometown, string gender)
        {
            var newstudent = new PM20530();
            newstudent.Code = code;
            newstudent.Name = name;
            newstudent.Hometown = hometown;
            bool isFemale = true;
            if (gender == "Female")
                isFemale = false;
            else
                isFemale = true;
            var db = new OOPCSEntities();
            newstudent.Gender = isFemale;
            db.PM20530.Add(newstudent);
            db.SaveChanges();
        }
        public void UpdateStudent(int id, string code, string name, string hometown,string gender)
        {
            var db = new OOPCSEntities();
            var oldStudent = db.PM20530.Find(id);
            oldStudent.Code = code;
            oldStudent.Name = name;
            oldStudent.Hometown = hometown;
            bool isFemale = true;
            if (gender == "Female")
                isFemale = false;
            else
                isFemale = true;
            oldStudent.Gender = isFemale;
            db.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var db = new OOPCSEntities();            
            var @student = db.PM20530.Find(id);
            db.PM20530.Remove(@student);            
            db.SaveChanges();
        }
        public PM20530 GetStudent(int id)
        {
            var db = new OOPCSEntities();
            return db.PM20530.Find(id);
        }
    }
}
