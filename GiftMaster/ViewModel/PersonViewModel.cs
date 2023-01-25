using System;
using GiftMaster.Models;
using GiftMaster.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Linq;
using CommunityToolkit.Maui.Views;

namespace GiftMaster.ViewModel;

public partial class PersonViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<PersonModel> people;

    [ObservableProperty]
    public List<Color> peopleBorderColorList = new List<Color> { Colors.Red, Colors.Purple, Colors.Blue, Colors.Chocolate, Colors.DeepPink, Colors.DodgerBlue, Colors.Green, Colors.Tomato, Colors.Yellow, Colors.Firebrick };


    public PersonViewModel()
    {
        People = new ObservableCollection<PersonModel>();

        People.Add(new PersonModel(
            "Remove Me",
            DateTime.Now,
            Colors.Red,
            new ObservableCollection<GiftModel> { }));
    }


    //New Person Input Data
    public string newPersonNameInput { get; set; }
    public DateTime newPersonDateInput { get; set; }
    public Color newPersonColorInput { get; set; }


    //Person Commands
    public ICommand AddPersonCommand => new Command(addPerson);
    void addPerson()
    {
        if (string.IsNullOrWhiteSpace(newPersonNameInput))
        {
            Helpers.Helpers.ErrorSnackbar("Name cannot be Empty");
            return;
        }

        people.Add(new PersonModel(newPersonNameInput, newPersonDateInput, newPersonColorInput, new ObservableCollection<GiftModel> { }));
    }

    public ICommand DeletePersonCommand => new Command(deletePerson);
    void deletePerson(object o)
    {
        PersonModel person = o as PersonModel;
        if (people.Contains(person))
        {
            people.Remove(person);
        } else
            Helpers.Helpers.ErrorSnackbar("Person could not be found");
    }

    public ICommand ClearInputsCommand => new Command(clearInputs);
    public void clearInputs()
    {
        newPersonColorInput = Colors.Red;
        newPersonDateInput = DateTime.Today;
        newPersonNameInput = "";
    }

    public ICommand AddColorToPersonCommand => new Command(addColorToPerson);
    void addColorToPerson(object o)
    {
        newPersonColorInput = o as Color;
        Helpers.Helpers.DisplaySnackBarMessage("Color selcted", newPersonColorInput);
    }


    //New Gift Input Data
    public string newGiftTitleInput { get; set; }
    public double newGiftPriceInput { get; set; }
    public string newGiftStatusInput { get; set; }
    public Color newGiftStatusColor { get; set; }

    public PersonModel CurrentPerson { get; set; }


    //Gift Commands
    public ICommand GetCurrentPersonCommand => new Command(GetCurrentPerson);
    void GetCurrentPerson(object o)
    {
        PersonModel person = o as PersonModel;
        CurrentPerson = person;

        clearGiftInputs();
    }

    public ICommand addGiftCommand => new Command(addGift);
    void addGift()
    {
        if (string.IsNullOrWhiteSpace(newGiftTitleInput))
        {
            Helpers.Helpers.ErrorSnackbar("Gift Title cannot be Empty");
            return;
        }

        CurrentPerson.gifts.Add(new GiftModel(newGiftTitleInput, newGiftPriceInput, newGiftStatusInput, newGiftStatusColor));
    }

    public ICommand DeleteGiftCommand => new Command(deleteGift);
    void deleteGift(object o)
    {
        GiftModel gift = o as GiftModel;

        for (int i = 0; i < people.Count; i++)
        {
            for (int j = 0; j < people[i].gifts.Count; j++)
            {
                if (people[i].gifts[j] == gift)
                {
                    people[i].gifts.Remove(gift);
                    break;
                }
                else
                    Helpers.Helpers.ErrorSnackbar("Gift could not be found");
            }
        }
    }

    void clearGiftInputs()
    {
        newGiftTitleInput = "";
        newGiftPriceInput = 0;
        newGiftStatusInput = giftStatus[0];
        newGiftStatusColor = giftStatusColor[0];
    }


    //Gift Status Lists
    [ObservableProperty]
    public List<string> giftStatus = new List<string> { "💡 Idea", "🛍 Bought", "🎉 Given" };
    [ObservableProperty]
    public List<Color> giftStatusColor = new List<Color> { Colors.LightYellow, Colors.LightGreen, Colors.MediumPurple };


    public ICommand SetGiftStatusCommand => new Command(setGiftStatus);
    void setGiftStatus()
    {
        int currentGiftStatus = giftStatus.FindIndex(value => value == newGiftStatusInput);

        currentGiftStatus++;
        if (currentGiftStatus >= giftStatus.Count) currentGiftStatus = 0;
        

        newGiftStatusInput = giftStatus[currentGiftStatus];
        newGiftStatusColor = giftStatusColor[currentGiftStatus];

        Helpers.Helpers.DisplaySnackBarMessage(newGiftStatusInput, newGiftStatusColor);
    }

    public ICommand ChangeGiftStatusCommand => new Command(changeGiftStatus);
    void changeGiftStatus(object o)
    {
        var gift = o as GiftModel;
        var tempGift = gift;
        int currentGiftStatus = giftStatus.FindIndex(value => value == gift.status);

        currentGiftStatus++;
        if (currentGiftStatus >= giftStatus.Count) currentGiftStatus = 0;
        
        gift.status = giftStatus[currentGiftStatus];
        gift.color = giftStatusColor[currentGiftStatus];        
        for (int i = 0; i < people.Count; i++)
        {
            for (int j = 0; j < people[i].gifts.Count; j++)
            {
                if (people[i].gifts[j].Guid == tempGift.Guid)
                {
                    people[i].gifts.Remove(tempGift);
                    people[i].gifts.Add(gift);
                    break;
                }
            }
        }
        Helpers.Helpers.DisplaySnackBarMessage(gift.status, gift.color);
    }
}