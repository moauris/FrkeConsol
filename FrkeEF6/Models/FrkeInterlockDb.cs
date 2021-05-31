using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace FrkeEFCore.Models
{
    public class FrkeInterlockDb
    {

        private SQLiteConnection conn;
        public FrkeInterlockDb()
        {
            conn = new SQLiteConnection("Data Source=hello.db");
            conn.Open();



            var cmd = conn.CreateCommand();

            using (StreamReader sr = new StreamReader(@".\SqlScripts\TblInterlockInitialData.sql"))
            {
                cmd.CommandText = sr.ReadToEnd();
            }

            cmd.ExecuteNonQuery();

            conn.Close();
        }



        ~FrkeInterlockDb()
        {
            conn.Dispose();
        }
    }
}
