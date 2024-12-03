using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentLib
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public short Course { get; set; }
        public string Specialty { get; set; }


        public Student(string name, string surname, DateTime birthday, short course, string specialty)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Course = course;
            Specialty = specialty;
        }

        public bool CheckName()
        {
            if (Name.Length < 2 || Name.Length > 15)
                return false;

            var regex = new Regex(@"^[A-Z][a-zA-Z0-9]*\d?$");
            return regex.IsMatch(Name) && Name.Count(char.IsDigit) == 1;
        }

        public string TransformSpecialty()
        {
            string transformed = Specialty.Trim();
            transformed = Regex.Replace(transformed, @"\s+", " ");
            return transformed.ToUpper();
        }

        public int CheckBirthday()
        {
            if (Birthday > DateTime.Now)
                return -1;

            int age = DateTime.Now.Year - Birthday.Year;
            if (Birthday > DateTime.Now.AddYears(-age))
                age--;

            if (age < 16)
                return 0;
            if (age >= 16 && age < 18)
                return 1;
            if (age >= 18 && age <= 22)
                return 2;

            return 3;
        }
    }
}

