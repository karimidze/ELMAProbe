using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCalc.db.Models;

namespace WebCalc.db.Repository
{
    public class CalcHistoryRepository : ICalcHistoryRepository
    {
        public void Add(CalcHistory item)
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Project\\Стажировка\\Calc\\WebCalc\\App_Data\\DBCalc.mdf;Integrated Security=True";
            string queryString = "INSERT INTO dbo.CalcHistory (X, Y, Result, Operation, CreationDate) VALUES ({0},{1},{2},'{3}', GETDATE());";
            //char separator = '.';
            var query = string.Format(queryString, item.X, item.Y, item.Result, item.Operation);

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                var count = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<CalcHistory> Find(string Operations)
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Project\\Стажировка\\Calc\\WebCalc\\App_Data\\DBCalc.mdf;Integrated Security=True";
            string queryString = "SELECT Id, X, Y, Result, Operation, CreationDate FROM dbo.CalcHistory WHERE Operation='{0}';";
            var query = string.Format(queryString, Operations);

            var result = new List<CalcHistory>();

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    result.Add(ReadSingleRow((IDataRecord)reader));
                }

                // Call Close when done reading.
                reader.Close();
            }

            return result;
        }

        public IEnumerable<CalcHistory> GetList()
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Project\\Стажировка\\Calc\\WebCalc\\App_Data\\DBCalc.mdf;Integrated Security=True";
            string queryString = "SELECT Id, X, Y, Result, Operation, CreationDate FROM dbo.CalcHistory;";

            var result = new List<CalcHistory>();

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    result.Add(ReadSingleRow((IDataRecord)reader));
                }

                // Call Close when done reading.
                reader.Close();
            }

            return result;
        }
        /// <summary>
        /// Взяли данные из базы, превратили в CalcHistory
        /// </summary>
        private CalcHistory ReadSingleRow(IDataRecord record)
        {
            var result = new CalcHistory();

            result.Id = record.GetInt32(0);
            result.X = record.GetDouble(1);
            result.Y = record.GetDouble(2);
            result.Result = record.GetDouble(3);
            result.Operation = record.GetString(4);
            result.CreationDate = record.GetDateTime(5);

            return result;
        }
    }
}