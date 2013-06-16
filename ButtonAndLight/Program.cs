using ButtonAndLight.Lib;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT;
using Gadgeteer.Modules.GHIElectronics;

namespace ButtonAndLight
{
    public partial class Program : IView
    {
        private Presenter _presenter;

        void ProgramStarted()
        {
            _presenter = new Presenter(this, new Model());

            // Wire up handler for the the physical button press
            button.ButtonPressed += new Button.ButtonEventHandler(button_ButtonPressed);
        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            if (ButtonPressed != null)
            {
                ButtonPressed(this, EventArgs.Empty);
            }
        }

        public event ButtonPressedEventHandler ButtonPressed;

        public void ShowColour(byte r, byte g, byte b)
        {
            var colour = ColorUtility.ColorFromRGB(r, g, b);
            multicolorLed.TurnColor(colour);
        }
    }
}
