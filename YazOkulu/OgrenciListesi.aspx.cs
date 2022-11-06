using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Sistem Kütüphaneleri eklenir
using entity;
using DataAccessLayer;
using BusinessLogicLayer;

namespace YazOkulu
{
    public partial class OgrenciListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //listin türü
            List<EntityOgrenci> OgrList = BLLOgrenci.BllListele(); //ilişkilendirilir
            Repeater1.DataSource = OgrList; //Repeater1 bire veri kaynağı olarak OgrList ver 
            Repeater1.DataBind(); //Repeater1 deki işlemleri bağla 

        }
    }
}