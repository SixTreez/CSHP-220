using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SixTreezTTT
{
 
    public partial class MainWindow : Window
    {
        public GameBoard MyGameBoard = new GameBoard();
        public MainWindow()
        {
            InitializeComponent();
        }
        //Reset the board to a new game
        private void UxNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        public void NewGame() {
            {//Restarts Game
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(uxGrid); i++) // This loop iterates through all the buttons/tiles in the grid and sets changed properties to default
                {
                    var child = VisualTreeHelper.GetChild(uxGrid, i) as Button;
                    child.Content = null;
                    child.IsHitTestVisible = true;
                    child.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
                }
                MyGameBoard = new GameBoard();
                this.DataContext = MyGameBoard;
                uxTurn.Text = "New Game";
                uxGrid.IsEnabled = true;                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            var tag = clickedButton.Tag.ToString();

            if (MyGameBoard.currentPlayer == GameBoard.CurrentPlayer.X)
            {
                clickedButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#811717"));
            }
            else if (MyGameBoard.currentPlayer == GameBoard.CurrentPlayer.O)
            {
                clickedButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#126712"));
            }
            clickedButton.Background = Brushes.WhiteSmoke;
            clickedButton.Content = MyGameBoard.currentPlayer;
            clickedButton.IsHitTestVisible = false;
            var name = MyGameBoard.currentPlayer.ToString();
            var tags = clickedButton.Tag.ToString();
             MyGameBoard.UpdateBoard(name, tags);
            if (MyGameBoard.HasWon)
            {
                uxTurn.Text = clickedButton.Content + " wins! Nice work.";
                uxGrid.IsEnabled = false;
            }            
        }

        //Exit's the application
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    public class GameBoard : System.ComponentModel.INotifyPropertyChanged
    {
        //Variables to be used
        public enum CurrentPlayer
        {
            X = 1,
            O
        }

        private int turn = 1;
        public CurrentPlayer currentPlayer = CurrentPlayer.X;
        private bool hasWon = false;
        public bool HasWon
        {
            get { return hasWon; }
            set { hasWon = value; NotifyPropertyChanged("HasWon"); }
        }

        private Dictionary<string, string> board = new Dictionary<string, string>() { }; //Will add tags to this dictionary as they are selected


        public void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(info));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;


        private bool IsThereAWinner(string buttonName)
        {
            if (WonInRow(buttonName))
            {
                return true;
            }
            else if (WonInColumn(buttonName))
            {
                return true;
            }
            else if (WonInDiagonal(buttonName))
            {
                return true;
            }
            else
                return false;
        }

        private bool WonInRow(string name)
        {
            //get just items that equal button name seleted
            var winner = from element in board
                         where name == element.Value
                         select element;

            //see if we have 3 in a row
            var row1 = winner.Where(x => x.Key.StartsWith("0"));
            var row2 = winner.Where(x => x.Key.StartsWith("1"));
            var row3 = winner.Where(x => x.Key.StartsWith("2"));

            if (row1.Count() == 3) return true;
            if (row2.Count() == 3) return true;
            if (row3.Count() == 3) return true;
            else return false;
        }

        private bool WonInColumn(string name)
        {

            //get just items that equal button name seleted
            var winner = from element in board
                         where name == element.Value
                         select element;

            //see if we have 3 in a column
            var col1 = winner.Where(x => x.Key.EndsWith("0"));
            var col2 = winner.Where(x => x.Key.EndsWith("1"));
            var col3 = winner.Where(x => x.Key.EndsWith("2"));

            if (col1.Count() == 3) return true;
            if (col2.Count() == 3) return true;
            if (col3.Count() == 3) return true;
            else return false;
        }

        private bool WonInDiagonal(string name)
        {
            //get just items that equal button name seleted
            //var option1 = from element in board
            //             where element.Key == ("0,0") && element.Key == ("1,1") && element.Key == ("2,2")                                        
            //             select element;
            //var option2 = from element in board
            //              where element.Key == ("0,2") && element.Key == ("1,1") && element.Key == ("2,0")
            //              select element;

            //var diag1 = option1.Where(x => x.Value == name);
            //var diag2 = option2.Where(x => x.Value == name); 

            int diagCount1 = 0;
            int diagCount2 = 0;
            foreach (var item in board) {
                if (item.Value == name &&
                    item.Key == "0,2" || item.Key == "1,1" || item.Key == "2,0")
                { diagCount1++; }
                if (item.Value == name &&
                    item.Key == "0,0" || item.Key == "1,1" || item.Key == "2,2")
                { diagCount2++; }
            }

            //see if we have 3 in a row           
            if (diagCount1 == 3) return true;
            if (diagCount2 == 3) return true;            
            else return false;
        }

        private void UpdateDictionary(string xOrY, string tags)
        {
            string tileName = xOrY;
            //board[tileName] = (int)currentPlayer;
            board.Add(tags, xOrY);
        }

        public void UpdateBoard(string xOrY, string tags)
        {
            UpdateDictionary(xOrY, tags);
            CheckTurn(xOrY);
        }

        public void CheckTurn(string buttonName)
        {
            if (turn >= 5)//Earliest turn a player can win
            {
                if (IsThereAWinner(buttonName))
                {
                    HasWon = true;
                }
            }

            turn++;        

            if (currentPlayer == CurrentPlayer.X)
                currentPlayer = CurrentPlayer.O;

            else if (currentPlayer == CurrentPlayer.O)
                currentPlayer = CurrentPlayer.X;
        }
    }

}



