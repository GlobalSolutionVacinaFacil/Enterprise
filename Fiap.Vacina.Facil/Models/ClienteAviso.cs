namespace Fiap.Vacina.Facil.Models
{
    public class ClienteAviso
    {
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public Aviso Aviso { get; set; }
        public int AvisoId { get; set; }

    }
}
