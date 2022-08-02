using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestbuyPractices
{

    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, price, categoryID) " +
                                "VALUES (@pName, @pprice, @pcategoryID);",
             new { pName = name, pprice = price, @pcategoryID = categoryID });
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("Delete From products "+
                                "WHERE ProductID = @pID ;",
             new {pID = productID });
        }
        public void UpdateProduct(string name, double price, int productID)
        {
            _connection.Execute("UPDATE products " +
                                "SET Name = @pName, price = @pprice" +
                                "WHERE ProductID = @pID ;",
             new { pName = name, pprice = price, pID = productID });
        }
    }
}
