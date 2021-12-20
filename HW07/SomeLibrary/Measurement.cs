using System;

namespace MyLibrary
{
    public sealed class Measurement
    {
        public DateTime MeasurementDateTime { get; set; }

        public int MeasurementOrder { get; set; }

        public decimal LoadCPU { get; set; }

        public decimal LoadRAM { get; set; }
    }
}
