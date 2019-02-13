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
    public class MechModController : Controller
    {
        IOrderService orderService;
        IImageMechModService imageMechModService;
        public MechModController(IOrderService serv, IImageMechModService imageMechModserv)
        {
            orderService = serv;
            imageMechModService = imageMechModserv;
        }

        public ActionResult Admin()
        {
            IEnumerable<MechModDTO> mechModDtos = orderService.GetMechMods();
            Mapper.Initialize(cfg => cfg.CreateMap<MechModDTO, MechModViewModel>());
            var mechMod = Mapper.Map<IEnumerable<MechModDTO>, List<MechModViewModel>>(mechModDtos);

            return View(mechMod);
        }

        public ActionResult DeleteMechMod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteMechMod(int id)
        {

            orderService.DeleteMechMod(id);
            return View("View");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MechModViewModel mechModViewModel)
        {

            if (ModelState.IsValid)
            {
                MechModDTO mechModDto = new MechModDTO
                {
                    Name = mechModViewModel.Name,
                    Company = mechModViewModel.Company,
                    Accumulator = mechModViewModel.Accumulator,
                    Brand = mechModViewModel.Brand,
                    Racks = mechModViewModel.Racks,
                    TypeButton = mechModViewModel.TypeButton,
                    Contry = mechModViewModel.Contry,
                    Outturn = mechModViewModel.Outturn,
                    Price = mechModViewModel.Price,
                };
                orderService.AddMechMod(mechModDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }




        public ActionResult Index()
        {
            IEnumerable<MechModDTO> mechModDtos = orderService.GetMechMods();
            Mapper.Initialize(cfg => cfg.CreateMap<MechModDTO, MechModViewModel>());
            var mechMod = Mapper.Map<IEnumerable<MechModDTO>, List<MechModViewModel>>(mechModDtos);
            return View(mechMod);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadImage, int id)
        {
            MechModDTO mechModDto = imageMechModService.GetMechMod(id);

            if (ModelState.IsValid && mechModDto != null)
            {
                ImageMechModDTO image = new ImageMechModDTO
                {
                    MechModId = id,
                    MimeType = uploadImage.ContentType,
                };
                image.Data = new byte[uploadImage.ContentLength];
                uploadImage.InputStream.Read(image.Data, 0, uploadImage.ContentLength);
                imageMechModService.Add(image);

                return View("View");
            }
            else
            {
                return View("View1");
            }
        }


        public ActionResult Update(int id)
        {
            MechModDTO mechModDto = orderService.GetMechMod(id);
            Mapper.Initialize(cfg => cfg.CreateMap<MechModDTO, MechModViewModel>());
            var mechMod = Mapper.Map<MechModDTO, MechModViewModel>(mechModDto);
            return View(mechMod);
        }

        [HttpPost]
        public ActionResult Update(MechModViewModel mechModViewModel)
        {

            if (ModelState.IsValid)
            {
                MechModDTO mechModDto = new MechModDTO
                {
                    Id = mechModViewModel.Id,
                    Name = mechModViewModel.Name,
                    Company = mechModViewModel.Company,
                    Accumulator = mechModViewModel.Accumulator,
                    Brand = mechModViewModel.Brand,
                    Racks = mechModViewModel.Racks,
                    TypeButton = mechModViewModel.TypeButton,
                    Contry = mechModViewModel.Contry,
                    Outturn = mechModViewModel.Outturn,
                    Price = mechModViewModel.Price,
                };
                orderService.UpdateMechMod(mechModDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }
        public ActionResult DeleteImgMechMod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImgMechMod(int id)
        {

            imageMechModService.DeleteImgMechMod(id);
            return View("View");
        }



        public ActionResult GetImgMechMod(int id)
        {
            IEnumerable<ImageMechModDTO> imageMechModDTO = imageMechModService.GetImgMechMods(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageMechModDTO, ImageMechModViewModel>());
            var img = Mapper.Map<IEnumerable<ImageMechModDTO>, List<ImageMechModViewModel>>(imageMechModDTO);
            return View(img);
        }

        public ActionResult GetImgMechModAdmin(int id)
        {
            IEnumerable<ImageMechModDTO> imageMechModDTO = imageMechModService.GetImgMechMods(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageMechModDTO, ImageMechModViewModel>());
            var img = Mapper.Map<IEnumerable<ImageMechModDTO>, List<ImageMechModViewModel>>(imageMechModDTO);
            return View(img);
        }

        public FileResult GetFile(int id)
        {
            ImageMechModDTO imgMechModDto = imageMechModService.GetImg(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageMechModDTO, ImageMechModViewModel>());
            var img = Mapper.Map<ImageMechModDTO, ImageMechModViewModel>(imgMechModDto);
            return File(img.Data, img.MimeType);
        }

        public ActionResult GetMechMod(int id)
        {
            MechModDTO mechModDto = orderService.GetMechMod(id);
            Mapper.Initialize(cfg => cfg.CreateMap<MechModDTO, MechModViewModel>());
            var mechMod = Mapper.Map<MechModDTO, MechModViewModel>(mechModDto);
            return View(mechMod);
        }
    }
}