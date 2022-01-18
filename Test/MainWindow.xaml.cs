using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /// Настройка стиля кнопок
            Uri uri = new Uri("ButtonStyle.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            textBox.Text += button.Content.ToString();
        }

        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception)
            {
                textBox.Text = "Ошибка";
            }
        }

        private void Result()
        {
            //Обравботка символов

            string res;
            int result = 0;
            if (textBox.Text.Contains("+"))
            {
                result = textBox.Text.IndexOf("+");
            }
            else if (textBox.Text.Contains("-"))
            {
                result = textBox.Text.IndexOf("-");
            }
            else if (textBox.Text.Contains("*"))
            {
                result = textBox.Text.IndexOf("*");
            }
            else if (textBox.Text.Contains("/"))
            {
                result = textBox.Text.IndexOf("/");
            }
          

            //Арифметическая обработка

            res = textBox.Text.Substring(result, 1);
            double x = Convert.ToDouble(textBox.Text.Substring(0, result));
            double y = Convert.ToDouble(textBox.Text.Substring(result + 1, textBox.Text.Length - result - 1));

            if (res == "+")
            {
                textBox.Text = Convert.ToString(x + y);
            }
            else if (res == "-")
            {
                textBox.Text = Convert.ToString(x - y);
            }
            else if (res == "*")
            {
                textBox.Text = Convert.ToString(x * y);
            }
            else
            {
                textBox.Text = Convert.ToString(x / y);
            }
        }
        //Настройка функций кнопок

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
        }
    }
}
