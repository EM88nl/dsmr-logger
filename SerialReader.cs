using System.IO.Ports;

public class SerialReader
{
    public SerialReader()
    {
        // Create and open the serial port
        _serialPort = new SerialPort("/dev/ttyUSB0", 115200, Parity.None, 8, StopBits.One);
        _serialPort.Open();
    }

    ~SerialReader()
    {
        _serialPort.Close();
    }
    static SerialPort _serialPort;


}