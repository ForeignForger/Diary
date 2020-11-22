using DiaryMVC.Services;
using System.Net;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        //[HttpDelete] doesn't work. The work around is too compicated and doesn't worth it
        public HttpStatusCodeResult Delete(int noteId)
        {
            HttpStatusCodeResult result;

            var foundAndDeleted = _noteService.DeleteNote(noteId);
            
            if (foundAndDeleted)
            {
                result = new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return result;
        }

        public HttpStatusCodeResult SetNoteStatus(int noteId, bool done)
        {
            HttpStatusCodeResult result;

            var foundAndUpdated = _noteService.SetNoteStatus(noteId, done);

            if (foundAndUpdated)
            {
                result = new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return result;
        }
    }
}