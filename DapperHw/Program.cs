using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperHw
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    public static class Commands
    {
        private const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=DapperHw; Integrated Security = True";
        
        //------Create------//

        public static void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age, City) VALUES(@Name, @Age, @City)";
                db.Execute(sqlQuery, user);
            }
        }

        //------ReadAll------//

        public static List<User> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        //------ReadId------//

        public static User ReadId(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
        
        //------Update------//

        public static void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age, City = @City WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        //------Delete------//
        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            bool working = true;
            while(working)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter command:");
                Console.ResetColor();
                Console.WriteLine("1 --> Create\n"+
                "2 --> ReadAll\n" +
                "3 --> ReadId\n" +
                "4 --> Update\n" +
                "5 --> Delete\n" +
                "Any other command --> Exit");
                int.TryParse(Console.ReadLine(), out int chooseCommand);
                switch(chooseCommand)
                {
                    case 1 :
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Create");
                        Console.ResetColor();
                        Console.Write("Name = "); string name = Console.ReadLine();
                        Console.Write("Age = "); int.TryParse(Console.ReadLine(), out int age);
                        Console.Write("City = "); string city = Console.ReadLine();
                        User user = new User
                        {
                            Name = name,
                            Age = age,
                            City = city
                        };
                        Commands.Create(user);
                    }
                    break;
                    case 2:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Read All");
                        Console.ResetColor();
                        foreach(var u in Commands.ReadAll())
                        {
                            Console.WriteLine($"Id: {u.Id}, Name: {u.Name}, Age: {u.Age}, City: {u.City}");
                        }
                    }
                    break;
                    case 3:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Read Id");
                        Console.ResetColor();
                        Console.Write("Id = "); int.TryParse(Console.ReadLine(), out int id);
                        User user = Commands.ReadId(id);
                        Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}, City: {user.City}");
                    }
                    break;
                    case 4:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Update");
                        Console.ResetColor();
                        Console.Write("Id = "); int.TryParse(Console.ReadLine(), out int id);
                        Console.Write("Name = "); string name = Console.ReadLine();
                        Console.Write("Age = "); int.TryParse(Console.ReadLine(), out int age);
                        Console.Write("City = "); string city = Console.ReadLine();
                        User user = new User
                        {
                            Id = id,
                            Name = name,
                            Age = age,
                            City = city
                        };
                        Commands.Update(user);
                    }
                    break;
                    case 5:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Delete");
                        Console.ResetColor();
                        Console.Write("Id = "); int.TryParse(Console.ReadLine(), out int id);
                        Commands.Delete(id);
                    }
                    break;
                    default:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Exit");
                        Console.ResetColor();
                        working = false;
                    }
                    break;
                }
            }
        }
    }
}
