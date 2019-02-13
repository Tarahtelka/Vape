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
using Vape.DAL.Entities;

namespace VapeApp.WEB.Controllers
{
    public class DripController : Controller
    {
        IOrderService orderService;
        IImageDripService imageDripService;
        public DripController(IOrderService serv, IImageDripService imageDripserv)
        {
            orderService = serv;
            imageDripService = imageDripserv;
        }

        public ActionResult Admin()
        {
            IEnumerable<DripDTO> dripDtos = orderService.GetDrips();
            Mapper.Initialize(cfg => cfg.CreateMap<DripDTO, DripViewModel>());
            var drip = Mapper.Map<IEnumerable<DripDTO>, List<DripViewModel>>(dripDtos);

            return View(drip);
        }

        public ActionResult DeleteDrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteDrip(int id)
        {

            orderService.DeleteDrip(id);
            return View("View");
        }

        public ActionResult DeleteImgDrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImgDrip(int id)
        {

            imageDripService.DeleteImgDrip(id);
            return View("View");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DripViewModel dripViewModel)
        {

            if (ModelState.IsValid)
            {
                DripDTO dripDto = new DripDTO
                {
                    Name = dripViewModel.Name,
                    Company = dripViewModel.Company,
                    Diameter = dripViewModel.Diameter,
                    Brand = dripViewModel.Brand,
                    Racks = dripViewModel.Racks,
                    Contry = dripViewModel.Contry,
                    Price = dripViewModel.Price,
                };
                orderService.AddDrip(dripDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Update(int id)
        {
            DripDTO dripDto = orderService.GetDrip(id);
            Mapper.Initialize(cfg => cfg.CreateMap<DripDTO, DripViewModel>());
            var drip = Mapper.Map<DripDTO, DripViewModel>(dripDto);
            return View(drip);
        }

        [HttpPost]
        public ActionResult Update(DripViewModel dripViewModel)
        {

            if (ModelState.IsValid)
            {
                DripDTO dripDto = new DripDTO
                {
                    Id = dripViewModel.Id,
                    Name = dripViewModel.Name,
                    Company = dripViewModel.Company,
                    Diameter = dripViewModel.Diameter,
                    Brand = dripViewModel.Brand,
                    Racks = dripViewModel.Racks,
                    Contry = dripViewModel.Contry,
                    Price = dripViewModel.Price,
                };
                orderService.UpdateDrip(dripDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Index()
        {
            IEnumerable<DripDTO> dripDtos = orderService.GetDrips();
            Mapper.Initialize(cfg => cfg.CreateMap<DripDTO, DripViewModel>());
            var drip = Mapper.Map<IEnumerable<DripDTO>, List<DripViewModel>>(dripDtos);
            return View(drip);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadImage, int id)
        {
            DripDTO dripDto = imageDripService.GetDrip(id);

            if (ModelState.IsValid && dripDto != null)
            {
                ImageDripDTO image = new ImageDripDTO
                {
                    DripId = id,
                    MimeType = uploadImage.ContentType,
                };
                image.Data = new byte[uploadImage.ContentLength];
                uploadImage.InputStream.Read(image.Data, 0, uploadImage.ContentLength);
                imageDripService.Add(image);

                return View("View");
            }
            else
            {
                return View("View1");
            }
        }


        public ActionResult GetImgDrip(int id)
        {
            IEnumerable<ImageDripDTO> imageDripDTO = imageDripService.GetImgDrips(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDripDTO, ImageDripViewModel>());
            var img = Mapper.Map<IEnumerable<ImageDripDTO>, List<ImageDripViewModel>>(imageDripDTO);
            return View(img);
        }

        public ActionResult GetImgDripAdmin(int id)
        {
            IEnumerable<ImageDripDTO> imageDripDTO = imageDripService.GetImgDrips(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDripDTO, ImageDripViewModel>());
            var img = Mapper.Map<IEnumerable<ImageDripDTO>, List<ImageDripViewModel>>(imageDripDTO);
            return View(img);
        }

        public FileResult GetFile(int id)
        {
            ImageDripDTO imgDripDto = imageDripService.GetImg(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDripDTO, ImageDripViewModel>());
            var img = Mapper.Map<ImageDripDTO, ImageDripViewModel>(imgDripDto);
            return File(img.Data, img.MimeType);
        }

        public ActionResult GetDrip(int id)
        {
            DripDTO dripDto = orderService.GetDrip(id);
            Mapper.Initialize(cfg => cfg.CreateMap<DripDTO, DripViewModel>());
            var drip = Mapper.Map<DripDTO, DripViewModel>(dripDto);
            return View(drip);
        }
    }
}