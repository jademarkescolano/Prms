using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using StarbeeRealty.Server.Class;
using StarbeeRealty.Server.Services;
using StarbeeRealty.Shared;
using System.Data;

namespace StarbeeRealty.Server.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : Controller
    {
        PaymentServices xservices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PaymentController(PaymentServices xservices, IWebHostEnvironment webHostEnvironment)
        {
            this.xservices = xservices;
            _webHostEnvironment = webHostEnvironment;
        }

        //View Payments
        [HttpGet]
        //[Authorize]
        public async Task<List<payments>> Payments()
        {
            var ret = await xservices.Payments();
            return ret;
        }

        //Search Payments
        [HttpGet]
        //[Authorize]
        public async Task<List<payments>> SearchPayment(string search)
        {
            var ret = await xservices.SearchPayment(search);
            return ret;
        }


        //Add Payment
        [HttpPost]
        //[Authorize]
        public async Task<int> AddPayment([FromBody] payments _payments)
        {
            var ret = await xservices.AddPayment(_payments);
            return ret;
        }

        //Update Payment
        [HttpPost]
        //[Authorize]
        public async Task<int> UpdatePayment([FromBody] payments _payments)
        {
            var ret = await xservices.UpdatePayment(_payments);
            return ret;
        }

        //Summary Report
        [HttpGet]
        public async Task<IActionResult> Summary(string search)
        {
            ListtoTable listtoTable = new();
            var dt = new DataTable();
            var lst = await xservices.SearchPayment(search);
            dt = listtoTable.ToDataTablee(lst);
            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Summary", "SummaryReport.rdlc");
            Stream reportDefinition;
            using var fs = new FileStream(reportPath, FileMode.Open);
            reportDefinition = fs;
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(reportDefinition);
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            byte[] excel = report.Render("EXCEL");
            fs.Dispose();

            return File(excel, "application/msexcel", "Payment.xls");
        }
    }
}

