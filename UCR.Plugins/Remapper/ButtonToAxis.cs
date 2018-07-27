using HidWizards.UCR.Core.Attributes;
using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Core.Models.Binding;
using HidWizards.UCR.Core.Utilities;

namespace HidWizards.UCR.Plugins.Remapper
{
    [Plugin("Button to axis")]
    [PluginInput(DeviceBindingCategory.Momentary, "Button")]
    [PluginOutput(DeviceBindingCategory.Range, "Axis")]
    public class ButtonToAxis : Plugin
    {
        [PluginGui("Invert", ColumnOrder = 0)]
        public bool Invert { get; set; }

        [PluginGui("Range target", ColumnOrder = 1)]
        public int Range { get; set; }

        public ButtonToAxis()
        {
            Range = 100;
        }

        public override void Update(params long[] values)
        {
            var outval = values[0];
            if (Invert) outval *= -1;
            outval *= (long)(Constants.AxisMaxValue * (Range / 100.0));
            WriteOutput(0, outval);
            OnPreviewUpdate?.Invoke( values, new long[] { outval } );
        }
    }
}
