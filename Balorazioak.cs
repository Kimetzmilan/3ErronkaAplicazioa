using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Erronka
{
    internal class Balorazioak
    {
        private double puntuazioa; private String izena;
        public Balorazioak(String izena, double puntuazioa)
        {
            this.izena = izena;
            this.puntuazioa = puntuazioa;
        }
        public static List<Balorazioak> webgunekoBalorazioak(int modua, DatuBaseKonexioa conn)
        {
            MySqlConnection konexioa = conn.getKonexioa();
            konexioa.Open();
            try
            {
                String ordenatu;
                List<Balorazioak> lista = new List<Balorazioak>();
                if (modua == 1)
                {
                    ordenatu = "V_Balorazio_Hobenak";
                }
                else
                {
                    ordenatu = "V_Balorazio_Txarrenak";
                }
                MySqlCommand iritziak = new MySqlCommand("select * from " + ordenatu + " order by puntuazioaAVG desc;", konexioa);
                MySqlDataReader asko = iritziak.ExecuteReader();
                while (asko.Read())
                {
                    Balorazioak b = new Balorazioak(Convert.ToString(asko[0]), Convert.ToDouble(asko[1]));
                    lista.Add(b);
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return null;
            }
            }//Getter
                public String getIzena()
            {
                return this.izena;
            }public Double getPuntuazioa()
            {
                return this.puntuazioa;
            }

    }
}
