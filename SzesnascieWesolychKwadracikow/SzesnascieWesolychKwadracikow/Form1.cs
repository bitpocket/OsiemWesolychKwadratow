using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.Threading;

namespace SzesnascieWesolychKwadracikow
{
    public partial class Form1 : Form
    {
        public OutputDevice outDevice1 = null;
        public OutputDevice outDevice2 = null;
        private InputDevice inDevice1 = null;
        private InputDevice inDevice2 = null;
        private SynchronizationContext context;
        Panel[,] panele = new Panel[4, 4];

        public bool DeviceOK = true;

        public Form1()
        {
            InitializeComponent();

            panele[0, 0] = panel1;
            panele[1, 0] = panel2;
            panele[2, 0] = panel3;
            panele[3, 0] = panel4;

            panele[0, 1] = panel5;
            panele[1, 1] = panel6;
            panele[2, 1] = panel7;
            panele[3, 1] = panel8;

            panele[0, 2] = panel9;
            panele[1, 2] = panel10;
            panele[2, 2] = panel11;
            panele[3, 2] = panel12;

            panele[0, 3] = panel13;
            panele[1, 3] = panel14;
            panele[2, 3] = panel15;
            panele[3, 3] = panel16;

            List<Point> droga = new List<Point>();
            droga.Add(new Point(0, 0));
            droga.Add(new Point(1, 0));
            droga.Add(new Point(2, 0));
            droga.Add(new Point(3, 0));
            droga.Add(new Point(3, 1));
            droga.Add(new Point(3, 2));
            droga.Add(new Point(3, 3));
            ListaDrog.Add(droga);


            List<Point> droga1 = new List<Point>();
            droga1.Add(new Point(0, 0));
            droga1.Add(new Point(1, 0));
            droga1.Add(new Point(2, 0));
            droga1.Add(new Point(2, 1));
            droga1.Add(new Point(3, 1));
            droga1.Add(new Point(3, 2));
            droga1.Add(new Point(3, 3));
            ListaDrog.Add(droga1);

            List<Point> droga2 = new List<Point>();
            droga2.Add(new Point(0, 0));
            droga2.Add(new Point(1, 0));
            droga2.Add(new Point(1, 1));
            droga2.Add(new Point(2, 1));
            droga2.Add(new Point(3, 1));
            droga2.Add(new Point(3, 2));
            droga2.Add(new Point(3, 3));
            ListaDrog.Add(droga2);

            List<Point> droga3 = new List<Point>();
            droga3.Add(new Point(0, 0));
            droga3.Add(new Point(0, 1));
            droga3.Add(new Point(1, 1));
            droga3.Add(new Point(2, 1));
            droga3.Add(new Point(3, 1));
            droga3.Add(new Point(3, 2));
            droga3.Add(new Point(3, 3));
            ListaDrog.Add(droga3);

            List<Point> droga4 = new List<Point>();
            droga4.Add(new Point(0, 0));
            droga4.Add(new Point(0, 1));
            droga4.Add(new Point(1, 1));
            droga4.Add(new Point(2, 1));
            droga4.Add(new Point(2, 2));
            droga4.Add(new Point(3, 2));
            droga4.Add(new Point(3, 3));
            ListaDrog.Add(droga4);

            List<Point> droga5 = new List<Point>();
            droga5.Add(new Point(0, 0));
            droga5.Add(new Point(0, 1));
            droga5.Add(new Point(1, 1));
            droga5.Add(new Point(1, 2));
            droga5.Add(new Point(2, 2));
            droga5.Add(new Point(3, 2));
            droga5.Add(new Point(3, 3));
            ListaDrog.Add(droga5);

            List<Point> droga6 = new List<Point>();
            droga6.Add(new Point(0, 0));
            droga6.Add(new Point(0, 1));
            droga6.Add(new Point(0, 2));
            droga6.Add(new Point(1, 2));
            droga6.Add(new Point(2, 2));
            droga6.Add(new Point(3, 2));
            droga6.Add(new Point(3, 3));
            ListaDrog.Add(droga6);

            List<Point> droga7 = new List<Point>();
            droga7.Add(new Point(0, 0));
            droga7.Add(new Point(0, 1));
            droga7.Add(new Point(0, 2));
            droga7.Add(new Point(1, 2));
            droga7.Add(new Point(2, 2));
            droga7.Add(new Point(2, 3));
            droga7.Add(new Point(3, 3));
            ListaDrog.Add(droga7);

            List<Point> droga8 = new List<Point>();
            droga8.Add(new Point(0, 0));
            droga8.Add(new Point(0, 1));
            droga8.Add(new Point(0, 2));
            droga8.Add(new Point(1, 2));
            droga8.Add(new Point(1, 3));
            droga8.Add(new Point(2, 3));
            droga8.Add(new Point(3, 3));
            ListaDrog.Add(droga8);

            List<Point> droga9 = new List<Point>();
            droga9.Add(new Point(0, 0));
            droga9.Add(new Point(0, 1));
            droga9.Add(new Point(0, 2));
            droga9.Add(new Point(0, 3));
            droga9.Add(new Point(1, 3));
            droga9.Add(new Point(2, 3));
            droga9.Add(new Point(3, 3));
            ListaDrog.Add(droga9);

            List<Point> droga10 = new List<Point>();
            droga10.Add(new Point(0, 0));
            droga10.Add(new Point(1, 0));
            droga10.Add(new Point(2, 0));
            droga10.Add(new Point(2, 1));
            droga10.Add(new Point(2, 2));
            droga10.Add(new Point(3, 2));
            droga10.Add(new Point(3, 3));
            ListaDrog.Add(droga10);

            List<Point> droga11 = new List<Point>();
            droga11.Add(new Point(0, 0));
            droga11.Add(new Point(1, 0));
            droga11.Add(new Point(2, 0));
            droga11.Add(new Point(2, 1));
            droga11.Add(new Point(2, 2));
            droga11.Add(new Point(2, 3));
            droga11.Add(new Point(3, 3));
            ListaDrog.Add(droga11);

            List<Point> droga12 = new List<Point>();
            droga12.Add(new Point(0, 0));
            droga12.Add(new Point(1, 0));
            droga12.Add(new Point(1, 1));
            droga12.Add(new Point(2, 1));
            droga12.Add(new Point(2, 2));
            droga12.Add(new Point(2, 3));
            droga12.Add(new Point(3, 3));
            ListaDrog.Add(droga12);

            List<Point> droga13 = new List<Point>();
            droga13.Add(new Point(0, 0));
            droga13.Add(new Point(1, 0));
            droga13.Add(new Point(1, 1));
            droga13.Add(new Point(1, 2));
            droga13.Add(new Point(2, 2));
            droga13.Add(new Point(2, 3));
            droga13.Add(new Point(3, 3));
            ListaDrog.Add(droga13);

            List<Point> droga14 = new List<Point>();
            droga14.Add(new Point(0, 0));
            droga14.Add(new Point(1, 0));
            droga14.Add(new Point(1, 1));
            droga14.Add(new Point(1, 2));
            droga14.Add(new Point(1, 3));
            droga14.Add(new Point(2, 3));
            droga14.Add(new Point(3, 3));
            ListaDrog.Add(droga14);

            List<Point> droga15 = new List<Point>();
            droga15.Add(new Point(0, 0));
            droga15.Add(new Point(0, 1));
            droga15.Add(new Point(1, 1));
            droga15.Add(new Point(1, 2));
            droga15.Add(new Point(1, 3));
            droga15.Add(new Point(2, 3));
            droga15.Add(new Point(3, 3));
            ListaDrog.Add(droga15);

            List<Point> droga16 = new List<Point>();
            droga16.Add(new Point(0, 0));
            droga16.Add(new Point(0, 1));
            droga16.Add(new Point(0, 2));
            droga16.Add(new Point(1, 2));
            droga16.Add(new Point(1, 3));
            droga16.Add(new Point(2, 3));
            droga16.Add(new Point(3, 3));
            ListaDrog.Add(droga16);

            droga = new List<Point>();
            droga.Add(new Point(0, 0));
            droga.Add(new Point(0, 1));
            droga.Add(new Point(1, 1));
            droga.Add(new Point(1, 2));
            droga.Add(new Point(2, 2));
            droga.Add(new Point(2, 3));
            droga.Add(new Point(3, 3));
            ListaDrog.Add(droga);

            droga = new List<Point>();
            droga.Add(new Point(0, 0));
            droga.Add(new Point(0, 1));
            droga.Add(new Point(1, 1));
            droga.Add(new Point(2, 1));
            droga.Add(new Point(2, 2));
            droga.Add(new Point(2, 3));
            droga.Add(new Point(3, 3));
            ListaDrog.Add(droga);

            droga = new List<Point>();
            droga.Add(new Point(0, 0));
            droga.Add(new Point(1, 0));
            droga.Add(new Point(1, 1));
            droga.Add(new Point(2, 1));
            droga.Add(new Point(2, 2));
            droga.Add(new Point(3, 2));
            droga.Add(new Point(3, 3));
            ListaDrog.Add(droga);

            droga = new List<Point>();
            droga.Add(new Point(0, 0));
            droga.Add(new Point(1, 0));
            droga.Add(new Point(1, 1));
            droga.Add(new Point(1, 2));
            droga.Add(new Point(2, 2));
            droga.Add(new Point(3, 2));
            droga.Add(new Point(3, 3));
            ListaDrog.Add(droga);


            if (OutputDevice.DeviceCount < 3)
            {
                DeviceOK = false;
                MessageBox.Show("No LPD8 x 2 = No game", "Game Over",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);                

                //Close();
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;
                    outDevice1 = new OutputDevice(1);
                    outDevice1.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);

                    context = SynchronizationContext.Current;
                    outDevice2 = new OutputDevice(2);
                    outDevice2.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
                }
                catch (Exception ex)
                {
                    DeviceOK = false;
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //Close();
                }
            }


