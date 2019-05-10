using DevExpress.XtraBars;
using DevExpress.XtraMap;
using System;
using System.Data;
using System.Windows.Forms;

namespace MapApplication
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            SetShapeData();
            SetChartData();
        }
        void SetChartData()
        {
            pieChartDataAdapter1.DataSource = LoadDataFromXml(GetRelativePath("EuropeEnergyStatictics.xml"));
        }
        void SetShapeData()
        {
            shapefileDataAdapter1.FileUri = new Uri(GetRelativePath("Countries.shp"));
        }
        DataTable LoadDataFromXml(string path)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            DataTable table = ds.Tables[0];
            return table;
        }
        void bbiInitialView_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapControl1.ZoomLevel = 3.0;
            mapControl1.CenterPoint = new GeoPoint(50, -7);
        }
        void bbiZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapControl1.ZoomOut();
        }
        void bbiZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapControl1.ZoomIn();
        }
        void chkLockNavigation_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            mapControl1.EnableScrolling = !mapControl1.EnableScrolling;
            mapControl1.EnableZooming = !mapControl1.EnableZooming;
            bbiZoomIn.Enabled = mapControl1.EnableZooming;
            bbiZoomOut.Enabled = mapControl1.EnableZooming;
        }
        void chkShowNavPanel_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            mapControl1.NavigationPanelOptions.Visible = !mapControl1.NavigationPanelOptions.Visible;
        }
        void chkShowMiniMap_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            mapControl1.MiniMap.Visible = !mapControl1.MiniMap.Visible;
        }
        void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (mapControl1.Legends.Count > 0)
            {
                if (mapControl1.Legends[0].Visibility == VisibilityMode.Auto)
                    mapControl1.Legends[0].Visibility = VisibilityMode.Hidden;
                else
                    mapControl1.Legends[0].Visibility = VisibilityMode.Auto;
            }
        }

        static string GetRelativePath(string name)
        {
            name = "Data\\" + name;
            string path = Application.StartupPath;
            string s = "\\";
            for (int i = 0; i <= 10; i++)
            {
                if (System.IO.File.Exists(path + s + name))
                    return (path + s + name);
                else
                    s += "..\\";
            }
            return "";
        }
    }
}
