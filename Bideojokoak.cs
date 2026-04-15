using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erronka3
{
    internal class Bideojokoak
    {
        private int id; private String izena; private double prezioa; private String hornitzailea; private String generoa; private Boolean garaia; private String irudia; private int argitaratzeUrtea; public Bideojokoak(int id, String ize, double pre, String hor, String gen, Boolean gar, String iru, int argitaratzeUrtea)

        {

            this.id = id;

            this.izena = ize;

            this.prezioa = pre;

            this.hornitzailea = hor;

            this.generoa = gen;

            this.garaia = gar;

            this.irudia = iru;

            this.argitaratzeUrtea = argitaratzeUrtea;

        }
        public Bideojokoak(String ize, double pre, String hor, String gen, String iru, int argitaratzeUrtea)

        {

            this.izena = ize;

            this.prezioa = pre;

            this.hornitzailea = hor;

            this.generoa = gen;

            this.irudia = iru;

            this.argitaratzeUrtea = argitaratzeUrtea;

        }
        public Bideojokoak(int id, String izena, Boolean garaia)

        {

            this.id = id;

            this.izena = izena;

            this.garaia = garaia;

        }
        public static List<Bideojokoak> informazioaIkusi(DatuBaseKonexioa conn)

        {

            MySqlConnection konexioa = conn.getKonexioa();

            konexioa.Open();

            List<Bideojokoak> lista = new List<Bideojokoak>();

            try
            {

                MySqlCommand bideojokoa = new MySqlCommand("SELECT * FROM bideojokoak;", konexioa);

                MySqlDataReader jokoa = bideojokoa.ExecuteReader();

                while (jokoa.Read())

                {

                    Bideojokoak b = new Bideojokoak(Convert.ToInt16(jokoa[0]), Convert.ToString(jokoa[1]), Convert.ToDouble(jokoa[2]), Convert.ToString(jokoa[3]), Convert.ToString(jokoa[4]), Convert.ToBoolean(jokoa[5]), Convert.ToString(jokoa[6]), Convert.ToInt16(jokoa[7]));

                    lista.Add(b);

                }

                return lista;

            }

            catch (Exception e)

            {

                MessageBox.Show(Convert.ToString(e));

                return null;

            }

        }
        public static List<Bideojokoak> garaiaIkusi(DatuBaseKonexioa conn)

        {

            MySqlConnection konexioa = conn.getKonexioa();

            konexioa.Open();

            List<Bideojokoak> lista = new List<Bideojokoak>();

            try
            {

                MySqlCommand bideojokoa = new MySqlCommand("SELECT id,izena,garaia FROM bideojokoak;", konexioa);

                MySqlDataReader jokoa = bideojokoa.ExecuteReader();

                while (jokoa.Read())

                {

                    Bideojokoak b = new Bideojokoak(Convert.ToInt16(jokoa[0]), Convert.ToString(jokoa[1]), Convert.ToBoolean(jokoa[2]));

                    lista.Add(b);

                }

                return lista;

            }

            catch (Exception e)

            {

                MessageBox.Show(Convert.ToString(e));

                return null;

            }

        }
        public Boolean igo(DatuBaseKonexioa conn)

        {

            MySqlConnection konexioa = conn.getKonexioa();

            Boolean gehituDa = false;

            konexioa.Open();

            try
            {

                MySqlCommand igo = new MySqlCommand("insert into bideojokoak values(null,@izena,@prezioa,@hornitzailea,@generoa,0,@irudia,@argitaratze);", konexioa);

                igo.Parameters.AddWithValue("@izena", this.izena);

                igo.Parameters.AddWithValue("@prezioa", this.prezioa);

                igo.Parameters.AddWithValue("@hornitzailea", this.hornitzailea);

                igo.Parameters.AddWithValue("@generoa", this.generoa);

                igo.Parameters.AddWithValue("@irudia", this.irudia);

                igo.Parameters.AddWithValue("@argitaratze", this.argitaratzeUrtea);

                igo.ExecuteNonQuery();

                return gehituDa = true;

            }

            catch (Exception e)

            {

                MessageBox.Show(Convert.ToString(e));

                return gehituDa;

            }

        }
        public Boolean garaiaAldatu(DatuBaseKonexioa conn)

        {

            MySqlConnection konexioa = conn.getKonexioa();

            Boolean aldaketa = false;

            konexioa.Open();

            try
            {

                MySqlCommand aldatu = new MySqlCommand("update bideojokoak set garaia=@garaia where id=@id;", konexioa);

                aldatu.Parameters.AddWithValue("@garaia", this.garaia);

                aldatu.Parameters.AddWithValue("@id", this.id);

                aldatu.ExecuteNonQuery();

                return aldaketa = true;

            }

            catch (Exception e)

            {

                MessageBox.Show(Convert.ToString(e));

                return aldaketa;

            }

        }
        public Boolean atributuaAldatu(DatuBaseKonexioa conn)

        {

            MySqlConnection konexioa = conn.getKonexioa();

            Boolean aldaketa = false;

            konexioa.Open();

            try
            {

                MySqlCommand igo = new MySqlCommand("update bideojokoak set izena=@izena, prezioa=@prezioa, hornitzailea=@hornitzailea, generoa=@generoa, irudia=@irudia, argitaratze_urtea=@urtea where id=@id;", konexioa);

                igo.Parameters.AddWithValue("@izena", this.izena);

                igo.Parameters.AddWithValue("@prezioa", this.prezioa);

                igo.Parameters.AddWithValue("@hornitzailea", this.hornitzailea);

                igo.Parameters.AddWithValue("@generoa", this.generoa);

                igo.Parameters.AddWithValue("@irudia", this.irudia);

                igo.Parameters.AddWithValue("@urtea", this.argitaratzeUrtea);

                igo.Parameters.AddWithValue("@id", this.id);

                igo.ExecuteNonQuery();

                return aldaketa = true;

            }

            catch (Exception e)

            {

                MessageBox.Show(Convert.ToString(e));

                return aldaketa;

            }

        }//Getter
         public int getId()

{

    return this.id;

}public String getIzena()

        {

            return this.izena;

        }
        public Double getPrezioa()

        {

            return this.prezioa;

        }
        public String getHornitzailea()

        {

            return this.hornitzailea;

        }
        public String getGeneroa()

        {

            return this.generoa;

        }
        public Boolean getGaraia()

        {

            return this.garaia;

        }
        public String getIrudia()

        {

            return this.irudia;

        }
        public int getArgitaratzeUrtea()

        {

            return this.argitaratzeUrtea;

        }//Setter
         public void setIzena(String izena)

{

    this.izena = izena;

        }
        public void setPrezioa(Double prezioa)

        {

            this.prezioa = prezioa;

        }
        public void setHornitzailea(String hornitzailea)

        {

            this.hornitzailea = hornitzailea;

        }
        public void setGeneroa(String generoa)

        {

            this.generoa = generoa;

        }
        public void setIrudia(String irudia)

        {

            this.irudia = irudia;

        }
        public void setGaraia(Boolean garaia)

        {

            this.garaia = garaia;

        }
        public void setArgitaratzeUrtea(int urtea)

        {

            this.argitaratzeUrtea = urtea;

        }
    }
}
