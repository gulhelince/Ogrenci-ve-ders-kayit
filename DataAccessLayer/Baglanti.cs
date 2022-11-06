using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Sistem kütüphaneleri eklenir
using System.Data;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
    public class Baglanti
    {
        /*
         -select,insert,update,delete işlemlerini gerçekleştireceğim sınıfım.
        -bir nesne türetilmeli diğer sınıf ve form alanlarında rahatça kullanabilmek için statik bir nesne türetilir.
        -bu nesneye diğer formlardan erişim sağlayacağız
        -bağlantı sınıfı içerisinde statik bir nesne türetilir ve bu nesneye diğer formlardan erişim sağlanır.
         */
        public static SqlConnection bgl = new SqlConnection(@"Data Source=LAPTOP-T6EVUJF1;Initial Catalog=Db_YazOkulu;Integrated Security=True");
   

    }
}
