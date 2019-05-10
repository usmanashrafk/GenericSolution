namespace MapApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraMap.KeyColorColorizer keyColorColorizer1 = new DevExpress.XtraMap.KeyColorColorizer();
            DevExpress.XtraMap.ArgumentItemKeyProvider argumentItemKeyProvider1 = new DevExpress.XtraMap.ArgumentItemKeyProvider();
            DevExpress.XtraMap.ColorizerKeyItem colorizerKeyItem1 = new DevExpress.XtraMap.ColorizerKeyItem();
            DevExpress.XtraMap.ColorizerKeyItem colorizerKeyItem2 = new DevExpress.XtraMap.ColorizerKeyItem();
            DevExpress.XtraMap.ColorizerKeyItem colorizerKeyItem3 = new DevExpress.XtraMap.ColorizerKeyItem();
            DevExpress.XtraMap.ColorizerKeyItem colorizerKeyItem4 = new DevExpress.XtraMap.ColorizerKeyItem();
            DevExpress.XtraMap.ColorizerKeyItem colorizerKeyItem5 = new DevExpress.XtraMap.ColorizerKeyItem();
            DevExpress.XtraMap.MapItemAttributeMapping mapItemAttributeMapping1 = new DevExpress.XtraMap.MapItemAttributeMapping();
            DevExpress.XtraMap.MeasureRules measureRules1 = new DevExpress.XtraMap.MeasureRules();
            DevExpress.XtraMap.LinearRangeDistribution linearRangeDistribution1 = new DevExpress.XtraMap.LinearRangeDistribution();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraMap.ColorListLegend colorListLegend1 = new DevExpress.XtraMap.ColorListLegend();
            DevExpress.XtraMap.MiniMap miniMap1 = new DevExpress.XtraMap.MiniMap();
            DevExpress.XtraMap.DynamicMiniMapBehavior dynamicMiniMapBehavior1 = new DevExpress.XtraMap.DynamicMiniMapBehavior();
            this.vectorItemsLayer2 = new DevExpress.XtraMap.VectorItemsLayer();
            this.pieChartDataAdapter1 = new DevExpress.XtraMap.PieChartDataAdapter();
            this.miniMapImageTilesLayer1 = new DevExpress.XtraMap.MiniMapImageTilesLayer();
            this.openStreetMapDataProvider1 = new DevExpress.XtraMap.OpenStreetMapDataProvider();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.chkMiniMap = new DevExpress.XtraBars.BarCheckItem();
            this.chkShowNavPanel = new DevExpress.XtraBars.BarCheckItem();
            this.chkNavigation = new DevExpress.XtraBars.BarCheckItem();
            this.bbiZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInitialView = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            this.shapefileDataAdapter1 = new DevExpress.XtraMap.ShapefileDataAdapter();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            this.SuspendLayout();
            keyColorColorizer1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(93)))), ((int)(((byte)(106))))));
            keyColorColorizer1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(124)))), ((int)(((byte)(217))))));
            keyColorColorizer1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(116))))));
            keyColorColorizer1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(191)))), ((int)(((byte)(88))))));
            keyColorColorizer1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(104)))), ((int)(((byte)(195))))));
            keyColorColorizer1.ItemKeyProvider = argumentItemKeyProvider1;
            colorizerKeyItem1.Key = "Gases";
            colorizerKeyItem1.Name = "Gases";
            colorizerKeyItem2.Key = "Nuclear";
            colorizerKeyItem2.Name = "Nuclear";
            colorizerKeyItem3.Key = "Petroleum Products";
            colorizerKeyItem3.Name = "Petroleum Products";
            colorizerKeyItem4.Key = "Renewables";
            colorizerKeyItem4.Name = "Renewables";
            colorizerKeyItem5.Key = "Solid Fuels";
            colorizerKeyItem5.Name = "Solid Fuels";
            keyColorColorizer1.Keys.Add(colorizerKeyItem1);
            keyColorColorizer1.Keys.Add(colorizerKeyItem2);
            keyColorColorizer1.Keys.Add(colorizerKeyItem3);
            keyColorColorizer1.Keys.Add(colorizerKeyItem4);
            keyColorColorizer1.Keys.Add(colorizerKeyItem5);
            this.vectorItemsLayer2.Colorizer = keyColorColorizer1;
            this.vectorItemsLayer2.Data = this.pieChartDataAdapter1;
            this.vectorItemsLayer2.Name = "ChartLayer";
            this.vectorItemsLayer2.ToolTipPattern = "{Country}\n\n%A0%: %V0:n2%\n%A1%: %V1:n2%\n%A2%: %V2:n2%\n%A3%: %V3:n2%\n%A4%: %V4:n2%";
            mapItemAttributeMapping1.Member = "Country";
            mapItemAttributeMapping1.Name = "Country";
            mapItemAttributeMapping1.ValueType = DevExpress.XtraMap.FieldValueType.String;
            this.pieChartDataAdapter1.AttributeMappings.Add(mapItemAttributeMapping1);
            this.pieChartDataAdapter1.ItemMaxSize = 25;
            this.pieChartDataAdapter1.Mappings.PieSegment = "EnergyType";
            this.pieChartDataAdapter1.Mappings.Value = "Production";
            this.pieChartDataAdapter1.Mappings.XCoordinate = "Longitude";
            this.pieChartDataAdapter1.Mappings.YCoordinate = "Latitude";
            measureRules1.RangeDistribution = linearRangeDistribution1;
            measureRules1.RangeStops.Add(1D);
            measureRules1.RangeStops.Add(10D);
            measureRules1.RangeStops.Add(25D);
            measureRules1.RangeStops.Add(50D);
            measureRules1.RangeStops.Add(100D);
            measureRules1.RangeStops.Add(150D);
            this.pieChartDataAdapter1.MeasureRules = measureRules1;
            this.pieChartDataAdapter1.PieItemDataMember = "Country";
            this.miniMapImageTilesLayer1.DataProvider = this.openStreetMapDataProvider1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.chkMiniMap,
            this.chkShowNavPanel,
            this.chkNavigation,
            this.bbiZoomIn,
            this.bbiZoomOut,
            this.bbiInitialView,
            this.barCheckItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1101, 143);
            // 
            // chkMiniMap
            // 
            this.chkMiniMap.Caption = "Show Minimap";
            this.chkMiniMap.Id = 1;
            this.chkMiniMap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkMiniMap.ImageOptions.Image")));
            this.chkMiniMap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkMiniMap.ImageOptions.LargeImage")));
            this.chkMiniMap.Name = "chkMiniMap";
            this.chkMiniMap.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowMiniMap_CheckedChanged);
            // 
            // chkShowNavPanel
            // 
            this.chkShowNavPanel.BindableChecked = true;
            this.chkShowNavPanel.Caption = "Show Navigation Panel";
            this.chkShowNavPanel.Checked = true;
            this.chkShowNavPanel.Id = 2;
            this.chkShowNavPanel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkShowNavPanel.ImageOptions.Image")));
            this.chkShowNavPanel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkShowNavPanel.ImageOptions.LargeImage")));
            this.chkShowNavPanel.Name = "chkShowNavPanel";
            this.chkShowNavPanel.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowNavPanel_CheckedChanged);
            // 
            // chkNavigation
            // 
            this.chkNavigation.Caption = "Lock Navigation";
            this.chkNavigation.Id = 3;
            this.chkNavigation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkNavigation.ImageOptions.Image")));
            this.chkNavigation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkNavigation.ImageOptions.LargeImage")));
            this.chkNavigation.Name = "chkNavigation";
            this.chkNavigation.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLockNavigation_CheckedChanged);
            // 
            // bbiZoomIn
            // 
            this.bbiZoomIn.Caption = "Zoom In";
            this.bbiZoomIn.Id = 4;
            this.bbiZoomIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiZoomIn.ImageOptions.Image")));
            this.bbiZoomIn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiZoomIn.ImageOptions.LargeImage")));
            this.bbiZoomIn.Name = "bbiZoomIn";
            this.bbiZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomIn_ItemClick);
            // 
            // bbiZoomOut
            // 
            this.bbiZoomOut.Caption = "Zoom Out";
            this.bbiZoomOut.Id = 5;
            this.bbiZoomOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiZoomOut.ImageOptions.Image")));
            this.bbiZoomOut.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiZoomOut.ImageOptions.LargeImage")));
            this.bbiZoomOut.Name = "bbiZoomOut";
            this.bbiZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomOut_ItemClick);
            // 
            // bbiInitialView
            // 
            this.bbiInitialView.Caption = "Initial View";
            this.bbiInitialView.Id = 6;
            this.bbiInitialView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiInitialView.ImageOptions.Image")));
            this.bbiInitialView.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiInitialView.ImageOptions.LargeImage")));
            this.bbiInitialView.Name = "bbiInitialView";
            this.bbiInitialView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInitialView_ItemClick);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.BindableChecked = true;
            this.barCheckItem1.Caption = "Legend";
            this.barCheckItem1.Checked = true;
            this.barCheckItem1.Id = 6;
            this.barCheckItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCheckItem1.ImageOptions.Image")));
            this.barCheckItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCheckItem1.ImageOptions.LargeImage")));
            this.barCheckItem1.Name = "barCheckItem1";
            this.barCheckItem1.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Options";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiInitialView);
            this.ribbonPageGroup2.ItemLinks.Add(this.chkShowNavPanel);
            this.ribbonPageGroup2.ItemLinks.Add(this.chkNavigation);
            this.ribbonPageGroup2.ItemLinks.Add(this.chkMiniMap);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiZoomIn);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiZoomOut);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "View";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // mapControl1
            // 
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(50D, -7D);
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Layers.Add(this.vectorItemsLayer1);
            this.mapControl1.Layers.Add(this.vectorItemsLayer2);
            colorListLegend1.Header = "Europe energy production";
            colorListLegend1.Layer = this.vectorItemsLayer2;
            this.mapControl1.Legends.Add(colorListLegend1);
            this.mapControl1.Location = new System.Drawing.Point(0, 143);
            miniMap1.Alignment = DevExpress.XtraMap.MiniMapAlignment.BottomRight;
            miniMap1.Behavior = dynamicMiniMapBehavior1;
            miniMap1.Layers.Add(this.miniMapImageTilesLayer1);
            miniMap1.Visible = false;
            this.mapControl1.MiniMap = miniMap1;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(1101, 580);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.ZoomLevel = 3D;
            this.vectorItemsLayer1.Data = this.shapefileDataAdapter1;
            this.vectorItemsLayer1.EnableHighlighting = false;
            this.vectorItemsLayer1.EnableSelection = false;
            this.vectorItemsLayer1.Name = "ShapeLayer";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 723);
            this.Controls.Add(this.mapControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Map project";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraMap.MapControl mapControl1;
        private DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1;
        private DevExpress.XtraMap.ShapefileDataAdapter shapefileDataAdapter1;
        private DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer2;
        private DevExpress.XtraMap.PieChartDataAdapter pieChartDataAdapter1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;

        private DevExpress.XtraBars.BarCheckItem chkShowNavPanel;
        private DevExpress.XtraBars.BarCheckItem chkNavigation;
        private DevExpress.XtraBars.BarCheckItem chkMiniMap;
        private DevExpress.XtraBars.BarButtonItem bbiZoomIn;
        private DevExpress.XtraBars.BarButtonItem bbiZoomOut;
        private DevExpress.XtraBars.BarButtonItem bbiInitialView;
        private DevExpress.XtraMap.MiniMapImageTilesLayer miniMapImageTilesLayer1;
        private DevExpress.XtraMap.OpenStreetMapDataProvider openStreetMapDataProvider1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}

