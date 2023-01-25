using System;
using GiftMaster.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace GiftMaster.Models;

public class PersonModel
{
    public string name { get; set; }
    public DateTime birthday { get; set; }
    public Color color { get; set; }


    public ObservableCollection<GiftModel> gifts { get; set; }


    public PersonModel(string name, DateTime birthday, Color color, ObservableCollection<GiftModel> gifts)
    {
        this.name = name;
        this.birthday = birthday;
        this.color = color;
        this.gifts = gifts;
    }
}

