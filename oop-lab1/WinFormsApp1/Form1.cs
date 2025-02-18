using System;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(textBoxX.Text, CultureInfo.CurrentCulture);
                double y = double.Parse(textBoxY.Text, CultureInfo.CurrentCulture);
                double z = double.Parse(textBoxZ.Text, CultureInfo.CurrentCulture);

                double result = CalculateExpression(x, y, z);
                textBoxResult.Text = result.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення значення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateExpression(double x, double y, double z)
        {
            return 1 + Math.Sin(x + y) / Math.Abs((z - 2 * x) / (1 + x * x * y * y)) * Math.Pow(x, Math.Abs(y)) + Math.Tan(1 / z);
        }
    }
}
