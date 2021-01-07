using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace OtoGalari_otomasyonu
{
    class SqlDatabase
    {
        SqlConnection connection;

        public SqlDataReader Reader(string commandStr)
        {
            Connect();

            SqlCommand command = new SqlCommand(commandStr, connection);

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
        public void Add_Update_Delete(string commandStr)
        {
            Connect();

            SqlCommand command = new SqlCommand(commandStr, connection);

            command.ExecuteNonQuery();

            Disconnect();
        }
        public void ImageUpdate(byte[] ImageByte, int id)
        {
            Connect();

            SqlCommand command = new SqlCommand("UPDATE Arac_ilanlar SET Resim = @resim WHERE Ilan_id = @id", connection);
            command.Parameters.AddWithValue("@resim", SqlDbType.Image).Value = ImageByte;
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();

            Disconnect();
        }

        private void Connect() // Bağlantı metodu veri tabanıyla olan bağlantıyı açıyor.
        {
            string connectionStr = "Data Source=MONSTER;Initial Catalog=OtogaleriOtomasyonu;Integrated Security=True";

            connection = new SqlConnection(connectionStr);

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
                Debug.WriteLine("Database bağlantısı açıldı");
            }
        }
        public void Disconnect() // Bağlantı kesme metodu veri tabanıyla olan bağlantıyı kesiyor.
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Debug.WriteLine("Database bağlantısı kapatıldı");
            }
        }
    }
}
