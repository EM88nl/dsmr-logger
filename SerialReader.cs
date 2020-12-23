using System;
using System.IO.Ports;
using System.Threading;

public class SerialReader
{
    public SerialReader()
    {
        // Create and open the serial port
        _serialPort = new SerialPort("/dev/ttyUSB0", 115200, Parity.None, 8, StopBits.One);
        _serialPort.Open();

        _readThread = new Thread(Read);
        _continueReading = true;
    }
    public void Read()
    {
        while (_continueReading)
        {
            string message = _serialPort.ReadLine();
            Console.WriteLine(message);
        }
    }

    ~SerialReader()
    {
        _readThread.Join();
        _serialPort.Close();
    }
    static SerialPort _serialPort;
    static Thread _readThread;
    static bool _continueReading;


}