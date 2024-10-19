using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace QuadEqMauiMVVMapp
{
    public interface IDialogService
    {
        void ShowMessage(string title, string msg);
    }
    public class QuadEqViewModel : INotifyPropertyChanged
    {
        private IDialogService ids;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SolveCommand { get; private set; }
        public QuadEqViewModel(IDialogService _ids)
        {
            SolveCommand =
            new Command(
            () => Solve()
            );
            this.ids = _ids;
        }

        string a, b, c, x1, x2;
        public string A
        {
            get { return a; }
            set
            {
                a = value;
                OnPropertyChanged("A");
            }
        }
        public string B
        {
            get { return b; }
            set
            {
                b = value;
                OnPropertyChanged("B");
            }
        }
        public string C
        {
            get { return c; }
            set
            {
                c = value;
                OnPropertyChanged("C");
            }
        }
        public string X1
        {
            get { return x1; }
            set
            {
                x1 = value;
                OnPropertyChanged("X1");
            }
        }
        public string X2
        {
            get { return x2; }
            set
            {
                x2 = value;
                OnPropertyChanged("X2");
            }
        }
        public void Solve()
        {
            float a, b, c;
            if (float.TryParse(A, out a) &&
            float.TryParse(B, out b) &&
            float.TryParse(C, out c))
            {
                QuadEquation eq = new QuadEquation(a, b, c);
                var x = eq.Solve();
                if (x.Count == 0)
                {
                    X1 = "Нет корней !";
                    X2 = "";
                }
                else if (x.Count == 1)
                {
                    X1 = "X1 = " + x[0].ToString();
                    X2 = "";
                }
                else
                {
                    X1 = "X1 = " + x[0].ToString();
                    X2 = "X2 = " + x[1].ToString();
                }
            }
            else
                ids.ShowMessage("Ошибка",
                "Неправильный формат чисел !");
        }
        public void OnPropertyChanged(
        [CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new
        PropertyChangedEventArgs(name));
    }
}
