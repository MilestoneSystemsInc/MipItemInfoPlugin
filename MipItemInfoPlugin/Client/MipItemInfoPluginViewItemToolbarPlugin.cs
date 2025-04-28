using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using VideoOS.Platform;
using VideoOS.Platform.Client;
using VideoOS.Platform.ConfigurationItems;

namespace MipItemInfoPlugin.Client
{
    internal class MipItemInfoPluginViewItemToolbarPluginInstance : ViewItemToolbarPluginInstance
    {
        private Item _viewItemInstance;

        public override void Init(Item viewItemInstance, Item window)
        {
            _viewItemInstance = viewItemInstance;

            Title = "Camera Info";
            Tooltip = "Show camera info";
            Icon = Properties.Resources.CameraInfo;
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

            MessageBox.Show(sb.ToString(), "Camera Info");
        }

        public override void Close()
        {
        }
    }

    internal class MipItemInfoPluginViewItemToolbarPlugin : ViewItemToolbarPlugin
    {
        public override Guid Id => MipItemInfoPluginDefinition.MipItemInfoPluginViewItemToolbarPluginId;

        public override string Name => "Camera Info Plugin";

        

        public override ToolbarPluginOverflowMode ToolbarPluginOverflowMode => ToolbarPluginOverflowMode.AsNeeded;

        public override void Init()
        {
            ViewItemToolbarPlaceDefinition.ViewItemIds = new List<Guid> { ViewAndLayoutItem.CameraBuiltinId };
            ViewItemToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>();
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
