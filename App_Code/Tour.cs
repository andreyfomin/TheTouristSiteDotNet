using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tour
/// </summary>
public class Tour
{
    public int Id { get; set; }
    public string Info { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

    public Tour()
    {
    }
    public Tour(int id, string info, string image, string description)
	{
        this.Id = id;
        this.Info = info;
        this.Image = image;
        this.Description = description;
		//
		// TODO: Add constructor logic here
		//
	}
}