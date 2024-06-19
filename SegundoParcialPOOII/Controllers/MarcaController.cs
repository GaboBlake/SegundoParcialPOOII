
using Microsoft.AspNetCore.Mvc;
using SegundoParcialPOOII;
using SegundoParcialPOOII.Entities;
using SegundoParcialPOOII.Models;

public class MarcaController : Controller
{
    private readonly ApplicationDBContext _context;
    public MarcaController(ApplicationDBContext context)
    {
        _context = context;
    }

     public IActionResult MarcasList()
    {
        List<MarcaModel> list =_context.Marcas.Select(x => new MarcaModel
        {
            Id = x.Id,
            Codigo=x.Codigo,
            Nombre=x.Nombre,
            Activo=x.Activo
        }).ToList();
        return View(list);
    }

    [HttpGet]
    public IActionResult AddMarcas()
    {

        return View();
    }

    [HttpPost]
     public IActionResult AddMarcas(MarcaModel marcaModel)
    {
         if (ModelState.IsValid)
            {
                MarcaEntity v = new MarcaEntity();
                v.Id = marcaModel.Id;
                v.Codigo = marcaModel.Codigo;
                v.Nombre = marcaModel.Nombre;
                v.Activo = marcaModel.Activo;

                this._context.Marcas.Add(v);
                this._context.SaveChanges();
                return RedirectToAction("MarcasList");

            }
        
        return View();
    }

    [HttpGet]
        public IActionResult DeleteMarca(int Id)
        {
            MarcaEntity marca = this._context.Marcas.Where(s => s.Id == Id).First();

            if (marca == null)
            {
                return RedirectToAction("MarcasList","Marca");

            }

            MarcaEntity model = new MarcaEntity();
            model.Id = model.Id;
            model.Codigo = model.Codigo;
            model.Nombre = model.Nombre;
            model.Activo=model.Activo;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteMarca (MarcaModel marcaModel)
        {
            bool exists = this._context.Marcas.Any(a => a.Id == marcaModel.Id);
            if (!exists)
            {
                return View (marcaModel);
            }

            MarcaEntity marca = this._context.Marcas.Where (s => s.Id == marcaModel.Id).First();
            marca.Codigo = marcaModel.Codigo;
            marca.Nombre = marcaModel.Nombre;
            marca.Activo=marcaModel.Activo;

            this._context.Marcas.Remove(marca);
            this._context.SaveChanges();

            return RedirectToAction("MarcasList","Marca");

            
        }

        [HttpGet]
    public IActionResult EditMarcas(int Id)
    {
            MarcaEntity marca = this._context.Marcas.Where(s => s.Id == Id).First();

            if (marca==null)
            {
                return RedirectToAction("MarcasList","Marca");
            }

            MarcaModel model = new MarcaModel();
            model.Id = marca.Id;
            model.Codigo = marca.Codigo;
            model.Nombre = marca.Nombre;
            model.Activo = marca.Activo;

            return View(model);
        
    }

     [HttpPost]
     public IActionResult EditMarcas(MarcaModel marcaModel)
     {
        MarcaEntity marca = this._context.Marcas
        .Where(v => v.Id == marcaModel.Id).First();

        if(marcaModel == null)
        {
            return RedirectToAction("MarcasList");
        }
        marca.Codigo=marcaModel.Codigo;
        marca.Nombre=marcaModel.Nombre;
        marca.Activo=marca.Activo;




        this._context.Marcas.Update(marca);
        this._context.SaveChanges();
       
       return RedirectToAction("MarcasList","Marca");

     }
}
