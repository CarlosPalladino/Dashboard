using Domain.Entities;
using Domain.Enums;
using Infrastructure.Configurartion;

namespace Infrastructure.Configuration
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Seed CLIENTES
            if (!context.Clients.Any())
            {
                var cliente1 = new Client(Guid.NewGuid(), "Acme Corp", 20123456789, "Av. Independencia 123");
                var cliente2 = new Client(Guid.NewGuid(), "Globant S.A.", 20987654321, "Calle Futura 456");
                context.Clients.AddRange(cliente1, cliente2);
                context.SaveChanges();
            }

            // Seed PROVEEDORES
            if (!context.Providers.Any())
            {
                var proveedor1 = new Provider(Guid.NewGuid(), "Tech Supplier", 30123456789, "contact@techsup.com");
                var proveedor2 = new Provider(Guid.NewGuid(), "Distribuciones Norte", 30987654321, "ventas@dnorte.com.ar");
                context.Providers.AddRange(proveedor1, proveedor2);
                context.SaveChanges();
            }

            // Seed PRODUCTOS
            if (!context.Products.Any())
            {
                var product1 = new Product("Mouse Logitech", 5500.50m, 100, true);
                var product2 = new Product("Teclado Redragon", 10500m, 60, true);
                var product3 = new Product("Monitor Samsung 24\"", 82000m, 20, true);
                context.Products.AddRange(product1, product2, product3);
                context.SaveChanges();
            }

            // Seed CONCILIACIONES
            if (!context.Conciliations.Any())
            {
                var conciliacion1 = new Conciliation(Guid.NewGuid(), DateTime.UtcNow.AddDays(-7), DateTime.UtcNow.AddDays(-1), "admin1", true);
                var conciliacion2 = new Conciliation(Guid.NewGuid(), DateTime.UtcNow.AddDays(-14), DateTime.UtcNow.AddDays(-8), "auditor2", false);
                context.Conciliations.AddRange(conciliacion1, conciliacion2);
                context.SaveChanges();
            }

            // Seed TRANSACCIONES
            if (!context.Transactions.Any())
            {
                // Para crear transacciones necesitamos clientes, proveedores y conciliaciones
                var cliente1 = context.Clients.FirstOrDefault();
                var cliente2 = context.Clients.Skip(1).FirstOrDefault();
                var proveedor1 = context.Providers.FirstOrDefault();
                var proveedor2 = context.Providers.Skip(1).FirstOrDefault();
                var conciliacion1 = context.Conciliations.FirstOrDefault();
                var conciliacion2 = context.Conciliations.Skip(1).FirstOrDefault();

                if (cliente1 != null && cliente2 != null && proveedor1 != null && proveedor2 != null && conciliacion1 != null && conciliacion2 != null)
                {
                    var transaccion1 = new Transaction(Guid.NewGuid(), DateTime.UtcNow.AddDays(-2), cliente1.Id, proveedor1.Id, conciliacion1.Id, "Compra mensual", TransactionType.Venta);
                    var transaccion2 = new Transaction(Guid.NewGuid(), DateTime.UtcNow.AddDays(-10), cliente2.Id, proveedor2.Id, conciliacion2.Id, "Compra especial", TransactionType.Compra);
                    context.Transactions.AddRange(transaccion1, transaccion2);
                    context.SaveChanges();
                }
            }

            // Seed DETALLES DE TRANSACCIÓN
            if (!context.TransactionDetails.Any())
            {
                var transaccion1 = context.Transactions.FirstOrDefault();
                var transaccion2 = context.Transactions.Skip(1).FirstOrDefault();
                var product1 = context.Products.FirstOrDefault();
                var product2 = context.Products.Skip(1).FirstOrDefault();
                var product3 = context.Products.Skip(2).FirstOrDefault();

                if (transaccion1 != null && transaccion2 != null && product1 != null && product2 != null && product3 != null)
                {
                    var detalle1 = new TransactionDetail(Guid.NewGuid(), transaccion1.Id, product1.Id, 2, product1.ReferenceAmount, (int)(2 * product1.ReferenceAmount));
                    var detalle2 = new TransactionDetail(Guid.NewGuid(), transaccion1.Id, product2.Id, 1, product2.ReferenceAmount, (int)(1 * product2.ReferenceAmount));
                    var detalle3 = new TransactionDetail(Guid.NewGuid(), transaccion2.Id, product2.Id, 2, product2.ReferenceAmount, (int)(2 * product2.ReferenceAmount));
                    var detalle4 = new TransactionDetail(Guid.NewGuid(), transaccion2.Id, product3.Id, 1, product3.ReferenceAmount, (int)(1 * product3.ReferenceAmount));
                    context.TransactionDetails.AddRange(detalle1, detalle2, detalle3, detalle4);
                    context.SaveChanges();
                }
            }

            // Seed PRODUCTOS-PROVEEDORES
            if (!context.Product_Providers.Any())
            {
                var product1 = context.Products.FirstOrDefault();
                var product2 = context.Products.Skip(1).FirstOrDefault();
                var product3 = context.Products.Skip(2).FirstOrDefault();
                var proveedor1 = context.Providers.FirstOrDefault();
                var proveedor2 = context.Providers.Skip(1).FirstOrDefault();

                if (product1 != null && product2 != null && product3 != null && proveedor1 != null && proveedor2 != null)
                {
                    var pp1 = new Product_Provider(product1.Id, proveedor1.Id, 5000m, DateTime.UtcNow.AddDays(-5));
                    var pp2 = new Product_Provider(product2.Id, proveedor1.Id, 10000m, DateTime.UtcNow.AddDays(-6));
                    var pp3 = new Product_Provider(product3.Id, proveedor2.Id, 80000m, DateTime.UtcNow.AddDays(-9));
                    context.Product_Providers.AddRange(pp1, pp2, pp3);
                    context.SaveChanges();
                }
            }
        }
    }
}
