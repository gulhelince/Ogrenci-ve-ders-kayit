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
    public partial class OgrenciGüncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x =Convert.ToInt32( Request.QueryString["Id"].ToString());//taşınan id yazdırılır
            TxtID.Text = x.ToString();
            TxtID.Enabled = false; //bu alana müdahale etmemi engeller

            //sayfayı hafızaya alıp veriyi korumasını sağlar 
            //sayfa ilk yüklendiğinde hafızaya aldığı verileri korusun
            if (Page.IsPostBack==false)
            {
                List<EntityOgrenci> OgrList = BLLOgrenci.BllDetay(x); //id mi karşılayan parametre girilir.

                //Yazdırma işlemi
                TxtAd.Text = OgrList[0].Ad.ToString();
                TxtSoyad.Text = OgrList[0].Soyad.ToString();
                TxtNumara.Text = OgrList[0].Numara.ToString();
                TxtFoto.Text = OgrList[0].Fotograf.ToString();
                TxtSifre.Text = OgrList[0].Sifre.ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci(); //EntityOgrenci sınıfından nesne oluşturulur
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sifre = TxtSifre.Text;
            ent.Numara = TxtNumara.Text;
            ent.Fotograf = TxtFoto.Text;
            ent.Id = Convert.ToInt32(TxtID.Text);
            BLLOgrenci.OgrenciGuncelleBLL(ent);
            Response.Redirect("OgrenciListesi.aspx"); //yönlendirir
        }
    }
}