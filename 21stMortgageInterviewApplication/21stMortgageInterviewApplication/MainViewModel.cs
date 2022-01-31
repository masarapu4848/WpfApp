using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace _21stMortgageInterviewApplication
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _dataInput;
        public string DataInput
        {
            get
            {
                return _dataInput;
            }
            set
            {
                _dataInput = value;
                OnPropertyRaised(nameof(DataInput));
            }
        }

        private int _outputResult;
        public int OutputResult
        {
            get
            {
                return _outputResult;
            }
            set
            {
                _outputResult = value;
                OnPropertyRaised(nameof(OutputResult));
            }
        }
        public bool IsOutputResultNegative { get { return (OutputResult < 0); } }
        public DelegateCommand EvenNumbersCommad { get; set; }

        public DelegateCommand OddNumbersCommand { get; set; }

        public DelegateCommand LargestNumberCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public MainViewModel()
        {

            this.EvenNumbersCommad = new DelegateCommand(() => { BaseNumbersCalculatons(DataInput, SumTypes.Even); });
            this.OddNumbersCommand = new DelegateCommand(() => { BaseNumbersCalculatons(DataInput, SumTypes.Odd); });
            this.LargestNumberCommand = new DelegateCommand(() => { BaseNumbersCalculatons(DataInput, SumTypes.Largest); });
        }

        private void BaseNumbersCalculatons(string input, SumTypes type)
        {
            if (type == SumTypes.Even )
            {
                OutputResult = sumOfEvenNumbers(input);
            }
            else if (type == SumTypes.Odd)
            {
                OutputResult = sumOfOddNumbers(input);
            }
            else
            {
                OutputResult = largest(input);
            }
            OnPropertyRaised(nameof(OutputResult));
            OnPropertyRaised(nameof(IsOutputResultNegative));
        }

        private int sumOfEvenNumbers(string input)
        {
            string[] inputList = input.Split(",");
            int i = 0;
            int evensum = 0;

            for (int j = 0; j < inputList.Length; j++)
            {
                bool result = int.TryParse(inputList[j].Trim(), out i);
                if (i % 2 == 0)
                {
                    evensum += i;
                }

            }
            return evensum;
        }

        private int sumOfOddNumbers(string input)
        {
            string[] inputList = input.Split(",");
            int i = 0;
            int oddSum = 0;

            for (int j = 0; j < inputList.Length; j++)
            {
                bool result = int.TryParse(inputList[j].Trim(), out i);
                if (i % 2 != 0)
                {
                    oddSum += i;
                }

            }
            return oddSum;
        }

        private int largest(string input)
        {

            string[] inputList = input.Split(",");
            int i = 0;
            int max = 0;

            for (int j=0; j< inputList.Length; j++)
            {
                bool result = int.TryParse(inputList[j].Trim(), out i);
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }


    }

}
