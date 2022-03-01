using DapperExampleOgrenci.Models;
using DapperExampleOgrenci.Models.DataVM;
using System.Collections.Generic;

namespace DapperExampleOgrenci.Repository
{
    public interface IStudentRepository
    {
        Student Find(int id);
        List<Student> GetAll(StudentVM model);
        List<Student> ddsListName(StudentVM std);
        List<Student> ddsListSurname(StudentVM std);
        List<Student> ddsListEmail(StudentVM std);
        Student Add(Student company);
        Student Update(Student company);
        void Delete(int id);
    }
}
