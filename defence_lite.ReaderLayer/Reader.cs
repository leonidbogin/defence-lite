using System;
using System.IO.Ports;
using defence_lite.ReaderLayer.Interface;

namespace defence_lite.ReaderLayer
{
    public class Reader : IReader
    {
        private static Reader _instance;
        private SerialPort _serialPort;
        
        public event Action<string> ReadEvent;
        
        public static Reader GetInstance()
        {
            return _instance ??= new Reader();
        }

        public bool IsOpen => _serialPort.IsOpen;
        
        public bool TryOpen(string portName)
        {
            _serialPort = new SerialPort(portName);
            _serialPort.Open();
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(OnReadEvent);
            return IsOpen;
        }
        
        public void Close()
        {
            _serialPort.Close();
        }
        
        private void OnReadEvent(object sender, SerialDataReceivedEventArgs e)
        {
            var data = new byte[14];
            var cardNumber = string.Empty;
            _serialPort.Read(data, 0, 14);
            for (var i = 1; i < 11; i++)
            {
                cardNumber += Convert.ToChar(data[i]);
            }
            ReadEvent?.Invoke(cardNumber);
        }
    }
}