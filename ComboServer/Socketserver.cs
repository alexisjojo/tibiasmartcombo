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
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections;

namespace ComboServer
{
    public class Socketserver
    {
        public BListController blist;
        private Socket socketMain;
        private AsyncCallback ASyncCallBack;
        private ArrayList socketWorker = new ArrayList();
        private int intClientCount, intMaxClients = 0;
        private int intPort;
        private ArrayList ALintsClientId;
        private bool serverlistening = false;
        Protocol protocol;
        public Form_Main formMain;

        public Socketserver(int PintPoort, Form_Main formMain)
        {
            this.intPort = PintPoort;
            this.formMain = formMain;
            this.intMaxClients = 200;
            ALintsClientId = new ArrayList();
            blist = new BListController(this, formMain.World);
            protocol = new Protocol(blist);
        }

        public ArrayList Clients
        {
            get { return ALintsClientId; }
        }

        public void connect()
        {
            if (socketMain == null)
            {
                System.Console.ForegroundColor = ConsoleColor.Blue;
                formMain.Log = "Starting server";
                socketMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, intPort);
                socketMain.Bind(ipLocal);
                socketMain.Listen(intMaxClients);
            }
            serverlistening = true;
            socketMain.BeginAccept(new AsyncCallback(OnClientConnect), null);
            formMain.Log = "Succesfull";
            formMain.Log =  "Server started, listening to port: " + intPort;
            formMain.Log = "Max Clients to accept: " + intMaxClients;
        }


        private int getClientCount()
        {
            return socketWorker.Count + 1;
        }

        private void OnClientConnect(IAsyncResult Pasyn)
        {
            if (serverlistening)
            {
                try
                {
                    if (intClientCount <= socketWorker.Count)
                    {
                        if (socketWorker.Count < intMaxClients)
                        {
                            socketWorker.Add(socketMain.EndAccept(Pasyn));
                            SocketPacket PsocketPacket = new SocketPacket(500, this, protocol, socketWorker.Count);
                            PsocketPacket.socketCurrent = (Socket)socketWorker[intClientCount];
                            WaitForData(PsocketPacket);
                            intClientCount++;
                            formMain.Log = "New Client Connected";
                            formMain.Log = "Aantal clients: " + intClientCount;
                            socketMain.BeginAccept(new AsyncCallback(OnClientConnect), null);
                        }
                        else
                        {
                            Socket currentsocket = socketMain.EndAccept(Pasyn);
                            SocketPacket PsocketPacket = new SocketPacket(500, this, protocol, socketWorker.Count);
                            PsocketPacket.socketCurrent = currentsocket;
                            this.sendErrorMessage(currentsocket, 2);
                            currentsocket.Close();
                            formMain.Log = "Kicked client";
                            socketMain.BeginAccept(new AsyncCallback(OnClientConnect), null);
                        }
                    }
                }
                catch (ObjectDisposedException)
                {
                    formMain.Log = "OnClientConnection: Socket has been Closed";
                }
                catch (SocketException se)
                {
                   formMain.Log = se.Message;
                }
            }
        }

        private void OnClientDisconnect(IAsyncResult Pasyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)Pasyn.AsyncState;
                int SocketClientId = socketData.ClientID;
                for (int i = 0; i < ALintsClientId.Count; i++)
                {
                    int currentClientId = (int)ALintsClientId[i];
                    if (currentClientId == SocketClientId)
                    {
                        ALintsClientId.RemoveAt(i);
                    }
                }
                for (int i = 0; i < socketWorker.Count; i++)
                {
                    Socket currentsocket = (Socket)socketWorker[i];
                    if (!currentsocket.Connected)
                    {
                        blist.removeClient(i);
                        socketWorker.RemoveAt(i);
                        formMain.Log = "Client " + SocketClientId + " Disconnected";
                        intClientCount--;
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                formMain.Log = "OnClientConnection: Socket has been Closed";
            }
            catch (SocketException se)
            {
                formMain.Log = se.Message;
            }
        }


