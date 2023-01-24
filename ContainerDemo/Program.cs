using MyDependecyContainer;
using System;

namespace ContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioc = new MyIoc();

            ioc.Register<ByeWriterService>();
            ioc.Register<HelloWriterService>();
            ioc.RegisterSingleton<SingletonNoteService>();


            ioc.Resolve<HelloWriterService>().Write();
            ioc.Resolve<ByeWriterService>().Write();

            Console.WriteLine(ioc.Resolve<SingletonNoteService>().Note); 
        }
    }

    class SingletonNoteService
    {
        public string Note { get; set; }
    }

    class HelloWriterService
    {
        private readonly SingletonNoteService _noteService;

        public HelloWriterService(SingletonNoteService noteService)
        {
            _noteService = noteService;
        }

        public void Write()
        {
            _noteService.Note = "Hello";
        }
    }

    class ByeWriterService
    {
        private readonly SingletonNoteService _noteService;

        public ByeWriterService(SingletonNoteService noteService)
        {
            _noteService = noteService;
        }

        public void Write()
        {
            _noteService.Note = "Bye";
        }
    }
}
