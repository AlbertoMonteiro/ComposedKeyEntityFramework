namespace ComposedKeyEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContaAReceber",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpresaId = c.Long(nullable: false),
                        Descricao = c.String(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnidadeNegocioId = c.Long(nullable: false),
                        UnidadeNegocioEmpresaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.EmpresaId })
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.UnidadeNegocio", t => new { t.UnidadeNegocioId, t.UnidadeNegocioEmpresaId })
                .Index(t => t.EmpresaId)
                .Index(t => new { t.UnidadeNegocioId, t.UnidadeNegocioEmpresaId });
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadeNegocio",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpresaId = c.Long(nullable: false),
                        RazaoSocial = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.EmpresaId })
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.EmpresaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContaAReceber", new[] { "UnidadeNegocioId", "UnidadeNegocioEmpresaId" }, "dbo.UnidadeNegocio");
            DropForeignKey("dbo.UnidadeNegocio", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.ContaAReceber", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.UnidadeNegocio", new[] { "EmpresaId" });
            DropIndex("dbo.ContaAReceber", new[] { "UnidadeNegocioId", "UnidadeNegocioEmpresaId" });
            DropIndex("dbo.ContaAReceber", new[] { "EmpresaId" });
            DropTable("dbo.UnidadeNegocio");
            DropTable("dbo.Empresa");
            DropTable("dbo.ContaAReceber");
        }
    }
}
