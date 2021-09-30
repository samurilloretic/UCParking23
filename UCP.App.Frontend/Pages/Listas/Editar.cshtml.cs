using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCP.App.Persistencia;
using UCP.App.Dominio;
namespace UCP.App.Frontend.Pages
{
    public class EditarModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        [BindProperty]
        public Profesor profesor{get;set;}

        public IActionResult OnGet(int profesorId)
        {
            profesor = _repoProfesor.GetProfesor(profesorId);
            if(profesor==null)
            {
                return RedirectToPage("./Personas");
            }else
            return Page(); 
        }

        public IActionResult OnPost()
        {

            if(profesor.id>0)
            {
                profesor = _repoProfesor.UpdateProfesor(profesor);
            }     
            return Page();       
        }

    }
}
