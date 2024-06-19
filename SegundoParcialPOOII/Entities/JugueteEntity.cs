namespace SegundoParcialPOOII.Entities
{
    public class JugueteEntity
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; } 
        public decimal Precio { get; set; }
        public DateTime Vigencia { get; set; }
        public bool Activo { get; set; }
    }
}