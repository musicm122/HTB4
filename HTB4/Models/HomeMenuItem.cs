using System;
using System.Collections.Generic;
using System.Text;

namespace HTB4.Models
{
    public enum MenuItemType
    {
        About,
        CaseDrain,
        Cylinder,
        Pump,
        Motor,
        MotorTorque,
        ConversionTable1,
        ConversionTable2,
        ConversionTable3,
        Debug,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
