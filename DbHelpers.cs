using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbPracticeConsoleApp
{
    internal class DbHelpers
    {
        public void DisplayData(List<DbModel> dbModels)
        {
            Console.WriteLine("Id\tName\t\tAge\n");
            foreach(DbModel model in  dbModels)
            {
                DisplayDbModel(model);
            }
        }

        private void DisplayDbModel(DbModel model)
        {
            Console.WriteLine($"\n{model.Id}\t{model.Name}\t\t{model.Age}");
        }

        public  List<DbModel> readData()
        {
            List<DbModel> dbModels = new List<DbModel>();
            int id, age;
            string name, val;
            char choice = 'n';

            Console.WriteLine("\nEnter Records...");
            do
            {
                Console.WriteLine("\nEnter Student Id: ");
                val = Console.ReadLine();
                if (val != null)
                {
                    id = Convert.ToInt32(val);
                }
                else
                {
                    Console.WriteLine("Id cannot be null");
                    continue;
                }
                Console.WriteLine("\nEnter Student Name: ");
                val = Console.ReadLine();
                if (val != null)
                {
                    name = val;
                }
                else
                {
                    Console.WriteLine("Name cannot be null");
                    continue;
                }
                Console.WriteLine("\nEnter Student Age: ");
                val = Console.ReadLine();
                if (val != null)
                {
                    age = Convert.ToInt32(val);
                }
                else
                {
                    Console.WriteLine("Age cannot be null");
                    continue;
                }
                DbModel dbModel = new DbModel(id, name, age);
                dbModels.Add(dbModel);
                Console.WriteLine("\nDo you want to enter more records (y /n): ");
                val= Console.ReadLine();
                choice = val.ToCharArray()[0];
            } while (choice == 'y');

            return dbModels;

        }
    }
}
