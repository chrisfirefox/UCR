﻿using System.Windows;
using System.Windows.Controls;

namespace HidWizards.UCR.Views.Controls
{
    class PluginGroupViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PluginTemplate { get; set; }
        public Window Window { get; set; }

        public PluginGroupViewTemplateSelector()
        {
            Window = Application.Current.MainWindow;
        }
        
        //You override this function to select your data template based in the given item
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item == null) return PluginTemplate;
            PluginTemplate = (DataTemplate)Window.FindResource(item.GetType().Name);
            return PluginTemplate;
        }
    }
}
