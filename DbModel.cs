using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPracticeConsoleApp
{
    internal class DbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public DbModel(int id, string name, int age)
        {
            Id = id;
            Name = name;   
            Age = age;
        }

        public DbModel GetDbModel()
        {
            return new DbModel(Id, Name, Age);
        }
    }
}
