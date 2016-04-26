using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Configuration;
using System.Data.SqlClient;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            string selectUsersSQL = "SELECT * FROM users";
            string selectToursSQL = "SELECT * FROM tours";
            string selectedToursSQL = "SELECT * FROM user_selected_tours";

            string connectionString = WebConfigurationManager.ConnectionStrings["ToursDB"].ConnectionString;

            SqlConnection myConnection = new SqlConnection(connectionString);
            // myConnection.ConnectionString is now set to connectionString.

            SqlCommand cmdUsers = new SqlCommand(selectUsersSQL, myConnection);
            SqlCommand cmdTours = new SqlCommand(selectToursSQL, myConnection);
            SqlCommand cmdSelectedTours = new SqlCommand(selectedToursSQL, myConnection);

            SqlDataReader usersReader;
            SqlDataReader toursReader;
            SqlDataReader selectedToursReader;

            Hashtable userSelectedToursTable = new Hashtable();
            ArrayList users = new ArrayList(10);
            ArrayList tours = new ArrayList(10);
            try
            {
                using (myConnection)
                {
                    // Try to open the connection.
                    myConnection.Open();
                    usersReader = cmdUsers.ExecuteReader();
                   
                   

                    // For each item, add the author name to the displayed
                    // list box text, and store the unique ID in the Value property.
                    while (usersReader.Read())
                    {
                        User usr = new User(
                            Int32.Parse(usersReader["id"].ToString()),
                            usersReader["first_name"].ToString(),
                            usersReader["last_name"].ToString(),
                            Boolean.Parse(usersReader["gender"].ToString()),
                            usersReader["user_name"].ToString(),
                            usersReader["password"].ToString(),
                            usersReader["email"].ToString(),
                            usersReader["phone_number"].ToString()
                            );
                        users.Add(usr);

                    }

                    usersReader.Close();
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

                    selectedToursReader = cmdSelectedTours.ExecuteReader();
                    while (selectedToursReader.Read())
                    {
                        if (userSelectedToursTable.ContainsKey(Int32.Parse(selectedToursReader["user_id"].ToString())))
                        {
                            (
                                (ArrayList)userSelectedToursTable[Int32.Parse(selectedToursReader["user_id"].ToString())]
                                ).Add(Int32.Parse(selectedToursReader["tour_id"].ToString()));
                        }
                        else
                        {
                            userSelectedToursTable[Int32.Parse(selectedToursReader["user_id"].ToString())] = new ArrayList(10);

                            (
                                (ArrayList)userSelectedToursTable[Int32.Parse(selectedToursReader["user_id"].ToString())]
                                ).Add(Int32.Parse(selectedToursReader["tour_id"].ToString()));

                        }

                    }
                    selectedToursReader.Close();
                }
            }
            catch (Exception err)
            {
                string error = err.Message;
                // Handle an error by displaying the information.
                // lblInfo.Text = "Error reading the database. ";
                // lblInfo.Text += err.Message;
            }
            // finally
            // {
            // Either way, make sure the connection is properly closed.
            // (Even if the connection wasn't opened successfully,
            // calling Close() won't cause an error.)
            myConnection.Close();
            // lblInfo.Text += "<br /><b>Now Connection Is:</b> ";
            // lblInfo.Text += myConnection.State.ToString();
            // }
            //zmani
            //ArrayList tours = new ArrayList();
            //tours.Add(new Tour(1, "gdgdg", "tour1.jpg", "<h1>a1</h1>"));
            //tours.Add(new Tour(2, "jksks", "tour2.jpg", "a2"));
            //tours.Add(new Tour(3, "ltltk", "tour3.jpg", "a3"));
            //tours.Add(new Tour(4, "babacs", "tour4.jpg", "a4"));

            // ArrayList users = new ArrayList(10);
            // users.Add(new User(1, "Admin", "Admin", true, "admin", "123456", "admin@gmail.com", "+(972)546171318"));
            // users.Add(new User(2, "Tom", "Hanks", true, "tomh", "111111", "tom@gmail.com", "+(972)546171322"));
            // users.Add(new User(3, "Arnold", "Schwarzenegger", true, "terminator", "222222", "arnold@gmail.com", "+(972)546171366"));

           

            /*ArrayList toursByUserId = new ArrayList(10);

            toursByUserId.Add(1);
            toursByUserId.Add(3);
            toursByUserId.Add(4);

            userSelectedToursTable.Add(2, toursByUserId);

            toursByUserId = new ArrayList(10);

            toursByUserId.Add(1);
            toursByUserId.Add(2);

            userSelectedToursTable.Add(3, toursByUserId);*/


            Application["tours"] = tours;
            Application["users"] = users;
            Application["userSelectedTours"] = userSelectedToursTable;
            Session["userSelectedTour"] = tours[0];

            foreach (Tour tour in tours)
            {

                BulletedListTours.Items.Add(new ListItem(tour.Info, Convert.ToString(tour.Id)));
            }

            ImageRomania.ImageUrl = ((Tour)tours[0]).Image;
            TourDescriptionPanel.Controls.Add(new LiteralControl(((Tour)tours[0]).Description));


        }



        if (Session["logedInUser"] != null)
        {
            LogdeinUserInfoHyperLink.Text = "User: " + ((User)Session["logedInUser"]).UserName;
            LogInOutLinkButton.Text = "Log Out";
            SignUpOutLinkButton.Visible = false;
            if (((User)Session["logedInUser"]).UserName.Equals("admin"))
            {
                ManageToursLinkButton.Visible = true;
            }
            else
                ManageToursLinkButton.Visible = false;

            if (Application["userSelectedTours"] != null)
            {
                Hashtable currentUserSelectedToursTable = (Hashtable)Application["userSelectedTours"];
                ArrayList currentUserSelectedTours = (ArrayList)currentUserSelectedToursTable[((User)Session["logedInUser"]).Id];

                MyFavoritBulletedList.Items.Clear();

                /*foreach (int currentUserSelectedTourId in currentUserSelectedTours)
                {
                    ArrayList allTours = (ArrayList)Application["tours"];

                    foreach (Tour tempTour in allTours)
                    {
                        if (tempTour.Id == currentUserSelectedTourId)
                        {
                            MyFavoritBulletedList.Items.Add(new ListItem(tempTour.Info, Convert.ToString(tempTour.Id)));
                        }
                    }
                }*/
            }
           
        }
        else
        {
            AddRemoveTourButton.Enabled = false;
            ManageToursLinkButton.Visible = false;
            LogInOutLinkButton.Text = "Log In";
            LogdeinUserInfoHyperLink.Text = "";
        }
    }

    protected void BulletedListTours_Click(object sender, BulletedListEventArgs e)
    {
        // Retrieve the selected ListItem object by its index number.
        ListItem item = BulletedListTours.Items[e.Index];

        ArrayList tours = (ArrayList)this.Application["tours"];
        Tour selectedTour = null;

        foreach (Tour tour in tours)
        {
            if (tour.Id == Decimal.Parse(item.Value))
            {
                selectedTour = tour;
            }
        }

        if (selectedTour != null)
        {
            Session["userSelectedTour"] = selectedTour;
        }

        if (Session["logedInUser"] != null)
        {
            User user = (User)Session["logedInUser"];
            Hashtable userSelectedToursTable = (Hashtable)Application["userSelectedTours"];
            ArrayList userSelectedTours = (ArrayList)userSelectedToursTable[user.Id];
            if (userSelectedTours != null)
            {
                int selectedtour = Array.Find((int[])userSelectedTours.ToArray(typeof(int)),
               tourId => tourId == Decimal.Parse(item.Value));

                if (selectedtour != 0)
                {
                    AddRemoveTourButton.Text = "Remove tour";
                }
                else
                {
                    AddRemoveTourButton.Text = "Add tour";
                }
            }
            else
            {
                AddRemoveTourButton.Text = "Add tour";
            }



            ImageRomania.ImageUrl = selectedTour.Image;
            TourDescriptionPanel.Controls.Add(new LiteralControl(selectedTour.Description));

        }
    }

    protected void LogInOutLinkButton_Click(object sender, EventArgs e)
    {
        if (Session["logedInUser"] != null)
        {
            Session["logedInUser"] = null;

            LogInOutLinkButton.Text = "Log In";
            LogdeinUserInfoHyperLink.Text = "";
            AddRemoveTourButton.Enabled = false;
            MyFavoritBulletedList.Items.Clear();
        }
        else
        {
            Response.Redirect("~/LogIn.aspx");
        }

    }
    protected void SignUpOutLinkButton_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/SignUp.aspx");
    }
    protected void MyFavoritPanel_DataBinding(object sender, EventArgs e)
    {

    }

    protected void AddRemoveTourButton_Click(object sender, EventArgs e)
    {
        Tour userSelectedTour = (Tour)Session["userSelectedTour"];
        User user = (User)Session["logedInUser"];
        Hashtable currentUserSelectedToursTable = (Hashtable)Application["userSelectedTours"];
        ArrayList currentUserSelectedTours = (ArrayList)currentUserSelectedToursTable[((User)Session["logedInUser"]).Id];

        
        if (AddRemoveTourButton.Text.Equals("Add tour"))
        {
           string connectionString = WebConfigurationManager.ConnectionStrings["ToursDB"].ConnectionString;

                    // Define ADO.NET objects.
                    string insertFavTourSQL;
                    insertFavTourSQL = "INSERT INTO user_selected_tours (";
                    insertFavTourSQL += "user_id,tour_id) ";
                   

                    insertFavTourSQL += "VALUES (";
                    insertFavTourSQL += "@user_id, @tour_id) ";
            
                

                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(insertFavTourSQL, con);

                    cmd.Parameters.AddWithValue("@user_id",user.Id );
                    cmd.Parameters.AddWithValue("@tour_id",userSelectedTour.Id );
                    
                    int added = 0;
                    try
                    {
                        con.Open();
                        added = cmd.ExecuteNonQuery();

                    }
                    catch (Exception err)
                    {

                    }
                    finally
                    {
                        con.Close();
                        AddRemoveTourButton.Text = "Remove tour";
                    }
            

 
               
        }
        else
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ToursDB"].ConnectionString;
           
            // Define ADO.NET objects.
            string deleteFavTourSQL;
            deleteFavTourSQL = "DELETE FROM user_selected_tours ";
            deleteFavTourSQL += " WHERE @tour_id=tour_id";
           
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(deleteFavTourSQL, con);

            cmd.Parameters.AddWithValue("@tour_id ", userSelectedTour.Id);
            cmd.Parameters.AddWithValue("@user_id", user.Id);
           
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
                AddRemoveTourButton.Text = "Add tour";
            } 
        }
        }
    protected void ManageToursLinkButton_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/ManageTours.aspx");
    }
   
}
              