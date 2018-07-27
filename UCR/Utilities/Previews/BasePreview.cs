using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HidWizards.UCR.Utilities.Previews
{
    public abstract class BasePreview : INotifyPropertyChanged
    {
        public enum IOType { Input, Output };
        public IOType iotype { get; set; }
        public uint which { get; set; }

        public string Name { get { return "Preview"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null ) {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        public abstract void UpdateValues( long[] input, long[] output );

        public static BasePreview Factory( Plugin.IODefinition iodef ) {
            if( iodef.Category == Core.Models.Binding.DeviceBindingCategory.Momentary )
                return new MomentaryPreview();
            if( iodef.Category == Core.Models.Binding.DeviceBindingCategory.Range )
                return new RangePreview();
            if( iodef.Category == Core.Models.Binding.DeviceBindingCategory.Delta )
                return new DeltaPreview();

            return null;
        }
    }
}
