namespace NicaWallet.Migrations
{
    using NicaWallet.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NicaWallet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NicaWallet.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Category.AddOrUpdate(
              p => p.CategoryId,
              new Category { CategoryName = "Comidas y Bebidas", IsParent = true, CategoryIcon = "category-icon-restaurant-filled" },
              new Category { CategoryName = "Compras", IsParent = true, CategoryIcon = "category-icon-shopping-bag-filled" },
              new Category { CategoryName = "Viajes", IsParent = true, CategoryIcon = "category-icon-car-filled" },
              new Category { CategoryName = "Automovil", IsParent = true, CategoryIcon = "category-icon-airplane-mode-on-filled" },
              new Category { CategoryName = "Vida & Entretenimiento", IsParent = true, CategoryIcon = "category-icon-man-filled" },
              new Category { CategoryName = "Finanzas", IsParent = true, CategoryIcon = "category-icon-billing-filled" },
              new Category { CategoryName = "Ingresos", IsParent = true, CategoryIcon = "category-icon-coins-filled" },
              new Category { CategoryName = "Otros", IsParent = true, CategoryIcon = "category-icon-menu-filled" }
            );
            context.AccountType.AddOrUpdate(
                p => p.AccountTypeId,
                new AccountType { AccountTypeName = "Corriente", AccountIcon="category-icon-billing-filled" },
                new AccountType { AccountTypeName = "Ahorro", AccountIcon= "category-icon-money-bag-filled" }
            );
            context.Currency.AddOrUpdate(
             p => p.CurrencyId,
             new Currency { CurrencyName = "C$", IsBaseCurrency = true }
             //new Currency { CurrencyName = "$", IsBaseCurrency = false }
         );

        }
    }
}
