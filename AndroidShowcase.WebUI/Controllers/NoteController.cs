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
        private IAndroidShowcaseRepository noteRepo;

        public NoteController(IAndroidShowcaseRepository noteRepoParameter)
        {
            this.noteRepo = noteRepoParameter;
        }

        // GET: Notes
        public ViewResult List()
        {
            var notes = noteRepo.Notes();
            return View(notes);
        }
    }
}