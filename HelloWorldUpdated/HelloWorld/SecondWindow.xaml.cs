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
using System.Windows.Shapes;
using HelloWorld;
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        
        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<HelloWorld.User>();

            users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;

            
        }

        private void uxNameListColumnHeader_Click(object sender, RoutedEventArgs e)
        {            
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
           // if (uxList.ItemsSource.(0)name == "Dave") { ListSortDirection.Ascending} else { ListSortDirection.Ascending};
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));         
        }

        private void uxPswdListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Descending));
        }
    }

    
}
