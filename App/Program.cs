// See https://aka.ms/new-console-template for more information

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                var product = new Product(){ Price = 100, Description = "Movie" };
                if(product != null)
                {
                    var item = new OrderItem
                    {
                        Quantity = 1,
                        Product = product
                    };
                    db.OrderItems.Add(item);
                    db.SaveChanges();
                    Console.WriteLine("{0} {1} Product: {2}", item.OrderItemId, item.Quantity, item.Product.Description);
                }
            }

        }
        private static void crearProducto()
        {
            using (var db = new DatabaseContext())
            {
    
                var product = new Product(){ Price = 100, Description = "Movie" };
                db.Products.Add(product);
                db.SaveChanges();

                foreach(var p in db.Products) 
                {
                    Console.WriteLine("{0} {1} {2}", p.ProductId, p.Description, p.Price);
                }            
            }
        }
        private static void actualizarProducto()
        {
            using(var db = new DatabaseContext()) 
            {
                var item = db.OrderItems.SingleOrDefault();
                item.Quantity++;
                db.SaveChanges();
            }
        }
        private static void eliminarProducto()
        {
            using(var db = new DatabaseContext()) 
            {
                var product = db.Products.SingleOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}

