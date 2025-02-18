using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
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
                double a = double.Parse(textBoxA.Text, CultureInfo.CurrentCulture);
                double b = double.Parse(textBoxB.Text, CultureInfo.CurrentCulture);
                double c = double.Parse(textBoxC.Text, CultureInfo.CurrentCulture);

                CalculateRoots(a, b, c);
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення значення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateRoots(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;
            labelDiscriminant.Text = $"Дискримінант: {discriminant:F3}";

            textBoxX1.Visible = false;
            textBoxX2.Visible = false;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                textBoxX1.Text = $"x1 = {x1:F3}";
                textBoxX2.Text = $"x2 = {x2:F3}";
                textBoxX1.Visible = true;
                textBoxX2.Visible = true;
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                textBoxX1.Text = $"x = {x:F3}";
                textBoxX1.Visible = true;
            }
            else
            {
                MessageBox.Show("Розв'язків немає.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
