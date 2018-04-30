using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Entities
{
    class DACustomVal : BaseValidator
    {
        public string PropertyName { get; set; }
        public string SourceType { get; set; }

        protected override bool EvaluateIsValid()
        {
            //Obtenemos la info del tipo, propiedades y del control.
            Type objType = Type.GetType(SourceType, true, true);
            PropertyInfo propInfo = objType.GetProperty(PropertyName);
            Control control = this.FindControl(this.ControlToValidate);

            //Verificamos si el control es de tipo textbox.
            if (control is TextBox)
            {
                TextBox txt = this.FindControl(this.ControlToValidate) as TextBox;
                foreach (ValidationAttribute attr in
 propInfo.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>())
                {
                    if (!attr.IsValid(txt.Text))
                    {
                        //this.Text = attr.ErrorMessage;
                        this.ErrorMessage = attr.ErrorMessage;
                        return false;
                    }
                }
            }
            //Verificamos si el control es un dropdownlist.
            else if (control is DropDownList)
            {
                DropDownList ddl = this.FindControl(this.ControlToValidate) as DropDownList;
                foreach (ValidationAttribute attr in
 propInfo.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>())
                {
                    if (!attr.IsValid(ddl.SelectedValue))
                    {
                        this.Text = attr.ErrorMessage;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
