using Dapper;
using DapperExampleOgrenci.Models;
using DapperExampleOgrenci.Models.DataVM;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperExampleOgrenci.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private IDbConnection db;
        public StudentRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Student Add(Student std)
        {
            var sql = "INSERT INTO Student(Name,Surname,Email,Adress) VALUES (@Name,@Surname,@Email,@Adress)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, std).Single();
            std.ID = id;
            return std;
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Student WHERE ID=@id";
            db.Query<Student>(sql, new { @id = id });
        }

        public Student Find(int id)
        {
            var sql = "SELECT * FROM Student WHERE ID=@id";
            return db.Query<Student>(sql, new { @id = id }).Single();
        }

        public List<Student> GetAll(StudentVM model)
        {
            var sql = "";
            if (model.Students == null)
            {
                sql = "SELECT * FROM Student";
            }
            else
            {            
            sql = $"SELECT * FROM Student WHERE Surname like '%{model.Students.Surname}%' OR Name like '%{model.Students.Name}%' OR Email like '%{model.Students.Email}%'";
            }
            var std = db.Query<Student>(sql).ToList();
            return std;
        }

        public Student Update(Student std)
        {
            var sql = "UPDATE Student SET Name=@Name,Surname=@Surname,Email=@Email,Adress=@Adress WHERE ID=@id";
            return db.Query<Student>(sql, std).FirstOrDefault();
        }
    }
}
