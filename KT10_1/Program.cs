// 1.Напишите обобщенный интерфейс IRepository<T>, который содержит методы для работы
// с данными типа T: void Add(T item), void Delete(T item), T FindById(int id) и
// IEnumerable<T> GetAll(). Затем напишите ограничение для этого интерфейса, чтобы
// он мог работать только с типами, которые реализуют интерфейс IEntity, который
// содержит свойство Id типа int. Затем напишите классы Product и Customer, которые
// реализуют интерфейс IEntity и имеют свои свойства, такие как Name, Price, Address
// и т.д. Затем напишите классы ProductRepository и CustomerRepository, которые
// реализуют интерфейс IRepository<T> для типов Product и Customer соответственно и
// используют коллекцию типа List<T> для хранения данных.
using static KT10_1.Program;

namespace KT10_1;

class Program
{
    public interface IEntity
    {
        int Id { get; set; }

    }
    public interface IRepository<T> where T: IEntity
    {
        void Add(T item);
        void Delete(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
    }


    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
    public class Customer: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }


    public class ProductRepository: IRepository<Product>
    {
        private List<Product> _products = new List<Product>();

        public void Add(Product item)
        {
            _products.Add(item);
        }
        public void Delete(Product item)
        {
            _products.Remove(item);
        }
        public Product FindById(int id)
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

    }
    public class CustomerRepository: IRepository<Customer>
    {
        private List<Customer> _customers = new List<Customer>();

        public void Add(Customer item)
        {
            _customers.Add(item);
        }
        public void Delete(Customer item)
        {
            _customers.Remove(item);
        }

        public Customer FindById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }
    }
    static void Main(string[] args)
    {
        var productR = new ProductRepository();
        productR.Add(new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" });
        productR.Add(new Product { Id = 2, Name = "Book", Price = 19.99m, Category = "Education" });
        Console.WriteLine("Все Products:");
        foreach (var product in productR.GetAll())
        {
            Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Category}");
        }

        var customerR = new CustomerRepository();
        customerR.Add(new Customer { Id = 1, Name = "John", Surname= "Doe", Email = "john@email.com"});
        customerR.Add(new Customer { Id = 2, Name = "Jane", Surname = "Smith", Email = "jane@email.com"});
        Console.WriteLine("\nAll Customers:");
        foreach (var customer in customerR.GetAll())
        {
            Console.WriteLine($"{customer.Id}: {customer.Name} - {customer.Email}");
        }

        var foundProduct = productR.FindById(1);
        var foundCustomer = customerR.FindById(2);
        Console.WriteLine($"\nFound Product: {foundProduct?.Name}");
        Console.WriteLine($"Found Customer: {foundCustomer?.Name}");

    }
}
