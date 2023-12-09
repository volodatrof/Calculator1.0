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

namespace Calculator
{

    public partial class MainWindow : Window
    {
        private double currentValue = 0;
        private string currentOperation = "";
        private double num1 = 0;
        private double num2 = 0;
        private bool lastButtonWasOperator = false;
        public MainWindow()
        {
            InitializeComponent();

        }


        private void DigitButtonClick(string digit)
        {
            if (lastButtonWasOperator || result.Content.ToString() == "0" || result.Content.ToString().Contains("."))
            {
                result.Content = digit;
                lastButtonWasOperator = false;
            }
            else
            {
                
                result.Content += digit;
            }

           
            operationHistory.Content += digit;
        }
        private void OperatorButtonClick(string op)
        {
            if (!lastButtonWasOperator)
            {
                num2 = Convert.ToDouble(result.Content);
                CalculateResult();
                result.Content = "0";
            }
            else
            {
                num1 = Convert.ToDouble(result.Content);
            }

            currentOperation = op;

           
            string num1String = num1.ToString();
            if (operationHistory.Content.ToString().Contains(num1String))
            {
                operationHistory.Content = operationHistory.Content.ToString().Replace(num1String, "");
            }

            operationHistory.Content += $" {num1} {currentOperation} ";
            lastButtonWasOperator = true;
        }

        private void sevenBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("7");
        }

        private void eightBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("8");
        }

        private void nineBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("9");
        }


        private void fourBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("4");
        }

        private void fiveBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("5");
        }

        private void sixBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("6");
        }


        private void oneBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("1");
        }

        private void twoBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("2");
        }

        private void threeBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("3");

        }
        private void nullBtn_Click(object sender, RoutedEventArgs e)
        {
            DigitButtonClick("0");
        }

        private void acBtn_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            currentValue = 0;
            currentOperation = "";
            result.Content = "0";
            operationHistory.Content = "";
            lastButtonWasOperator = false;
        }

        private void negativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(result.Content.ToString()) && result.Content.ToString() != "0")
            {
                double currentNumber = Convert.ToDouble(result.Content);
                currentNumber = -currentNumber;
                result.Content = currentNumber.ToString();
            }
        }
        private void minusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(result.Content.ToString()))
            {
                if (lastButtonWasOperator)
                {
                    operationHistory.Content = $"{num1} {currentOperation}";
                }
                else
                {
                    num1 = Convert.ToDouble(result.Content);
                    operationHistory.Content = $"{num1} -";
                }

                currentOperation = "-";
                lastButtonWasOperator = true;
            }
        }

        private void perventBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(result.Content.ToString()))
            {
                double currentNumber = Convert.ToDouble(result.Content);
                currentNumber = currentNumber / 100;
                result.Content = currentNumber.ToString();
            }
        }
        private void divisionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(result.Content.ToString()))
            {
                if (lastButtonWasOperator)
                {
                    operationHistory.Content = $"{num1} {currentOperation}";
                }
                else
                {
                    num1 = Convert.ToDouble(result.Content);
                    operationHistory.Content = $"{num1} /";
                }

                currentOperation = "/";
                lastButtonWasOperator = true;
            }
        }
        private void multBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(result.Content.ToString()))
            {
                if (lastButtonWasOperator)
                {
                    operationHistory.Content = $"{num1} {currentOperation}";
                }
                else
                {
                    num1 = Convert.ToDouble(result.Content);
                    operationHistory.Content = $"{num1} *";
                }

                currentOperation = "*";
                lastButtonWasOperator = true;
            }
        }
        private void plusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(result.Content.ToString()))
            {
                if (lastButtonWasOperator)
                {
                    operationHistory.Content = $"{num1} {currentOperation}";
                }
                else
                {
                    num1 = Convert.ToDouble(result.Content);
                    operationHistory.Content = $"{num1} +";
                }

                currentOperation = "+";
                lastButtonWasOperator = true;
            }
        }


        private void pintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!result.Content.ToString().Contains("."))
            {
                
                result.Content += ".";
                operationHistory.Content += ".";
            }
            else if (lastButtonWasOperator)
            {
                
                result.Content = "0.";
                lastButtonWasOperator = false;
                operationHistory.Content = "0.";
            }
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            
                if (!string.IsNullOrEmpty(result.Content.ToString()))
                {
                    num2 = Convert.ToDouble(result.Content);
                    CalculateResult();
                    lastButtonWasOperator = true;
                }
            

        }
        private void CalculateResult()
        {
            switch (currentOperation)
            {
                case "+":
                    currentValue = num1 + num2;
                    break;
                case "-":
                    currentValue = num1 - num2;
                    break;
                case "*":
                    currentValue = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        currentValue = num1 / num2;
                    }
                    else
                    {
                        
                        result.Content = "Error";
                        return;
                    }
                    break;
                default:
                    break;
            }

           
            operationHistory.Content = $"{num1} {currentOperation} {num2} =";

            
            result.Content = currentValue.ToString();

          
            num1 = 0;
            num2 = 0;
            currentOperation = "";
        }

    }
}