using System.Web.Mvc;

namespace App.Presentation.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        public UsuariosController()
        {

        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        public ActionResult DesativarLock(string id)
        {
            return View();
        }
    }
}