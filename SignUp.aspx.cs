using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;


public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnectLinkButton.Visible = false;
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        ArrayList users = (ArrayList)Application["users"];

        if (users != null)
        {
            if (!String.IsNullOrEmpty(TextBoxUser.Text) && !String.IsNullOrEmpty(TextBoxPassword.Text) && !String.IsNullOrEmpty(TextBoxEmail.Text) && !String.IsNullOrEmpty(TextBoxPhone.Text) && !String.IsNullOrEmpty(TextBoxFName.Text) && !String.IsNullOrEmpty(TextBoxLName.Text))
            {
                User SignedupUser = Array.Find((User[])users.ToArray(typeof(User)),
                     user => user.UserName.Equals(TextBoxUser.Text) || user.Email.Equals(TextBoxEmail.Text) || user.PhoneNumber.Equals(TextBoxPhone));

                if (SignedupUser != null)
                {
                    ErrorMessageLabel.Text = "This user already exists";

                }
                else
                {

                    string connectionString = WebConfigurationManager.ConnectionStrings["ToursDB"].ConnectionString;

                    // Define ADO.NET objects.
                    string insertUserSQL;
                    insertUserSQL = "INSERT INTO users (";
                    insertUserSQL += "first_name, last_name, gender, ";
                    insertUserSQL += "user_name, password, email, phone_number) ";

                    insertUserSQL += "VALUES (";
                    insertUserSQL += "@first_name, @last_name, @gender, ";
                    insertUserSQL += "@user_name, @password, @email, @phone_number)";

                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(insertUserSQL, con);

                    // Add the parameters.
                    cmd.Parameters.AddWithValue("@first_name", TextBoxFName.Text);
                    cmd.Parameters.AddWithValue("@last_name", TextBoxLName.Text);
                    cmd.Parameters.AddWithValue("@gender", RadioButtonMale.Checked);
                    cmd.Parameters.AddWithValue("@user_name", TextBoxUser.Text);
                    cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@phone_number", TextBoxPhone.Text);

                    // Try to open the database and execute the update.
                    int added = 0;
                    try
                    {
                        con.Open();
                        added = cmd.ExecuteNonQuery();
                        ErrorMessageLabel.ForeColor = System.Drawing.Color.Green;
                        ErrorMessageLabel.Visible = true;
                        ErrorMessageLabel.Text = added.ToString() + " record inserted.";
                        ConnectLinkButton.Visible = true;
                    }
                    catch (Exception err)
                    {
                        ErrorMessageLabel.Visible = true;
                        ErrorMessageLabel.Text = "Error inserting record. ";
                        ErrorMessageLabel.Text += err.Message;
                    }
                    finally
                    {
                        con.Close();

                    }
                    ClearTextBoxes();
                    ClearRadioButtons();
                }

            }
            else
                ErrorMessageLabel.Text = "Insert your details";
        }
    }
    protected void ConnectLinkButton_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Default.aspx");
 }
    public static Control[] FlattenHierachy(Control root)
    {
        List<Control> list = new List<Control>();
        list.Add(root);
        if (root.HasControls())
        {
            foreach (Control control in root.Controls)
            {
                list.AddRange(FlattenHierachy(control));
            }
        }
        return list.ToArray();
    }

    private void ClearTextBoxes()
    {
        Control[] allControls = FlattenHierachy(Page);
        foreach (Control control in allControls)
        {
            TextBox textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.Text = "";
            }
        }
    }

    private void ClearRadioButtons()
    {
        Control[] allControls = FlattenHierachy(Page);
        foreach (Control control in allControls)
        {
            RadioButton rb = control as RadioButton;
            if (rb != null)
            {
                if (rb.Checked == true)
                {
                    rb.Checked = false;
                }
            }
        }
    }
}
     
