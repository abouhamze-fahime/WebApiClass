using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Day_IPG_Sample.App_Start;
using Day_IPG_Sample.DayContext.Models.Instalment;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.Controllers
{
    public class InstalmentController : ApiController
    {
        [DayAuthorize]
        [HttpGet]
        [Route("api/instalment/get")]
        public List<InstalmentViewModel> GetInstalments(int insuranceNumber)
        {
            if (insuranceNumber <= 0)
            {
                throw new Exception("Invalid data");
            }
            List<Instalments> instalments;
            using (var ctx = new DayContext.DayContext())
            {
                instalments = ctx.Instalments.Where(x =>
                        x.NationalCode == HttpContext.Current.User.Identity.Name &&
                        x.InsuranceNumber == insuranceNumber)
                    .ToList();
            }

            //Instalment MAP InstalmentViewModel ===> MAPPER AutoMapper
            List<InstalmentViewModel> result = new List<InstalmentViewModel>();
            foreach (var item in instalments)
            {
                result.Add(new InstalmentViewModel()
                {
                    Id = item.Id,
                    Price = item.Price,
                    DueDate = item.DueDate
                });
            }

            return result;
        }

        [DayAuthorize]
        [HttpPost]
        [Route("api/instalment/set-log")]
        public IHttpActionResult SetPaymentLog(InstalmentpaymentLogViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.TrackCode.Trim()) || vm.Price <= 0 || vm.InstalmentId <= 0)
            {
                throw new Exception("Invalid data");
            }

            using (var ctx = new DayContext.DayContext())
            {
                ctx.InstalmentPaymentLogs.Add(new InstalmentPaymentLogs()
                {
                    InstalmentId = vm.InstalmentId,
                    Status = true,
                    TrackCode = vm.TrackCode
                });
                try
                {
                    ctx.SaveChanges();
                    return Ok();

                }
                catch
                {
                    return BadRequest();
                }
            }
        }
    }
}