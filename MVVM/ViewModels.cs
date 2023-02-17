using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM
{
    class ViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstOperand 
        {
            set
            {
                Model.firstOperand = value;
            }
        }
        public string SecondOperand 
        {
            set
            {
                Model.secondOperand = value;
            }
        }

        public string ChangeResult 
        {
            get
            {
                return Model.result.ToString();
            }
        }

        public List<String> ChangeCombobox
        {
            get
            {
                return Model.dataListDisplay;
            }
        }
        int cbIndex = -1;
        public int SelectedIndex
        {
            set
            {
                Model.indexComboBox = value;
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }

        public string CBIndex 
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataListValue[cbIndex];
                }
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                double firstNumber = 0; 
                double secondNumber = 0; 
                if (Model.firstOperand != "") 
                {
                    firstNumber = Convert.ToDouble(Model.firstOperand);
                    
                }
                if (Model.secondOperand != "") 
                {
                    secondNumber = Convert.ToDouble(Model.secondOperand);
                }
                switch (Model.indexComboBox)
                {
                    case -1:
                        MessageBox.Show("Арифметическая операция не выбрана");
                        return;
                    case 0:
                        Model.result = Convert.ToString(firstNumber + secondNumber);
                        break;
                    case 1:
                        Model.result = Convert.ToString(firstNumber - secondNumber);
                        break;
                    case 2:
                        Model.result = Convert.ToString(firstNumber * secondNumber);
                        break;
                    case 3:
                        if (secondNumber == 0)
                        {
                            Model.result = "Деление на 0";
                            MessageBox.Show("Деление на 0 невозможно");
                        }
                        else
                        {
                            Model.result = Convert.ToString(firstNumber / secondNumber);
                        }
                        break;
                    default:
                        MessageBox.Show("При расчёте возникла ошибка");
                        return;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ChangeResult"));
            }
            catch
            {
                MessageBox.Show("При вычисление возникла ошибка");
            }
        }
        public CommandBinding bind;
        public ViewModels()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}