using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models
{
    public class Percentage
    {
        private readonly int _percentage;

        public Percentage(int percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentOutOfRangeException($"Percentage value: '{percentage}' is out of expected range.");
            }

            _percentage = percentage;
        }

        public int From(int value)
        {
            return value / 100 * _percentage;
        }
    }
}
