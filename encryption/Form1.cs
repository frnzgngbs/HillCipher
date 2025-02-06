using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace encryption
{
    public partial class Form1 : Form
    {

        private int[,] key = { { 3, 3 }, { 2, 5 } };

        public Form1()

        {

            InitializeComponent();

        }

        private byte[] Encrypt(byte[] data)
        {
            if (data.Length % 2 != 0)
            {
                Array.Resize(ref data, data.Length + 1); // Add padding if necessary
            }

            byte[] encryptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i += 2)
            {
                int[] vector = { data[i], data[i + 1] };
                int[] encryptedVector = new int[2];

                encryptedVector[0] = (key[0, 0] * vector[0] + key[0, 1] * vector[1]) % 256;
                encryptedVector[1] = (key[1, 0] * vector[0] + key[1, 1] * vector[1]) % 256;

                encryptedData[i] = (byte)encryptedVector[0];
                encryptedData[i + 1] = (byte)encryptedVector[1];
            }

            return encryptedData;
        }

        // Decrypt Raw Bytes Using Hill Cipher
        private byte[] Decrypt(byte[] data)
        {
            int determinant = (key[0, 0] * key[1, 1] - key[0, 1] * key[1, 0]) % 256;
            if (determinant < 0) determinant += 256;

            int determinantInverse = ModInverse(determinant, 256);

            int[,] inverseMatrix = {
                { (key[1, 1] * determinantInverse) % 256, (-key[0, 1] * determinantInverse) % 256 },
                { (-key[1, 0] * determinantInverse) % 256, (key[0, 0] * determinantInverse) % 256 }
            };

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (inverseMatrix[i, j] < 0) inverseMatrix[i, j] += 256;

            byte[] decryptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i += 2)
            {
                int[] vector = { data[i], data[i + 1] };
                int[] decryptedVector = new int[2];

                decryptedVector[0] = (inverseMatrix[0, 0] * vector[0] + inverseMatrix[0, 1] * vector[1]) % 256;
                decryptedVector[1] = (inverseMatrix[1, 0] * vector[0] + inverseMatrix[1, 1] * vector[1]) % 256;

                decryptedData[i] = (byte)decryptedVector[0];
                decryptedData[i + 1] = (byte)decryptedVector[1];
            }

            return decryptedData;
        }

        // Compute Modular Inverse for 256 (Byte-Level Math)
        private int ModInverse(int a, int m)
        {
            a %= m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            return 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a File to Encrypt",
                Filter = "All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileData = File.ReadAllBytes(filePath);
                byte[] encryptedData = Encrypt(fileData);

                File.WriteAllBytes(filePath, encryptedData); // Overwrite original file
                MessageBox.Show("File encrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Encrypted File",
                Filter = "All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] encryptedData = File.ReadAllBytes(filePath);
                byte[] decryptedData = Decrypt(encryptedData);

                File.WriteAllBytes(filePath, decryptedData); // Overwrite original file
                MessageBox.Show("File decrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
