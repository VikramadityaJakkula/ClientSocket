using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace clientsocket
{
	/// <summary>
	/// Summary description for Form1 (socket client).
	/// </summary>
	public class socketclient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button buttonDisconnect;
		private System.Windows.Forms.Button buttonSendMessage;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.TextBox textBoxConnectStatus;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.RichTextBox richTextTxMessage;
		private System.Windows.Forms.RichTextBox richTextRxMessage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		byte[] m_dataBuffer = new byte [10];
		IAsyncResult m_result;
		int port;
		public AsyncCallback m_pfnCallBack ;
		public Socket m_clientSocket;

		public socketclient()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			textBoxIP.Text = GetIP();
            
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnClear = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxConnectStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.richTextTxMessage = new System.Windows.Forms.RichTextBox();
            this.richTextRxMessage = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(408, 225);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 24);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.Silver;
            this.buttonDisconnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.ForeColor = System.Drawing.Color.Yellow;
            this.buttonDisconnect.Location = new System.Drawing.Point(464, 17);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(72, 48);
            this.buttonDisconnect.TabIndex = 30;
            this.buttonDisconnect.Text = "Disconnet From Server";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(40, 193);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(240, 24);
            this.buttonSendMessage.TabIndex = 29;
            this.buttonSendMessage.Text = "Send Message";
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(32, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Connection Status";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(472, 225);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(64, 24);
            this.buttonClose.TabIndex = 27;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxConnectStatus
            // 
            this.textBoxConnectStatus.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConnectStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxConnectStatus.Location = new System.Drawing.Point(160, 233);
            this.textBoxConnectStatus.Name = "textBoxConnectStatus";
            this.textBoxConnectStatus.ReadOnly = true;
            this.textBoxConnectStatus.Size = new System.Drawing.Size(240, 13);
            this.textBoxConnectStatus.TabIndex = 26;
            this.textBoxConnectStatus.Text = "Not Connected";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Message To Server";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(288, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Message From Server";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.ForeColor = System.Drawing.Color.Yellow;
            this.buttonConnect.Location = new System.Drawing.Point(376, 17);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(72, 48);
            this.buttonConnect.TabIndex = 23;
            this.buttonConnect.Text = "Connect To Server";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(144, 40);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(48, 20);
            this.textBoxPort.TabIndex = 22;
            this.textBoxPort.Text = "8000";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Server Port";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Server IP Address";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(144, 17);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(152, 20);
            this.textBoxIP.TabIndex = 19;
            // 
            // richTextTxMessage
            // 
            this.richTextTxMessage.Location = new System.Drawing.Point(40, 89);
            this.richTextTxMessage.Name = "richTextTxMessage";
            this.richTextTxMessage.Size = new System.Drawing.Size(240, 96);
            this.richTextTxMessage.TabIndex = 18;
            this.richTextTxMessage.Text = "";
            this.richTextTxMessage.TextChanged += new System.EventHandler(this.richTextTxMessage_TextChanged);
            // 
            // richTextRxMessage
            // 
            this.richTextRxMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextRxMessage.Location = new System.Drawing.Point(288, 89);
            this.richTextRxMessage.Name = "richTextRxMessage";
            this.richTextRxMessage.ReadOnly = true;
            this.richTextRxMessage.Size = new System.Drawing.Size(248, 128);
            this.richTextRxMessage.TabIndex = 17;
            this.richTextRxMessage.Text = "";
            // 
            // socketclient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 266);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxConnectStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.richTextTxMessage);
            this.Controls.Add(this.richTextRxMessage);
            this.Name = "socketclient";
            this.Text = "socketclient";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new socketclient());
		}
        // This is for the close button click.
		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			if ( m_clientSocket != null )
			{
				m_clientSocket.Close ();
				m_clientSocket = null;
			}		
			Close();
		}
		// this is for the button connect click.
		private void buttonConnect_Click(object sender, System.EventArgs e)
		{
			if(textBoxIP.Text == "" || textBoxPort.Text == "")
			{
				MessageBox.Show("IP Address and Port Number are required to connect to the Server\n");
				return;
			}
			string portStr = textBoxPort.Text;
			port = System.Convert.ToInt32(portStr);
			if (port <= 1024)
			{
				MessageBox.Show("Please enter another port number above 1024 and less than 32768"); 
				return;		
			}

			if (port >= 32768)
			{
				MessageBox.Show("Please enter another port number above 1024 and less than 32768"); 
				return;		
			}
				
			try
			{
				UpdateControls(false);
				// Create the socket instance
				m_clientSocket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
				
				// Cet the remote IP address
				IPAddress ip = IPAddress.Parse (textBoxIP.Text);
				int iPortNo = System.Convert.ToInt16 ( textBoxPort.Text);
				// Create the end point 
				IPEndPoint ipEnd = new IPEndPoint (ip,iPortNo);
				// Connect to the remote host
				m_clientSocket.Connect ( ipEnd );
				if(m_clientSocket.Connected) 
				{
					
					UpdateControls(true);
					//Wait for data asynchronously 
					WaitForData();
				}
			}
			catch(SocketException se)
			{
				string str;
				str = "\nConnection failed, is the server running?\n" + se.Message;
				MessageBox.Show (str);
				UpdateControls(false);
			}
		}
		// This is for the Send Button Click.
		private void buttonSendMessage_Click(object sender, System.EventArgs e)
		{
			try
			{
				string msg = richTextTxMessage.Text;
				// New code to send strings
				NetworkStream networkStream = new NetworkStream(m_clientSocket);
				System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
				streamWriter.WriteLine(msg);
				streamWriter.Flush();

				/*//Use the following code to send bytes
				byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString ());
				if(m_clientSocket != null){
					m_clientSocket.Send (byData);
				}*/
				
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}	
		}
		public void WaitForData()
		{
			try
			{
				if  ( m_pfnCallBack == null ) 
				{
					m_pfnCallBack = new AsyncCallback (OnDataReceived);
				}
				SocketPacket theSocPkt = new SocketPacket ();
				theSocPkt.thisSocket = m_clientSocket;
				// Start listening to the data asynchronously
				m_result = m_clientSocket.BeginReceive (theSocPkt.dataBuffer,
					0, theSocPkt.dataBuffer.Length,
					SocketFlags.None, 
					m_pfnCallBack, 
					theSocPkt);
                 }
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}

		}
		public class SocketPacket
		{
			public System.Net.Sockets.Socket thisSocket;
			public byte[] dataBuffer = new byte[1024];
		}

		public  void OnDataReceived(IAsyncResult asyn)
		{
			try
			{
				SocketPacket theSockId = (SocketPacket)asyn.AsyncState ;
				int iRx  = theSockId.thisSocket.EndReceive (asyn);
				char[] chars = new char[iRx +  1];
				System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
				int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
				System.String szData = new System.String(chars);
				richTextRxMessage.Text = richTextRxMessage.Text + szData;
				WaitForData();
			}
			catch (ObjectDisposedException )
			{
				System.Diagnostics.Debugger.Log(0,"1","\nOnDataReceived: Socket has been closed\n");
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}
		}	
		private void UpdateControls( bool connected ) 
		{
			buttonConnect.Enabled = !connected;
			buttonDisconnect.Enabled = connected;
			string connectStatus = connected? "Connected" : "Not Connected";
			textBoxConnectStatus.Text = connectStatus;
		}
		// disconnect the client.
		private void buttonDisconnect_Click(object sender, System.EventArgs e)
		{
			if ( m_clientSocket != null )
			{
				m_clientSocket.Close();
				m_clientSocket = null;
				UpdateControls(false);
			}
		}
		//----------------------------------------------------	
		// This is a helper function used (for convenience) to 
		// get the IP address of the local machine
		//----------------------------------------------------
		String GetIP()
		{	   
			String strHostName = Dns.GetHostName();
		
			// Find host by name
			IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
		
			// Grab the first IP addresses
			String IPStr = "";
			foreach(IPAddress ipaddress in iphostentry.AddressList)
			{
				IPStr = ipaddress.ToString();
				return IPStr;
			}
			return IPStr;
		}
		// to clear the textfield.
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			richTextRxMessage.Clear();

		}

        private void richTextTxMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
