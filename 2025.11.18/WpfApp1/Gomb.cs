using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp1
{
        public class Gomb : Button
        {
            public ButtonState CurrentState { get; private set; } = ButtonState.Inactive;

            public Gomb()
            {
                Width = 80;
                Height = 80;
                Margin = new Thickness(5);
                ResetButtonState();
            }

            public virtual void Activate()
            {
                CurrentState = ButtonState.Green;
                Background = Brushes.Green;
            }

            public virtual void ChangeColor()
            {
                switch (CurrentState)
                {
                    case ButtonState.Green:
                        CurrentState = ButtonState.Yellow;
                        Background = Brushes.Yellow;
                        break;
                    case ButtonState.Yellow:
                        CurrentState = ButtonState.Red;
                        Background = Brushes.Red;
                        break;
                    case ButtonState.Red:
                        CurrentState = ButtonState.Inactive;
                        Background = Brushes.Gray;
                        break;
                }
            }

            public virtual int CalculateScore()
            {                
                switch(CurrentState)
                {
                    case ButtonState.Green:
                        return 10;
                    case ButtonState.Yellow:
                        return 5;
                    default:
                        return 0;
                }
            }

            public virtual void ResetButtonState()
            {
                CurrentState = ButtonState.Inactive;
                Background = Brushes.Gray;
            }

            public void ApplyTemplate(Window window)
            {
                Template = (ControlTemplate)window.FindResource("NoMouseOverButtonTemplate");
            }
        }
}

