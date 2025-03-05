using ArduinoSimulator.Enums;
using ArduinoSimulator.Helper;
using ArduinoSimulator.Strucures;
using System.IO.Ports;

namespace ArduinoSimulator
{
    // https://docs.arduino.cc/built-in-examples/usb/KeyboardReprogram/
    public class ArduinoDeviceSimulator : IDisposable
    {
        private KeyData keyDatasend = new KeyData();
        public SerialPort _serialPort;
        byte[] bytes = { };

        public NativeBackgroundScreenWorker nativeBackgroundScreenWorker = new NativeBackgroundScreenWorker();


        public ArduinoDeviceSimulator(string myPortName, Action<ArduinoDeviceSimulator, byte[]> Received, int baudRate = 9600)
        {
            #region serial
            _serialPort = new SerialPort();
            _serialPort.PortName = myPortName;
            _serialPort.BaudRate = baudRate;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataBits = 8;
            _serialPort.Handshake = Handshake.None;
            _serialPort.RtsEnable = true;


            _serialPort.DataReceived += (o, e) =>
            {
                ReadBytes(ref bytes);
                if (bytes.Length > 40)
                {
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes));
                    return;
                }
                Received?.Invoke(this, bytes);
            };


            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {

                throw;
            }
            #endregion





        }
        #region Mouse

        public void LocalMouseMove(int x = 0, int y = 0, int wheel = 0, int delay = 5)
        {
            SendInfo(0, delay);
            WriteLineInt(x);
            WriteLineInt(y);
            WriteLineInt(wheel);
        }

        public void Click(MouseKeys keys, MouseStatus mouseStatus = MouseStatus.click, int delay = 5)
        {
            SendInfo(1, delay);

            WriteLineInt(((int)keys));
            WriteLineInt(((int)mouseStatus));
        }




        #endregion
        #region Extensions

        private void WriteLineInt(int value)
        {
            _serialPort.WriteLine(((int)value).ToString());
        }
        protected void SendInfo(int mode, int delay = 5)
        {
            _serialPort.WriteLine(mode.ToString());
            _serialPort.WriteLine(delay.ToString());
        }
        public int ReadBytes(ref byte[] array)
        {
            array = new byte[_serialPort.BytesToRead];
            return _serialPort.Read(array, 0, array.Length);
        }
        public void WriteMouseData()
        {
            byte[] bytesData = new byte[10];
            bytesData[0] = 1;
            _serialPort.Write(bytesData, 0, bytesData.Length);
        }

        #endregion

        public void Dispose()
        {
            _serialPort?.Dispose();
        }
    }
}
