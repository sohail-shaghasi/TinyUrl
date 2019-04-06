using MySql.Data.MySqlClient;
using Nintex.Data;
using System;
using System.Configuration;
using NLog;

namespace Nintex.Service
{
    public class BaseClass
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public TinyUrlContext DatabaseConnection()
        {
            TinyUrlContext contextDB;
            MySqlTransaction transaction;
            string connectionString = ConfigurationManager.ConnectionStrings["NintexDB"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            // Create database if not exists
            contextDB = new TinyUrlContext(connection, false);
           
                contextDB.Database.CreateIfNotExists();
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
                transaction = connection.BeginTransaction();
                // Passing an existing transaction to the context
                contextDB.Database.UseTransaction(transaction);
            
            return contextDB;
        }
    }
}
