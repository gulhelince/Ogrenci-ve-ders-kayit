using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity; //entity değerlerini kullanmamı sağlar
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLDers
    {
        //Listeleme işlemi 
        public static List<EntityDersler> BllListele()
        {
            return DALDers.DersListesi();
        }

        public static int TalepEkleBLL(EntityBasvuruFormu p)
        {
            if (p.Basogrid != null && p.Basdersid != null)
            {
                return DALDers.TalepEkle(p);
            }
            return -1;

        }
    }
}

//proje ilk olarak entity katmanından başlar 
/*
 -entity katmanında değişkenler yer alır ,biz bu değişkenlere değer ataması gerçekleştiririz.
-değer ataması DataAccessLayer üzerinde gerçekleştirilir.
-BusinessLogicLayer deki şart sağlanıyorsa burdan bizi sunum katmanına gönderir
-sunum katmanında istediğimiz formatta değerleri gönderir.

 */
