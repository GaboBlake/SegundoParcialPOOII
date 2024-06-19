namespace SegundoParcialPOOII.Models
{
    public class JugueteModel
    {
         public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }=null!;
        public decimal Precio { get; set; }
        public DateTime Vigencia { get; set; }
        public bool Activo { get; set; }
    }
}