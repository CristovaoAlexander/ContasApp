using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContasApp.Presentation.Controllers
{
    [Authorize] //incluir apos criar a politica de cookoes
    public class PrincipalController : Controller
    {   //metodo GET da pagina 
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
