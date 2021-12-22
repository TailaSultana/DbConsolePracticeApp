using System;

namespace DbPracticeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=DESKTOP-EAM3MLK; Initial Catalog=SchoolDB; Integrated Security= true";
            DbHelpers dbHelpers = new DbHelpers();
            DbUtilities dbUtilities = new DbUtilities();
            dbHelpers.DisplayData(dbUtilities.getData(connection));
            Console.ReadLine();
            dbUtilities.insertData(dbHelpers.readData(), connection);
            Console.ReadLine();
        }
    }
}
