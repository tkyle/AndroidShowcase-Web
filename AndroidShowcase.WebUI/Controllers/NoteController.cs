using AndroidShowcase.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndroidShowcase.WebUI.Controllers
{
    public class NoteController : Controller
    {
        private INotesRepository noteRepo;

        public NoteController(INotesRepository noteRepoParameter)
        {
            this.noteRepo = noteRepoParameter;
        }

        // GET: Notes
        public ViewResult List()
        {
            return View(noteRepo.Notes);
        }
    }
}