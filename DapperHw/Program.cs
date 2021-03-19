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

         public static List<User> Read()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            
        }
    }
}
