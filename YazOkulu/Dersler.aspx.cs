using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entity;
using BusinessLogicLayer;
using DataAccessLayer;

namespace YazOkulu
{
    public partial class Dersler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            {
                //ders seçinin içi doldurulur 
                List<EntityDersler> EntDers = BLLDers.BllListele(); //nesne ilişkilendirilir.
                DropDownList1.DataSource = BLLDers.BllListele();
                DropDownList1.DataTextField = "DERSAD"; //veri tabanından gözükücek olan alanım
                DropDownList1.DataValueField = "Id"; //Arka planda tutar
                DropDownList1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBox1.Text = DropDownList1.SelectedValue.ToString();
            EntityBasvuruFormu ent = new EntityBasvuruFormu();
            ent.Basogrid = int.Parse(TextBox1.Text);
            ent.Basdersid = int.Parse(DropDownList1.SelectedValue.ToString());
            BLLDers.TalepEkleBLL(ent);
        }
    }
}