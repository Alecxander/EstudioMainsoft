using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entities;
using Entities.DTO;

namespace PruebaDesarrollo
{
    public partial class ConsultarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string id = Convert.ToString(Request.QueryString["Id"]);
                if(id != null)
                {
                    int _id = int.Parse(id);

                    var persona = Logica.Persona.ObtenerPersonaPorId(_id);
                    textbox_nombre.Text = persona.Nombre;
                    textbox_numeroIdentificacion.Text = persona.NumeroIdentificacion.ToString();
                    bool estado = false;
                    if (bool.TryParse(persona.Estado.ToString(), out estado))
                    {
                        CheckBox_estado.Checked = estado;
                    }
                    ObtenerTipoIdentificacion(_id);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                
            }
        }

        private void ObtenerTipoIdentificacion(int tipoIdentificacion)
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

            dropDownList_tipoIdentificacion.SelectedValue = tipoIdentificacion.ToString();
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public string ModificarPersona(PersonaDTO personaDTO)
        {
            string mensaje = "";
            if (ModelState.IsValid)
            {
                mensaje = Persona.ModificarPersona(personaDTO);
            }
            return mensaje;
        }

        protected void button_Modificar_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(Request.QueryString["Id"]);
            if (id != null)
            {
                int _id = int.Parse(id);

                var _tipoIdentificacion = dropDownList_tipoIdentificacion.SelectedValue;
                var _numeroIdentificacion = textbox_numeroIdentificacion.Text;
                var _nombre = textbox_nombre.Text;
                var _estado = CheckBox_estado.Checked;


                var personaDTO = new PersonaDTO()
                {
                    Estado = _estado,
                    Nombre = _nombre,
                    NumeroIdentificacion = _numeroIdentificacion,
                    TipoIdentificacionId = Int32.Parse(_tipoIdentificacion)
                };

                string mensaje = ModificarPersona(personaDTO);


                //var mensaje = Logica.Persona.ModificarPersona(personaDTO);
                if (mensaje == "ok")
                {
                    label_mensaje.Text = "";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    label_mensaje.Text = "ERROR: " + mensaje;
                }
            }
        }
    }
}