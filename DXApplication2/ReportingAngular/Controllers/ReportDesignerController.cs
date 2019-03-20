using DevExpress.Compatibility.System.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Mvc;

namespace ReportingAngular.Controllers {
    [Route("api/[controller]")]
    public class ReportDesignerController: Controller {
        [HttpPost("[action]")]
        public object GetReportDesignerModel(string reportUrl) {
            string modelJsonScript = new ReportDesignerClientSideModelGenerator(HttpContext.RequestServices).GetJsonModelScript(reportUrl, null, "/DXXRD", "/DXXRDV", "/DXXQB");
            return new JavaScriptSerializer().Deserialize<object>(modelJsonScript);
        }
    }
}