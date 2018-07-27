using HidWizards.UCR.Core.Attributes;
using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Core.Models.Binding;

namespace HidWizards.UCR.Plugins.Remapper
{
    [Plugin("Button to button")]
    [PluginInput(DeviceBindingCategory.Momentary, "Button")]
    [PluginOutput(DeviceBindingCategory.Momentary, "Button")]
    public class ButtonToButton : Plugin
    {

        [PluginGui("Invert", ColumnOrder = 0, RowOrder = 0)]
        public bool Invert { get; set; }

        public override void Update( params long[] values )
        {
            long[] outval = new long[1];
            if (Invert)
            {
                outval[0] = values[0] == 0 ? 1 : 0;
            }
            else
            {
                outval[0] = values[0];
            }
            WriteOutput( 0, outval[0] );
            OnPreviewUpdate?.Invoke( values, outval );
        }
    }
}
