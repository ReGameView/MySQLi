using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Gazovik
{
    class MySQLi
    {
        IniFile INI = new IniFile("config.ini");
        SQLiteCommand cmd;
        SQLiteConnection conn;

        string DataBase = null;

        public MySQLi()
        {
            if (INI.KeyExists("Name", "DataBase"))
            {
                DataBase = INI.ReadINI("DataBase", "Name");
                conn = new SQLiteConnection("Data Source=" + DataBase + "; Version=3;");
                try
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine("Error Connect to MySQLi: " + ex);
                }
            }
        }

        public SQLiteDataReader query(string command)
        {
            try
            {
                cmd.CommandText = command;
            }catch(InvalidOperationException er)
            {
                Console.WriteLine("Error in Query in MySQLi: " + er);
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            SQLiteDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }catch(StackOverflowException error)
            {
                Console.WriteLine("Error Query in MySQLi: " + error);
            }catch(InvalidOperationException er)
            {
                Console.WriteLine("Error Query in MySQLi: " + er);
            }
            return reader;
        }
    }
}
