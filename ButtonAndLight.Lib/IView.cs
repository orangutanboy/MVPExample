using Microsoft.SPOT;

namespace ButtonAndLight.Lib
{
    public delegate void ButtonPressedEventHandler(object sender, EventArgs args);

    public interface IView
    {
        // The event that the UI will raise when the button is pressed
        event ButtonPressedEventHandler ButtonPressed;
        
        //The method the presenter will call when the colour needs to change
        void ShowColour(byte r, byte g, byte b);
    }    
}
