using System.Collections.Generic;
using Xamarin.Forms;
using Point = NGraphics.Point;

namespace XNControls.SourceCode.Views
{
    public partial class TestPageView : ContentPage
    {
        public TestPageView()
        {
            InitializeComponent();
            BindingContext = new TestPageViewModel();
        }
    }
}
