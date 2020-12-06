using System;
using System.ComponentModel;

namespace ToyRobot.Core.Enums
{    
    public enum Commands
    {
        [Description("PLACE")]
        Place,
        [Description("MOVE")]
        Move,
        [Description("LEFT")]
        Left,
        [Description("RIGHT")]
        Right,
        [Description("REPORT")]
        Report
    }
}