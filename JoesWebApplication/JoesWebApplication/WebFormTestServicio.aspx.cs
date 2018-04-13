using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoesWebApplication
{
    public partial class WebFormTestServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCallService_Click(object sender, EventArgs e)
        {
            JoesWebService  hello = new JoesWebService();

            //labelServiceResult.Text = hello.HelloWorld();
            labelServiceResult.Text = hello.HelloWorldByUser(TextBoxUserName.Text, TextBoxPassword.Text);
        }
    }
}