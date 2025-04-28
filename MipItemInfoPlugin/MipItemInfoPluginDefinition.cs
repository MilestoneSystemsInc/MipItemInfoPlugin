using MipItemInfoPlugin.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using VideoOS.Platform;
using VideoOS.Platform.Admin;
using VideoOS.Platform.Background;
using VideoOS.Platform.Client;

namespace MipItemInfoPlugin
{
    public class MipItemInfoPluginDefinition : PluginDefinition
    {
        private static readonly Image TopTreeNodeImage;

        internal static Guid MipItemInfoPluginPluginId = new Guid("4c0e5a9e-93a4-4e9e-93ff-371d9c975aba");
        internal static Guid MipItemInfoPluginKind = new Guid("c8326bcd-522d-4521-ab8c-5beec0b71188");
        internal static Guid MipItemInfoPluginViewItemToolbarPluginId = new Guid("591ffdd4-cbfb-49fb-b20e-c737b1a1dbe4");

        #region Private fields

        private readonly List<BackgroundPlugin> _backgroundPlugins = new List<BackgroundPlugin>();
        private readonly List<ViewItemPlugin> _viewItemPlugins = new List<ViewItemPlugin>();
        private readonly List<ItemNode> _itemNodes = new List<ItemNode>();
        private readonly List<SidePanelPlugin> _sidePanelPlugins = new List<SidePanelPlugin>();
        private readonly List<SecurityAction> _securityActions = new List<SecurityAction>();
        private readonly List<WorkSpacePlugin> _workSpacePlugins = new List<WorkSpacePlugin>();
        private readonly List<ViewItemToolbarPlugin> _viewItemToolbarPlugins = new List<ViewItemToolbarPlugin>();
        private readonly List<WorkSpaceToolbarPlugin> _workSpaceToolbarPlugins = new List<WorkSpaceToolbarPlugin>();
        private readonly List<ViewLayout> _viewLayouts = new List<ViewLayout>();
        private readonly List<ToolsOptionsDialogPlugin> _toolsOptionsDialogPlugins = new List<ToolsOptionsDialogPlugin>();

        #endregion

        #region Initialization

        static MipItemInfoPluginDefinition()
        {
            TreeNodeImage = Properties.Resources.DummyItem;
            TopTreeNodeImage = Properties.Resources.Server;
        }

        internal static Image TreeNodeImage { get; private set; }

        #endregion

        public override void Init()
        {
            _itemNodes.Add(new ItemNode(MipItemInfoPluginKind, Guid.Empty,
                                         "CameraInfoPlugin", TreeNodeImage,
                                         "CameraInfoPlugins", TreeNodeImage,
                                         Category.Text, true,
                                         ItemsAllowed.Many,
                                         null,
                                         null
                                         ));
            if (EnvironmentManager.Instance.EnvironmentType == EnvironmentType.SmartClient)
            {
                _viewItemToolbarPlugins.Add(new MipItemInfoPluginViewItemToolbarPlugin());
            }

        }

        public override void Close()
        {
            _itemNodes.Clear();
            _sidePanelPlugins.Clear();
            _viewItemPlugins.Clear();
            _backgroundPlugins.Clear();
            _workSpacePlugins.Clear();
            _viewItemToolbarPlugins.Clear();
            _workSpaceToolbarPlugins.Clear();
            _toolsOptionsDialogPlugins.Clear();
        }

        public override List<string> PluginDefinedMessageIds => new List<string>();

        public override List<SecurityAction> SecurityActions
        {
            get => _securityActions;
            set
            {
            }
        }

        #region Identification Properties

        public override Guid Id => MipItemInfoPluginPluginId;

        public override Guid SharedNodeId => Guid.Empty;

        public override string Name => "Camera Info Plugin";

        public override string Manufacturer => "Milestone Systems";

        public override string VersionString => ThisAssembly.AssemblyFileVersion;

        public override Image Icon => TopTreeNodeImage;

        #endregion


        #region Administration properties

        public override List<ItemNode> ItemNodes => _itemNodes;

        public override List<ToolsOptionsDialogPlugin> ToolsOptionsDialogPlugins => _toolsOptionsDialogPlugins;

        public override bool UserControlFillEntirePanel => false;

        #endregion

        #region Client related methods and properties

        public override List<ViewItemPlugin> ViewItemPlugins => _viewItemPlugins;

        public override List<SidePanelPlugin> SidePanelPlugins => _sidePanelPlugins;

        public override List<WorkSpacePlugin> WorkSpacePlugins => _workSpacePlugins;

        public override List<ViewItemToolbarPlugin> ViewItemToolbarPlugins => _viewItemToolbarPlugins;

        public override List<WorkSpaceToolbarPlugin> WorkSpaceToolbarPlugins => _workSpaceToolbarPlugins;

        public override List<ViewLayout> ViewLayouts => _viewLayouts;

        #endregion

        public override List<BackgroundPlugin> BackgroundPlugins => _backgroundPlugins;
    }
}
