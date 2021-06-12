namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAddMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Hang Over 3',5, '2012-06-18', '2012-06-18',3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Transporter',2, '2012-06-18', '2012-06-18',3)");
        }
        
        public override void Down()
        {
        }
    }
}
