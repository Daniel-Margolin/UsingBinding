using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UsingBinding.Models
{
    public class Muscle : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string bodyPart = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BodyPart
        {
            get => bodyPart;
            set
            {
                if (bodyPart != value)
                {
                    bodyPart = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}