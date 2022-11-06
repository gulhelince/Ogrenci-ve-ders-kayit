using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity; //entity değerlerini kullanmamı sağlar
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLOgrenci
    {
        //ekleme işlemi için bir metot oluşturulur
        public static int OgrenciEkleBLL(EntityOgrenci p)
        {
            if(p.Ad!=null && p.Soyad!=null && p.Numara!=null && p.Sifre!=null && p.Fotograf!=null )
            {
                return DALOgrenci.OgrenciEkle(p);
            }

            return -1;
        }

        //Listeleme işlemi 
        public static List<EntityOgrenci> BllListele()
        {
            return DALOgrenci.OgrenciListesi();
        }

        //Bir silme iişlemi oluşturulur
        public static bool OgrenciSilBLL(int p) //metot tanımlanır
        {
            if (p >= 0)
            {
                return DALOgrenci.OgrenciSil(p); //öğrenci sil metodu çağrılır
            }
            return false; //şart sağlanmazsa
        }


        //Listeleme işlemi 
        public static List<EntityOgrenci> BllDetay(int p) //dışarıdan bir parametre alması gerekir
        {
            return DALOgrenci.OgrenciDetay(p);
        }

        //Güncelleme işlemleri için bir metot oluşturulur 
        public static bool OgrenciGuncelleBLL(EntityOgrenci p)
        {
            if (p.Ad != null && p.Ad!=""  && p.Soyad != null && p.Soyad != ""  && p.Numara != null && p.Numara != "" &&  p.Sifre != null && p.Sifre != ""  && p.Fotograf != null && p.Fotograf != "" && p.Id>0)
            {
                return DALOgrenci.OgrenciGüncelle(p);
            }
            return false;

        }

    }
}
