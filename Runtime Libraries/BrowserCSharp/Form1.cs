using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser Chrome;
        SimpleHTTPServer Server;

        void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            Debug.WriteLine("STARTING INTERNAL SERVER");

            var path = "";
            var port = 0;
            try
            {

                path = Environment.GetEnvironmentVariable("Web-Run-Directory");
                //path = "C:\\Users\\SamarthCat™\\Documents\\SamsidPartySite";
                if (!Directory.Exists(path)) { throw new Exception(); }

                if (File.Exists(path + "\\favicon.ico"))
                {
                    this.Icon = new Icon(path + "\\favicon.ico");
                }

                Server = new SimpleHTTPServer(path);
                port = Server.Port;
                Chrome = new ChromiumWebBrowser("http://127.0.0.1:" + port);
                
            }
            catch
            {
                Debug.WriteLine("Reverting To Google");
                path = "https://google.com";
                Chrome = new ChromiumWebBrowser(path);
            }

            Chrome.TitleChanged += ChangeTitle;
            this.panel1.Controls.Add(Chrome);

        }

        void ChangeTitle(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() => {
                this.Text = e.Title;
            }));
            
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            try { Server.Stop(); }
            catch { }
            Environment.Exit(0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Alt) == Keys.Alt) && e.KeyCode == Keys.Left)
            {
                Chrome.Back();
            }
            else if (((Control.ModifierKeys & Keys.Alt) == Keys.Alt) && e.KeyCode == Keys.Right)
            {
                Chrome.Forward();
            }
        }

    
    }
}
