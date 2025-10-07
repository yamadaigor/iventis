namespace Iventis.Domain.Entities
{
    public class Moto : BaseEntity
    {
        public Moto()
        {
             Id = Guid.NewGuid();
        }
        public string Identificador { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        // EntityFramework Relationships
        public IEnumerable<Locacao> Locacoes { get; set; }
    }
}
