using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace GiftMaster.Helpers;

public class Helpers
{


    public static void ErrorSnackbar(string title)
    {
        var s = new SnackbarOptions
        {
            BackgroundColor = Colors.OrangeRed
        };

        var snackbar = Snackbar.Make(title, visualOptions: s);
        snackbar.Show();
    }

    public static void DisplaySnackBarMessage(string title, Color color)
    {
        var s = new SnackbarOptions
        {
            BackgroundColor = color
        };

        var snackbar = Snackbar.Make(title, visualOptions: s);
        snackbar.Show();
    }
}