            if (DeviceOK)
            if (InputDevice.DeviceCount < 2)
            {
                DeviceOK = false;
                MessageBox.Show("LPD8 x2 = No game", "Game Over",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Close();
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;

                    inDevice1 = new InputDevice(0);
                    inDevice1.ChannelMessageReceived += HandleChannelMessageReceived;
                    inDevice1.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);

                    AddLogDevice(0, InputDevice.GetDeviceCapabilities(0));

                    inDevice1.StartRecording();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    DeviceOK = false;
                    //Close();
                }

                try
                {
                    context = SynchronizationContext.Current;

                    inDevice2 = new InputDevice(1);
                    inDevice2.ChannelMessageReceived += HandleChannelMessageReceived;
                    inDevice2.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);

                    AddLogDevice(1, InputDevice.GetDeviceCapabilities(1));

                    inDevice2.StartRecording();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    DeviceOK = false;
                    //Close();
                }
            }


            if (DeviceOK)
                Reset();
        }

        void AddLogDevice(int device, MidiInCaps mic)
        {
            //AddLog("device= " + device.ToString());
            //AddLog("name= " + mic.name.ToString());
            //AddLog("mid= " + mic.mid.ToString());
            //AddLog("pid= " + mic.pid.ToString());
            //AddLog("support= " + mic.support.ToString());
            //AddLog("driverVersion= " + mic.driverVersion.ToString());
        }

        void AddLog(string s)
        {
            //textBox1.Text += s + "\r\n";
        }

        private void inDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message, "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            //context.Post(delegate(object dummy)
            //{

            textBox1.Text += "message = " + e.Message.Command + "; ID" + e.Message.Data1 + "\r\n";

                int PanelID = e.Message.Data1;

                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (Convert.ToInt32(panele[x, y].Tag) == PanelID)
                        {
                            //if (e.Message.Command == ChannelCommand.NoteOn)
                            //    ZapalPanel(panele[x, y], Color.Orange);
                            //else
                            //    ZapalPanel(panele[x, y], Color.Black);

                            if (e.Message.Command == ChannelCommand.NoteOff)
                                panel13_MouseClick(panele[x, y], null);
                        }

                    }
                }
              //}, null);


            //SprawdzDroge_Click(null, null);
            
            }

        private void ZapalPanel(Panel panel,Color color)
        {
            panel.BackColor = color;

            AddLog("Panel ID " + panel.Tag + " <- " + color);
        }
        
 

        void Reset()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;


            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    panele[x, y].BackColor = Color.Black;
                    ZapalMidi(panele[x, y], ChannelCommand.NoteOff);
                }                
            }


        }

        bool PanelJestZapalony(int x, int y)
        {
            return panele[x, y].BackColor == Color.Orange;
        }




        private void panel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (timer1.Enabled)
            {
                if (!MigajacaDrogaOn) timer1_Tick(null, null);
            }


            if (((Panel)sender).BackColor == Color.Black)
            {
                ((Panel)sender).BackColor = Color.Orange;
                ZapalMidi((Panel)sender, ChannelCommand.NoteOn);
            }
            else
            {

                ((Panel)sender).BackColor = Color.Black;
                ZapalMidi((Panel)sender, ChannelCommand.NoteOff);            
            }

            SprawdzDroge_Click(null, null);            
        }

        private void ZapalMidi(Panel panel, ChannelCommand cm)
        {
            ChannelMessageBuilder cmb = new ChannelMessageBuilder();
            cmb.Command = cm;
            cmb.MidiChannel = 0;
            cmb.Data1 = Convert.ToInt32(panel.Tag);
            cmb.Data2 = 127;
            cmb.Build();

            outDevice1.Send(cmb.Result);
            outDevice2.Send(cmb.Result);
        }

        private void SprawdzDroge_Click(object sender, EventArgs e)
        {
            List<Point> d = SprawdzDroge(0, 0);

            if (d != null)
            {
                MigajacaDroga = d;
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        public List<List<Point>> ListaDrog = new List<List<Point>>();



        List<Point> SprawdzDroge(int x, int y)
        {
            foreach (List<Point> d in ListaDrog)
            {
                bool DrogaZnaleziona = true;

                foreach (Point p in d)
                {
                    DrogaZnaleziona = DrogaZnaleziona && (PanelJestZapalony(p.X, p.Y));
                }

                if (DrogaZnaleziona)
                    return d;
            }

            //Point p = new Point(0, 0);

            //if (PanelJestZapalony(p.X, p.Y))
            //{
            //    if (!(SprawdzDroge(p.X + 1, p.Y)))
            //        if (!SprawdzDroge(p.X, p.Y+1))
            //}

            return null;
        }

        private void bNewgame_Click(object sender, EventArgs e)
        {
            Reset();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            List<Point> droga = new List<Point>();

            textBox1.Text += "droga = new List<Point>();\r\n";

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (panele[x, y].BackColor == Color.Orange)
                    {
                        droga.Add(new Point(x, y));

                        textBox1.Text += "droga.Add(new Point(" + x.ToString() + ", " + y.ToString() + "));" + "\r\n";
                    }
                }
            }

            textBox1.Text += "ListaDrog.Add(droga);\r\n\r\n";

        }

        List<Point> MigajacaDroga = null;

        bool MigajacaDrogaOn = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MigajacaDroga != null)
            {
                MigajacaDrogaOn = !MigajacaDrogaOn;

                foreach (Point p in MigajacaDroga)
                {
                    if (MigajacaDrogaOn)
                    {
                        panele[p.X, p.Y].BackColor = Color.Orange;
                        ZapalMidi(panele[p.X, p.Y], ChannelCommand.NoteOn);
                    }
                    else
                    {
                        panele[p.X, p.Y].BackColor = Color.Black;
                        ZapalMidi(panele[p.X, p.Y], ChannelCommand.NoteOff);
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reset();

            inDevice1.StopRecording();
            inDevice2.StopRecording();
            inDevice1.Close();
            inDevice2.Close();

            outDevice1.Close();
            outDevice2.Close();


        }

        Int16 LiczDoMiliona = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            LiczDoMiliona = 0;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LiczDoMiliona++;

            int x, y;

            for (int i = 0; i < 15; i++)
            {
                x = i % 4;
                y = i / 4;

                if ((LiczDoMiliona & Convert.ToInt16(Math.Pow(2, i))) != 0)
                {
                    panele[x, y].BackColor = Color.Orange;
                    ZapalMidi(panele[x, y], ChannelCommand.NoteOn);
                }
                else
                {
                    panele[x, y].BackColor = Color.Black;
                    ZapalMidi(panele[x, y], ChannelCommand.NoteOff);
                }

            }
        }


    }
}
