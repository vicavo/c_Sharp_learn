using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using Shuyz.Common;

namespace Shuyz.Communication
{
    /// <summary>
    /// serial communication class
    /// </summary>
    public class SerialBase
    { 
        private SerialPort port = null;
        
        /// <summary>
        /// 
        /// </summary>
        public SerialBase()
        {

        }

        ~SerialBase()
        {
            this.closePort();
        }

        /// <summary>
        /// get active port names on this machine
        /// </summary>
        /// <returns></returns>
        public string[] getPortList()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// check if the serial port is already open
        /// </summary>
        /// <returns></returns>
        public bool isPortOpen()
        {
            try
            {
                if ((null != this.port) && this.port.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.runLog("Can not read serial port status: " + ex.Message.ToString(), LogLevel.ERROR);
                return false;
            }
        }

        /// <summary>
        /// open port and set communication parameters
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="recvThreshold">the max size of recv message, to avoid an incomplete message
        /// we can not predict how much data will be received when send a command, so we set the max size
        /// the receive buffer will fulfill with recvThreshold bytes of data, then trigger the OnDataReceive event.
        /// if the message length is less than recvThreshold, the message will repeat until the length reaches recvThreshold
        /// use state machine to decode the message when receiving done
        /// NOTE: the receive buffer is set every time when send a msg, see HandleSendQueue()
        /// </param>
        /// <returns></returns>
        public bool openPort(string portName, int baudRate, Parity parity, Int32 dataBits, StopBits stopBits, Int32 recvThreshold=1)
        {
            portName = portName.ToUpper();

            // check if the port name is available on the machine
            string[] portList = SerialPort.GetPortNames();
            if( !portList.Contains(portName) )
            {
                Logger.Instance.runLog("Open serial port " + portName + " failed! the port is not exist in this machine.", LogLevel.ERROR);

                return false;
            }

            // check if the specified port is already open, if not, close any other opened port
            if (this.isPortOpen() && this.port.PortName == portName)
            {
                Logger.Instance.runLog("Open serial port " + portName + " OK, the port has already been opened.", LogLevel.WARN);

                return true;
            }
            else
            {
                if (this.isPortOpen()) // the opened port is not the same as the specified port
                {
                    this.port.Close();
                }
                this.port = null;
            }

            //open the port and register send and receive event handle
            try
            {
                // create new port and set parameters
                this.port = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                this.port.ReceivedBytesThreshold = recvThreshold;

                this.port.Open();
            }
            catch (System.Exception ex)
            {
                Logger.Instance.runLog("Open serial port " + portName + " failed with exception: " + ex.Message.ToString(), LogLevel.ERROR);

                this.port = null;
            	return false;
            }

            // receive event handler
            if (this.isPortOpen())
            {
                this.flushPort();
                this.port.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                this.doAfterPortOpen();

                Logger.Instance.runLog("Open serial port " + portName + " OK: "
                                        + ", " + baudRate.ToString()
                                        + ", " + dataBits.ToString()
                                        + ", " + stopBits.ToString()
                                        + ", " + parity.ToString(), LogLevel.NORMAL);
                return true;
            }
            else
            {
                Logger.Instance.runLog("Open serial port " + portName + " failed, the port seems not be opened correctly.", LogLevel.ERROR);

                return false;
            }
        }

        /// <summary>
        /// write data to serial port (in byte format)
        /// Note: use "QueueMsg(ComMsg newMsg)" on external call
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool sendData(Byte[] data)
        {
            if (!this.isPortOpen())
            {
                Logger.Instance.debugLog("serial message not send, port not opened!", LogLevel.ERROR);

                return false;
            }
            else
            {
                try
                {
                    this.port.Write(data, 0, data.Count());
                }
                catch (System.Exception ex)
                {
                    Logger.Instance.runLog("Serial port " + this.port.PortName + " send data error: " + ex.Message.ToString(), LogLevel.ERROR);
                }
                
                return true;
            }
        }
        
        /// <summary>
        /// clear send and receive buffer
        /// </summary>
        protected void flushPort()
        {
            if (this.isPortOpen())
            {
                try
                {
                    this.port.DiscardInBuffer();
                    this.port.DiscardOutBuffer();
                }
                catch (System.Exception ex)
                {
                    Logger.Instance.runLog("Flush serial port " + this.port.PortName + " error: " + ex.Message.ToString(), LogLevel.ERROR);
                }
            }
        }

        protected byte[] readReceivedData(SerialReadMode mode, string rbsStr = "")
        {
            if (this.isPortOpen())
            {
                byte[] data = new byte[] { };
                this.port.ReadTimeout = 1000;

                if(mode == SerialReadMode.RBL)
                {
                    string str =  this.port.ReadLine();
                    data =  Encoding.ASCII.GetBytes(str);
                }
                else if(mode == SerialReadMode.RBS)
                {
                    string str = this.port.ReadTo(rbsStr);
                    data = Encoding.ASCII.GetBytes(str);
                }
                else
                {
                    data = new byte[this.port.BytesToRead];
                    this.port.Read(data, 0, this.port.BytesToRead);
                }

                if (this.port.BytesToRead > 0)
                {
                    this.port.ReadExisting();
                }

                return data;
            }
            else
            {
                throw (new Communication.ComunicationException("Could not read Bytes while serial port is not opened."));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="thresHold"></param>
        protected void setThresHold(Int32 thresHold)
        {
            if (this.isPortOpen())
            {
                this.port.ReceivedBytesThreshold = thresHold;
            }
            else
            {
                throw (new Communication.ComunicationException("Could not set threshold while serial port is not opened."));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string getPortName()
        {
            if (this.isPortOpen())
            {
                return this.port.PortName;
            }

            else
            {
                throw (new Communication.ComunicationException("Could not get port name while serial port is not opened."));
            }
        }

        /// <summary>
        /// close port
        /// </summary>
        /// <returns></returns>
        protected bool closePort()
        {
            try
            {
                if (this.isPortOpen() ) 
                {
                    this.port.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(this.OnDataReceived);

                    this.port.Close();

                    Logger.Instance.runLog("Close serial port " + this.port.PortName + " OK!", LogLevel.NORMAL);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.runLog("Close serial port " + this.port.PortName + " failed with exception: " + ex.Message.ToString(), LogLevel.WARN);
            }

            return true;
        }

        /// <summary>
        /// receive handle: receive here, verify on derived class  and handle on listeners
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        
        }

        protected virtual void doAfterPortOpen()
        {

        }

    }
}
