using HidWizards.UCR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HidWizards.UCR.Views.Controls
{
    public class PluginPreviewTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate( object item, DependencyObject container ) {
            var element = container as FrameworkElement;
            if( element == null ) return null;
            return element.FindResource( item.GetType().Name ) as DataTemplate;
        }
    }
}
