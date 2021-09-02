using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using System.Text;

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

        // TODO: Code this yourself instead of TextInfo, because TextInfo API may change to more accurately
        //       title case strings according to linguistic rules.
        private String toTitleCase(String s)
        {
            TextInfo TI = new CultureInfo("en-us", false).TextInfo;
            s = TI.ToTitleCase(s.ToLower());

            if (s.Contains("-"))
            {
                String[] parts = Regex.Split(s, @"\-");
                char[] sCharacters;
                s = parts[0];

                for (int i = 1; i < parts.Length; i++)
                {
                    if (!String.IsNullOrEmpty(parts[i])) {
                        sCharacters = parts[i].ToCharArray();
                        sCharacters[0] = Char.ToLower(sCharacters[0]);
                        parts[i] = new string(sCharacters);
                        s += "-" + parts[i];
                    }
                    else
                    {
                        s += "-";
                    }
                }
            }

            return s;
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            String final_output = "";
            Regex regexBasic, regexChat, regexRoll, regexWorldName, regexEmoteWorldName, regexPartyNumber;
            StringBuilder builder;

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
                        regexRoll = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(204a|104a|084a)\|(.*)\|");
                        regexWorldName = new Regex(@"(.*) [A-Z][a-z]*[A-Z]");
                        regexEmoteWorldName = new Regex(@"[A-Z]([a-z]|\-|\')* [A-Z][a-z]*[A-Z][a-z]*");
                        regexPartyNumber = new Regex(@"[^\s][A-Z]");

                        String cleaned_line, line;
                        String[] parts;
                        String characterName;
                        Match match;

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
                                        characterName = "";

                                        // If there are name filters active, go through each name filter in the
                                        // list. If one of the names in the list matches with the name in the
                                        // current line being read, then we have a matched name and will
                                        // extract that line.
                                        if (listBoxNames.Items.Count > 0)
                                        {
                                            foreach (String currName in listBoxNames.Items)
                                            {
                                                if (parts[3].Contains(currName))
                                                {
                                                    // We use currName, which is the name in the list, because it
                                                    // will not have any World Names after it (if the character is
                                                    // from a different world than the user).
                                                    characterName = currName;
                                                    break;
                                                }
                                            }
                                        }
                                        else // if there are no name filters active, then we will always extract the line.
                                        {
                                            // Chop off world name if there is one. If there isn't one, use the regular name.
                                            match = regexWorldName.Match(parts[3]);
                                            if (match.Success)
                                            {
                                                characterName = (match.Value).Substring(0, (match.Value).Length - 1);
                                            }
                                            else
                                            {
                                                characterName = parts[3];
                                            }

                                            match = regexPartyNumber.Match(characterName);
                                            if (match.Success)
                                            {
                                                characterName = characterName.Substring(1);
                                            }
                                        }

                                        // if there are no name filters, always proceed.
                                        // OR
                                        // if there was a matched name (which only occurs if name filters are active), then proceed.
                                        if (listBoxNames.Items.Count == 0 || !String.IsNullOrEmpty(characterName))
                                        {
                                            switch (parts[2])
                                            {
                                                case "000a" when checkBoxSay.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(SAY) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "000b" when checkBoxShout.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(SHOUT) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "000c" when checkBoxTellIn.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(TELL) " + ">> " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += ">> " + characterName + ": " + parts[4];
                                                    break;
                                                case "000d" when checkBoxTellOut.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(TELL) " + characterName + " >> " + parts[4];
                                                    else
                                                        cleaned_line += characterName + " >> " + parts[4];
                                                    break;
                                                case "000e" when checkBoxParty.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(PARTY) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "000f" when checkBoxAlliance.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(ALLIANCE) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "001e" when checkBoxYell.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(YELL) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "001c" when checkBoxCustomEmote.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(CEMOTE) " + characterName + parts[4];
                                                    else
                                                        cleaned_line += characterName + parts[4];
                                                    break;
                                                case "001d" when checkBoxEmote.Checked:
                                                    match = regexEmoteWorldName.Match(parts[4]);
                                                    if (match.Success)
                                                    {
                                                        builder = new StringBuilder(parts[4]);
                                                        while (match.Success)
                                                        {
                                                            characterName = (match.Value).Substring(0, (match.Value).Length - 1);
                                                            builder.Replace(match.Value, characterName);
                                                            match = regexEmoteWorldName.Match(builder.ToString());
                                                        }

                                                        if (checkBoxChannel.Checked)
                                                            cleaned_line += "(EMOTE) " + builder.ToString();
                                                        else
                                                            cleaned_line += builder.ToString();
                                                    }
                                                    else
                                                    {
                                                        if (checkBoxChannel.Checked)
                                                            cleaned_line += "(EMOTE) " + parts[4];
                                                        else
                                                            cleaned_line += parts[4];
                                                    }
                                                    break;
                                                case "0018" when checkBoxFreeCompany.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(FC) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "0010" or "0011" or "0012" or "0013" or "0014" or "0015" or "0016" or "0017" when checkBoxLinkshell.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(LINKSHELL) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                case "0025" or "0065" or "0066" or "0067" or "0068" or "0069" or
                                                        "006a" or "006b" when checkBoxCW.Checked:
                                                    if (checkBoxChannel.Checked)
                                                        cleaned_line += "(CWLINKSHELL) " + characterName + ": " + parts[4];
                                                    else
                                                        cleaned_line += characterName + ": " + parts[4];
                                                    break;
                                                default:
                                                    if (checkBoxOther.Checked)
                                                    {
                                                        if (checkBoxChannel.Checked)
                                                            cleaned_line += "(OTHER) " + characterName + ": " + parts[4];
                                                        else
                                                            cleaned_line += characterName + ": " + parts[4];
                                                        break;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    else if (checkBoxRolls.Checked && regexRoll.IsMatch(line))
                                    {
                                        parts = Regex.Split(line, @"\|");

                                        characterName = "";
                                        if (listBoxNames.Items.Count > 0)
                                        {
                                            foreach (String currName in listBoxNames.Items)
                                            {
                                                // this always assumes that user wants their rolls included
                                                if (parts[4].Contains(currName))
                                                {
                                                    characterName = currName;
                                                    break;
                                                }
                                                else if (parts[4].Contains("Random! You ")) {

                                                }
                                            }
                                        }
                                        // with roll, we don't know where the name will be, so we need to replace it
                                        // We use StringBuilder to do so
                                        if (listBoxNames.Items.Count == 0 || !String.IsNullOrEmpty(characterName))
                                        {
                                            match = regexEmoteWorldName.Match(parts[4]);
                                            builder = new StringBuilder(parts[4]);
                                            while (match.Success)
                                            {
                                                characterName = (match.Value).Substring(0, (match.Value).Length - 1);
                                                builder.Replace(match.Value, characterName);
                                                match = regexEmoteWorldName.Match(builder.ToString());
                                            }

                                            if (checkBoxChannel.Checked)
                                            {
                                                cleaned_line += "(ROLL) " + builder.ToString();
                                            }
                                            else
                                            {
                                                cleaned_line += builder.ToString();
                                            }
                                        }
                                    }
                                    
                                    if (!String.IsNullOrEmpty(cleaned_line)) 
                                    {
                                        if (checkBoxTimeStamps.Checked)
                                        {
                                            cleaned_line = "(" + parts[0] + parts[1] + ") | " + cleaned_line;
                                        }

                                        if (checkBoxSpaceMessages.Checked)
                                        {
                                            final_output += cleaned_line + "\n" + "\n";
                                        }
                                        else
                                        {
                                            final_output += cleaned_line + "\n";
                                        }
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
                listBoxNames.Items.Add(toTitleCase(textBoxNameInput.Text));
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

                Properties.Settings.Default.SavedNames.Add(toTitleCase(textBoxSavedNameInput.Text));

                listBoxSavedNames.Items.Add(toTitleCase(textBoxSavedNameInput.Text));
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

        private void buttonALEDir_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.Arguments = Directory.GetCurrentDirectory();
            Process.Start(startInfo);
        }

        private void buttonLogsDir_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
                @"\Advanced Combat Tracker\FFXIVLogs";
            Process.Start(startInfo);
        }

        private void buttonKOFI_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.Verb = "open";
            startInfo.FileName = @"https://ko-fi.com/yesokcool";
            Process.Start(startInfo);
        }

        private void buttonGithub_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.Verb = "open";
            startInfo.FileName = @"https://github.com/yesokcool/ALE";
            Process.Start(startInfo);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxNames.Items.Clear();
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            (listBoxNames.Items).AddRange(listBoxSavedNames.Items);
        }

        private void textBoxSavedNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAddSavedName_Click(sender, e);
            }
        }

        private void textBoxNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAddName_Click(sender, e);
            }
        }

        private void listBoxSavedNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonRemoveSavedName_Click(sender, e);
            }
        }

        private void listBoxNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonRemoveName_Click(sender, e);
            }
        }
    }
}
