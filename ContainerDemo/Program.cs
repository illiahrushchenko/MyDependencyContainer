using MyDependecyContainer;
using System;

namespace ContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioc = new MyIoc();

            ioc.Register<ProfileService>();
            ioc.Register<EmailService>();


            var emailService = ioc.Resolve<EmailService>();
            emailService.Send();
        }
    }

    class ProfileService
    {
        public string GetDefaultUser()
        {
            return "William Shakespear";
        }
    }

    class EmailService
    {
        private readonly ProfileService _profileService;

        public EmailService(ProfileService profileService)
        {
            _profileService = profileService;
        }

        public void Send()
        {
            Console.WriteLine($"Message sent to user {_profileService.GetDefaultUser()}");
        }
    }
}
