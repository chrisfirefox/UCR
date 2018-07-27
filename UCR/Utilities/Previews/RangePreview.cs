using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidWizards.UCR.Utilities.Previews
{
    public class RangePreview : BasePreview
    {
        long _val;

        public long Value
        {
            get { return _val; }
            set
            {
                _val = value;
                OnPropertyChanged();
            }
        }

        public override void UpdateValues( long[] input, long[] output ) {
            if( iotype == IOType.Input )
                Value = input[which];
            else
                Value = output[which];
        }
    }
}
