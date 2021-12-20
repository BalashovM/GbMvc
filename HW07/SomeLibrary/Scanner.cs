using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MyLibrary
{
    public class Scanner : IScanner
    {
        // Состояние процессора и оперативной памяти
        public int LoadCPU { get; private set; }
        public int LoadRAM { get; private set; }

        private readonly string filePath = "FakeScanFile.png";

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        // Изменение данных о загрузке процессора и оперативной памяти
        public void ChangeLoadState()
        {
            Measurement measurementCurent = new Measurement();

            LoadCPU = new Random().Next(0, 100);
            LoadRAM = new Random().Next(0, 100);

            Thread.Sleep(500);

            Notify();
        }

        public byte[] Scan()
        {
            var bytes = File.ReadAllBytes(filePath);
            return bytes;
        }
    }
}
