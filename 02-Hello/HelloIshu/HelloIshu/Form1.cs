using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloIshu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
            TcpListener tcplist = new TcpListener(System.Net.IPAddress.Any, 4444);
            tcplist.Start();

            Socket socketForClient = tcplist.AcceptSocket();
            NetworkStream networkstream = new NetworkStream(socketForClient);
            StreamReader streamReader = new StreamReader(networkstream);

            string line = streamReader.ReadLine();

            if (line.LastIndexOf("m") >= 0) MessageBox.Show("Hello Baby");





            streamReader.Close();
            networkstream.Close();
            socketForClient.Close();
            tcplist.Stop();
            System.Environment.Exit(0);
        }
    }
}
