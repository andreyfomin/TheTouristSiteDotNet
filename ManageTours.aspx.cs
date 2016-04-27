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

    protected void DropDownListTours_Click(object sender, EventArgs e)
    {

        ArrayList tours = (ArrayList)this.Application["tours"];
        Tour selectedTour = null;

        foreach (Tour tour in tours)
        {
            if (DropDownListTours.SelectedValue != null)
                if (tour.Id == DropDownListTours.SelectedIndex + 2)
                {
                    selectedTour = tour;
                }
        }

        if (selectedTour != null)
        {
            Session["userSelectedTour"] = selectedTour;
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

        if (FileUpload1.HasFile && !String.IsNullOrEmpty(TextBox1.Text) && !String.IsNullOrEmpty(TextBox2.Text))
        {
            ArrayList tours = (ArrayList)Application["tours"];
            string str = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "/images/" + str);
            string path = "images/" + str.ToString();
            SqlConnection con = new SqlConnection(connectionString);

            if (tours != null)
            {
                Tour KnownTour = Array.Find((Tour[])tours.ToArray(typeof(Tour)),
                         tour => tour.Info.Equals(TextBox1.Text) || tour.Description.Equals(TextBox2.Text) || tour.Image.Equals(path));
                if (KnownTour == null)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into tours (info,image,description) values (@info,@image,@description)", con);
                    cmd.Parameters.AddWithValue("@info", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@image", path);
                    cmd.Parameters.AddWithValue("@description", TextBox2.Text);

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
                    cmd.Parameters.AddWithValue("@description", TextBox2.Text);
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
        if (Session["userSelectedTour"] != null)
        {
            Tour userSelectedTour = (Tour)Session["userSelectedTour"];
            string deleteTourFromSelectedSQL;
            deleteTourFromSelectedSQL = "DELETE FROM user_selected_tours ";
            deleteTourFromSelectedSQL += " WHERE @tour_id=tour_id";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(deleteTourFromSelectedSQL, con);

            cmd.Parameters.AddWithValue("@tour_id", userSelectedTour.Id);

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
            deleteTourSQL = "DELETE FROM tours ";
            deleteTourSQL += " WHERE @info=info";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comd = new SqlCommand(deleteTourSQL, conn);

            comd.Parameters.AddWithValue("@info", userSelectedTour.Info);
            comd.Parameters.AddWithValue("@image", userSelectedTour.Image);
            comd.Parameters.AddWithValue("@description", userSelectedTour.Description);


            int removed2 = 0;
            try
            {
                con.Open();
                removed2 = cmd.ExecuteNonQuery();

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
    }


}
