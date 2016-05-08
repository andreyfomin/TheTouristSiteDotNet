using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Configuration;
using System.Data.SqlClient;


public partial class ManageTours : System.Web.UI.Page
{

    string connectionString = WebConfigurationManager.ConnectionStrings["ToursDB"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            string selectToursSQL = "SELECT * FROM tours";
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand cmdTours = new SqlCommand(selectToursSQL, myConnection);
            SqlDataReader toursReader;
            ArrayList tours = new ArrayList(10);

            try
            {
                using (myConnection)
                {
                    // Try to open the connection.
                    myConnection.Open();
                    toursReader = cmdTours.ExecuteReader();
                    while (toursReader.Read())
                    {
                        tours.Add(
                            new Tour(
                            Int32.Parse(toursReader["id"].ToString()),
                            toursReader["info"].ToString(),
                            toursReader["image"].ToString(),
                            toursReader["description"].ToString()
                            ));


                    }
                    toursReader.Close();
                }

            }
            catch (Exception err)
            {
                string error = err.Message;
            }
            myConnection.Close();

            Application["tours"] = tours;

            foreach (Tour tour in tours)
            {

                DropDownListTours.Items.Add(new ListItem(tour.Info, Convert.ToString(tour.Id)));
            }
        }
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


    private void ClearDropDownLists()
    {
        Control[] allControls = FlattenHierachy(Page);
        foreach (Control control in allControls)
        {
            DropDownList ddl = control as DropDownList;
            if (ddl != null)
            {
                ddl.SelectedValue = null;
            }
        }
    }

    protected void AdminAddTour_Click(object sender, EventArgs e)
    {

        if (FileUpload1.HasFile && !String.IsNullOrEmpty(TextBox1.Text) && !String.IsNullOrEmpty(TextArea1.Value))
        {
            ArrayList tours = (ArrayList)Application["tours"];
            string str = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "/Images/" + str);
            string path = "Images/" + str.ToString();
            SqlConnection con = new SqlConnection(connectionString);

            if (tours != null)
            {
                Tour KnownTour = Array.Find((Tour[])tours.ToArray(typeof(Tour)),
                         tour => tour.Info.Equals(TextBox1.Text) || tour.Description.Equals(TextArea1.Value) || tour.Image.Equals(path));
                if (KnownTour == null)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into tours (info,image,description) values (@info,@image,@description)", con);
                    cmd.Parameters.AddWithValue("@info", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@image", path);
                    cmd.Parameters.AddWithValue("@description", TextArea1.Value);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClearTextBoxes();
                    ClearDropDownLists();
                }
                else
                {
                    string updateSQL;
                    updateSQL = "UPDATE tours SET ";
                    updateSQL += "info=@info, image=@image, ";
                    updateSQL += "description=@description ";

                    updateSQL += "WHERE tour_id=@tour_id";
                    SqlCommand cmd = new SqlCommand(updateSQL, con);
                    // Add the parameters.
                    cmd.Parameters.AddWithValue("@info", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@image", path);
                    cmd.Parameters.AddWithValue("@description", TextArea1.Value);
                    cmd.Parameters.AddWithValue("@tour_id", KnownTour.Id);

                    // Try to open database and execute the update.
                    int updated = 0;
                    try
                    {
                        con.Open();
                        updated = cmd.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {

                    }
                    finally
                    {
                        con.Close();
                        ClearTextBoxes();
                        ClearDropDownLists();

                    }
                }
            }
        }
    }

    protected void AdminDeleteTour_Click(object sender, EventArgs e)
    {

        Tour selectedTour = null;
        ArrayList tours = (ArrayList)this.Application["tours"];



        foreach (Tour tour in tours)
        {
            if (DropDownListTours.SelectedValue != null)
                if (tour.Id == Decimal.Parse(DropDownListTours.SelectedItem.Value))
                {
                    selectedTour = tour;
                }
        }

        string deleteTourFromSelectedSQL;
        deleteTourFromSelectedSQL = "DELETE FROM user_selected_tours ";
        deleteTourFromSelectedSQL += " WHERE tour_id=@tour_id";

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(deleteTourFromSelectedSQL, con);

        cmd.Parameters.AddWithValue("@tour_id", selectedTour.Id);
        // cmd.Parameters.AddWithValue("@user_id", ((User)Session["logedInUser"]).Id);

        int removed = 0;
        try
        {
            con.Open();
            removed = cmd.ExecuteNonQuery();

        }
        catch (Exception err)
        {

        }
        finally
        {
            con.Close();
        }
        ClearDropDownLists();
        ClearTextBoxes();

        string deleteTourSQL;
        deleteTourSQL = "DELETE FROM tours WHERE id=@id";

        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(deleteTourSQL, con);

        cmd.Parameters.AddWithValue("@id ", selectedTour.Id);
        removed = 0;
        try
        {
            con.Open();
            removed = cmd.ExecuteNonQuery();

        }
        catch (Exception err)
        {

        }
        finally
        {
            con.Close();
        }
        ClearDropDownLists();
        ClearTextBoxes();
    }
    protected void LinkButtonMain_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Default.aspx");
    }
}
