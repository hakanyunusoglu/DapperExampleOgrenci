using System.Collections.Generic;

namespace DapperExampleOgrenci.Models.DataVM
{
    public class StudentVM
    {
        public Student Students { get; set; }
        public List<Student> sList { get; set; }
        public List<Student> ddListName { get; set; }
        public List<Student> ddListSurname { get; set; }
        public List<Student> ddListEmail { get; set; }


    }
}
