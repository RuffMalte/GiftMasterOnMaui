namespace GiftMaster;
using CommunityToolkit.Maui.Views;
using GiftMaster.ViewModel;

public partial class MainPage : ContentPage
{


    public MainPage()
    {
        InitializeComponent();
        BindingContext = new PersonViewModel();

    }

    void AddPersonPopupClicked(System.Object sender, System.EventArgs e)
    {
        this.ShowPopup(new AddPersonPopup());
    }

    void AddPersonGiftPopupClicked(System.Object sender, System.EventArgs e)
    {
        this.ShowPopup(new AddPersonGiftPopup());
    }


}


