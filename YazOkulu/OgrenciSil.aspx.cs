using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entity;
using DataAccessLayer;
using BusinessLogicLayer;

namespace YazOkulu
{
    public partial class OgrenciSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //öğrenci silme işlemi için gerekli,taşınan id yi göstermek için 
            int x = Convert.ToInt32(Request.QueryString["Id"]); //diğer formadan taşınan değer burada x atanır,hangi değer olduğu belirtilir
            Response.Write(x); //yazdır

            EntityOgrenci ent = new EntityOgrenci(); //EntityOgrenci den bir nesne türetilir
            //EntityOgrenci den türettiğim nesne yardımıyla EntityOgrenci sınıfı içerisindeki değişkenlere ulaşabilirim.

            ent.Id = x; //Id nin değeri x ten gelir
            BLLOgrenci.OgrenciSilBLL(ent.Id);
            Response.Redirect("OgrenciListesi.aspx"); //tekrar yönlendir
        }
    }
}