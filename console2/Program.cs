using System;
using System.Data;
using System.Data.SqlClient;

namespace RentalAlatKemah
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            SqlConnection conn = null;

            while (true)
            {
                try
                {
                    Console.Write("\nKetik K untuk Terhubung ke database, E untuk keluar dari aplikasi, M untuk mengedit:  ");
                    char chr = Console.ReadKey().KeyChar;
                    switch (chr)
                    {
                        case 'K':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan nama database yang dituju kemudian klik Enter: ");
                                string db = Console.ReadLine();
                                string strKoneksi = $"Data Source=DESKTOP-4KVEAKA\\TIARAHASNABILA;Initial Catalog={db};User ID=sa;Password=12345";
                                conn = new SqlConnection(strKoneksi);
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Mengelola Data Barang");
                                        Console.WriteLine("2. Mengelola Data Penyewa");
                                        Console.WriteLine("3. Mengelola Data Sewa");
                                        Console.WriteLine("4. Keluar");
                                        Console.WriteLine("\nMasukkan pilihan Anda (1-4): ");
                                        char ch = Console.ReadKey().KeyChar;
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    pr.MenuDataBarang(conn);
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    pr.MenuDataPenyewa(conn);
                                                }
                                                break;
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    pr.MenuDataSewa(conn);
                                                }
                                                break;
                                            case '4':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nPilihan tidak valid");
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Tidak dapat mengakses database tersebut: {ex.Message}\n");
                                        Console.ResetColor();
                                    }
                                }
                            }
                        case 'E':
                            return;
                        case 'M':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan data barang yang ingin di edit\n");
                                string kodeBarang = Console.ReadLine();
                                pr.EditData(kodeBarang, conn);
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tidak dapat mengakses database tersebut: {ex.Message}\n");
                    Console.ResetColor();
                }
            }
        }

        public void MenuDataBarang(SqlConnection conn)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMengelola Data Barang");
                    Console.WriteLine("1. Melihat Seluruh Data Barang");
                    Console.WriteLine("2. Tambah Data Barang");
                    Console.WriteLine("3. Hapus Data Barang");
                    Console.WriteLine("4. Edit Data Barang");
                    Console.WriteLine("5. Kembali");
                    Console.WriteLine("\nMasukkan pilihan Anda (1-5): ");
                    char ch = Console.ReadKey().KeyChar;
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("Tabel Barang\n");
                                Console.WriteLine();
                                this.ReadData(conn, "Tabel Barang");
                            }
                            break;
                        case '2':
                            {
                                Console.Clear();
                                Console.WriteLine("Input Data Barang\n");
                                Console.WriteLine("Masukkan Kode Barang :");
                                string Kd_Brg = Console.ReadLine();
                                Console.WriteLine("Masukkan Nama Barang :");
                                string Nama_Brg = Console.ReadLine();
                                Console.WriteLine("Masukkan Jenis Barang :");
                                string Jenis_Brg = Console.ReadLine();

                                try
                                {
                                    this.InsertDataBarang(Kd_Brg, Nama_Brg, Jenis_Brg, conn);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n Anda tidak memiliki " +
                                        "akses untuk menambah data");
                                    Console.WriteLine(e.ToString());
                                }
                            }
                            break;
                        case '3':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan Kode Barang yang ingin dihapus\n");
                                string Kd_Brg = Console.ReadLine();
                                try
                                {
                                    this.DeleteData(Kd_Brg, conn, "Tabel Barang");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nAnda tidak memiliki " +
                                        "akses untuk menghapus data atau Data yang Anda masukkan salah");
                                    Console.WriteLine(e.ToString());
                                }
                            }
                            break;
                        case '4':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan Kode Barang yang ingin di edit\n");
                                string kodeBarang = Console.ReadLine();
                                this.EditData(kodeBarang, conn);
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\nPilihan tidak valid");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\nPeriksa nilai yang dimasukkan.");
                }
            }
        }

        public void MenuDataPenyewa(SqlConnection conn)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu Pengelolaan Data Penyewa");
                    Console.WriteLine("1. Melihat Seluruh Data Penyewa");
                    Console.WriteLine("2. Tambah Data Penyewa");
                    Console.WriteLine("3. Hapus Data Penyewa");
                    Console.WriteLine("4. Edit Data Penyewa");
                    Console.WriteLine("5. Kembali");
                    Console.WriteLine("\nMasukkan pilihan Anda (1-5): ");
                    char ch = Console.ReadKey().KeyChar;
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("Tabel Penyewa\n");
                                Console.WriteLine();
                                this.ReadData(conn, "Tabel Penyewa");
                            }
                            break;
                        case '2':
                            {
                                Console.Clear();
                                Console.WriteLine("Input Data Penyewa\n");
                                Console.WriteLine("Masukkan NIK Penyewa :");
                                string NIK_Penyewa = Console.ReadLine();
                                Console.WriteLine("Masukkan Kode Barang :");
                                string Kd_Brg = Console.ReadLine();
                                Console.WriteLine("Masukkan Nama Penyewa :");
                                string Nama_Penyewa = Console.ReadLine();
                                Console.WriteLine("Masukkan Nomor Telepon Penyewa :");
                                string No_Telpon = Console.ReadLine();

                                try
                                {
                                    this.InsertDataPenyewa(NIK_Penyewa, Kd_Brg, Nama_Penyewa, No_Telpon, conn);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n Anda tidak memiliki " +
                                        "akses untuk menambah data");
                                    Console.WriteLine(e.ToString());
                                }
                            }
                            break;
                        case '3':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan NIK Penyewa yang ingin dihapus\n");
                                string NIK_Penyewa = Console.ReadLine();
                                try
                                {
                                    this.DeleteData(NIK_Penyewa, conn, "Tabel Penyewa");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nAnda tidak memiliki " +
                                        "akses untuk menghapus data atau Data yang Anda masukkan salah");
                                    Console.WriteLine(e.ToString());
                                }
                            }
                            break;
                        case '4':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan NIK Penyewa yang ingin di edit\n");
                                string NIK_Penyewa = Console.ReadLine();
                                this.EditData(NIK_Penyewa, conn);
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\nPilihan tidak valid");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\nPeriksa nilai yang dimasukkan.");
                }
            }
        }

        public void MenuDataSewa(SqlConnection conn)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu Pengelolaan Data Sewa");
                    Console.WriteLine("1. Melihat Seluruh Data Sewa");
                    Console.WriteLine("2. Tambah Data Sewa");
                    Console.WriteLine("3. Hapus Data Sewa");
                    Console.WriteLine("4. Edit Data Sewa");
                    Console.WriteLine("5. Kembali");
                    Console.WriteLine("\nMasukkan pilihan Anda (1-5): ");
                    char ch = Console.ReadKey().KeyChar;
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("Tabel Sewa\n");
                                Console.WriteLine();
                                this.ReadData(conn, "Tabel Sewa");
                            }
                            break;
                        case '2':
                            {
                                Console.Clear();
                                Console.WriteLine("Input Data Sewa\n");
                                Console.WriteLine("Masukkan ID Sewa :");
                                string ID_Sewa = Console.ReadLine();
                                Console.WriteLine("Masukkan NIK Penyewa :");
                                string NIK_Penyewa = Console.ReadLine();
                                Console.WriteLine("Masukkan Kode Barang :");
                                string Kd_Brg = Console.ReadLine();
                                Console.WriteLine("Masukkan Jenis Sewa :");
                                string Jenis_Sewa = Console.ReadLine();
                                Console.WriteLine("Masukkan Tanggal Sewa :");
                                string Tgl_Sewa = Console.ReadLine();
                                try
                                {
                                    this.InsertDataSewa(ID_Sewa, NIK_Penyewa, Kd_Brg, Jenis_Sewa, Tgl_Sewa, conn);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n Anda tidak memiliki " +
                                        "akses untuk menambah data");
                                    Console.WriteLine(e.ToString());
                                }
                            }
                            break;
                        case '3':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan ID Sewa yang ingin dihapus\n");
                                string ID_Sewa = Console.ReadLine();
                                try
                                {
                                    this.DeleteData(ID_Sewa, conn, "Tabel Sewa");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nAnda tidak memiliki " +
                                        "akses untuk menghapus data atau Data yang Anda masukkan salah");
                                    Console.WriteLine(e.ToString());
                                }
                            }
                            break;
                        case '4':
                            {
                                Console.Clear();
                                Console.WriteLine("Masukkan ID Sewa yang ingin di edit\n");
                                string ID_Sewa = Console.ReadLine();
                                this.EditData(ID_Sewa, conn);
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\nPilihan tidak valid");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\nPeriksa nilai yang dimasukkan.");
                }
            }
        }

        public void ReadData(SqlConnection conn, string tableName)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [{tableName}]", conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close(); // Tutup pembaca data setelah selesai membaca
        }

        public void InsertDataBarang(string Kd_Brg, string Nama_Brg, string Jenis_Brg, SqlConnection con)
        {
            string str = "INSERT INTO [Tabel Barang] (Kd_Brg, Nama_Brg, Jenis_Brg) " +
                         "VALUES (@kd, @nm, @jns)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@kd", Kd_Brg));
            cmd.Parameters.Add(new SqlParameter("@nm", Nama_Brg));
            cmd.Parameters.Add(new SqlParameter("@jns", Jenis_Brg));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        public void InsertDataPenyewa(string NIK_Penyewa, string Kd_Brg, string Nama_Penyewa, string No_Telpon, SqlConnection con)
        {
            string str = "INSERT INTO [Tabel Penyewa] (NIK_Penyewa,Kd_Brg, Nama_Penyewa, No_Telpon) " +
                         "VALUES (@nik,@kd, @nmP, @noTlp)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@nik", NIK_Penyewa));
            cmd.Parameters.Add(new SqlParameter("@kd", Kd_Brg));
            cmd.Parameters.Add(new SqlParameter("@nmP", Nama_Penyewa));
            cmd.Parameters.Add(new SqlParameter("@noTlp", No_Telpon));

            // Tidak perlu membaca data, cukup jalankan ExecuteNonQuery
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        public void InsertDataSewa(string ID_Sewa, string NIK_Penyewa, string Kd_Brg, string Jenis_Sewa, string Tgl_Sewa, SqlConnection con)
        {
            string str = "INSERT INTO [Tabel Sewa] (ID_Sewa,NIK_Penyewa,Kd_Brg,Jenis_Sewa,Tgl_Sewa) " +
                         "VALUES (@id,@nik, @kd, @jnss, @tgl)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", ID_Sewa));
            cmd.Parameters.Add(new SqlParameter("@nik", NIK_Penyewa));
            cmd.Parameters.Add(new SqlParameter("@kd", Kd_Brg));
            cmd.Parameters.Add(new SqlParameter("@jnss", Jenis_Sewa));
            cmd.Parameters.Add(new SqlParameter("@tgl", Tgl_Sewa));

            // Tidak perlu membaca data, cukup jalankan ExecuteNonQuery
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        public void DeleteData(string id, SqlConnection con, string tableName)
        {
            string str = $"DELETE FROM [{tableName}] WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", id));

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                Console.WriteLine("Data Berhasil Dihapus");
            else
                Console.WriteLine("Data Tidak Ditemukan");
        }

        public void EditData(string id, SqlConnection con)
        {
            string str = $"SELECT * FROM [Tabel Barang] WHERE Kd_Brg = @id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                r.Close();
                Console.WriteLine("Masukkan Nama Barang Baru :");
                string Nama_Brg = Console.ReadLine();
                Console.WriteLine("Masukkan Jenis Barang Baru :");
                string Jenis_Brg = Console.ReadLine();

                str = $"UPDATE [Tabel Barang] SET Nama_Brg = @nm, Jenis_Brg = @jns WHERE Kd_Brg = @id";
                cmd = new SqlCommand(str, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@nm", Nama_Brg));
                cmd.Parameters.Add(new SqlParameter("@jns", Jenis_Brg));
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Berhasil Diubah");
            }
            else
            {
                r.Close();
                Console.WriteLine("Data Tidak Ditemukan");
            }
        }
    }
}
