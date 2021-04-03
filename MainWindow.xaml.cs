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
    //partial keyword: 코드가 흩어져있을때(InitialzeComponent()함수는 다른 cs파일에 담겨있음) 컴파일러가 눈치채게 하는 키워드
    public partial class MainWindow : Window 
    {
        double lastValue; //처음 입력한 값을 저장하는 변수
        public MainWindow()
        {
            InitializeComponent();
            resultLabel.Content = "0"; //(.찍었을때 나오는 기호들 회색 스패너는 property 보라색 네모는 메소드, 번개표시는 이벤트)
            acButton.Click += AcButton_Click;//(이벤트 등록)Button필드의 상속되어있는것들에 Click이라는 이벤트델리게이트를 사용가능 그 델리게이트에 내가 만든 이벤트헨들러 함수를 넣는것 
            plusMinusBtn.Click += plusMinusBtn_Click;
            divButton.Click += divButton_Click;
            EqualButton.Click += EqualButton_Click;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e) //sender에는 이 이벤트를 호출하도록 한 객체를 넘겨줌(예를 들어 8번버튼을 눌렀으면 8번이 객체가 됨)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastValue))
            {
                resultLabel.Content = "0";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e) //sender에는 이 이벤트를 호출하도록 한 객체를 넘겨줌(예를 들어 8번버튼을 눌렀으면 8번이 객체가 됨)
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
            //delegate void Click(object, RoutedEventArg) <-- 대리자 이니까 안에 들어갈 것도 형식이 맞춰져워함 void acbutton_click(object sender, routedEventtArgs)
            resultLabel.Content = "0";
        }

        private void plusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
           
            //parse는 두가지가 있는데 TryParse -> 변환을 해서 반환을 성공했는지 실패했는지를 나타낸다.
            if (double.TryParse(resultLabel.Content.ToString(), out lastValue)) //out => value를 받아와서 이 함수에 참조형으로 넣겠다는 뜻
            {
                lastValue *= -1;
                resultLabel.Content = lastValue.ToString();
            }

            /*double value = double.Parse(resultLabel.Content.ToString());

            value = -1 * value;
            resultLabel.Content = value.ToString();*/
        }
        private void divButton_Click(object sender, RoutedEventArgs e)
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

        }
    }
    
}
