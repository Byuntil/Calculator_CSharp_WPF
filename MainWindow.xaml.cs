using Calculator.Classes;
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
    public enum SelectedOperator
    {
        Addition, Substraction, Multiplication, Division,
        NotExist
    }

    
    //partial keyword: 코드가 흩어져있을때(InitialzeComponent()함수는 다른 cs파일에 담겨있음) 컴파일러가 눈치채게 하는 키워드
    public partial class MainWindow : Window 
    {
        double lastValue = 0; //처음 입력한 값을 저장하는 변수
        double nextValue = 0;
        bool oneOrAnother = false;
        
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            resultLabel.Content = "0";
            acButton.Click += AcButton_Click; 
            plusMinusBtn.Click += plusMinusBtn_Click;
            percentButton.Click += percentButton_Click;
            EqualButton.Click += EqualButton_Click;
        }

        public void ControlOperation(bool oneOrA, object sender, double lastV)
        {
            if(oneOrA == false)
            {
                if (sender == diviButton)
                {
                    selectedOperator = SelectedOperator.Division;
                    calDisplay.Content += lastV + " / ";
                    nextValue = lastV;
                }
                if (sender == mulButton)
                {
                    selectedOperator = SelectedOperator.Multiplication;
                    calDisplay.Content += lastV + " * ";
                    nextValue = lastV;
                }
                if (sender == subButton)
                {
                    selectedOperator = SelectedOperator.Substraction;
                    calDisplay.Content += lastV + " - ";
                    nextValue = lastV;
                }
                if (sender == addButton)
                {
                    selectedOperator = SelectedOperator.Addition;
                    calDisplay.Content += lastV + " + ";
                    nextValue = lastV;
                }
                oneOrAnother = true;
            }
            else
            {
                if (selectedOperator == SelectedOperator.Division)
                {
                    nextValue = SimpleMate.Div(nextValue, lastV);
                    if (sender == diviButton)
                    {
                        selectedOperator = SelectedOperator.Division;
                        calDisplay.Content += lastV + " / ";
                    }
                    if (sender == mulButton)
                    {
                        selectedOperator = SelectedOperator.Multiplication;
                        calDisplay.Content += lastV + " * ";
                    }
                    if (sender == subButton)
                    {
                        selectedOperator = SelectedOperator.Substraction;
                        calDisplay.Content += lastV + " - ";
                    }
                    if (sender == addButton)
                    {
                        selectedOperator = SelectedOperator.Addition;
                        calDisplay.Content += lastV + " + ";
                    }

                }
                else if (selectedOperator == SelectedOperator.Multiplication)
                {
                    nextValue = SimpleMate.Mul(nextValue, lastV);
                    if (sender == diviButton)
                    {
                        selectedOperator = SelectedOperator.Division;
                        calDisplay.Content += lastV + " / ";
                    }
                    if (sender == mulButton)
                    {
                        selectedOperator = SelectedOperator.Multiplication;
                        calDisplay.Content += lastV + " * ";
                    }
                    if (sender == subButton)
                    {
                        selectedOperator = SelectedOperator.Substraction;
                        calDisplay.Content += lastV + " - ";
                    }
                    if (sender == addButton)
                    {
                        selectedOperator = SelectedOperator.Addition;
                        calDisplay.Content += lastV + " + ";
                    }
                }
                else if (selectedOperator == SelectedOperator.Substraction)
                {
                    nextValue = SimpleMate.Sub(nextValue, lastV);
                    if (sender == diviButton)
                    {
                        selectedOperator = SelectedOperator.Division;
                        calDisplay.Content += lastV + " / ";
                    }
                    if (sender == mulButton)
                    {
                        selectedOperator = SelectedOperator.Multiplication;
                        calDisplay.Content += lastV + " * ";
                    }
                    if (sender == subButton)
                    {
                        selectedOperator = SelectedOperator.Substraction;
                        calDisplay.Content += lastV + " - ";
                    }
                    if (sender == addButton)
                    {
                        selectedOperator = SelectedOperator.Addition;
                        calDisplay.Content += lastV + " + ";
                    }
                }
                else if (selectedOperator == SelectedOperator.Addition)
                {
                    nextValue = SimpleMate.Add(nextValue, lastV);
                    if (sender == diviButton)
                    {
                        selectedOperator = SelectedOperator.Division;
                        calDisplay.Content += lastV + " / ";
                    }
                    if (sender == mulButton)
                    {
                        selectedOperator = SelectedOperator.Multiplication;
                        calDisplay.Content += lastV + " * ";
                    }
                    if (sender == subButton)
                    {
                        selectedOperator = SelectedOperator.Substraction;
                        calDisplay.Content += lastV + " - ";
                    }
                    if (sender == addButton)
                    {
                        selectedOperator = SelectedOperator.Addition;
                        calDisplay.Content += lastV + " + ";
                    }
                }
            }
        }
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                resultLabel.Content = "0";
                ControlOperation(oneOrAnother, sender, lastValue);
            }

            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            /*var button = (System.Windows.Controls.Button)sender;
            selectedValue = int.Parse(button.Content.ToString());*/ //최악의 경우는 버튼이긴 하지만 7을 입력하기 위한 버튼이 아닐수도 있음=>그런데 입력되는 경우가 생길 수도 있어서 고유한 Name을 주어서 구별

            if(sender == zeroButton)
            {
                selectedValue = 0;
            }
            if (sender == oneButton)
            {
                selectedValue = 1;
            }
            if (sender == twoButton)
            {
                selectedValue = 2;
            }
            if (sender == threeButton)
            {
                selectedValue = 3;
            }
            if (sender == fourButton)
            {
                selectedValue = 4;
            }
            if (sender == fiveButton)
            {
                selectedValue = 5;
            }
            if (sender == sixButton)
            {
                selectedValue = 6;
            }
            if (sender == sevenButton)
            {
                selectedValue = 7;
            }
            if (sender == eightButton)
            {
                selectedValue = 8;
            }
            if (sender == nineButton)
            {
                selectedValue = 9;
            }

            if(resultLabel.Content.ToString() == "0") //Content는 object 타입
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                //resultLabel.Content += "7";
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            selectedOperator = SelectedOperator.NotExist;
            Label label = calDisplay;
            label.Content = "";
        }

        private void plusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                lastValue *= -1;
                resultLabel.Content = lastValue.ToString();
            }

            /*double value = double.Parse(resultLabel.Content.ToString());

            value = -1 * value;
            resultLabel.Content = value.ToString();*/
        }
        private void percentButton_Click(object sender, RoutedEventArgs e)
        { 
            //resultLabel.Content = $"{Convert.ToDouble(resultLabel.Content)/100}";
            
            if(double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                lastValue /= 100;
                resultLabel.Content = lastValue.ToString();
            }
        }
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newValue;
            double result = 0;
            if (double.TryParse(resultLabel.Content.ToString(), out newValue))
            {
                if(selectedOperator == SelectedOperator.Addition) //swich문으로도 가능
                {
                    result = SimpleMate.Add(nextValue, newValue);
                }
                if (selectedOperator == SelectedOperator.Substraction)
                {
                    result = SimpleMate.Sub(nextValue, newValue);
                }
                if (selectedOperator == SelectedOperator.Multiplication)
                {
                    result = SimpleMate.Mul(nextValue, newValue);
                }
                if (selectedOperator == SelectedOperator.Division) 
                {
                    result = SimpleMate.Div(nextValue, newValue);
                }
            }
            resultLabel.Content = result.ToString();
            ItemCollection items = history.Items;
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Content = calDisplay.Content.ToString() + newValue.ToString() + " = " + result.ToString();
            calDisplay.Content = "";
            resultLabel.Content = "0";
            items.Add(listViewItem);
            selectedOperator = SelectedOperator.NotExist;
            oneOrAnother = false;
                

        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains(".") == true)
            {
            }
            else
            {
                resultLabel.Content += ".";
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int leng = resultLabel.Content.ToString().Length;
            if(leng>0)
            {
                if(leng == 1)
                {
                    resultLabel.Content = "0";
                }
                else
                {
                    resultLabel.Content = resultLabel.Content.ToString().Substring(0, leng - 1);
                }
            }
        }

        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            double content = Convert.ToDouble(resultLabel.Content.ToString());
            if(content>0)
            {
                content = Math.Sqrt(content);
            }
            resultLabel.Content = content;
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            double content = Convert.ToDouble(resultLabel.Content.ToString());
            content = Math.Pow(content,2);
            resultLabel.Content = content;
        }

        private void inverseButton_Click(object sender, RoutedEventArgs e)
        {
            double content = Convert.ToDouble(resultLabel.Content.ToString());
            if (content == 0)
            {
                MessageBox.Show("Wrong!!");
                content = 0;
            }
            else
            {
                content = 1 / content;
            }
            
            resultLabel.Content = content;
        }

        private void historyDelete_Click(object sender, RoutedEventArgs e)
        {
            history.Items.Clear();
        }
    }
    
}
