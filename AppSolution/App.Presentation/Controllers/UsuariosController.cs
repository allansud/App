using App.Business.Interface;
using System.Web.Mvc;
using System.Linq;

namespace App.Presentation.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuariosController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_usuarioBusiness.GetAll());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View(_usuarioBusiness.GetById(id));
        }

        public ActionResult DesativarLock(string id)
        {
            //_usuarioRepository.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}
