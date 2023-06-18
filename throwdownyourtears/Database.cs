using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web;
using System.Windows.Controls.Primitives;
using MySql.Data.MySqlClient;
using throwdownyourtears.list;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace throwdownyourtears
{
    internal class Database
    {
#pragma warning disable CS8618 // поле "connection", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        private Database() { }
#pragma warning restore CS8618 // поле "connection", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "instance", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        static Database instance;
#pragma warning restore CS8618 // поле "instance", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public static Database GetInstance()
        {
            if (instance == null)
                instance = new();
            return instance;
        }

        internal void AddData3(Product SelectedData)
        {
            if (OpenConnection())
            {
                string sql = $"UPDATE throwdownyourtears.products SET quantity = quantity + 1 WHERE id = " + SelectedData.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                

            };
            connection.Close();
        }

        internal void AddData2(Product SelectedData)
        {
            if (OpenConnection())
            {
                string sql = $"UPDATE throwdownyourtears.products SET productsales = productsales + 1 WHERE id = " + SelectedData.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                sql = $"UPDATE throwdownyourtears.products SET productgain = productgain + price WHERE id = " + SelectedData.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                sql = $"UPDATE throwdownyourtears.products SET quantity = quantity - 1 WHERE id = " + SelectedData.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                sql = $"UPDATE throwdownyourtears.products SET productgain2 = productgain2 + (price - PurchasePrice) WHERE id = " + SelectedData.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
            };
            connection.Close();
        }

        



        internal void EditData(Product edit)
        {
            if (OpenConnection())
            {
                string sql = "UPDATE throwdownyourtears.products SET Name = @Name WHERE id = " + edit.Id;
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("name", edit.Name),
                    new MySqlParameter("price", edit.Price),
                    new MySqlParameter("minimum", edit.Minimum),
                    new MySqlParameter("quantity", edit.Quantity),
                    new MySqlParameter("PurchasePrice", edit.PurchasePrice),
                    new MySqlParameter("productgain", edit.Productgain),
                    new MySqlParameter("productsales", edit.Productsales)
                };
                MySqlHelper.ExecuteNonQuery(connection, sql, parameters);


                connection.Close();
            }
        }


        internal void DeleteProduct(Product edit)
        {
            if (OpenConnection())
            {
                string sql = "DELETE FROM throwdownyourtears.productsprovider WHERE products_id = " + edit.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                sql = "DELETE FROM throwdownyourtears.productshop WHERE productid = " + edit.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                sql = "DELETE FROM throwdownyourtears.products WHERE id = " + edit.Id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
            };
            connection.Close();
        }

        internal void AddData(Product edit)
        {
            if (OpenConnection())
            {
                string sql = "INSERT INTO throwdownyourtears.products (name, price, minimum, quantity, PurchasePrice) VALUES (@Name, @Price, @Minimum, @Quantity, @PurchasePrice);";
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("name", edit.Name),
                    new MySqlParameter("price", edit.Price),
                    new MySqlParameter("minimum", edit.Minimum),
                    new MySqlParameter("quantity", edit.Quantity),
                    new MySqlParameter("PurchasePrice", edit.PurchasePrice),
                };
                MySqlHelper.ExecuteNonQuery(connection, sql, parameters);
                connection.Close();
            }
        }

        internal void AddData(Provider edit)
        {
            if (OpenConnection())
            {
                string sql = "INSERT INTO throwdownyourtears.provider (name, telegramid) VALUES (@Name, @Telegramid);";
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("name", edit.Name),
                    new MySqlParameter("telegramid", edit.Telegram),
                };
                MySqlHelper.ExecuteNonQuery(connection, sql, parameters);
                connection.Close();
            }
        }


        internal List<Shop>? GetShop()
        {
            List<Shop> shops = new List<Shop>();
            if (OpenConnection())
            {
                string sql = "select * from `shop`";
                using (var mc = new MySqlCommand(sql, connection))
                using (var reader = mc.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Shop product = new Shop()
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("Name")
                        };
                        shops.Add(product);
                    }
                }
                connection.Close();
            }
            return shops;
        }


        internal void UpdateProductShop(int id, List<int> ps)
        {
            if (OpenConnection())
            {
                string sql = "delete from productshop where productid = " + id;
                MySqlHelper.ExecuteNonQuery(connection, sql);
                sql = "";
                foreach (int i in ps)
                {
                    sql += $"insert into productshop (productid, shopid) values ({id}, {i});";
                }
                MySqlHelper.ExecuteNonQuery(connection, sql);
                connection.Close();
            }
        }

        bool OpenConnection()
        {
            if (connection == null)
                ConfigureConnection();
            try
            {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                connection.Open();
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public void TestConnection()
        {
            if (OpenConnection())
            {
                connection.Close();
                System.Windows.MessageBox.Show("Успешно");
            }
        }

        MySqlConnection connection;
        void ConfigureConnection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "1234512345";
            sb.Database = "throwdownyourtears";
            sb.CharacterSet = "utf8mb4";
            connection = new MySqlConnection(sb.ToString());
        }
    }
}
