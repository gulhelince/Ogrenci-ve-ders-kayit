using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using entity; //entity katmanında bulunan sınıflardaki değişkenlere ulaşabilmek için kullanılır.

namespace DataAccessLayer
{
    public class DALDers //öncelikle sınıf public formata çevrilir
    {
        //Listeleme işlemleri,metodun türü list olucak ,verileri veri tabanından çekmek için kullanılır
        public static List<EntityDersler> DersListesi() //EntityOgrenci sınıfım içindeki değerler ne ise o değerleri almasını sağlar ,daha sonra metoda isim ver .
        {
            List<EntityDersler> degerler = new List<EntityDersler>();
            SqlCommand komut2 = new SqlCommand("Select * from TblDersler", Baglanti.bgl);

            //eğer bağlantım kapalıysa bağlantımı aç
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

            //öğrenci tablosunda bulunan bütün kayıtları döndürür
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read()) //dr komutu okuma işlemini gerçekleştirdiği müdettçe 
            {
                EntityDersler ent = new EntityDersler(); //nesne türet 
                ent.Id = Convert.ToInt32(dr["DersID"].ToString());
                ent.DERSAD = dr["DersAD"].ToString();
                ent.Min= int.Parse(dr["DersMaxKont"].ToString());
                ent.Max= int.Parse(dr["DersMinKont"].ToString());
                degerler.Add(ent); //ent den gelen değerleri degerler içerisine ekle 
            }
            dr.Close();
            return degerler; //geriye degerleri döndür 
        }

        public static int TalepEkle(EntityBasvuruFormu parametre)
        {
            SqlCommand komut = new SqlCommand("insert into TblBasvuruFormu (OgrenciID,DersID) values (@p1,@p2)", Baglanti.bgl);
            komut.Parameters.AddWithValue("@p1", parametre.Basogrid);
            komut.Parameters.AddWithValue("@p2", parametre.Basdersid);

            //eğer bağlantım kapalıysa bağlantımı aç
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            return komut.ExecuteNonQuery();
        }

    }
}
