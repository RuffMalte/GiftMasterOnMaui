using System;
namespace GiftMaster.Models;

public class GiftModel
{
    public string title { get; set; }
    public double price { get; set; }
    public string status { get; set; }
    public Guid Guid;
    public Color color { get; set; }

    public GiftModel(string title, double price, string status, Color color)
    {
        this.title = title;
        this.price = price;
        this.status = status;
        this.color = color;
        Guid = Guid.NewGuid();
    }
}

