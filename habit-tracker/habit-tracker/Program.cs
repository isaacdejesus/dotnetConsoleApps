
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;

namespace habit_tracker
{
    class Program
    {
        static string connectionString = @"Data Source=habit-Tracker.db";
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drinking_water (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Date TEXT,
                Quantity INTEGER
                )";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
            GetUserInput();
        }
        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application");
                Console.WriteLine("Type 1 to View All Records");
                Console.WriteLine("Type 2 to Insert Record");
                Console.WriteLine("Type 3 to Delete Record");
                Console.WriteLine("Type 4 to Update Record");
                Console.WriteLine("--------------------------------------\n");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye\n");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                       GetAllRecords();
                      break;
                    case "2":
                        Insert();
                        break;
                    case "3": Delete();
                        break;
                    case "4": Update();
                         break;
                    default:
                         Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                         break;

                }
            }
        }
        private static void Insert()
        {
            string date = GetDateInput();
            int quantity = GetNumberInput("\n\nPlease insert number of glasses. No decimals allowed. \n\n");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', {quantity})";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static void GetAllRecords()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    $"SELECT * FROM drinking_water ";
                List<DrinkingWater> tableData = new();
                SqliteDataReader reader = tableCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new DrinkingWater
                            {
                                Id = reader.GetInt32(0),
                                Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", new CultureInfo("en-US")),
                                Quantity = reader.GetInt32(2)
                            });
                    }
                }
                else
                    Console.WriteLine("No rows found");
                connection.Close();
                Console.WriteLine("--------------------------------------------------\n");
                foreach (var dw in tableData){
                    Console.WriteLine($"{dw.Id} - {dw.Date.ToString("dd-MMM-yyyy")} - Quantity: {dw.Quantity} glasses");
                }
                Console.WriteLine("---------------------------------------------------\n");
            }
        }
        internal static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease enter the date: (Format: dd-mm-yy). Type 0 to return to main menu.\n\n");
            string dateInput = Console.ReadLine();
            if (dateInput == "0") GetUserInput();
            while(!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\n\nInvalid date. (Format: dd-mm-yy). Type 0 to return to menu or try again: \n\n");
                dateInput = Console.ReadLine();
            }
            return dateInput;
        }
        internal static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();
            if (numberInput == "0") GetUserInput();
            while(!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.WriteLine("\n\nInvalid number. Try again.\n\n");
                numberInput = Console.ReadLine();
            }
            int finalInput = Convert.ToInt32(numberInput);
            return finalInput;
        }
        private static void Delete()
        {
            GetAllRecords();
            var recordId = GetNumberInput("\n\nPlease type the id of the recourd you want to delete or 0 to return to menu\n\n");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"DELETE from drinking_water WHERE Id = '{recordId}'";
                int rowCount = tableCmd.ExecuteNonQuery();
                if (rowCount == 0)
                {
                    Console.WriteLine($"\n\nRecord with Id {recordId} doesn't exist. \n\n");
                    Delete();
                }
            }
            Console.WriteLine($"\n\nRecord with Id {recordId} was deleted. \n\n");
            GetUserInput();
        }
        internal static void Update()
        {
            GetAllRecords();
            var recordId = GetNumberInput("\n\nPlease type the id of the record you want to update or 0 to return to menu\n\n");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var checkCmd = connection.CreateCommand();
                checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM drinking_water WHERE Id = {recordId})";
                int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());
                if(checkQuery == 0)
                {
                    Console.WriteLine($"\n\nRecord with Id {recordId} doesn't exist.\n\n");
                    connection.Close();
                    Update();
                }
                string date = GetDateInput();
                int quantity = GetNumberInput("\n\nPlease enter new quantity\n\n");
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"UPDATE drinking_water SET date ='{date}', quantity = {quantity} WHERE Id = {recordId}";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
public class DrinkingWater
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}
