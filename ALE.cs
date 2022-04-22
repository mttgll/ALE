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
        // Chat ID constants.
        const string Say = "000A";
        const string Shout = "000B";
        const string TellOut = "000C";
        const string TellIn = "000D";
        const string Party = "000E";
        const string Alliance = "000F";
        const string Yell = "001E";
        const string CustomEmote = "001C";
        const string Emote = "001D";
        const string FightingCompany = "0018";

        const string Linkshell1 = "0010";
        const string Linkshell2 = "0011";
        const string Linkshell3 = "0012";
        const string Linkshell4 = "0013";
        const string Linkshell5 = "0014";
        const string Linkshell6 = "0015";
        const string Linkshell7 = "0016";
        const string Linkshell8 = "0017";

        const string CrossWorldLinkshell1 = "0025";
        const string CrossWorldLinkshell2 = "0065";
        const string CrossWorldLinkshell3 = "0066";
        const string CrossWorldLinkshell4 = "0067";
        const string CrossWorldLinkshell5 = "0068";
        const string CrossWorldLinkshell6 = "0069";
        const string CrossWorldLinkshell7 = "006a";
        const string CrossWorldLinkshell8 = "006b";

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

        //      TextInfo API may change to more accurately
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
                    if (!String.IsNullOrEmpty(parts[i]))
                    {
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

            String chatLog = "";
            String combinedChatLog = "";
            Regex regexBasic, regexChat, regexRoll,
                regexWorldName, regexEmoteWorldName, regexPartyNumber;
            StringBuilder builder;

            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\Advanced Combat Tracker\\FFXIVLogs";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    chatLog = "";
                    try
                    {
                        if (file != null)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            // Regex that matches lines with a 4 letter ID.
                            // Ex. "00|2022-04-11T01:31:33.0000000-04:00|000F|"
                            regexBasic = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(\w{4})\|");

                            // Regex that matches with a 4 letter ID, and a player's name and message.
                            // Ex. "00|2022-04-11T01:31:33.0000000-04:00|000F|Player One|hello|"
                            regexChat = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(\w{4})\|(\S*\s\S*)\|(.*)\|");

                            // Regex that matches chat lines where a player is rolling.
                            regexRoll = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*(\-|\+)\d{2}\:\d{2}\|(204A|104A|084A)\|(.*)\|");

                            // Regex that matches chat when a player is from a different world.
                            // Ex. "00|2022-02-15T13:50:08.0000000-05:00|000E|Player OneB"
                            // (where the original text might continue as "Player OneBalmung") 
                            regexWorldName = new Regex(@"(.*) [A-Z][a-z]*[A-Z]");

                            // Regex that matches emotes when a player is from a different world.
                            regexEmoteWorldName = new Regex(@"[A-Z]([a-z]|\-|\')* [A-Z][a-z]*[A-Z][a-z]*");

                            // Regex that matches a player's party number.
                            regexPartyNumber = new Regex(@"[^\s][A-Z]");

                            String cleanedLine, line;
                            String[] parts;
                            String characterName;
                            Match match;

                            using (var reader = new StreamReader(file))
                            {
                                while (reader.Peek() >= 0)
                                {
                                    cleanedLine = "";
                                    line = reader.ReadLine();

                                    if (regexBasic.IsMatch(line))
                                    {
                                        // Split the string into pieces where the '|' character occurs.
                                        parts = Regex.Split(line, @"\|");
                                        if (regexChat.IsMatch(line))
                                        {
                                            characterName = "";

                                            // If there are name filters active, go through each name filter in the
                                            // list. If one of the names in the list matches with the name in the
                                            // current line being read, then we have a matched name and will
                                            // extract that line.
                                            // Else, we will always extract the line.
                                            if (listBoxNames.Items.Count > 0)
                                            {
                                                foreach (String currName in listBoxNames.Items)
                                                {
                                                    if (parts[3].Contains(currName))
                                                    {
                                                        // Conveniently use the name from the user's list
                                                        // rather than parts[3], since the user's list will
                                                        // not have any world names cluttering it up.
                                                        characterName = currName;
                                                        
                                                    }
                                                }
                                            }
                                            else
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

                                            // If there are no name filters, always proceed with parsing.
                                            // OR
                                            // If there was a matched name (which only occurs if name filters are active), then proceed with parsing.
                                            // Else (if there were name filters but no matches), we don't need to parse anything.
                                            if (listBoxNames.Items.Count == 0 || !String.IsNullOrEmpty(characterName))
                                            {
                                                cleanedLine = parseLine(parts[2], characterName, parts[4]);
                                            }
                                        }
                                        else if (checkBoxRolls.Checked && regexRoll.IsMatch(line))
                                        {
                                            parts = Regex.Split(line, @"\|");

                                            // This always assumes that user wants their rolls included.
                                            if (parts[4].Contains(" You roll a "))
                                            {
                                                if (checkBoxChannel.Checked)
                                                {
                                                    cleanedLine += "(ROLL) " + parts[4];
                                                }
                                                else
                                                {
                                                    cleanedLine += parts[4];
                                                }
                                            }
                                            else if (listBoxNames.Items.Count > 0)
                                            {
                                                characterName = "";
                                                foreach (String currName in listBoxNames.Items)
                                                {
                                                    if (parts[4].Contains(currName))
                                                    {
                                                        characterName = currName;
                                                    }
                                                }
                                                // With roll, we don't know where the name will be, so we need to replace it.
                                                // We use StringBuilder to do so.
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
                                                        cleanedLine += "(ROLL) " + builder.ToString();
                                                    }
                                                    else
                                                    {
                                                        cleanedLine += builder.ToString();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (checkBoxChannel.Checked)
                                                {
                                                    cleanedLine += "(ROLL) " + parts[4];
                                                }
                                                else
                                                {
                                                    cleanedLine += parts[4];
                                                }
                                            }
                                        }

                                        // Apply timestamps and message spaces if checked.
                                        if (!String.IsNullOrEmpty(cleanedLine))
                                        {
                                            if (checkBoxTimeStamps.Checked)
                                            {
                                                cleanedLine = "(" + parts[1].Substring(3, parts[1].Length - 17) + ") | " + cleanedLine;
                                            }

                                            if (checkBoxSpaceMessages.Checked)
                                            {
                                                chatLog += cleanedLine + "\n" + "\n";
                                            }
                                            else
                                            {
                                                chatLog += cleanedLine + "\n";
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

                    combinedChatLog += chatLog;
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
                    File.WriteAllText(name, combinedChatLog);
                    OpenWithDefaultProgram(name);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Empty file name. " + ex.Message);
                }
            }

            String parseLine(String id, String characterName, String message)
            {
                StringBuilder builder;
                Match match;

                switch (id)
                {
                    case Say when checkBoxSay.Checked:
                        if (checkBoxChannel.Checked)
                            return "(SAY) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Shout when checkBoxShout.Checked:
                        if (checkBoxChannel.Checked)
                            return "(SHOUT) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case TellOut when checkBoxTellIn.Checked:
                        if (checkBoxChannel.Checked)
                            return "(TELL) " + ">> " + characterName + ": " + message;
                        else
                            return ">> " + characterName + ": " + message;
                    case TellIn when checkBoxTellOut.Checked:
                        if (checkBoxChannel.Checked)
                            return "(TELL) " + characterName + " >> " + message;
                        else
                            return characterName + " >> " + message;
                    case Party when checkBoxParty.Checked:
                        if (checkBoxChannel.Checked)
                            return "(PARTY) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Alliance when checkBoxAlliance.Checked:
                        if (checkBoxChannel.Checked)
                            return "(ALLIANCE) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Yell when checkBoxYell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(YELL) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CustomEmote when checkBoxCustomEmote.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CEMOTE) " + characterName + message;
                        else
                            return characterName + message;
                    case Emote when checkBoxEmote.Checked:
                        match = regexEmoteWorldName.Match(message);
                        if (match.Success)
                        {
                            builder = new StringBuilder(message);
                            while (match.Success)
                            {
                                characterName = (match.Value).Substring(0, (match.Value).Length - 1);
                                builder.Replace(match.Value, characterName);
                                match = regexEmoteWorldName.Match(builder.ToString());
                            }

                            if (checkBoxChannel.Checked)
                                return "(EMOTE) " + builder.ToString();
                            else
                                return builder.ToString();
                        }
                        else
                        {
                            if (checkBoxChannel.Checked)
                                return "(EMOTE) " + message;
                            else
                                return message;
                        }
                    case FightingCompany when checkBoxFreeCompany.Checked:
                        if (checkBoxChannel.Checked)
                            return "(FC) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    // ========== Linkshells ==========
                    case Linkshell1 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL1) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell2 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL2) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell3 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL3) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell4 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL4) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell5 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL5) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell6 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL6) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell7 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL7) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case Linkshell8 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(LINKSHELL8) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    // ========== Crossworld Linkshells ==========
                    case CrossWorldLinkshell1 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CW LINKSHELL1) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell2 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL2) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell3 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL3) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell4 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL4) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell5 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL5) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell6 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL6) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell7 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL7) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    case CrossWorldLinkshell8 when checkBoxLinkshell.Checked:
                        if (checkBoxChannel.Checked)
                            return "(CWLINKSHELL8) " + characterName + ": " + message;
                        else
                            return characterName + ": " + message;
                    default:
                        if (checkBoxOther.Checked)
                        {
                            if (checkBoxChannel.Checked)
                                return "(OTHER) " + characterName + ": " + message;
                            else
                                return characterName + ": " + message;
                        }
                        return "";
                }
            }
        }

        public static void OpenWithDefaultProgram(string path)
        {
            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }

        private void buttonAddName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNameInput.Text))
            {
                listBoxNames.Items.Add(toTitleCase(textBoxNameInput.Text));
                textBoxNameInput.Clear();
            }
        }

        private void buttonRemoveName_Click(object sender, EventArgs e)
        {
            int index;

            if (listBoxNames.SelectedIndex != -1)
            {
                index = listBoxNames.Items.IndexOf(listBoxNames.SelectedItem);
                listBoxNames.Items.RemoveAt(listBoxNames.SelectedIndex);

                if (index < listBoxNames.Items.Count)
                {
                    listBoxNames.SetSelected(index, true);
                }
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
            int index;

            if (listBoxSavedNames.SelectedIndex != -1)
            {
                Properties.Settings.Default.SavedNames.Remove(listBoxSavedNames.SelectedItem.ToString());

                index = listBoxSavedNames.Items.IndexOf(listBoxSavedNames.SelectedItem);
                listBoxSavedNames.Items.Remove(listBoxSavedNames.SelectedItem);

                Properties.Settings.Default.Save();

                if (index < listBoxSavedNames.Items.Count)
                {
                    listBoxSavedNames.SetSelected(index, true);
                }
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
            foreach (String item in listBoxSavedNames.Items)
            {
                if (!listBoxNames.Items.Contains(item))
                {
                    listBoxNames.Items.Add(item);
                }
            }
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

            if (e.KeyCode == Keys.Right)
            {
                buttonAddSavedNameToFilter_Click(sender, e);
            }
        }

        private void listBoxNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonRemoveName_Click(sender, e);
            }

            if (e.KeyCode == Keys.Left)
            {
                if (listBoxNames.SelectedIndex != -1 && !listBoxSavedNames.Items.Contains(listBoxNames.SelectedItem))
                {
                    listBoxSavedNames.Items.Add(listBoxNames.SelectedItem);
                }
            }
        }
    }
}
