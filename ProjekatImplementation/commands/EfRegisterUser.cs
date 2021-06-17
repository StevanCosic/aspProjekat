using PorjekatDataAccsess;
using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using ProjekatImplementation.validation;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjekatDomain;
using ProjekatiApplication.emailSender;

namespace ProjekatImplementation.commands
{
    public class EfRegisterUser : IRegisterUserCommand
    {
        private readonly ProjekatDbContext _context;
        private readonly registrationValidator validator;
        private readonly IEmailSender _sender;

        public EfRegisterUser(ProjekatDbContext context, registrationValidator validator, IEmailSender sender)
        {
            _context = context;
            this.validator = validator;
            _sender = sender;
        }

        public int id => 4;

        public string name => "User Registration";

        public void Execute(RegisterUserDto request)
        {
            validator.ValidateAndThrow(request);

            var user = new user
            {
                email = request.email,
                name = request.name,
                password = request.password,
                Lname = request.Lname,






            };
            _context.user.Add(user);
            _context.SaveChanges();
            _sender.Send(new SendEmail
            {
                Content = "<h1>You registred your account</h1>",
                Adress = request.email,
                Subject = "Registration"



            });
        }
    }
}
