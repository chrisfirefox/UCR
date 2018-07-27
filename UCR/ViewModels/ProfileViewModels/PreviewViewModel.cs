using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Properties;
using HidWizards.UCR.Utilities.Previews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HidWizards.UCR.ViewModels.ProfileViewModels
{
    public class PreviewViewModel
    {
        public ObservableCollection<BasePreview> Previews { get; set; }

        private Plugin _plugin;
        public Plugin Plugin { get { return _plugin; }
            set
            {
                _plugin = value;
                _plugin.OnPreviewUpdate = PreviewUpdate;
            }
        }

        public PreviewViewModel( Plugin p ) {
            Plugin = p;
            InitializePreviews();
        }

        private void InitializePreviews() {
            Previews = new ObservableCollection<BasePreview>();
            for( var i = 0; i < Plugin.InputCategories.Count; i++ ) {
                BasePreview bp = BasePreview.Factory( Plugin.InputCategories[i] );
                bp.iotype = BasePreview.IOType.Input;
                bp.which = (uint) i;
                Previews.Add( bp );
            }
            for( var i = 0; i < Plugin.OutputCategories.Count; i++ ) {
                BasePreview bp = BasePreview.Factory( Plugin.OutputCategories[i] );
                bp.iotype = BasePreview.IOType.Output;
                bp.which = (uint)i;
                Previews.Add( bp );
            }
        }

        private void PreviewUpdate( long[] invals, long[] outvals ) {
            foreach( BasePreview bp in Previews )
                bp.UpdateValues( invals, outvals );
        }
    }
}
