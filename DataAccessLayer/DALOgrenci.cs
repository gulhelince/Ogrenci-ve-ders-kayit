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
    public class DALOgrenci //public yapılarak diğer alanlardan erişim sağlanır.
    {
        //ilk olarak ekleme metodu oluşturulur
        public static int OgrenciEkle(EntityOgrenci parametre) //ilgili katmanıma ait değer türetmesi yapılır
        {
            SqlCommand komut1 = new SqlCommand("insert into TblOgrenci (OgrAd,OgrSoyad,OgrNumara,OgrFoto,OgrSifre) values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl); //sql bağlantısı tanımlanır

            //eğer bağlantım kapalıysa bağlantımı aç
            if(komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }

            //parametrelere değer ataması yapılır 
            komut1.Parameters.AddWithValue("@p1", parametre.Ad); //EntityOgrenci sınıfımdaki değerleri bana getirir.     
            komut1.Parameters.AddWithValue("@p2", parametre.Soyad);
            komut1.Parameters.AddWithValue("@p3", parametre.Numara);
            komut1.Parameters.AddWithValue("@p4", parametre.Fotograf);
            komut1.Parameters.AddWithValue("@p5", parametre.Sifre);

            return komut1.ExecuteNonQuery(); //etkilenen kayıt sayısını geriye döndür.

        }

        //Listeleme işlemleri,metodun türü list olucak ,verileri veri tabanından çekmek için kullanılır
        public static List<EntityOgrenci> OgrenciListesi() //EntityOgrenci sınıfım içindeki değerler ne ise o değerleri almasını sağlar ,daha sonra metoda isim ver .
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut2 = new SqlCommand("Select * from TblOgrenci", Baglanti.bgl);

            //eğer bağlantım kapalıysa bağlantımı aç
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

            //öğrenci tablosunda bulunan bütün kayıtları döndürür
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read()) //dr komutu okuma işlemini gerçekleştirdiği müdettçe 
            {
                EntityOgrenci ent = new EntityOgrenci(); //nesne türet 
                ent.Id=Convert.ToInt32(dr["OgrID"].ToString());
                ent.Ad = dr["OgrAd"].ToString();
                ent.Soyad = dr["OgrSoyad"].ToString();
                ent.Numara = dr["OgrNumara"].ToString();
                ent.Fotograf= dr["OgrFoto"].ToString();
                ent.Sifre = dr["OgrSifre"].ToString();
                ent.Bakiye=Convert.ToDouble( dr["OgrBakiye"].ToString());
                degerler.Add(ent); //ent den gelen değerleri degerler içerisine ekle 
            }
            dr.Close();
            return degerler; //geriye degerleri döndür 
        }

        //Öğrenci üzerinde silme işlemi gerçekleştirilir
        //ekleme işleminde int bir metot kullandık  ve bu metoda bir parametre gönderip burada (entityOgrenci Parametre) dedik çünkü entity sınıfındaki tüm değerleri almalı
        //silme işleminde entity sınıfındaki değişkenler yerine sadece bir Id değeri tutulur.

        public static bool OgrenciSil (int parametre) //öğrenci sil adında bir metot oluşturulur
        {
            SqlCommand komut3 = new SqlCommand("delete From TblOgrenci where OgrID=@p1", Baglanti.bgl);
           
            //eğer bağlantım kapalıysa bağlantımı aç
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }

            komut3.Parameters.AddWithValue("@p1", parametre); //p1 değer ataması yapılır
            return komut3.ExecuteNonQuery() > 0; //işlem sağlanıyorsa zaten döndürür.
        }


        //Öğrenciye ait verileri listeleme 
        public static List<EntityOgrenci> OgrenciDetay(int id) //EntityOgrenci sınıfım içindeki değerler ne ise o değerleri almasını sağlar ,daha sonra metoda isim ver .
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut4 = new SqlCommand("Select * from TblOgrenci where OgrID=@p1", Baglanti.bgl);
            komut4.Parameters.AddWithValue("@p1", id); //parametreyi dışarıdan gönderdiğim id değikeninden alır
            
            
            //eğer bağlantım kapalıysa bağlantımı aç
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }

            SqlDataReader dr = komut4.ExecuteReader();
            while (dr.Read()) //dr komutu okuma işlemini gerçekleştirdiği müdettçe 
            {
                EntityOgrenci ent = new EntityOgrenci(); //nesne türet 
                
                ent.Ad = dr["OgrAd"].ToString();
                ent.Soyad = dr["OgrSoyad"].ToString();
                ent.Numara = dr["OgrNumara"].ToString();
                ent.Fotograf = dr["OgrFoto"].ToString();
                ent.Sifre = dr["OgrSifre"].ToString();
                ent.Bakiye = Convert.ToDouble(dr["OgrBakiye"].ToString());
                degerler.Add(ent); //ent den gelen değerleri degerler içerisine ekle 
            }
            dr.Close();
            return degerler; //geriye degerleri döndür 
        }



        //Güncelleme işlemi
        public static bool OgrenciGüncelle(EntityOgrenci deger)
        {
            //deger adlı türetmiş olduğum nesnemle entity sınıfımdaki öğelere ulaşmış olurum
            //Güncelleme sorgusu yazılır 
            SqlCommand komut5 = new SqlCommand("update TblOgrenci set OgrAd=@p1,OgrSoyad=@p2,OgrNumara=@p3,OgrFoto=@p4,OgrSifre=@p5 where OgrID=@p6", Baglanti.bgl);

            //eğer bağlantım kapalıysa bağlantımı aç
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }

            komut5.Parameters.AddWithValue("@p1", deger.Ad);
            komut5.Parameters.AddWithValue("@p2", deger.Soyad);
            komut5.Parameters.AddWithValue("@p3", deger.Numara);
            komut5.Parameters.AddWithValue("@p4", deger.Fotograf);
            komut5.Parameters.AddWithValue("@p5", deger.Sifre);
            komut5.Parameters.AddWithValue("@p6", deger.Id);

            return komut5.ExecuteNonQuery() > 0;
        }

    }
}
