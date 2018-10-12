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
using System.Text.RegularExpressions;

namespace Algorithms
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CheckInput())
            {
                List<int> numbers = new List<int>();
                string input = txtInput.Text;
                while(input.Contains(","))
                {
                    string tmp;
                    tmp = input.Substring(0, txtInput.Text.IndexOf(","));
                    numbers.Add(Convert.ToInt32(tmp));
                    input = input.Substring(tmp.Length + 1);
                }
                numbers.Add(Convert.ToInt32(input));

                txtResult.Text = Convert.ToString(cmbAlgorithm.SelectedIndex);

                switch(cmbAlgorithm.SelectedIndex.ToString())
                {
                    case "0":
                        numbers.Sort(Bubble);
                        txtResult.Text = "";
                        for(int i = 0; i < numbers.Count - 1; i++)
                        {
                            txtResult.Text += numbers[i] + ", ";
                        }
                        txtResult.Text += numbers[numbers.Count - 1];
                        break;
                    case "1":
                        Insert(numbers);
                        break;
                    case "2":
                        Chose(numbers);
                        break;
                    case "3":
                        Merge(numbers);
                        break;
                    case "4":
                        Heap(numbers);
                        break;
                    case "5":
                        Quick(numbers);
                        break;
                }
            }

        }

        bool CheckInput()
        {
            bool result = true;
            txtResult.Text = "";
            Regex r1 = new Regex("[a-zA-Z]");
            Regex r2 = new Regex("[0-9]");
            if(r1.IsMatch(txtInput.Text)||txtInput.Text=="")
            {
                txtResult.Text = "Wprowadź liczby.";
                result = false;
            }
            else if(!r2.IsMatch(Convert.ToString(txtInput.Text.Last())))
            {
                txtResult.Text = "Na końcu musi znajdować się liczba.";
                result = false;
            }
            return result;
        }

        public static int Bubble(int x, int y)
        {
            if (x == 0)
            {
                if (y == 0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == 0)
                {
                    return 1;
                }
                else
                {
                    int val = x.CompareTo(y);


                    if (val != 0)
                    {
                        return val;
                    }
                    else
                    {
                        return x.CompareTo(y);
                    }
                }
            }
        }

        void Chose(List<int> numbers)
        {

        }

        void Insert(List<int> numbers)
        {

        }
        
        void Merge(List<int> numbers)
        {

        }

        void Heap(List<int> numbers)
        {

        }

        void Quick(List<int> numbers)
        {

        }
    }
}
