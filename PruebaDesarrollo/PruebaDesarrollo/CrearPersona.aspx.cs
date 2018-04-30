using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrollo
{
    public partial class CrearPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ObtenerTipoIdentificacion();
            }
        }

        protected void button_CrearPersona_Click(object sender, EventArgs e)
        {
            var _tipoIdentificacion = dropDownList_tipoIdentificacion.SelectedValue;
            var _numeroIdentificacion = textbox_numeroIdentificacion.Text;
            var _nombre = textbox_nombre.Text;
            var _estado = CheckBox_estado.Checked;

            var mensaje = Logica.Persona.CrearPersona(_tipoIdentificacion, _numeroIdentificacion, _nombre, _estado);
            if (mensaje == "ok")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                label_mensaje.Text = "ERROR: " + mensaje;
            }
        }

        private void ObtenerTipoIdentificacion()
        {
            var tipos = Logica.TipoIdentificacion.ObtenerTipoIdentificacion();
            
            foreach (var t in tipos)
            {
                var tipo = new ListItem();
                tipo.Text = t.Tipo;
                tipo.Value = t.Id.ToString();
                dropDownList_tipoIdentificacion.Items.Add(tipo);
                dropDownList_tipoIdentificacion.DataBind();
            }
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}