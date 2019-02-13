using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;
using Vape.BLL.Interfaces;
using VapeApp.WEB.Models;

namespace VapeApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home       

           private IUserService UserService
           {
               get
               {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
               }
           }
            IOrderService orderService;
            public HomeController(IOrderService serv)
            {
                orderService = serv;
            }
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult MakeOrderFullVape(int? id)
            {
                try
                {
                    FullVapeDTO fullVape = orderService.GetFullVape(id);
                    Mapper.Initialize(cfg => cfg.CreateMap<FullVapeDTO, OrderViewModel>()
                        .ForMember("FullVapeId", opt => opt.MapFrom(src => src.Id)));
                    var order = Mapper.Map<FullVapeDTO, OrderViewModel>(fullVape);
                    return View(order);
                }
                catch (ValidationException ex)
                {
                    return Content(ex.Message);
                }
            }
            [HttpPost]
            public ActionResult MakeOrderFullVape(OrderViewModel order)
            {
                try
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
                    var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
                    orderService.MakeOrderFullVape(orderDto);
                    return Content("<h2>Ваш заказ успешно оформлен</h2>");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
                return View(order);
            }
            protected override void Dispose(bool disposing)
            {
                orderService.Dispose();
                base.Dispose(disposing);
            }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
    }