using DiaryMVC.Services;
using System.Net;
using System.Web.Mvc;

namespace DiaryMVC.Controllers
{
    //would be better to make it rest API and use ApiCOntroller, but too much work
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

            var foundAndDeleted = _noteService.Delete(noteId);
            
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

        public HttpStatusCodeResult SetStatus(int noteId, bool status)
        {
            HttpStatusCodeResult result;

            var foundAndUpdated = _noteService.SetStatus(noteId, status);

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