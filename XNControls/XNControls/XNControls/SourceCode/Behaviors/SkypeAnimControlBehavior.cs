using Acr.DeviceInfo;
using System;
using Xamarin.Forms;
using XNControls.SourceCode.Controls;

namespace XNControls.SourceCode.Behaviors
{
    public class SkypeAnimControlBehavior : Behavior<SkypeAnimControl>
    {
        public double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value);}
        }

        public static readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create<SkypeAnimControlBehavior, double>(p => p.HeightRequest, DeviceInfo.Hardware.ScreenHeight / 2, BindingMode.TwoWay);

        private SkypeAnimControl _associatedObject;
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            _associatedObject = bindable as SkypeAnimControl;
            if(_associatedObject == null) return;
            _associatedObject.ShowAnimEvent += ShowAnimAction;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            if (_associatedObject == null) return;
            _associatedObject.ShowAnimEvent -= ShowAnimAction;
            _associatedObject = null;
        }

        private void ShowAnimAction(object sender, EventArgs e)
        {
            var control = sender as SkypeAnimControl;
            if (control == null) return;
            if (!control.IsShowAnim)
            {
                //hide anim
                var positionShow = new Rectangle(0, DeviceInfo.Hardware.ScreenHeight, DeviceInfo.Hardware.ScreenWidth, 0);
                _associatedObject.LayoutTo(positionShow, 500, Easing.SpringIn);
            }
            else
            {
                //show anim
                var positionShow = new Rectangle(0, HeightRequest, DeviceInfo.Hardware.ScreenWidth,
                    HeightRequest);
                _associatedObject.LayoutTo(positionShow, 500, Easing.SpringOut);
                /*
                var sidecoeff = 0;
                _associatedObject.LayoutTo(positionShow, 500,
                    new Easing((x) => ((x - 1)*(x - 1)*((sidecoeff + 1)*(x - 1) + sidecoeff) + 1)));*/
            }
        }
    }
}
