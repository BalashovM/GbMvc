using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public sealed class MeasurementInfo
    {
        public DateTime ReportDate { get; set; }
        public string MeasurementDuration { get; set; }
        public decimal LoadCpuMax { get; set; }
        public decimal LoadRamMax { get; set; }
        public decimal LoadCpuAve { get; set; }
        public decimal LoadRamAve { get; set; }
        public List<Measurement> Measurements { get; set; }

        public MeasurementInfo()
        {
            Measurements = new List<Measurement>();
        }

        public void Add(decimal LoadCpu, decimal LoadRam) 
        {
            Measurement measurementNew = new Measurement();
            measurementNew.LoadCPU = LoadCpu;
            measurementNew.LoadRAM = LoadRam;
            measurementNew.MeasurementDateTime = DateTime.Now;

            if (Measurements != null)
                measurementNew.MeasurementOrder = Measurements.Count + 1;
            else
                measurementNew.MeasurementOrder = 1;

            this.Measurements.Add(measurementNew);

            CalcResult();
        }

        void ClearCalc() 
        {
            this.LoadCpuMax = 0;
            this.LoadCpuAve = 0;
            this.LoadRamAve = 0;
            this.LoadRamMax = 0;
        }

        void CalcResult ()
        {
            decimal LoadCpuSum = 0;
            decimal LoadRamSum = 0;
            DateTime MeasurementDateTimeMin = DateTime.MaxValue;
            DateTime MeasurementDateTimeMax = DateTime.MinValue;
            TimeSpan DuractionCalc = TimeSpan.Zero;

            this.ClearCalc();

            foreach (Measurement measurement in this.Measurements) 
            {
                this.LoadCpuMax = this.LoadCpuMax < measurement.LoadCPU ? measurement.LoadCPU : this.LoadCpuMax;
                this.LoadRamMax = this.LoadRamMax < measurement.LoadRAM ? measurement.LoadRAM : this.LoadRamMax;
                LoadCpuSum += measurement.LoadCPU;
                LoadRamSum += measurement.LoadRAM;
                MeasurementDateTimeMin = MeasurementDateTimeMin > measurement.MeasurementDateTime ? measurement.MeasurementDateTime : MeasurementDateTimeMin;
                MeasurementDateTimeMax = MeasurementDateTimeMax < measurement.MeasurementDateTime ? measurement.MeasurementDateTime : MeasurementDateTimeMax;
            }

            this.LoadCpuAve = LoadCpuSum/ this.Measurements.Count;
            this.LoadRamAve = LoadRamSum / this.Measurements.Count;

            DuractionCalc = (MeasurementDateTimeMax - MeasurementDateTimeMin).Duration();
            this.MeasurementDuration = String.Format("{0} минут {1} секунд", DuractionCalc.Minutes, DuractionCalc.Seconds);
        }
    }
}
