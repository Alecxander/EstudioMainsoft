using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrollo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                gridView_Personas.DataSource = Logica.Persona.ObtenerPersonas();
                gridView_Personas.DataBind();
            }
        }

        protected void gridView_Personas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = gridView_Personas.SelectedDataKey;

            //var id = gridView_Personas.Rows[item].Cells[1].ToString();
            Response.Redirect("ConsultarPersona.aspx?Id=" + item.Value);
        }

        protected void button_crearPersona_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPersona.aspx");
        }
    }
}