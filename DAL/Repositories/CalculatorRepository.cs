using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DAL.Repositories
{
    public class CalculatorRepository: ICalculatorRepository
    {
        readonly CalculatorDBContext _ctx;

        public CalculatorRepository(CalculatorDBContext ctx)
        {
            _ctx = ctx;
        }

        public void SaveResult(string s)
        {
            MySqlConnection con = new MySqlConnection("server=185.51.76.19;user id=root;password=Adm1npassword;persistsecurityinfo=True;database=CalculationsDB;port=63306");
            

            MySqlCommand cmd = new MySqlCommand("INSERT INTO CalculationsDB.Calculations (Id, CalcHistory) VALUES ('0', '" + s + "');", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            /*string constring = "Server=185.51.76.19;Port=33306;Database=CalculationsDB;Uid=root;Pwd=Adm1npassword;";
            string Query = "INSERT INTO CalculationsDB.Calculations (Id, CalcHistory) VALUES ('0', '" + s + "');";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            conDatabase.Open();
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            conDatabase.Close();*/


            //var equation = _ctx.Calculations.Add(s).Entity;
            //_ctx.SaveChanges();
        }

        public IEnumerable<string> ReadCalculations()
        {
            return _ctx.Calculations;
        }
    }
}
