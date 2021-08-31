using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace ALE
{
    public partial class ALE : Form
    {
        public ALE()
        {
            InitializeComponent();

            foreach (String name in Properties.Settings.Default.SavedNames.Cast<string>().ToArray())
            {
                listBoxSavedNames.Items.Add(name);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            String final_output = "";
            Regex regexBasic, regexChat, regexRoll;

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
                "\\Advanced Combat Tracker\\FFXIVLogs";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        regexBasic = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(\w{4})\|");
                        regexChat = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(\w{4})\|(\S*\s\S*)\|(.*)\|");
                        regexRoll = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(204a)\|(.*)\|");

                        String cleaned_line, line;
                        String[] parts;
                        bool nameMatch;

                        using (var reader = new StreamReader(stream))
                        {
                            while (reader.Peek() >= 0)
                            {
                                cleaned_line = "";
                                line = reader.ReadLine();

                                if (regexBasic.IsMatch(line))
                                {
                                    parts = Regex.Split(line, @"\|");
                                    if (regexChat.IsMatch(line))
                                    {
                                        nameMatch = false;
                                        if (listBoxNames.Items.Count > 0)
                                        {
                                            foreach (String currName in listBoxNames.Items)
                                            {
                                                if (parts[3].Contains(currName))
                                                {
                                                    nameMatch = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (listBoxNames.Items.Count == 0 || nameMatch)
                                        {
                                            if (!checkBoxChannel.Checked)
                                            {
                                                switch (parts[2])
                                                {
                                                    case "000c" when checkBoxTellIn.Checked:
                                                        cleaned_line += ">> " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "000d" when checkBoxTellOut.Checked:
                                                        cleaned_line += parts[3] + " >> " + parts[4];
                                                        break;
                                                    default:
                                                        cleaned_line += parts[3] + ": " + parts[4];
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (parts[2])
                                                {
                                                    case "000a" when checkBoxSay.Checked:
                                                        cleaned_line += "(SAY) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "000b" when checkBoxShout.Checked:
                                                        cleaned_line += "(SHOUT) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "000c" when checkBoxTellIn.Checked:
                                                        cleaned_line += "(TELL) " + ">> " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "000d" when checkBoxTellOut.Checked:
                                                        cleaned_line += "(TELL) " + parts[3] + " >> " + parts[4];
                                                        break;
                                                    case "000e" when checkBoxParty.Checked:
                                                        cleaned_line += "(PARTY) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "000f" when checkBoxAlliance.Checked:
                                                        cleaned_line += "(ALLIANCE) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "001e" when checkBoxYell.Checked:
                                                        cleaned_line += "(YELL) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "001c" when checkBoxCustomEmote.Checked:
                                                        cleaned_line += "(CEMOTE) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "001d" when checkBoxCustomEmote.Checked:
                                                        cleaned_line += "(EMOTE) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "0018" when checkBoxFreeCompany.Checked:
                                                        cleaned_line += "(FC) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "0010" or "0011" or "0012" or "0013" or "0014" or "0015" or "0016" or "0017" when checkBoxLinkshell.Checked:
                                                        cleaned_line += "(LINKSHELL) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    case "0025" or "0065" or "0066" or "0067" or "0068" or "0069" or
                                                            "006a" or "006b" when checkBoxCW.Checked:
                                                        cleaned_line += "(CWLINKSHELL) " + parts[3] + ": " + parts[4];
                                                        break;
                                                    default:
                                                        if (checkBoxOther.Checked)
                                                        {
                                                            cleaned_line += "(OTHER) " + parts[3] + ": " + parts[4];
                                                        }
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    else if (regexRoll.IsMatch(line))
                                    {
                                        parts = Regex.Split(line, @"\|");
                                        if (checkBoxChannel.Checked)
                                        {
                                            cleaned_line += "(ROLL) " + parts[3];
                                        }
                                        else
                                        {
                                            cleaned_line += parts[3];
                                        }
                                    }
                                    
                                    if (!String.IsNullOrEmpty(cleaned_line)) 
                                    {
                                        if (checkBoxTimeStamps.Checked)
                                        {
                                            cleaned_line = "(" + parts[0] + parts[1] + ") | " + cleaned_line;
                                        }
                                        final_output += cleaned_line + "\n";
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

                Cursor.Current = Cursors.Default;

                MessageBox.Show("Parsing complete.", "Confirmation", MessageBoxButtons.OK);

                saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.FileName = "ExtractedLog";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                saveFileDialog1.ShowDialog();
                string name = saveFileDialog1.FileName;
                try
                {
                    File.WriteAllText(name, final_output);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Empty file name. " + ex.Message);
                }
            }
        }

        private void buttonAddName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNameInput.Text)) {
                listBoxNames.Items.Add(textBoxNameInput.Text);
                textBoxNameInput.Clear();
            }
        }

        private void buttonRemoveName_Click(object sender, EventArgs e)
        {
            if (listBoxNames.SelectedIndex != -1)
            {
                listBoxNames.Items.RemoveAt(listBoxNames.SelectedIndex);
            }
        }

        private void buttonAddSavedName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSavedNameInput.Text))
            {

                Properties.Settings.Default.SavedNames.Add(textBoxSavedNameInput.Text);

                listBoxSavedNames.Items.Add(textBoxSavedNameInput.Text);
                textBoxSavedNameInput.Clear();

                Properties.Settings.Default.Save();
            }
        }

        private void buttonRemoveSavedName_Click(object sender, EventArgs e)
        {
            if (listBoxSavedNames.SelectedIndex != -1)
            {
                Properties.Settings.Default.SavedNames.Remove(listBoxSavedNames.SelectedItem.ToString());

                listBoxSavedNames.Items.Remove(listBoxSavedNames.SelectedItem);

                Properties.Settings.Default.Save();
            }
        }

        private void buttonAddSavedNameToFilter_Click(object sender, EventArgs e)
        {
            if (listBoxSavedNames.SelectedIndex != -1 && !listBoxNames.Items.Contains(listBoxSavedNames.SelectedItem))
            {
                listBoxNames.Items.Add(listBoxSavedNames.SelectedItem);
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
