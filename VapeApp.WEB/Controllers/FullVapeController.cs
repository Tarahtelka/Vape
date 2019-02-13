using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;
using Vape.BLL.Interfaces;
using VapeApp.WEB.Models;
using System.Web.Helpers;
using System.IO;

namespace VapeApp.WEB.Controllers
{
    public class FullVapeController : Controller
    {
        // GET: FullVape
        IOrderService orderService;
        IImageService imageService;
        public FullVapeController(IOrderService serv, IImageService imageserv)
        {
            orderService = serv;
            imageService = imageserv;
        }

        public ActionResult Admin()
        {
            IEnumerable<FullVapeDTO> fullVapeDtos = orderService.GetFullVapes();
            Mapper.Initialize(cfg => cfg.CreateMap<FullVapeDTO, FullVapeViewModel>());
            var fullvape = Mapper.Map<IEnumerable<FullVapeDTO>, List<FullVapeViewModel>>(fullVapeDtos);

            return View(fullvape);
        }

        public ActionResult DeleteFullVape()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteFullVape(int id)
        {

            orderService.DeleteFullVape(id);
            return View("View");
        }

        public ActionResult DeleteImgFullVape()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImgFullVape(int id)
        {

            imageService.DeleteImgFullVape(id);
            return View("View");
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FullVapeViewModel fullVapeViewModel)
        {
            
            if (ModelState.IsValid)
            {
                FullVapeDTO fullVapeDto = new FullVapeDTO
                {

                    Name = fullVapeViewModel.Name,
                    Company = fullVapeViewModel.Company,
                    Accumulator = fullVapeViewModel.Accumulator,
                    Brand = fullVapeViewModel.Brand,
                    Amount = fullVapeViewModel.Amount,
                    Contry = fullVapeViewModel.Contry,
                    Outturn = fullVapeViewModel.Outturn,
                    Price = fullVapeViewModel.Price,
                };
                orderService.AddFullVape(fullVapeDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Update(int id)
        {
            FullVapeDTO fullVapeDto = orderService.GetFullVape(id);
            Mapper.Initialize(cfg => cfg.CreateMap<FullVapeDTO, FullVapeViewModel>());
            var fullvape = Mapper.Map<FullVapeDTO, FullVapeViewModel>(fullVapeDto);
            return View(fullvape);
        }

        [HttpPost]
        public ActionResult Update(FullVapeViewModel fullVapeViewModel)
        {

            if (ModelState.IsValid)
            {
                FullVapeDTO fullVapeDto = new FullVapeDTO
                {
                    Id = fullVapeViewModel.Id,
                    Name = fullVapeViewModel.Name,
                    Company = fullVapeViewModel.Company,
                    Accumulator = fullVapeViewModel.Accumulator,
                    Brand = fullVapeViewModel.Brand,
                    Amount = fullVapeViewModel.Amount,
                    Contry = fullVapeViewModel.Contry,
                    Outturn = fullVapeViewModel.Outturn,
                    Price = fullVapeViewModel.Price,
                };
                orderService.UpdateFullVape(fullVapeDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }


        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadImage, int id)
        {
            FullVapeDTO fullVapeDto = imageService.GetFullVape(id);//?

            if (ModelState.IsValid && fullVapeDto!=null)
            {            
                    ImageDTO image = new ImageDTO
                    {
                        FullVapeId = id,
                        MimeType = uploadImage.ContentType,
                    };
                    image.Data = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(image.Data, 0, uploadImage.ContentLength);
                    imageService.Add(image);
                
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Index()
        {
            IEnumerable<FullVapeDTO> fullVapeDtos = orderService.GetFullVapes();
            Mapper.Initialize(cfg => cfg.CreateMap<FullVapeDTO, FullVapeViewModel>());
            var fullvape = Mapper.Map<IEnumerable<FullVapeDTO>, List<FullVapeViewModel>>(fullVapeDtos);
            
            return View(fullvape);
        }

        public ActionResult GetImgFullVape(int id)
        {
            IEnumerable<ImageDTO> imageDTO = imageService.GetImgFullVapes(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDTO, ImageViewModel>());
            var img = Mapper.Map<IEnumerable<ImageDTO>, List<ImageViewModel>>(imageDTO);
            return View(img);
        }

        public ActionResult GetImgFullVapeAdmin(int id)
        {
            IEnumerable<ImageDTO> imageDTO = imageService.GetImgFullVapes(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDTO, ImageViewModel>());
            var img = Mapper.Map<IEnumerable<ImageDTO>, List<ImageViewModel>>(imageDTO);
            return View(img);
        }

        public FileResult GetFile(int id)
        {
            ImageDTO imgDto = imageService.GetImg(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDTO, ImageViewModel>());
            var img = Mapper.Map<ImageDTO, ImageViewModel>(imgDto);
            return File(img.Data ,img.MimeType);
        }

        public ActionResult GetFullVape(int id)
        {
            FullVapeDTO fullVapeDto = orderService.GetFullVape(id);
            Mapper.Initialize(cfg => cfg.CreateMap<FullVapeDTO, FullVapeViewModel>());
            var fullvape = Mapper.Map<FullVapeDTO, FullVapeViewModel>(fullVapeDto);
            return View(fullvape);
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
    }
}