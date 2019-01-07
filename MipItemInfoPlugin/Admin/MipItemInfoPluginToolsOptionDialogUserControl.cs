using VideoOS.Platform.Admin;

namespace MipItemInfoPlugin.Admin
{
    public partial class MipItemInfoPluginToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public MipItemInfoPluginToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
