using DAL.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.Interfaces
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        public string Calculate(string value)
        {
            string calc = new DataTable().Compute(value, null).ToString();

            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "server=185.51.76.19;user id=root;password=Adm1npassword;persistsecurityinfo=True;database=CalculationsDB;port=63306";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into calculationsdb.calculations (calchistory) value('" + value + " = " + calc + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                
            }



            /*MySqlConnection con = new MySqlConnection("server=185.51.76.19;user id=root;password=Adm1npassword;persistsecurityinfo=True;database=CalculationsDB;port=63306");
            MySqlCommand cmd = new MySqlCommand("INSERT INTO CalculationsDB.Calculations (Id, CalcHistory) VALUES ('0', '" + value + " = " + calc + "');", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();*/


            _calculatorRepository.SaveResult(value + " = " + calc);
            return calc;
        }
    }
}
