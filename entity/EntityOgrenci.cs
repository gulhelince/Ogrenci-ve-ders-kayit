using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity
{
    public class EntityOgrenci
    {
        //Öğrenci sınıfı için;
        //sınıfın içerisine değişkenler tanımlanır
        //değişkenlere diğer formlardan ulaşmak için değişkenlerden birer tane daha üretilmeli
       //Burada ilgili değerlere kısatlamalar getirilebilir.

        private string ad;
        public string Ad
        { get { return ad; }
            set { ad = value; }
        }

        private string soyad;
        public string Soyad 
        { get { return soyad; }
            set { soyad = value; } }

        private int  id;
        public int Id 
        { get { return id; }
            set { id = value; } }

        private string numara;
        public string Numara
        { get { return numara; }
            set { numara = value; } }

        private string fotograf;
        public string Fotograf 
        { get { return fotograf; }
            set { fotograf = value; } }


        private double bakiye;
        public double Bakiye 
        { get { return bakiye; }
            set { bakiye = value; } }


        private string sifre;
        public string Sifre
        { get => sifre; 
          set => sifre = value; }

       

    }
}
