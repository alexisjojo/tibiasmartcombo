/*  This file is part of Tibia Smart Combo.

    Tibia Smart Combo is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Tibia Smart Combo is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Tibia Smart Combo.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ComboClient
{
    class SocketClient
    {
        Socket socketClient;
        public AsyncCallback ASyncCallBack;
        string strIp;
        int intPort;
        private FormBot formBot;
        protected byte[] pingCommand;
        protected byte[] pingResult;
        protected ManualResetEvent readComplete;
        protected byte lastSequenceNr = 0;
        private static SocketClient instanceSocketClient = null;
        protected Socket socket;
        private bool connected = false;
        public string strBuffer = "";

        public bool isConnected
        {
            get { return connected; }
        }

        public static SocketClient Instance(string PStrIp, int PIntPort, FormBot PFormBot)
        {

            if (instanceSocketClient == null)
                instanceSocketClient = new SocketClient(PStrIp, PIntPort, PFormBot);
            return instanceSocketClient;
        }

        private SocketClient(string PStrIp, int PIntPort, FormBot pformBot)
        {
            this.formBot = pformBot;
            this.strIp = PStrIp;
            this.intPort = PIntPort;
        }

        public void connect()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                readComplete = new ManualResetEvent(false);

                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ip = IPAddress.Parse(strIp);
                IPEndPoint ipEnd = new IPEndPoint(ip, intPort);
                socketClient.Connect(ipEnd);
                if (socketClient.Connected)
                {
                    connected = true;
                    WaitForData();
                }
            }
            catch (SocketException se)
            {
                string str;
                connected = false;
                str = "Connection failed, is the server running?" + se.Message;
                MessageBox.Show(str);
            }
        }

        private void WaitForData()
        {
            try
            {
                if (ASyncCallBack == null)
                {
                    ASyncCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket socketPacket = new SocketPacket();
                socketPacket.socketCurrent = socketClient;
                socketClient.BeginReceive(socketPacket.BAdatabuffer, 0,
                                     socketPacket.BAdatabuffer.Length,
                                     SocketFlags.None,
                                     ASyncCallBack,
                                     socketPacket);
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
        }

        private void OnDataReceived(IAsyncResult Pasyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)Pasyn.AsyncState;
                int iRx = 0;
                iRx = socketData.socketCurrent.EndReceive(Pasyn);
                char[] recivedSocketData = new char[iRx + 1];
                System.Text.Decoder decodeText = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = decodeText.GetChars(socketData.BAdatabuffer, 0, iRx, recivedSocketData, 0);
                System.String szData = new System.String(recivedSocketData);
                strBuffer += szData;
                strBuffer = strBuffer.Replace("\0", "");
                if (strBuffer.Contains("<END>"))
                {
                    int intIndex = strBuffer.IndexOf("<END>") + 5;
                    string strBuffer2 = strBuffer.Substring(0,intIndex);
                     formBot.handleDataReceived(strBuffer2);
                    strBuffer = strBuffer.Substring(intIndex);
                }
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
        }

        public void send(string PStrMsg)
        {
            try
            {
                if (socketClient.Connected)
                {
                    NetworkStream networkStream = new NetworkStream(socketClient);
                    System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
                    streamWriter.WriteLine(PStrMsg);
                    streamWriter.Flush();
                }
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
        }

        public void Disconnect()
        {
            if (socketClient != null)
            {
                socketClient.Close();
                connected = false;
                socket.Close();
                readComplete.Close();
            }
        }
        
        public int Ping(string address)
        {
            int intTimespan = 0;
            pingCommand = new byte[8];
            pingCommand[0] = 8;              
            pingCommand[1] = 0;              
            pingCommand[2] = 0;            
            pingCommand[3] = 0;
            pingCommand[4] = 1;            
            pingCommand[5] = 0;
            pingCommand[6] = 0;               
            pingCommand[7] = 0;
          
            pingResult = new byte[pingCommand.Length + 1000];

            for (int i = 0; i < 4; i++)
            {
                while (socketClient.Available > 0)
                    socketClient.Receive(pingResult, Math.Min(socketClient.Available, pingResult.Length), SocketFlags.None);
                readComplete.Reset();
                DateTime timeSend = DateTime.Now;
                pingCommand[6] = lastSequenceNr++;
                SetChecksum(pingCommand);
                int iSend = socket.SendTo(pingCommand, new IPEndPoint(IPAddress.Parse(address), 7171));
                socket.BeginReceive(pingResult, 0, pingResult.Length, SocketFlags.None, new AsyncCallback(CallBack), null);
                TimeSpan timeout = new TimeSpan(0, 0, 1);
                if (readComplete.WaitOne(timeout, false))

                    if ((pingResult[20] == 0) &&
                          (pingCommand[4] == pingResult[24]) && (pingCommand[5] == pingResult[25]) &&
                          (pingCommand[6] == pingResult[26]) && (pingCommand[7] == pingResult[27]))
                    {
                        TimeSpan timespan = DateTime.Now.Subtract(timeSend);
                        intTimespan += timespan.Milliseconds;
                    }
                    else
                    {
                        return 1000;
                    }
            }
            return intTimespan/4;
        }       

        protected void CallBack(IAsyncResult result)
        {
                try { socket.EndReceive(result); }
                catch (Exception) { }
                readComplete.Set();
        }




        protected void SetChecksum(byte[] tel)
        {
            tel[2] = 0;
            tel[3] = 0;
            uint cs = 0;
            for (int i = 0; i < pingCommand.Length; i = i + 2)
                cs += BitConverter.ToUInt16(pingCommand, i);
            cs = ~((cs & 0xffffu) + (cs >> 16));
            tel[2] = (byte)cs;
            tel[3] = (byte)(cs >> 8);
        }


        public class SocketPacket
        {
            public System.Net.Sockets.Socket socketCurrent;
            public byte[] BAdatabuffer = new byte[1];
        }
    }
}
