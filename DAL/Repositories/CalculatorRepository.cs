using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace DAL.Repositories
{
    public class CalculatorRepository: ICalculatorRepository
    {
        

        public CalculatorRepository()
        {
            
        }

        public void SaveResult(string s)
        {
            try
            {
                string MyConnection2 = "server=185.51.76.19;user id=root;password=Adm1npassword;persistsecurityinfo=True;database=CalculationsDB;port=63306";
                string Query = "insert into CalculationsDB.Calculations (CalcHistory) value('" + s + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public string[] ReadCalculations()
        {
            List<string> calcList = new List<string>();

            try
            {
                string connectionString = "server=185.51.76.19;user id=root;password=Adm1npassword;persistsecurityinfo=True;database=CalculationsDB;port=63306";
                using(var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("select calchistory from Calculations", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                calcList.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                return calcList.ToArray();
                /*List<string> list = new List<string>();
                string tempString;
                string MyConnection2 = "server=185.51.76.19;user id=root;password=Adm1npassword;persistsecurityinfo=True;database=CalculationsDB;port=63306";
                string Query = "select calchistory from calculations";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MyConn2.Open();
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                using (var reader = MyCommand2.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                } */
                /*while (reader.HasRows)
                {
                    list.Add($"{reader.GetString("CalcHistory")}");
                }*/
                /*
                String[] stringArr = list.ToArray();
                MyConn2.Close();
                //MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                //MyAdapter.SelectCommand = MyCommand2;
                //DataTable dTable = new DataTable();
                //MyAdapter.Fill(dTable);
                //string[] stringArr = dTable.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                
                return stringArr;*/
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
