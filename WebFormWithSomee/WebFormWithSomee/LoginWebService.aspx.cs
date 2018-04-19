using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormWithSomee.LoginServiceReference;

namespace WebFormWithSomee
{
    public partial class LoginWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            var usuar = usuario.Value;
            var pass = password.Value;

            WebFormWithSomee.LoginServiceReference.LoginSoapClient login = new LoginServiceReference.LoginSoapClient();
            mensaje_label.Text = login.LoginByUserAndPassword(usuar, pass);
            usuario.Value = String.Empty;
            password.Value = string.Empty;
        }

        protected void token_button_Click(object sender, EventArgs e)
        {
            var token = token_input.Value;
            LoginSoapClient login = new LoginSoapClient();
            mensaje_token_label.Text = login.validarToken(token).ToString();
            token_input.Value = "";

        }
    }
}