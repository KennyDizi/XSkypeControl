using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;

namespace XNControls.SourceCode.Controls
{
    public class SkypeAnimControl : NControlView
    {
        public event EventHandler<EventArgs> ShowAnimEvent;

        public static readonly BindableProperty IsShowAnimProperty =
            BindableProperty.Create<SkypeAnimControl, bool>(p => p.IsShowAnim, false, BindingMode.TwoWay, null,
                IsShowAnimChanged);
        
        private static void IsShowAnimChanged(BindableObject bindable, bool oldvalue, bool newvalue)
        {
            var control = bindable as SkypeAnimControl;
            if(control == null) return;
            control.IsShowAnim = newvalue;
            control.ShowAnimEvent?.Invoke(control, new EventArgs());
        }

        public bool IsShowAnim
        {
            get { return (bool)GetValue(IsShowAnimProperty); }
            set { SetValue(IsShowAnimProperty, value);}
        }
        public override void Draw(NGraphics.ICanvas canvas, NGraphics.Rect rect)
        {
            base.Draw(canvas, rect);
            const double delta = -10.0;
            const double yOffset = 20;
            var width = rect.Width;
            var height = rect.Height;

            var points = new PathOp[]
            {
                new MoveTo(0, yOffset - delta),
                new CurveTo(new NGraphics.Point(width/2, yOffset + delta),
                    new NGraphics.Point(width/2, yOffset + delta),
                    new NGraphics.Point(width, yOffset - delta)),
                new LineTo(width, height),
                new LineTo(0, height)
            };
            
            canvas.DrawPath(points, null, new SolidBrush(new NGraphics.Color(0, 0.722, 1, 1)));
        }
    }
}
