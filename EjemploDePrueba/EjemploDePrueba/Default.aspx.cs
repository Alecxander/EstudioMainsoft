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
            //ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            //texBox_Saludo.Text = service.Saludar("Buenos dias Sr. ");

            ObtenerProductos();
        }

        private void ObtenerProductos()
        {
            ServiceReferenceSomee.ProductosSoapClient serviceReferenceSomee = new EjemploDePrueba.ServiceReferenceSomee.ProductosSoapClient();

            GridView1.DataSource = serviceReferenceSomee.ObtenerProductos();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indexSeleccionado = GridView1.SelectedIndex;


            hdn_Id.Value = GridView1.Rows[indexSeleccionado].Cells[1].Text;
            textBox_nombre.Text = GridView1.Rows[indexSeleccionado].Cells[2].Text;
            textBox_precio.Text = GridView1.Rows[indexSeleccionado].Cells[3].Text;

        }

        protected void button_Actualizar_Click(object sender, EventArgs e)
        {
            ServiceReferenceSomee.ProductosSoapClient productosSoapClient = new ServiceReferenceSomee.ProductosSoapClient();
            var nombre = textBox_nombre.Text.Trim();
            var precio = textBox_precio.Text.Trim();

            if(!(string.IsNullOrEmpty(nombre)) && !(string.IsNullOrEmpty(precio)))
            {
                var p = decimal.Parse(precio);
                var id = Int32.Parse(hdn_Id.Value);
                productosSoapClient.ActualizarProducto(id, nombre, 2, "Verde", p);
                textBox_nombre.Text = String.Empty;
                textBox_precio.Text = string.Empty;
                ObtenerProductos();
            }
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            textBox_nombre.Text = String.Empty;
            textBox_precio.Text = string.Empty;
        }
    }
}