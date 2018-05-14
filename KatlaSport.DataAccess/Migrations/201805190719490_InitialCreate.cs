using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    /// <summary>
    /// Initial create migration.
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catalogue_products",
                c => new
                {
                    product_id = c.Int(nullable: false, identity: true),
                    product_name = c.String(nullable: false, maxLength: 60),
                    product_code = c.String(nullable: false, maxLength: 5),
                    product_category_id = c.Int(nullable: false),
                    deleted = c.Boolean(nullable: false),
                    created_by_id = c.Int(nullable: false),
                    created_utc = c.DateTime(nullable: false),
                    updated_by_id = c.Int(nullable: false),
                    updated_utc = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.product_categories", t => t.product_category_id, cascadeDelete: true)
                .Index(t => t.product_code)
                .Index(t => t.product_category_id);

            CreateTable(
                "dbo.product_categories",
                c => new
                {
                    category_id = c.Int(nullable: false, identity: true),
                    category_name = c.String(nullable: false, maxLength: 60),
                    category_code = c.String(nullable: false, maxLength: 5),
                    deleted = c.Boolean(nullable: false),
                    created_by_id = c.Int(nullable: false),
                    created_utc = c.DateTime(nullable: false),
                    updated_by_id = c.Int(nullable: false),
                    updated_utc = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.category_id)
                .Index(t => t.category_code);

            CreateTable(
                "dbo.product_hive_section_categories",
                c => new
                {
                    product_category_id = c.Int(nullable: false),
                    product_hive_section_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.product_category_id, t.product_hive_section_id })
                .ForeignKey("dbo.product_categories", t => t.product_category_id, cascadeDelete: true)
                .ForeignKey("dbo.product_hive_sections", t => t.product_hive_section_id, cascadeDelete: true)
                .Index(t => t.product_category_id)
                .Index(t => t.product_hive_section_id);

            CreateTable(
                "dbo.product_hive_sections",
                c => new
                {
                    product_hive_section_id = c.Int(nullable: false, identity: true),
                    product_hive_section_name = c.String(nullable: false, maxLength: 60),
                    product_hive_code = c.String(nullable: false, maxLength: 5),
                    deleted = c.Boolean(nullable: false),
                    created_by_id = c.Int(nullable: false),
                    created_utc = c.DateTime(nullable: false),
                    updated_by_id = c.Int(nullable: false),
                    updated_utc = c.DateTime(nullable: false),
                    product_hive_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.product_hive_section_id)
                .ForeignKey("dbo.product_hives", t => t.product_hive_id, cascadeDelete: true)
                .Index(t => t.product_hive_id);

            CreateTable(
                "dbo.product_store_items",
                c => new
                {
                    product_store_item_id = c.Int(nullable: false, identity: true),
                    product_store_item_product_id = c.Int(nullable: false),
                    product_store_item_hive_section_id = c.Int(nullable: false),
                    product_store_item_quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.product_store_item_id)
                .ForeignKey("dbo.product_hive_sections", t => t.product_store_item_hive_section_id, cascadeDelete: true)
                .ForeignKey("dbo.catalogue_products", t => t.product_store_item_product_id, cascadeDelete: true)
                .Index(t => t.product_store_item_product_id)
                .Index(t => t.product_store_item_hive_section_id);

            CreateTable(
                "dbo.product_hives",
                c => new
                {
                    product_hive_id = c.Int(nullable: false, identity: true),
                    product_hive_name = c.String(nullable: false, maxLength: 60),
                    product_hive_code = c.String(nullable: false, maxLength: 5),
                    product_hive_address = c.String(nullable: false, maxLength: 300),
                    deleted = c.Boolean(nullable: false),
                    created_by_id = c.Int(nullable: false),
                    created_utc = c.DateTime(nullable: false),
                    updated_by_id = c.Int(nullable: false),
                    updated_utc = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.product_hive_id);

            CreateTable(
                "dbo.customer_records",
                c => new
                {
                    customer_id = c.Int(nullable: false, identity: true),
                    customer_name = c.String(),
                    customer_address = c.String(),
                    customer_phone = c.String(),
                })
                .PrimaryKey(t => t.customer_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.catalogue_products", "product_category_id", "dbo.product_categories");
            DropForeignKey("dbo.product_hive_section_categories", "product_hive_section_id", "dbo.product_hive_sections");
            DropForeignKey("dbo.product_hive_sections", "product_hive_id", "dbo.product_hives");
            DropForeignKey("dbo.product_store_items", "product_store_item_product_id", "dbo.catalogue_products");
            DropForeignKey("dbo.product_store_items", "product_store_item_hive_section_id", "dbo.product_hive_sections");
            DropForeignKey("dbo.product_hive_section_categories", "product_category_id", "dbo.product_categories");
            DropIndex("dbo.product_store_items", new[] { "product_store_item_hive_section_id" });
            DropIndex("dbo.product_store_items", new[] { "product_store_item_product_id" });
            DropIndex("dbo.product_hive_sections", new[] { "product_hive_id" });
            DropIndex("dbo.product_hive_section_categories", new[] { "product_hive_section_id" });
            DropIndex("dbo.product_hive_section_categories", new[] { "product_category_id" });
            DropIndex("dbo.product_categories", new[] { "category_code" });
            DropIndex("dbo.catalogue_products", new[] { "product_category_id" });
            DropIndex("dbo.catalogue_products", new[] { "product_code" });
            DropTable("dbo.customer_records");
            DropTable("dbo.product_hives");
            DropTable("dbo.product_store_items");
            DropTable("dbo.product_hive_sections");
            DropTable("dbo.product_hive_section_categories");
            DropTable("dbo.product_categories");
            DropTable("dbo.catalogue_products");
        }
    }
}
