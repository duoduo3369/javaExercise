using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calcuator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private String op;
        private String current_op;
        private double result;
        private Boolean shouldClear;
        private Boolean hasDot;
        public MainWindow()
        {
            InitializeComponent();
            init();

        }
        private void init()
        {
            op = null;
            current_op = null;
            result = 0;
            textOut.Text = "0";
            shouldClear = false;
            hasDot = false;
        }
        //private void 
        private void Dot_Button_Click(object sender, RoutedEventArgs e) 
        {
            if (!hasDot) 
            {
                hasDot = true;
                textOut.Text += ".";
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            init();
        }
        private void CutOneCharactor(object sender, RoutedEventArgs e)
        {
            String old = textOut.Text;
            if (old.Length > 1)
            {
                Console.WriteLine("cut:"+old[old.Length - 1]);
                if (old[old.Length-1].Equals('.')) 
                {
                    hasDot = false;
                }
                textOut.Text = old.Substring(0, old.Length - 1);
            }
            else
            {
                textOut.Text = "0";
            }

        }

        private void CalculateDoubleOp()
        {
            if (op != null)
            {
                double number = Double.Parse(textOut.Text);
                switch (op)
                {
                    case "+": result += number; break;
                    case "-": result -= number; break;
                    case "*": result *= number; break;
                    case "/": result /= number; break;
                    case "%": result %= number; break;
                }
                op = null;
            }

        }
        private void CalculateSingleOp()
        {
            double number = Double.Parse(textOut.Text);
            switch (current_op)
            {
                case "+ / -": number = 0 - number;
                    shouldClear = false;
                    current_op = null;
                    break;
                case "1 / x": number = 1 / number;
                    
                    shouldClear = true;
                    break;
                case "√": number = Math.Sqrt(number);
                    shouldClear = true;
                    break;
            }
            textOut.Text = number + "";
        }
        private void CalculateDoubleOpAndShow()
        {
            CalculateDoubleOp();
            textOut.Text = "" + result;

        }
        private void Equal_Button_Click(object sender, RoutedEventArgs e)
        {
            if (current_op != null)
            {
                double number = Double.Parse(textOut.Text);
                switch (current_op)
                {
                    case "+": result += number; break;
                    case "-": result -= number; break;
                    case "*": result *= number; break;
                    case "/": result /= number; break;
                    case "%": result %= number; break;
                }

                textOut.Text = "" + result;

            }
            op = null;
            current_op = null;
            result = 0;
        }
        private void Single_OP_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            current_op = button.Content.ToString();
            CalculateSingleOp();
            
        }
        private void Double_OP_Click(object sender, RoutedEventArgs e)
        {
            if (current_op == null && op == null)
            {
                result = Double.Parse(textOut.Text);
            }
            if (current_op != null && op == null)
            {
                op = current_op;
                CalculateDoubleOpAndShow();
            }
            Button button = (Button)sender;
            current_op = button.Content.ToString();
            shouldClear = true;
        }
        private void Number_Button_Click_OP_IsNull(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (shouldClear)
            {
                textOut.Text = "";
                hasDot = false;

            }
            if (textOut.Text == "0")
            {
                textOut.Text = button.Content.ToString();
            }
            else
            {
                textOut.Text += button.Content.ToString();
            }
            shouldClear = false;
        }
    }
}
