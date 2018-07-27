using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidWizards.UCR.Utilities.Previews
{
    public class MomentaryPreview : BasePreview
    {
        bool _active;

        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }

        public override void UpdateValues( long[] input, long[] output ) {
            if( iotype == IOType.Input )
                Active = (input[which] == 1);
            else
                Active = (output[which] == 1);
        }
    }
}
