using FluentMigrator;

namespace CMS.Migration.Migrations;
[Migration(4)]
public class _202307131359_AddedUsageTypeAndComplexUsageTypeTable : FluentMigrator.Migration
{
    public override void Up()
    {
        CreateUsageTypeTable();
        CreateComplexUsageTypeTable();
    }



    public override void Down()
    {
        Delete.Table("ComplexUsageType");
        Delete.Table("UsageType");

    }
    private void CreateComplexUsageTypeTable()
    {
        Create.Table("ComplexUsageType")
            .WithColumn("ComplexId")
            .AsInt32()
            .PrimaryKey()
            .WithColumn("UsageTypeId")
            .AsInt32()
            .PrimaryKey();
    }

    private void CreateUsageTypeTable()
    {
        Create.Table("UsageType")
            .WithColumn("Id").AsInt32().Identity()
            .PrimaryKey()
            .WithColumn("Name").AsString(30).NotNullable();
    }
}