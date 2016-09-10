using AndroidShowcase.Business.Abstract;
using AndroidShowcase.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShowcase.Business.Concrete
{
    public class AndroidShowcaseRepository : INotesRepository
    {
        //private AndroidRepositoryContext context = new AndroidRepositoryContext();

        public IEnumerable<Note> Notes { get; }
    }
}
