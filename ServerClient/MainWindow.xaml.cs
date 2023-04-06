using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int port = 8080;
        static string address = "127.0.0.1";
        string text = "";
        string filename = "";
        public MainWindow()
        {

            InitializeComponent();
        }
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

         TcpClient client = new TcpClient();

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            if (openFileDialog1.ShowDialog() == true) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    filename = openFileDialog1.FileName;
                }
                catch (IOException)
                {
                }
            }
            client.Connect(ipPoint);
        }
    }
}
