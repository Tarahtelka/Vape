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
    public class BoxModController : Controller
    {

        IOrderService orderService;
        IImageBoxModService imageBoxModService;
        public BoxModController(IOrderService serv, IImageBoxModService imageBoxModserv)
        {
            orderService = serv;
            imageBoxModService = imageBoxModserv;
        }

        public ActionResult Admin()
        {
            IEnumerable<BoxModDTO> boxModDtos = orderService.GetBoxMods();
            Mapper.Initialize(cfg => cfg.CreateMap<BoxModDTO, BoxModViewModel>());
            var boxMod = Mapper.Map<IEnumerable<BoxModDTO>, List<BoxModViewModel>>(boxModDtos);

            return View(boxMod);
        }

        public ActionResult DeleteBoxMod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteBoxMod(int id)
        {

            orderService.DeleteBoxMod(id);
            return View("View");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BoxModViewModel boxModViewModel)
        {

            if (ModelState.IsValid)
            {
                BoxModDTO boxModDto = new BoxModDTO
                {
                    Name = boxModViewModel.Name,
                    Company = boxModViewModel.Company,                   
                    Accumulator = boxModViewModel.Accumulator,
                    Brand = boxModViewModel.Brand,
                    Amount = boxModViewModel.Amount,
                    Contry = boxModViewModel.Contry,
                    Outturn = boxModViewModel.Outturn,
                    Price = boxModViewModel.Price,
                };
                orderService.AddBoxMod(boxModDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }



        // GET: BoxMod
        public ActionResult Index()
        {
            IEnumerable<BoxModDTO> boxmodDtos = orderService.GetBoxMods();
            Mapper.Initialize(cfg => cfg.CreateMap<BoxModDTO, BoxModViewModel>());
            var boxmod = Mapper.Map<IEnumerable<BoxModDTO>, List<BoxModViewModel>>(boxmodDtos);
            return View(boxmod);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadImage, int id)
        {
            BoxModDTO boxModDto = imageBoxModService.GetBoxMod(id);

            if (ModelState.IsValid && boxModDto != null)
            {
                ImageBoxModDTO image = new ImageBoxModDTO
                {
                    BoxModId = id,
                    MimeType = uploadImage.ContentType,
                };
                image.Data = new byte[uploadImage.ContentLength];
                uploadImage.InputStream.Read(image.Data, 0, uploadImage.ContentLength);
                imageBoxModService.Add(image);

                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult DeleteImgBoxMod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImgBoxMod(int id)
        {

            imageBoxModService.DeleteImgBoxMod(id);
            return View("View");
        }


        public ActionResult Update(int id)
        {
            BoxModDTO boxModDto = orderService.GetBoxMod(id);
            Mapper.Initialize(cfg => cfg.CreateMap<BoxModDTO, BoxModViewModel>());
            var boxMod = Mapper.Map<BoxModDTO, BoxModViewModel>(boxModDto);
            return View(boxMod);
        }

        [HttpPost]
        public ActionResult Update(BoxModViewModel boxModViewModel)
        {

            if (ModelState.IsValid)
            {
                BoxModDTO boxModDto = new BoxModDTO
                {
                    Id = boxModViewModel.Id,
                    Name = boxModViewModel.Name,
                    Company = boxModViewModel.Company,
                    Accumulator = boxModViewModel.Accumulator,
                    Brand = boxModViewModel.Brand,
                    Amount = boxModViewModel.Amount,
                    Contry = boxModViewModel.Contry,
                    Outturn = boxModViewModel.Outturn,
                    Price = boxModViewModel.Price,
                };
                orderService.UpdateBoxMod(boxModDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }



        public ActionResult GetImgBoxMod(int id)
        {
            IEnumerable<ImageBoxModDTO> imageBoxModDTO = imageBoxModService.GetImgBoxMods(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageBoxModDTO, ImageBoxModViewModel>());
            var img = Mapper.Map<IEnumerable<ImageBoxModDTO>, List<ImageBoxModViewModel>>(imageBoxModDTO);
            return View(img);
        }

        public ActionResult GetImgBoxModAdmin(int id)
        {
            IEnumerable<ImageBoxModDTO> imageBoxModDTO = imageBoxModService.GetImgBoxMods(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageBoxModDTO, ImageBoxModViewModel>());
            var img = Mapper.Map<IEnumerable<ImageBoxModDTO>, List<ImageBoxModViewModel>>(imageBoxModDTO);
            return View(img);
        }

        public FileResult GetFile(int id)
        {
            ImageBoxModDTO imgBoxModDto = imageBoxModService.GetImg(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageBoxModDTO, ImageBoxModViewModel>());
            var img = Mapper.Map<ImageBoxModDTO, ImageBoxModViewModel>(imgBoxModDto);
            return File(img.Data, img.MimeType);
        }

        public ActionResult GetBoxMod(int id)
        {
            BoxModDTO boxModDto = orderService.GetBoxMod(id);
            Mapper.Initialize(cfg => cfg.CreateMap<BoxModDTO, BoxModViewModel>());
            var boxMod = Mapper.Map<BoxModDTO, BoxModViewModel>(boxModDto);
            return View(boxMod);
        }

    }
}