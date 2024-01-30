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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        bool decimalE = false;
        string cInput = "0";
        double cResult = 0;
        string cOperator = " ";
        char currentOperator = ' ';
        bool isPositive = true;




        public void result()
        {
            double operand = double.Parse(cInput);

            switch (cOperator)
            {
                case "+":
                    txt1.Text = (cResult + double.Parse(txt1.Text)).ToString();
                    
                    break;
                case "-":
                    txt1.Text = (cResult - double.Parse(txt1.Text)).ToString();
                    
                    break;
                case "×":
                    txt1.Text = (cResult * double.Parse(txt1.Text)).ToString();
                    break;
                case "÷":
                    if(operand != 0 ) 
                    {
                    txt1.Text = (cResult / double.Parse(txt1.Text)).ToString();
                    }
                    else 
                    {
                    cInput ="E";
                    }
                    
                    break;
                      default: break;
            }

            cInput = cResult.ToString();
            txt2.Text = cInput + "" + cOperator;
        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (buttonText == "." && txt1.Text.Contains("."))
            {
                // اگر قبلاً علامت اعشار وارد شده باشد، کاری انجام ندهید
               
            }
            else if (txt1.Text == "0")
            {
                    txt1.Text = buttonText;
            }
            else
            {
                txt1.Text += buttonText;

                if (buttonText == ".")
                {
                    // اگر علامت اعشار وارد شده است، متغیر را تنظیم کنید
                    decimalE = true;
                }
            }



        }

        private void txt1_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txt1.Text.Length > 0)
            {
                txt1.Text = txt1.Text.Substring(0, txt1.Text.Length - 1);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txt1.Text = "0";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txt1.Text = "0";
            txt2.Text = "0";
            cResult = 0;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {     Button btn = (Button)sender;
            if (txt1.Text == "")
            {
                txt1.Text = "";
            }
            else
            {
            cOperator = (string)btn.Content;
            cResult=double.Parse(txt1.Text);
            txt2.Text = cResult + " " + cOperator;
            txt1.Text = " ";
            decimalE = true;
            
            }
        
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            
            result(); 
            
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // تغییر وضعیت علامت
            isPositive = !isPositive;

            // نمایش علامت در متن
            txt1.Text = (isPositive ? txt1.Text.TrimStart('0').TrimStart('-') : "-" + txt1.Text.TrimStart('0'));

        }
    }
}
