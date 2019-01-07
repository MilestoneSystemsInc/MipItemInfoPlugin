using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using VideoOS.Platform;
using VideoOS.Platform.Client;
using VideoOS.Platform.ConfigurationItems;

namespace MipItemInfoPlugin.Client
{
    class MipItemInfoPluginViewItemToolbarPluginInstance : ViewItemToolbarPluginInstance
    {
        private Item _viewItemInstance;
        private Item _window;

        public override void Init(Item viewItemInstance, Item window)
        {
            _viewItemInstance = viewItemInstance;
            _window = window;

            Title = "Show Info";
            Tooltip = "Show item info";
        }

        public override void Activate()
        {
            if (!_viewItemInstance.Properties.ContainsKey("CameraId")) return;
            var item = Configuration.Instance.GetItem(new Guid(_viewItemInstance.Properties["CameraId"]), Kind.Camera);
            if (item == null) return;

            var camera = new Camera(item.FQID);
            var hardware = new Hardware(camera.ServerId, camera.ParentItemPath);
            var recorder = new RecordingServer(hardware.ServerId, hardware.ParentItemPath);
            var ms = new ManagementServer(recorder.ServerId);
            var sb = new StringBuilder();
            sb.AppendLine($"Camera: {camera.Name}");
            sb.AppendLine($"Hardware: {hardware.Name}");
            sb.AppendLine($"NVR: {recorder.Name}");
            sb.AppendLine($"Management Server: {ms.Name}");

            MessageBox.Show(sb.ToString());
        }

        private string GetRecordingServer(Item viewItemInstance)
        {
            return viewItemInstance.Name;
        }

        public override void Close()
        {
        }
    }

    class MipItemInfoPluginViewItemToolbarPlugin : ViewItemToolbarPlugin
    {
        public override Guid Id
        {
            get { return MipItemInfoPluginDefinition.MipItemInfoPluginViewItemToolbarPluginId; }
        }

        public override string Name
        {
            get { return "MipItemInfoPlugin"; }
        }

        public override ToolbarPluginOverflowMode ToolbarPluginOverflowMode
        {
            get { return ToolbarPluginOverflowMode.AsNeeded; }
        }

        public override void Init()
        {
            // TODO: remove below check when MipItemInfoPluginDefinition.MipItemInfoPluginViewItemToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("33333333-3333-3333-3333-333333333333"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for MipItemInfoPluginViewItemToolbarPluginId!");
            }

            ViewItemToolbarPlaceDefinition.ViewItemIds = new List<Guid>() { ViewAndLayoutItem.CameraBuiltinId };
            ViewItemToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, MipItemInfoPluginDefinition.MipItemInfoPluginWorkSpacePluginId };
            ViewItemToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override ViewItemToolbarPluginInstance GenerateViewItemToolbarPluginInstance()
        {
            return new MipItemInfoPluginViewItemToolbarPluginInstance();
        }
    }
}
