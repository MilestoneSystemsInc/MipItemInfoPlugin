using System;
using VideoOS.Platform.Client;

namespace MipItemInfoPlugin.Client
{
    /// <summary>
    /// Interaction logic for MipItemInfoPluginWorkSpaceViewItemWpfUserControl.xaml
    /// </summary>
    public partial class MipItemInfoPluginWorkSpaceViewItemWpfUserControl : ViewItemWpfUserControl
    {
        public MipItemInfoPluginWorkSpaceViewItemWpfUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        /// <summary>
        /// Do not show the sliding toolbar!
        /// </summary>
        public override bool ShowToolbar
        {
            get { return false; }
        }

        private void ViewItemWpfUserControl_ClickEvent(object sender, EventArgs e)
        {
            FireClickEvent();
        }

        private void ViewItemWpfUserControl_DoubleClickEvent(object sender, EventArgs e)
        {
            FireDoubleClickEvent();
        }
    }
}
