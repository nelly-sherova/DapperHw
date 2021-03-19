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
        
    }
    class Program
    {

        static void Main(string[] args)
        {
            
        }
    }
}
