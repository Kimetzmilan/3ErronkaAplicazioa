using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Erronka3
{
    internal class DatuBaseKonexioa
    {
        private String konexioa = "Server=192.168.115.159;Database=3erronka;User Id=admin;Password=1MG32025;";

        //private String konexioa = "Server=localhost;Database=erronka3;User Id=root;Password=1MG32025;";
        public MySqlConnection getKonexioa()

{

    MySqlConnection con = new MySqlConnection(this.konexioa);

    return con;

}
}
}
