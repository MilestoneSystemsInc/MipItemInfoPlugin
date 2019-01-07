using VideoOS.Platform.Client;

namespace MipItemInfoPlugin.Client
{
    public class MipItemInfoPluginWorkSpaceViewItemManager : ViewItemManager
    {
        public MipItemInfoPluginWorkSpaceViewItemManager() : base("MipItemInfoPluginWorkSpaceViewItemManager")
        {
        }

        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            return new MipItemInfoPluginWorkSpaceViewItemWpfUserControl();
        }
    }
}
