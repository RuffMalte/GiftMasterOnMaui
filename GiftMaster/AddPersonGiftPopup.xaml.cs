﻿using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Alerts;
using GiftMaster.ViewModel;
using System.Threading;
using CommunityToolkit.Maui.Core;

namespace GiftMaster;

public partial class AddPersonPopup : Popup
{
    public AddPersonPopup()
    {
        InitializeComponent();
    }

    void ClosePopup(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}
