using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }


    public User(int id, string firstName, string lastName, bool gender, string userName, string password, string email, string phoneNumber)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Gender = gender;
        this.UserName = userName;
        this.Password = password;
        this.Email = email;
        this.PhoneNumber = phoneNumber;

    }
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }


}