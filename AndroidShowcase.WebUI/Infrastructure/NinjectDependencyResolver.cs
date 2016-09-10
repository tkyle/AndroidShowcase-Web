using AndroidShowcase.Business.Abstract;
using AndroidShowcase.Business.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndroidShowcase.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        object IDependencyResolver.GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBindings()
        {
            Mock<INotesRepository> mock = new Mock<INotesRepository>();

            mock.Setup(m => m.Notes).Returns(new List<Note>
            {
                new Note { NoteId = "1", NoteTitle = "Title 1", NoteContent = "Content 1"},
                new Note { NoteId = "2", NoteTitle = "Title 2", NoteContent = "Content 2"},
                new Note { NoteId = "3", NoteTitle = "Title 3", NoteContent = "Content 3"}
            });

            kernel.Bind<INotesRepository>().ToConstant(mock.Object);
        }
    }
}