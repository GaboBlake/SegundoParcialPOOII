using Microsoft.AspNetCore.Mvc;
using SegundoParcialPOOII;
using SegundoParcialPOOII.Entities;
using SegundoParcialPOOII.Models;



public class JugueteController : Controller
{
    private readonly ApplicationDBContext _context;
    public JugueteController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult JuguetesList()
    {
        List<JugueteModel> list =_context.Juguetes.Select(x => new JugueteModel
        {
            Id = x.Id,
            Codigo=x.Codigo,
            Nombre=x.Nombre,
            Precio=x.Precio,
            Vigencia=x.Vigencia,
            Activo=x.Activo
        }).ToList();
        return View(list);
    }

    [HttpGet]
    public IActionResult AddJuguete()
    {

        return View();
    }

    [HttpPost]
     public IActionResult AddJuguete(JugueteModel jugueteModel)
    {
         if (ModelState.IsValid)
            {
                JugueteEntity v = new JugueteEntity();
                v.Id = jugueteModel.Id;
                v.Codigo = jugueteModel.Codigo;
                v.Nombre = jugueteModel.Nombre;
                v.Precio=jugueteModel.Precio;
                v.Vigencia=jugueteModel.Vigencia;
                v.Activo=jugueteModel.Activo;

                this._context.Juguetes.Add(v);
                this._context.SaveChanges();
                return RedirectToAction("JuguetesList");

            }
        
        return View();
    }

    [HttpGet]
        public IActionResult DeleteJuguete(int Id)
        {
            JugueteEntity juguete = this._context.Juguetes.Where(s => s.Id == Id).First();

            if (juguete == null)
            {
                return RedirectToAction("JuguetesList","Juguete");

            }

            JugueteEntity model = new JugueteEntity();
            model.Id = model.Id;
            model.Codigo = model.Codigo;
            model.Nombre = model.Nombre;
            model.Precio=model.Precio;
            model.Vigencia=model.Vigencia;
            model.Activo=model.Activo;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteJuguete(JugueteModel jugueteModel)
        {
            bool exists = this._context.Juguetes.Any(a => a.Id == jugueteModel.Id);
            if (!exists)
            {
                return View (jugueteModel);
            }

            JugueteEntity juguete = this._context.Juguetes.Where (s => s.Id == jugueteModel.Id).First();
            juguete.Codigo = jugueteModel.Codigo;
            juguete.Nombre = jugueteModel.Nombre;
            juguete.Precio=jugueteModel.Precio;
            juguete.Vigencia=jugueteModel.Vigencia;
            juguete.Activo=jugueteModel.Activo;

            this._context.Juguetes.Remove(juguete);
            this._context.SaveChanges();

            return RedirectToAction("JuguetesList","Juguetes");

            
        }

        [HttpGet]
    public IActionResult EditJuguete(int Id)
    {
            JugueteEntity juguete = this._context.Juguetes.Where(s => s.Id == Id).First();

            if (juguete==null)
            {
                return RedirectToAction("JuguetesList","Juguete");
            }

            JugueteModel model = new JugueteModel();
            model.Id = juguete.Id;
            model.Codigo = juguete.Codigo;
            model.Nombre=juguete.Nombre;
            model.Precio=juguete.Precio;
            model.Vigencia= juguete.Vigencia;
            model.Activo= juguete.Activo;

            return View(model);
        
    }

     [HttpPost]
     public IActionResult EditVehiculos(JugueteModel jugueteModel)
     {
        JugueteEntity juguete = this._context.Juguetes
        .Where(v => v.Id == jugueteModel.Id).First();

        if(jugueteModel == null)
        {
            return RedirectToAction("JuguetesModel");
        }
        juguete.Codigo = jugueteModel.Codigo;
        juguete.Nombre= jugueteModel.Nombre;
        juguete.Precio= jugueteModel.Precio;
        juguete.Vigencia=jugueteModel.Vigencia;
        juguete.Activo=jugueteModel.Activo;



        this._context.Juguetes.Update(juguete);
        this._context.SaveChanges();
       
       return RedirectToAction("JuguetesList","Juguete");

     }





        
}
