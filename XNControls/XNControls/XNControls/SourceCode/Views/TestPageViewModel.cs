using System.Windows.Input;
using XNControls.SourceCode.Mvvm;

namespace XNControls.SourceCode.Views
{
    public class TestPageViewModel : BindableBase
    {
        private bool _isShowSkypeAnim;

        public bool IsShowSkypeAnim
        {
            get { return _isShowSkypeAnim; }
            set { Set(() => IsShowSkypeAnim, ref _isShowSkypeAnim, value); }
        }


        private string _message;

        public string Message
        {
            get { return _message ?? (_message = "lhglsahgas"); }
            set { Set(() => Message, ref _message, value); }
        }
        private DelegateCommand _showAnimCommand;

        public ICommand ShowAnimCommand
            => _showAnimCommand ?? (_showAnimCommand = new DelegateCommand(ShowAnimCommandAction));

        private void ShowAnimCommandAction()
        {
            IsShowSkypeAnim = !IsShowSkypeAnim;
            Message += "T202T";
        }
    }
}
