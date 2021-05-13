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
        bool oneOrAnother = false; //처음 계산인지 여러번 연산인지
        
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
            //처음 연산일때
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
            //여러번 연산일때
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
            if (double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                resultLabel.Content = "0";
                ControlOperation(oneOrAnother, sender, lastValue);
            }
            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

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

            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
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
        }
        private void percentButton_Click(object sender, RoutedEventArgs e)
        {  
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
                if(selectedOperator == SelectedOperator.Addition)
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
            //collection에 history 저장
            ItemCollection items = history.Items;
            //새로운 listviewtiem추가
            ListViewItem listViewItem = new ListViewItem();
            //listvieitem의 content에 계산 결과
            listViewItem.Content = calDisplay.Content.ToString() + newValue.ToString() + " = " + result.ToString();
            //초기화
            calDisplay.Content = "";
            resultLabel.Content = "0";
            //collection에 listviewitem추가
            items.Add(listViewItem);
            //operator를 기능 없는거로 바꿈(초기화)
            selectedOperator = SelectedOperator.NotExist;
            //다시 false로 바꾸기
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
