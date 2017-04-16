using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
    class PracticeWordsViewModel : INotifyPropertyChanged
    {
        private string questionLabelText;
        private string firstButtonText;
        private string secondButtonText;
        private string thirdButtonText;
        private string fourthButtonText;

        public string QuestionLabelText
        {
            get
            {
                return questionLabelText;
            }
            set
            {
                questionLabelText = value;
                OnPropertyChanged();
            }
        }

        public string FirstButtonText
        {
            get
            {
                return firstButtonText;
            }
            set
            {
                firstButtonText = value;
                OnPropertyChanged();
            }
        }

        public string SecondButtonText
        {
            get
            {
                return secondButtonText;
            }
            set
            {
                secondButtonText = value;
                OnPropertyChanged();
            }
        }

        public string ThirdButtonText
        {
            get
            {
                return thirdButtonText;
            }
            set
            {
                thirdButtonText = value;
                OnPropertyChanged();
            }
        }

        public string FourthButtonText
        {
            get
            {
                return fourthButtonText;
            }
            set
            {
                fourthButtonText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
