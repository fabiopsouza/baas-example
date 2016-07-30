namespace tcc.core.repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movimentacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(nullable: false, maxLength: 15),
                        NomeTitular = c.String(nullable: false, maxLength: 100),
                        NumeroConta = c.String(),
                        TotalCreditos = c.Double(nullable: false),
                        TotalDebitos = c.Double(nullable: false),
                        StatusMovimentacaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusMovimentacao", t => t.StatusMovimentacaoId, cascadeDelete: true)
                .Index(t => t.StatusMovimentacaoId);
            
            CreateTable(
                "dbo.StatusMovimentacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentacao", "StatusMovimentacaoId", "dbo.StatusMovimentacao");
            DropIndex("dbo.Movimentacao", new[] { "StatusMovimentacaoId" });
            DropTable("dbo.StatusMovimentacao");
            DropTable("dbo.Movimentacao");
        }
    }
}
