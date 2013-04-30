using Fiddler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Candyman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();

            Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
            {
                oS.bBufferResponse = true;
                Monitor.Enter(oAllSessions);
                oAllSessions.Add(oS);
                Monitor.Exit(oAllSessions);
            };

            Fiddler.FiddlerApplication.BeforeResponse += delegate(Fiddler.Session oS) {
                if (oS.host.Contains("candycrush") && oS.uriContains("/api/gameStart"))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    oS.utilDecodeResponse();
                    string json = System.Text.Encoding.ASCII.GetString(oS.ResponseBody);
                    try
                    {
                        CandyResponse res = jss.Deserialize<CandyResponse>(json);
                        LevelData ld = jss.Deserialize<LevelData>(res.levelData);
                        ld.numberOfColours = 3;
                        ld.moveLimit = 50;
                        res.levelData = jss.Serialize(ld);
                        res.currentUser.lives = 5;
                        res.currentUser.soundMusic = true;
                        res.currentUser.soundFx = true;
                        json = jss.Serialize(res);
                        byte[] resp = System.Text.Encoding.ASCII.GetBytes(json);
                        oS.ResponseBody = new byte[0];
                        oS.ResponseBody = resp;
                    }
                    catch (Exception ex)
                    { }
                }
            };
            Fiddler.CONFIG.IgnoreServerCertErrors = true;
            Fiddler.FiddlerApplication.Startup(8877, true, true, true);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //disable proxy
            Fiddler.FiddlerApplication.Shutdown();
            Thread.Sleep(500);
        }
    }
}
