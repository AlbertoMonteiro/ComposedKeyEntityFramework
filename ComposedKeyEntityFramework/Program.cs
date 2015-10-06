using System;
using System.Linq;

namespace ComposedKeyEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyContext();

            Console.WriteLine("Criando DB se não existir");
            ctx.Database.CreateIfNotExists();

            if (!ctx.Empresas.Any())
            {
                var empresa = ctx.Empresas.Add(ctx.Empresas.Create());
                empresa.Nome = "Fortes Tecnologia em Sistemas";

                var empresa2 = ctx.Empresas.Add(ctx.Empresas.Create());
                empresa2.Nome = "Fortes Educação";
                ctx.SaveChanges();
                Console.WriteLine($"Empresa {empresa.Nome} criada");
                Console.WriteLine($"Empresa {empresa2.Nome} criada");
            }

            if (!ctx.UnidadesNegocio.Any())
            {
                var unidadeNegocio = ctx.UnidadesNegocio.Add(ctx.UnidadesNegocio.Create());
                unidadeNegocio.RazaoSocial = "Matriz Tecnologia";
                unidadeNegocio.EmpresaId = 1;

                var unidadeNegocio2 = ctx.UnidadesNegocio.Add(ctx.UnidadesNegocio.Create());
                unidadeNegocio2.RazaoSocial = "Matriz Educação";
                unidadeNegocio2.EmpresaId = 2;
                ctx.SaveChanges();
            }

            Console.WriteLine("Salvando conta a receber (que vai da certo)");
            ctx.Database.Log = Console.WriteLine;
            var contaAReceber = ctx.ContasAReceber.Add(ctx.ContasAReceber.Create());
            contaAReceber.UnidadeNegocioId = 1;
            contaAReceber.UnidadeNegocioEmpresaId = 1;
            contaAReceber.Valor = 10;
            contaAReceber.EmpresaId = 1;
            contaAReceber.Descricao = "Venda de sapato";
            ctx.SaveChanges();
            Console.WriteLine("Salvo conta a receber (que vai da certo)");


            Console.WriteLine("Salvando conta a receber (que não vai da certo)");
            var contaAReceber2 = ctx.ContasAReceber.Add(ctx.ContasAReceber.Create());
            contaAReceber2.UnidadeNegocioId = 2;
            contaAReceber2.UnidadeNegocioEmpresaId = 1;
            contaAReceber2.Valor = 10;
            contaAReceber2.Descricao = "Venda de sapato que não vai da certo";
            contaAReceber2.EmpresaId = 1;
            ctx.SaveChanges();
            Console.WriteLine("Salvo conta a receber (que não vai da certo)");
        }
    }
}
