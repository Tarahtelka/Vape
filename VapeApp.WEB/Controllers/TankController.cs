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
    public class TankController : Controller
    {
        IOrderService orderService;
        IImageTankService imageTankService;
        public TankController(IOrderService serv, IImageTankService imageTankserv)
        {
            orderService = serv;
            imageTankService = imageTankserv;
        }

        public ActionResult Admin()
        {
            IEnumerable<TankDTO> tankDtos = orderService.GetTanks();
            Mapper.Initialize(cfg => cfg.CreateMap<TankDTO, TankViewModel>());
            var tank = Mapper.Map<IEnumerable<TankDTO>, List<TankViewModel>>(tankDtos);

            return View(tank);
        }

        public ActionResult DeleteTank()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteTank(int id)
        {

            orderService.DeleteTank(id);
            return View("View");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TankViewModel tankViewModel)
        {

            if (ModelState.IsValid)
            {
                TankDTO tankDto = new TankDTO
                {
                    Name = tankViewModel.Name,
                    Company = tankViewModel.Company,
                    Amount = tankViewModel.Amount,
                    Brand = tankViewModel.Brand,
                    Racks = tankViewModel.Racks,
                    Contry = tankViewModel.Contry,
                    Price = tankViewModel.Price,
                    Diameter = tankViewModel.Diameter,
                };
                orderService.AddTank(tankDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Update(int id)
        {
            TankDTO tankDto = orderService.GetTank(id);
            Mapper.Initialize(cfg => cfg.CreateMap<TankDTO, TankViewModel>());
            var tank = Mapper.Map<TankDTO, TankViewModel>(tankDto);
            return View(tank);
        }

        [HttpPost]
        public ActionResult Update(TankViewModel tankViewModel)
        {

            if (ModelState.IsValid)
            {
               TankDTO tankDto = new TankDTO
               {
                    Id = tankViewModel.Id,
                    Name = tankViewModel.Name,
                    Company = tankViewModel.Company,
                    Amount = tankViewModel.Amount,
                    Brand = tankViewModel.Brand,
                    Racks = tankViewModel.Racks,
                    Contry = tankViewModel.Contry,
                    Price = tankViewModel.Price,
                    Diameter = tankViewModel.Diameter,
                };
                orderService.UpdateTank(tankDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }
        public ActionResult DeleteImgTank()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImgTank(int id)
        {

            imageTankService.DeleteImgTank(id);
            return View("View");
        }


        public ActionResult Index()
        {
            IEnumerable<TankDTO> tankDtos = orderService.GetTanks();
            Mapper.Initialize(cfg => cfg.CreateMap<TankDTO, TankViewModel>());
            var tank = Mapper.Map<IEnumerable<TankDTO>, List<TankViewModel>>(tankDtos);
            return View(tank);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadImage, int id)
        {
            TankDTO tankDto = imageTankService.GetTank(id);

            if (ModelState.IsValid && tankDto != null)
            {
                ImageTankDTO image = new ImageTankDTO
                {
                    TankId = id,
                    MimeType = uploadImage.ContentType,
                };
                image.Data = new byte[uploadImage.ContentLength];
                uploadImage.InputStream.Read(image.Data, 0, uploadImage.ContentLength);
                imageTankService.Add(image);

                return View("View");
            }
            else
            {
                return View("View1");
            }
        }


        public ActionResult GetImgTank(int id)
        {
            IEnumerable<ImageTankDTO> imageTankDTO = imageTankService.GetImgTanks(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageTankDTO, ImageTankViewModel>());
            var img = Mapper.Map<IEnumerable<ImageTankDTO>, List<ImageTankViewModel>>(imageTankDTO);
            return View(img);
        }

        public ActionResult GetImgTankAdmin(int id)
        {
            IEnumerable<ImageTankDTO> imageTankDTO = imageTankService.GetImgTanks(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageTankDTO, ImageTankViewModel>());
            var img = Mapper.Map<IEnumerable<ImageTankDTO>, List<ImageTankViewModel>>(imageTankDTO);
            return View(img);
        }

        public FileResult GetFile(int id)
        {
            ImageTankDTO imgTankDto = imageTankService.GetImg(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageTankDTO, ImageTankViewModel>());
            var img = Mapper.Map<ImageTankDTO, ImageTankViewModel>(imgTankDto);
            return File(img.Data, img.MimeType);
        }

        public ActionResult GetTank(int id)
        {
            TankDTO tankDto = orderService.GetTank(id);
            Mapper.Initialize(cfg => cfg.CreateMap<TankDTO, TankViewModel>());
            var tank = Mapper.Map<TankDTO, TankViewModel>(tankDto);
            return View(tank);
        }
    }
}