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
            //dbHelpers.DisplayData(dbUtilities.getData(connection));
            //Console.ReadLine();
            Console.WriteLine("Display through Adapter");
            DbAdapter adapter = new DbAdapter();
            adapter.getDataFromAdapter(connection);
            Console.ReadLine();
            adapter.updateDataFromAdapter(dbHelpers.readData(), connection);
            //dbUtilities.insertData(dbHelpers.readData(), connection);
            Console.ReadLine();
        }
    }
}
