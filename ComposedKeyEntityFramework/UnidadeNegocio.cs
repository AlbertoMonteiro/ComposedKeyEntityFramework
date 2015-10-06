namespace ComposedKeyEntityFramework
{
    public class UnidadeNegocio
    {
        public long Id { get; set; }

        public string RazaoSocial { get; set; }

        public long EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}