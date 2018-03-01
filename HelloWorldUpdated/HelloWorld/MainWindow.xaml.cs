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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string inputPattern = "/[0-9a-zA-Z]/";
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;            
          //  Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            validateUserAndPswd();
            MessageBox.Show("Submitting Passord: " + uxPassword.Text);
        }

        public void validateUserAndPswd() {
            if (uxName.Text == " " || uxPassword.Text == " ")
            {
                MessageBox.Show("Pleae enter valid User and Pswd");
                uxSubmit.IsEnabled = false;
            }
            else { uxSubmit.IsEnabled = true; }
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxName.Text.Length > 0 & uxPassword.Text.Length > 0) { uxSubmit.IsEnabled = true; }
            else { uxSubmit.IsEnabled = false; }
           // if (uxName.Text == inputPattern & uxPassword.Text == inputPattern) { uxSubmit.IsEnabled = true; }
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxName.Text.Length > 0 & uxPassword.Text.Length > 0) { uxSubmit.IsEnabled = true; }
            else { uxSubmit.IsEnabled = false; }
        }

     
    }

   
}
