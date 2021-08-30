using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace ALE
{
    public partial class ALE : Form
    {
        public ALE()
        {
            InitializeComponent();
        }


        private void buttonExtract_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            String final_output = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        Regex r = new Regex(@"00\|(\d{4}\-\d{2}\-\d{2}).(\d{2}\:\d{2}\:\d{2})\..*\-\d{2}\:\d{2}\|(\w{4})\|(\S*\s\S*)\|(.*)\|");
                        String cleaned_line = "";

                        using (var reader = new StreamReader(stream))
                        {
                            while (reader.Peek() >= 0)
                            {
                                String line = reader.ReadLine();

                                if (r.IsMatch(line))
                                {
                                    cleaned_line = "";

                                    String[] parts = Regex.Split(line, @"\|");

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
                                        case "0018" when checkBoxFreeCompany.Checked:
                                            cleaned_line += "(FC) " + parts[3] + ": " + parts[4];
                                            break;
                                        case "0010" or "0011" or "0012" or "0013" or "0014" or "0015" or "0016" or "0017" when checkBoxLinkshell.Checked:
                                            cleaned_line += "(LINKSHELL) " + parts[3] + ": " + parts[4];
                                            break;
                                        case "0060" or "0061" or "0062" or "0063" or "0064" or "0065" or "0066" or "0067" or "0068" or "0069" or
                                                "0070" or "0071" or "0072" when checkBoxCW.Checked:
                                            cleaned_line += "(CWLINKSHELL) " + parts[3] + ": " + parts[4];
                                            break;
                                        default:
                                            if (checkBoxOther.Checked) {
                                                cleaned_line += "(OTHER) " + parts[3] + ": " + parts[4];
                                            }
                                            break;
                                    }

                                    if (!String.IsNullOrEmpty(cleaned_line)) {
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

    }
}
