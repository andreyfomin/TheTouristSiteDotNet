using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //  if (PreviousPage == null || !PreviousPage.AppRelativeVirtualPath.Equals("~/Default.aspx"))
        //  {
        //      Server.Transfer("~/Default.aspx");
        //  }

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

        ArrayList users = (ArrayList)Application["users"];
        if (users != null)
        {
            User logedInUser = Array.Find((User[])users.ToArray(typeof(User)),
                 user => user.UserName == UserNameTextBox.Text&&user.Password==TextBoxPassword.Text);

            if (logedInUser!=null)
            {
                Session["logedInUser"] = logedInUser;
                Server.Transfer("~/Default.aspx");
                   
            }
            else
            {
                ErrorMessageLabel.Text = "Wrong user or password!";
            }
        }
    }
}