using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
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

        private AmazonDynamoDBClient client = new AmazonDynamoDBClient();

        public async Task<IEnumerable<Note>> Notes()
        {
            ScanRequest scanRequest = new ScanRequest("androidshowcase-mobilehub-757025675-Notes");
            ScanResult result = client.Scan(scanRequest);

            var notes = new List<Note>();

            foreach(var n in result.Items)
            {
                var note = new Note() { NoteTitle = n["noteId"].S, NoteId = n["userId"].S, NoteContent = n["content"].S };
                notes.Add(note);
            }

            return notes;
        }
    }
}
