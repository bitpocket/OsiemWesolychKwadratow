using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace OsiemWesolychKwadratow
{
    public partial class MainForm : Form
    {
        public OutputDevice outDevice1 = null;
        private InputDevice inDevice1 = null;
        private SynchronizationContext context;
        Panel[,] panele = new Panel[4, 2];

        public bool DeviceOK = true;

        public MainForm()
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

            foreach (GameType gameType in Enum.GetValues(typeof(GameType)))
            {
                lbxGames.Items.Add(gameType);
            }

            if (OutputDevice.DeviceCount < 2)
            {
                DeviceOK = false;
                MessageBox.Show("No LPD8 = No game", "Game Over",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;
                    outDevice1 = new OutputDevice(1);
                    outDevice1.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
                }
                catch (Exception ex)
                {
                    DeviceOK = false;
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }


            if (DeviceOK)
                if (InputDevice.DeviceCount < 1)
                {
                    DeviceOK = false;
                    MessageBox.Show("LPD8 = No game", "Game Over",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    }
                }


            if (DeviceOK)
                ResetSquares();
        }

        private void inDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message, "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
           // textBox1.Text += "message=" + e.Message.Command + "; ID=" + e.Message.Data1 + "; Val=" + e.Message.Data2 + "\r\n";

            int PanelID = e.Message.Data1;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (Convert.ToInt32(panele[x, y].Tag) == PanelID)
                    {
                        panel1_Click(panele[x, y], null);
						IGame game = GameController.Instance().currentGame;

						if (game != null)
						{
							game.ButtonPress(x, y);
						}
					}

                }
            }

            if (PanelID == 25)
            {
                int val = e.Message.Data2 / 10;

                if (val < lbxGames.Items.Count)
                {
                    lbxGames.SelectedIndex = val;
                    IGame game = GameController.Instance().currentGame;

                    if (game ==null || (int)game.GameType != val)
                    {
                        GameController.Instance().StartGame((GameType)val, CurrentGame_Repaint);
                    }
                }
            }
        }

        private void CurrentGame_Repaint(object sender, EventArgs e)
        {
            IGame game = GameController.Instance().currentGame;

            if (game != null)
            {
                SetSquares(game.GetState());
            }
        }

        private void ZapalMidi(Panel panel, ChannelCommand cm)
        {
            ChannelMessageBuilder cmb = new ChannelMessageBuilder();
            cmb.Command = cm;
            cmb.MidiChannel = 3;
            cmb.Data1 = Convert.ToInt32(panel.Tag);
            cmb.Data2 = 127;
            cmb.Build();

            outDevice1.Send(cmb.Result);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetSquares();
            inDevice1.StopRecording();
            inDevice1.Close();
            outDevice1.Close();
        }

        void ResetSquares()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    panele[x, y].BackColor = Color.Black;
                    ZapalMidi(panele[x, y], ChannelCommand.NoteOff);
                }
            }
        }

        void SetSquares(bool[,] arr)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (arr[x, y])
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

        private void panel1_Click(object sender, EventArgs e)
        {
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
        }

        void AddLogDevice(int device, MidiInCaps mic)
        {
            AddLog("device= " + device.ToString());
            AddLog("name= " + mic.name.ToString());
            AddLog("mid= " + mic.mid.ToString());
            AddLog("pid= " + mic.pid.ToString());
            AddLog("support= " + mic.support.ToString());
            AddLog("driverVersion= " + mic.driverVersion.ToString());
        }

        void AddLog(string s)
        {
            textBox1.Text += s + "\r\n";
        }
    }
}
