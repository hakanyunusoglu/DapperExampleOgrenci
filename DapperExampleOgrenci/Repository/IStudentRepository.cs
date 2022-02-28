using DapperExampleOgrenci.Models;
using DapperExampleOgrenci.Models.DataVM;
using System.Collections.Generic;

namespace DapperExampleOgrenci.Repository
{
    public interface IStudentRepository
    {
        Student Find(int id);
        List<Student> GetAll(StudentVM model);
        Student Add(Student company);
        Student Update(Student company);
        void Delete(int id);
    }
}
