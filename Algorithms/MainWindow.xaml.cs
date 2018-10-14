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
            //if(CheckInput())
            if(true)
            {
                List<int> numbers = new List<int>();
                string input = "12,51,81,61,26,38,61,74,26,3,15,73,31,63,96"; //txtInput.Text;
                txtResult.Text = "";

                while (input.Contains(","))
                {
                    string tmp;
                    tmp = input.Substring(0, input.IndexOf(","));
                    numbers.Add(Convert.ToInt32(tmp));
                    input = input.Substring(tmp.Length + 1);
                }
                numbers.Add(Convert.ToInt32(input));

                switch(cmbAlgorithm.SelectedIndex.ToString())
                {
                    case "0":
                        numbers = Bubble(numbers);
                        break;
                    case "1":
                        numbers = Insert(numbers);
                        break;
                    case "2":
                        numbers = Chose(numbers);
                        break;
                    case "3":
                        numbers = Merge(numbers);
                        break;
                    case "4":
                        numbers = Heap(numbers);
                        break;
                    case "5":
                        numbers = Quick(numbers);
                        break;
                }

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    txtResult.Text += numbers[i] + ", ";
                }

                txtResult.Text += numbers[numbers.Count - 1];
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

        List<int> Bubble(List<int> x)
        {
            int n = x.Count;
            do
            {
                for(int i = 0; i <n - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int tmp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
            return x;
        }

        List<int> Insert(List<int> x)
        {
            int n = x.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int j = i;
                while (j>-1 && x[j] > x[j + 1])
                {
                    int tmp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = tmp;
                    j--;
                }
            }
            return x;
        }

        List<int> Chose(List<int> x)
        {
            List<int> output = new List<int>();
            for (int i = x.Count - 1; i > -1 ; i--)
            {
                output.Add(x.Min());
                x.Remove(x.Min());
            }

            return output;
        }

        List<int> Merge(List<int> x)
        {
            if(x.Count > 2)
            {
                List<int> y = x.GetRange(0, x.Count / 2);
                List<int> z = x.GetRange(x.Count / 2, x.Count - x.Count / 2);
                x.Clear();
                Merge(y);
                Merge(z);
                while(y.Count + z.Count > 0)
                {
                    if (y.Count > 0)
                    {
                        if (z.Count > 0)
                        {

                            if (y[0] > z[0])
                            {
                                x.Add(z[0]);
                                z.Remove(z[0]);
                            }
                            else
                            {
                                x.Add(y[0]);
                                y.Remove(y[0]);
                            }
                        }
                        else
                        {
                            x.Add(y[0]);
                            y.Remove(y[0]);
                        }
                    }
                    else
                    {
                        x.Add(z[0]);
                        z.Remove(z[0]);
                    }
                }
            }
            else
            {
                if(x.Count > 1)
                {
                    if(x[0] > x[1])
                    {
                        int tmp = x[0];
                        x[0] = x[1];
                        x[1] = tmp;
                    }
                }
            }
            return x;
        }

        List<int> Heap(List<int> x)
        {
            return x;
        }

        List<int> Quick(List<int> x)
        {
            return x;
        }
    }
}
