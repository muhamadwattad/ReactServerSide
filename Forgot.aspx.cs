using ReactProject_ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReactProject_ServerSide
{
    public partial class Forgot : System.Web.UI.Page
    {
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            this.email = email;
            string code = Request.QueryString["code"];
            if (email == null || code == null)
            {
                Response.Write($"<script>  alert('Wrong email') </script>");
                string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                Response.Write(close);
                return;
            }
            int res=SqlDB.CodeAndEmailSame(email, code);
            if(res==0)
            {
                 Response.Write($"<script>  alert('This Code Has Expired. Please Press Again on the Forgot password.') </script>");
                string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                Response.Write(close);
                return;
            }
           
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string RptPassword = rptpassword.Text;
            string Password = password.Text;
            if (!(Password.Length >= 6 && Password.Length <=14))
            {
                Response.Write($"<script>  alert('Password has to be between 6-14') </script>");
                return;
              
            }
            if(Password!=RptPassword)
            {
                Response.Write($"<script>  alert('Passwords has to be the same.') </script>");
                return;
            }
          int res= SqlDB.UpdatePassword(Password, email);
            if(res==0)
            {
                Response.Write($"<script>  alert('Something went wrong.') </script>");
            }
            else
            {
               int r= SqlDB.DeleteCode(email);
                if(r==1)
                {
                    Response.Write($"<script>  alert('Password Reseted Succesfully') </script>");
                }
                else
                {
                    Response.Write($"<script>  alert('Code Not deleted,But password reseted.') </script>");
                }
                string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                Response.Write(close);
            }
            

        }
    }
}