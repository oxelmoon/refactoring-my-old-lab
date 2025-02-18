using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Помилка введення значення!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalculateExpression(double x, double y, double z)
        {
            return 1 + Math.Sin(x + y) / Math.Abs((z - 2 * x) / (1 + x * x * y * y)) * Math.Pow(x, Math.Abs(y)) + Math.Tan(1 / z);
        }
    }
}
