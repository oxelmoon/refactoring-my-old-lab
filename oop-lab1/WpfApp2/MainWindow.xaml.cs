using System;
using System.Globalization;
using System.Windows;

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
                double a = double.Parse(textBoxA.Text, CultureInfo.CurrentCulture);
                double b = double.Parse(textBoxB.Text, CultureInfo.CurrentCulture);
                double c = double.Parse(textBoxC.Text, CultureInfo.CurrentCulture);

                CalculateRoots(a, b, c);
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення значення!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalculateRoots(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;
            textBoxDiscriminant.Text = $"Дискримінант: {discriminant:F3}";

            textBoxX1.Visibility = Visibility.Collapsed;
            textBoxX2.Visibility = Visibility.Collapsed;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                textBoxX1.Text = $"x1 = {x1:F3}";
                textBoxX2.Text = $"x2 = {x2:F3}";
                textBoxX1.Visibility = Visibility.Visible;
                textBoxX2.Visibility = Visibility.Visible;
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                textBoxX1.Text = $"x = {x:F3}";
                textBoxX1.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Розв'язків немає.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
