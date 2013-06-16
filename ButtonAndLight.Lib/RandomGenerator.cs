using System;
using Microsoft.SPOT;

namespace ButtonAndLight.Lib
{
    public interface IRandomGenerator
    {
        byte GetNextColourPart();
    }

    public class RandomGenerator : IRandomGenerator
    {
        private Random _random = new Random();
        
        public byte GetNextColourPart()
        {
            return (byte)_random.Next(byte.MaxValue);
        }
    }
}
