﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYouMobile.Views.Friends
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendsListUserControl : ScrollView
    {
        public FriendsListUserControl()
        {
            InitializeComponent();
        }
    }
}