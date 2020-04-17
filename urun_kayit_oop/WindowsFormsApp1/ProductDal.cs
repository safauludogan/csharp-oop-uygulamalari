using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(LocalDb)\MSSQLLocalDB;initial catalog=deneme;integrated security=false");

        public List<Product> GetAll()
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("select * from Products", _connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductName = reader["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();
            return products;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("insert into Products values(@name,@unitPrice,@stockAmount)", _connection);
            sqlCommand.Parameters.AddWithValue("@name", product.ProductName);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("update Products set ProductName=@name, UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            sqlCommand.Parameters.AddWithValue("@name", product.ProductName);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            sqlCommand.Parameters.AddWithValue("@id", product.Id);
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("delete from Products where @id=Id", _connection);
            sqlCommand.Parameters.AddWithValue("@id",id);
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
