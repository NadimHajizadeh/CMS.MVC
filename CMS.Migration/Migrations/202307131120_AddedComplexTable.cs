using FluentMigrator;

namespace CMS.Migration.Migrations;
[Migration(1)]
public class _202307131120_AddedComplexTable : FluentMigrator.Migration
{
    
    public override void Up()
    {
        CreateTable();
    }

  

    public override void Down()
    {
        Delete.Table("Complexes");
    }
    private void CreateTable()
    {
        Create.Table("Complexes").WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30).NotNullable().WithColumn("UnitCount")
            .AsInt32().NotNullable();
    }
}