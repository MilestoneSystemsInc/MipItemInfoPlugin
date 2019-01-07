using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace MipItemInfoPlugin.Client
{
    class MipItemInfoPluginWorkSpaceToolbarPluginInstance : WorkSpaceToolbarPluginInstance
    {
        private Item _window;

        public MipItemInfoPluginWorkSpaceToolbarPluginInstance()
        {
        }

        public override void Init(Item window)
        {
            _window = window;

            Title = "MipItemInfoPlugin";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }

    }

    class MipItemInfoPluginWorkSpaceToolbarPlugin : WorkSpaceToolbarPlugin
    {
        public MipItemInfoPluginWorkSpaceToolbarPlugin()
        {
        }

        public override Guid Id
        {
            get { return MipItemInfoPluginDefinition.MipItemInfoPluginWorkSpaceToolbarPluginId; }
        }

        public override string Name
        {
            get { return "MipItemInfoPlugin"; }
        }

        public override void Init()
        {
            // TODO: remove below check when MipItemInfoPluginDefinition.MipItemInfoPluginWorkSpaceToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("22222222-2222-2222-2222-222222222222"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for MipItemInfoPluginWorkSpaceToolbarPluginId!");
            }

            WorkSpaceToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, MipItemInfoPluginDefinition.MipItemInfoPluginWorkSpacePluginId };
            WorkSpaceToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override WorkSpaceToolbarPluginInstance GenerateWorkSpaceToolbarPluginInstance()
        {
            return new MipItemInfoPluginWorkSpaceToolbarPluginInstance();
        }
    }
}