        private void WaitForData(SocketPacket PsocketPacket)        //Bij iedere nieuwe client wordt deze functie aangeroepen
        {
            try
            {
                if (ASyncCallBack == null)
                {
                    ASyncCallBack = new AsyncCallback(OnDataReceived);
                }
                PsocketPacket.socketCurrent.BeginReceive(PsocketPacket.BAdatabuffer, 0,
                                     PsocketPacket.BAdatabuffer.Length,
                                     SocketFlags.None,
                                     ASyncCallBack,
                                     PsocketPacket);
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
        }

        public void sendErrorMessage(Socket PsocketClient, int PintErrorCode)
        {
            String strMessage = "<ER>CODE=" + PintErrorCode + "</ER>";
            byte[] BAData = Encoding.ASCII.GetBytes(strMessage);
            if (PsocketClient.Connected)
                PsocketClient.Send(BAData);
        }


        private void OnDataReceived(IAsyncResult Pasyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)Pasyn.AsyncState;
                int intRx = 0;
                System.Text.Decoder decodeText = System.Text.Encoding.UTF8.GetDecoder();
                if (Pasyn != null)
                {
                    intRx = socketData.socketCurrent.EndReceive(Pasyn);
                    char[] CAreceivedSocketData = new char[intRx];
                    int charLen = decodeText.GetChars(socketData.BAdatabuffer, 0, intRx, CAreceivedSocketData, 0);
                    socketData.AddChars(CAreceivedSocketData);
                    WaitForData(socketData);
                }
            }
            catch (ObjectDisposedException)
            {
                formMain.Log = "OnDataReceived: Socket has been closed";
            }
            catch (SocketException se)
            {
                OnClientDisconnect(Pasyn);
                formMain.Log = se.Message;
            }
        }

        public void send(string PStrMsg, int id)
        {
            try
            {
                Object objData = PStrMsg;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());

                if (id <= socketWorker.Count)
                {
                    Socket currentSocket = (Socket)socketWorker[id - 1];
                    if (currentSocket != null)
                    {
                        if (currentSocket.Connected)
                        {
                            currentSocket.Send(byData);
                        }
                    }
                }
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
        }

        public void sendAll(string PStrMsg)
        {
            try
            {
                Object objData = PStrMsg;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());

                for (int i = 0; i < socketWorker.Count; i++)
                {
                    Socket currentSocket = (Socket)socketWorker[i];
                    if (currentSocket != null)
                    {
                        if (currentSocket.Connected)
                        {
                            currentSocket.Send(byData);
                        }
                    }
                }
            }
            catch (SocketException se)
            {
                System.Console.WriteLine(se.Message);
            }
        }

        public void CloseSockets()
        {
            for (int i = 0; i < socketWorker.Count; i++)
            {
                Socket currentsocket = (Socket)socketWorker[i];
                if (currentsocket != null)
                {
                    currentsocket.Close();
                    currentsocket = null;
                }
            }
            socketWorker.Clear();
            this.ALintsClientId.Clear();
            serverlistening = false;
            if (socketMain != null)
                socketMain.Close();
            socketMain = null;
            this.intClientCount = 0;
            formMain.Log = "Server closed all Clients and stopped listening";
        }

        public class SocketPacket
        {
            public Socket socketCurrent;
            public byte[] BAdatabuffer;
            public char[] CABuffer;
            public string strBuffer;
            public string strNaam;
            private int intDataLength, intClientID;
            private Socketserver server;
            Protocol protocol;
            public int socketworkerid;
            public SocketPacket(int PintDatalength, Socketserver Pserver, Protocol protocol, int socketworkerid)
            {
                this.protocol = protocol;
                this.intDataLength = PintDatalength;
                this.intClientID = -1;
                this.server = Pserver;
                this.socketworkerid = socketworkerid;
                BAdatabuffer = new byte[intDataLength];
                CABuffer = new Char[intDataLength];
                strBuffer = "";
            }

            public Socketserver Server
            {
                get { return server; }
            }

            public int ClientID
            {
                get { return intClientID; }
                set
                {
                    if (intClientID == -1)
                        intClientID = value;
                }
            }

            public void AddChars(char[] PCAInhoud)
            {
                strBuffer += new String(PCAInhoud);
                strBuffer = SocketReader.Read(this, strBuffer, protocol);
            }
        }
    }

    public class SocketReader
    {
        public static String Read(ComboServer.Socketserver.SocketPacket PSPsocketData, String PstrData, Protocol Pprotocol)
        {
            PstrData = PstrData.Replace("\0", "");
            while (PstrData.Contains("<INFO>") && PstrData.Contains("</INFO>"))
            {
                int intIndex = PstrData.IndexOf("</INFO>") + 7;
                string strBuffer2 = PstrData.Substring(0, intIndex);
                Pprotocol.handleInfo(strBuffer2, PSPsocketData.socketworkerid);
                PstrData = PstrData.Substring(intIndex);
            }
            if (PstrData.Contains("<PING>") && PstrData.Contains("</PING>"))
            {
                int intIndex = PstrData.IndexOf("</PING>");
                string strNaam = PstrData.Substring(6, intIndex-6);
                PSPsocketData.strNaam = strNaam;
                PstrData = PstrData.Substring(intIndex+8);
                string strData = "ACTION=PING;PLAYER=" + strNaam + ";<END>";
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(strData);
                PSPsocketData.socketCurrent.Send(byData);
            }
            return PstrData;
        }
    }
}