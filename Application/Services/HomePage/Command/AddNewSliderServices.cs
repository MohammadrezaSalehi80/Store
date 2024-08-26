using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store.Application.Interfaces.Context;
using Store.Application.Services.Product.Command.AddProduct;
using Store.Common.Dto;
using Store.Domain.Entities.HomePage;
using System;
using System.IO;

namespace Store.Application.Services.HomePage
{
    public class AddNewSliderServices : IAddNewSliderServices
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _environment;

        public AddNewSliderServices(IDataBaseContext dataBaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataBaseContext = dataBaseContext;
            _environment = webHostEnvironment;
        }

        public ResultDto Execute(IFormFile formFile, string link)
        {
            var FileUpload = Upload(formFile);

            Slider slider = new Slider()
            {
                ImageSrc = FileUpload.fileName,
                Link = link,
                CreateDate= DateTime.Now
            };

            _dataBaseContext.sliders.Add(slider);
            _dataBaseContext.SaveChanges();

            return new ResultDto() { IsSuccess = true, Message = "Success"};

        }



        private FileUploadDto Upload(IFormFile file)
        {
            string folder = $@"Images\HomePgae\Sliders\";
            var root = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
            var filePath = Path.Combine(root, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return new FileUploadDto()
            {
                fileName = folder + fileName,
                IsSuccess = true,
            };
        }


    }

}
