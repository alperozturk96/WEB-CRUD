using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace dataAccess
{
    public class dbContext
    {
        public dbContext()
        {

        }

        private SqlConnection GetConn()
        {
            return new SqlConnection(@"Server=DESKTOP-HVDL6V5\SQLEXPRESS;Database=CPUs;Connection Timeout=1;Integrated Security=SSPI");
        }

        public void UpdateCommand(string query)
        {
            try
            {
                using (var conn = GetConn())
                {

                    var command = new SqlCommand(query, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                    Console.WriteLine("Execution failed");
            }
        }

        public void InsertCommand(string query)
        {
            try
            {
                using (var conn = GetConn())
                {

                    var command = new SqlCommand(query, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Execution failed");
            }
        }

        public SqlDataReader SelectCommand(string query)
        {
            try
            {
                using (var conn = GetConn())
                {

                  var command = new SqlCommand(query, conn);
                  conn.Open();
                  return  command.ExecuteReader();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Execution failed");
                return null;
            } 
        }
        public DataTable SelectCommandList(string query) // her koşulda return olmalı.
        {
            try
            {
                using (var conn = GetConn()) // using kullanarak işimiz bittiğinde direk bellekten silmiş oluyoruz bu sayede
                    //finally yapmamıza gerek yok ki yapsak bile connection kapatmak için sadece o bellekten de silmiş olucaz hemde
                    // bağlantıda kapatılmış olacak.
                {
                    var command = new SqlCommand(query, conn);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    
                  return dataTable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Execution failed");
                return null;
            } 
        }

        public void DeleteCommand(string query)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var command = new SqlCommand(query, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {

            } 
        }

    }

}
