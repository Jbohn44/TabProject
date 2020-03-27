namespace TabIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noteMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        BarId = c.Int(nullable: false),
                        String = c.String(),
                        Fret = c.String(),
                    })
                .PrimaryKey(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
