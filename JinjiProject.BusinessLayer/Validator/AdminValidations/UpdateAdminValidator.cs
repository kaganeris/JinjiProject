﻿using FluentValidation;
using JinjiProject.BusinessLayer.Validator.ProductValidations;
using JinjiProject.Core.Enums;
using JinjiProject.Dtos.Admins;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjiProject.BusinessLayer.Validator.AdminValidations
{
    public class UpdateAdminValidator : AbstractValidator<UpdateAdminDto>
    {
        public UpdateAdminValidator()
        {
            RuleFor(admin => admin.FirstName).NotEmpty().WithMessage("Ad boş geçilemez.").WithErrorCode("1").MinimumLength(2).WithMessage("Admin adı en az 2 karakter içermelidir.").WithErrorCode("1").Must(IsNumber).WithMessage("Admin adı sadece sayı içermemelidir.").WithErrorCode("1");

            RuleFor(admin => admin.LastName).NotEmpty().WithMessage("Soyad boş geçilemez.").WithErrorCode("2").MinimumLength(2).WithMessage("Admin soyadı en az 2 karakter içermelidir.").WithErrorCode("2").Must(IsNumber).WithMessage("Admin soyadı sadece sayı içermemelidir.").WithErrorCode("2");


            RuleFor(admin => admin.BirthDate).NotEmpty().WithMessage("Doğum Tarihi boş geçilemez.").WithErrorCode("3");

            RuleFor(admin => admin.Email).NotEmpty().WithMessage("Email adresi boş geçilemez.").WithErrorCode("4");

            RuleFor(admin => admin.Gender).Must(gender => (gender == Gender.Man || gender == Gender.Woman)).WithMessage("Cinsiyet boş geçilemez.").WithErrorCode("5");
            RuleFor(x => x.UploadPath).Must(file => file == null || file.IsImage()).WithMessage("Dosya sadece .jpg .jpeg veya .png uzantılı olmalıdır!").WithErrorCode("6");
        }
        private static bool IsNumber(string description)
        {

            if (description == null)
            {
                return true;
            }
            foreach (var item in description)
            {
                if (!char.IsDigit(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
