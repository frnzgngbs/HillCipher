using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace encryption
{
    public partial class Form1 : Form
    {

        private static readonly int[,] key = { { 3, 3 }, { 2, 5 } };
        private static readonly int[,] inverseKey;

        static Form1()
        {
            int determinant = (key[0, 0] * key[1, 1] - key[0, 1] * key[1, 0]) % 256;
            if (determinant < 0) determinant += 256;

            int determinantInverse = ModInverse(determinant, 256);

            inverseKey = new int[2, 2];
            inverseKey[0, 0] = (key[1, 1] * determinantInverse) % 256;
            inverseKey[0, 1] = (-key[0, 1] * determinantInverse) % 256;
            inverseKey[1, 0] = (-key[1, 0] * determinantInverse) % 256;
            inverseKey[1, 1] = (key[0, 0] * determinantInverse) % 256;

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (inverseKey[i, j] < 0) inverseKey[i, j] += 256;
        }

        public Form1()

        {

            InitializeComponent();

        }

        private static byte[] Encrypt(byte[] data)
        {
            int paddedLength = data.Length + (data.Length % 2);
            byte[] encryptedData = new byte[paddedLength];

            Span<byte> dataSpan = data;
            Span<byte> encryptedSpan = encryptedData;

            for (int i = 0; i < data.Length - 1; i += 2)
            {
                int x = dataSpan[i];
                int y = dataSpan[i + 1];

                encryptedSpan[i] = (byte)((key[0, 0] * x + key[0, 1] * y) % 256);
                encryptedSpan[i + 1] = (byte)((key[1, 0] * x + key[1, 1] * y) % 256);
            }

            if (data.Length % 2 != 0)
            {
                int x = dataSpan[data.Length - 1];
                int y = 0; // Padding

                encryptedSpan[data.Length - 1] = (byte)((key[0, 0] * x + key[0, 1] * y) % 256);
                encryptedSpan[data.Length] = (byte)((key[1, 0] * x + key[1, 1] * y) % 256);
            }

            return encryptedData;
        }

        private static byte[] Decrypt(byte[] data)
        {
            if (data.Length % 2 != 0)
                throw new ArgumentException("Encrypted data length must be even");

            byte[] decryptedData = new byte[data.Length];
            Span<byte> dataSpan = data;
            Span<byte> decryptedSpan = decryptedData;

            for (int i = 0; i < data.Length; i += 2)
            {
                int x = dataSpan[i];
                int y = dataSpan[i + 1];

                decryptedSpan[i] = (byte)((inverseKey[0, 0] * x + inverseKey[0, 1] * y) % 256);
                decryptedSpan[i + 1] = (byte)((inverseKey[1, 0] * x + inverseKey[1, 1] * y) % 256);
            }

            return decryptedData;
        }

        private static int ModInverse(int a, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            while (a > 1)
            {
                int q = a / m;
                (a, m) = (m, a % m);
                (x, y) = (y, x - q * y);
            }

            return x < 0 ? x + m0 : x;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new()
            {
                Title = "Select a File to Encrypt",
                Filter = "All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    byte[] fileData = await File.ReadAllBytesAsync(filePath);
                    byte[] encryptedData = Encrypt(fileData);
                    await File.WriteAllBytesAsync(filePath, encryptedData);
                    MessageBox.Show("File encrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new()
            {
                Title = "Select an Encrypted File",
                Filter = "All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    byte[] encryptedData = await File.ReadAllBytesAsync(filePath);
                    byte[] decryptedData = Decrypt(encryptedData);
                    await File.WriteAllBytesAsync(filePath, decryptedData);
                    MessageBox.Show("File decrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
