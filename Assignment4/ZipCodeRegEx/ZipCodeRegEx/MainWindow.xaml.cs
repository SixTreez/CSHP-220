//Andrew Molloy
//Assignment 4

using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;


namespace ZipCodeRegEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnSubmit.IsEnabled = false; //disable button upon initialization       
        }
           
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var usRegExPattern = @"^\d{5}(?:[-\s]\d{4})?$"; // declare US regex pattern          
            var caRegExPattern = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$"; //declare Canada regex pattern
            var validZipCode = ((Regex.Match(tbZip.Text, usRegExPattern).Success || Regex.Match(tbZip.Text, caRegExPattern).Success)) ? true : false; //set true or false upon text change
            btnSubmit.IsEnabled = validZipCode; //update btn enabled property           
        }
    }
}
