﻿using System.ComponentModel.Composition;
using System.Windows;

namespace HidWizards.UCR.Plugins.JoystickGroup
{
    [Export(typeof(ResourceDictionary))]
    public partial class Resources : ResourceDictionary
    {
        public Resources()
        {
            InitializeComponent();
        }
    }
}