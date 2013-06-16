using System;
using Microsoft.SPOT;

namespace ButtonAndLight.Lib.Test
{
    public class Program
    {
        public static void Main()
        {
            ButtonPressed_ExpectRandomColourGenerated();
        }

        private static void ButtonPressed_ExpectRandomColourGenerated()
        {
            // Create objects
            var view = new FakeView();
            var model = new Model(new FakeRandomGenerator());
            var presenter = new Presenter(view, model);

            // Raise event
            view.RaiseButtonPressEvent();

            // Check result
            if (view.R == 10 && view.G == 20 && view.B == 30)
            {
                Debug.Print("Success");
                return;
            }

            throw new InvalidOperationException("Failure");
        }
    }

    public class FakeView : IView
    {
        // Sensing variables
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        // Pretend a button's been pushed
        public void RaiseButtonPressEvent()
        {
            if (ButtonPressed != null)
            {
                ButtonPressed(this, EventArgs.Empty);
            }
        }

        #region IView interface

        public event ButtonPressedEventHandler ButtonPressed;

        public void ShowColour(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        #endregion
    }

    public class FakeRandomGenerator : IRandomGenerator
    {
        byte[] _values = new byte[] { 10, 20, 30 };
        int _valuePointer = 0;

        public byte GetNextColourPart()
        {
            return _values[_valuePointer++];
        }
    }
}
