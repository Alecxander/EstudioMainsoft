using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploDePrueba
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_EjecutarServicio_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            //texBox_Saludo.Text = service.Saludar("Buenos dias Sr. ");

            GridView1.DataSource = service.ObtenerAlumnos();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = 10;


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var a = 10;

        }
    }
}