using Microsoft.SPOT;

namespace ButtonAndLight.Lib
{
    public class Model
    {
        public Model()
            : this(new RandomGenerator())
        { }

        public Model(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        private IRandomGenerator _randomGenerator;

        // Old school event handler for the Micro Framework
        public delegate void ColourChangedEventHandler(object sender, ColourChangedEventArgs args);

        // The event that will be raised when the colour has changed
        public event ColourChangedEventHandler ColourChanged;

        // This will be called by the presenter
        public void CalculateNewColour()
        {
            var r = _randomGenerator.GetNextColourPart();
            var g = _randomGenerator.GetNextColourPart();
            var b = _randomGenerator.GetNextColourPart();

            OnColourChanged(r, g, b);
        }

        private void OnColourChanged(byte r, byte g, byte b)
        {
            if (ColourChanged != null)
            {
                ColourChanged(this, new ColourChangedEventArgs(r, g, b));
            }
        }
    }

    public class ColourChangedEventArgs : EventArgs
    {
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }
        public ColourChangedEventArgs(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
