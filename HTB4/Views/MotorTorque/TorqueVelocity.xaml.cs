﻿using HTB4.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HTB4.Views.MotorTorque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class TorqueVelocity : CalcPage
    {
        public TorqueVelocity()
        {
            InitializeComponent();
            Title = "Motor Torque Velocity Calculator";
            NavigationPage.SetBackButtonTitle(this, "Motor Torque");

        }
    }
}