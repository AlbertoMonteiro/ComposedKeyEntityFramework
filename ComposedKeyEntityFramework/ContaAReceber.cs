namespace ComposedKeyEntityFramework
{
    public class ContaAReceber
    {
        public long Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public long EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public long UnidadeNegocioId { get; set; }

        public long UnidadeNegocioEmpresaId { get; set; }

        public UnidadeNegocio UnidadeNegocio { get; set; }
    }
}