
namespace ALE
{
    partial class ALE
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALE));
            this.buttonExtract = new System.Windows.Forms.Button();
            this.checkBoxTellOut = new System.Windows.Forms.CheckBox();
            this.checkBoxYell = new System.Windows.Forms.CheckBox();
            this.checkBoxAlliance = new System.Windows.Forms.CheckBox();
            this.checkBoxSay = new System.Windows.Forms.CheckBox();
            this.checkBoxShout = new System.Windows.Forms.CheckBox();
            this.checkBoxTellIn = new System.Windows.Forms.CheckBox();
            this.checkBoxCustomEmote = new System.Windows.Forms.CheckBox();
            this.checkBoxFreeCompany = new System.Windows.Forms.CheckBox();
            this.checkBoxLinkshell = new System.Windows.Forms.CheckBox();
            this.checkBoxParty = new System.Windows.Forms.CheckBox();
            this.checkBoxCW = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBoxOther = new System.Windows.Forms.CheckBox();
            this.checkBoxEmote = new System.Windows.Forms.CheckBox();
            this.checkBoxChannel = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeStamps = new System.Windows.Forms.CheckBox();
            this.listBoxNames = new System.Windows.Forms.ListBox();
            this.buttonAddName = new System.Windows.Forms.Button();
            this.buttonRemoveName = new System.Windows.Forms.Button();
            this.checkBoxRolls = new System.Windows.Forms.CheckBox();
            this.textBoxNameInput = new System.Windows.Forms.TextBox();
            this.textBoxSavedNameInput = new System.Windows.Forms.TextBox();
            this.buttonRemoveSavedName = new System.Windows.Forms.Button();
            this.buttonAddSavedName = new System.Windows.Forms.Button();
            this.listBoxSavedNames = new System.Windows.Forms.ListBox();
            this.buttonAddSavedNameToFilter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonX = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxSpaceMessages = new System.Windows.Forms.CheckBox();
            this.buttonLogsDir = new System.Windows.Forms.Button();
            this.buttonALEDir = new System.Windows.Forms.Button();
            this.buttonGithub = new System.Windows.Forms.Button();
            this.buttonKOFI = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExtract
            // 
            this.buttonExtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonExtract.FlatAppearance.BorderSize = 0;
            this.buttonExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExtract.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonExtract.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonExtract.Location = new System.Drawing.Point(12, 575);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(740, 163);
            this.buttonExtract.TabIndex = 29;
            this.buttonExtract.Text = "Select File and Extract";
            this.buttonExtract.UseVisualStyleBackColor = false;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // checkBoxTellOut
            // 
            this.checkBoxTellOut.AutoSize = true;
            this.checkBoxTellOut.Checked = true;
            this.checkBoxTellOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTellOut.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxTellOut.Location = new System.Drawing.Point(53, 174);
            this.checkBoxTellOut.Name = "checkBoxTellOut";
            this.checkBoxTellOut.Size = new System.Drawing.Size(105, 19);
            this.checkBoxTellOut.TabIndex = 4;
            this.checkBoxTellOut.Text = "Tell (Outgoing)";
            this.checkBoxTellOut.UseVisualStyleBackColor = true;
            // 
            // checkBoxYell
            // 
            this.checkBoxYell.AutoSize = true;
            this.checkBoxYell.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxYell.Location = new System.Drawing.Point(53, 249);
            this.checkBoxYell.Name = "checkBoxYell";
            this.checkBoxYell.Size = new System.Drawing.Size(44, 19);
            this.checkBoxYell.TabIndex = 7;
            this.checkBoxYell.Text = "Yell";
            this.checkBoxYell.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlliance
            // 
            this.checkBoxAlliance.AutoSize = true;
            this.checkBoxAlliance.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxAlliance.Location = new System.Drawing.Point(53, 224);
            this.checkBoxAlliance.Name = "checkBoxAlliance";
            this.checkBoxAlliance.Size = new System.Drawing.Size(68, 19);
            this.checkBoxAlliance.TabIndex = 6;
            this.checkBoxAlliance.Text = "Alliance";
            this.checkBoxAlliance.UseVisualStyleBackColor = true;
            // 
            // checkBoxSay
            // 
            this.checkBoxSay.AutoSize = true;
            this.checkBoxSay.Checked = true;
            this.checkBoxSay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSay.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxSay.Location = new System.Drawing.Point(53, 99);
            this.checkBoxSay.Name = "checkBoxSay";
            this.checkBoxSay.Size = new System.Drawing.Size(44, 19);
            this.checkBoxSay.TabIndex = 1;
            this.checkBoxSay.Text = "Say";
            this.checkBoxSay.UseVisualStyleBackColor = true;
            // 
            // checkBoxShout
            // 
            this.checkBoxShout.AutoSize = true;
            this.checkBoxShout.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxShout.Location = new System.Drawing.Point(53, 124);
            this.checkBoxShout.Name = "checkBoxShout";
            this.checkBoxShout.Size = new System.Drawing.Size(57, 19);
            this.checkBoxShout.TabIndex = 2;
            this.checkBoxShout.Text = "Shout";
            this.checkBoxShout.UseVisualStyleBackColor = true;
            // 
            // checkBoxTellIn
            // 
            this.checkBoxTellIn.AutoSize = true;
            this.checkBoxTellIn.Checked = true;
            this.checkBoxTellIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTellIn.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxTellIn.Location = new System.Drawing.Point(53, 149);
            this.checkBoxTellIn.Name = "checkBoxTellIn";
            this.checkBoxTellIn.Size = new System.Drawing.Size(105, 19);
            this.checkBoxTellIn.TabIndex = 3;
            this.checkBoxTellIn.Text = "Tell (Incoming)";
            this.checkBoxTellIn.UseVisualStyleBackColor = true;
            // 
            // checkBoxCustomEmote
            // 
            this.checkBoxCustomEmote.AutoSize = true;
            this.checkBoxCustomEmote.Checked = true;
            this.checkBoxCustomEmote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCustomEmote.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxCustomEmote.Location = new System.Drawing.Point(53, 274);
            this.checkBoxCustomEmote.Name = "checkBoxCustomEmote";
            this.checkBoxCustomEmote.Size = new System.Drawing.Size(105, 19);
            this.checkBoxCustomEmote.TabIndex = 8;
            this.checkBoxCustomEmote.Text = "Custom Emote";
            this.checkBoxCustomEmote.UseVisualStyleBackColor = true;
            // 
            // checkBoxFreeCompany
            // 
            this.checkBoxFreeCompany.AutoSize = true;
            this.checkBoxFreeCompany.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxFreeCompany.Location = new System.Drawing.Point(53, 324);
            this.checkBoxFreeCompany.Name = "checkBoxFreeCompany";
            this.checkBoxFreeCompany.Size = new System.Drawing.Size(103, 19);
            this.checkBoxFreeCompany.TabIndex = 10;
            this.checkBoxFreeCompany.Text = "Free Company";
            this.checkBoxFreeCompany.UseVisualStyleBackColor = true;
            // 
            // checkBoxLinkshell
            // 
            this.checkBoxLinkshell.AutoSize = true;
            this.checkBoxLinkshell.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxLinkshell.Location = new System.Drawing.Point(53, 349);
            this.checkBoxLinkshell.Name = "checkBoxLinkshell";
            this.checkBoxLinkshell.Size = new System.Drawing.Size(77, 19);
            this.checkBoxLinkshell.TabIndex = 11;
            this.checkBoxLinkshell.Text = "Linkshells";
            this.checkBoxLinkshell.UseVisualStyleBackColor = true;
            // 
            // checkBoxParty
            // 
            this.checkBoxParty.AutoSize = true;
            this.checkBoxParty.Checked = true;
            this.checkBoxParty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxParty.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxParty.Location = new System.Drawing.Point(53, 199);
            this.checkBoxParty.Name = "checkBoxParty";
            this.checkBoxParty.Size = new System.Drawing.Size(53, 19);
            this.checkBoxParty.TabIndex = 5;
            this.checkBoxParty.Text = "Party";
            this.checkBoxParty.UseVisualStyleBackColor = true;
            // 
            // checkBoxCW
            // 
            this.checkBoxCW.AutoSize = true;
            this.checkBoxCW.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxCW.Location = new System.Drawing.Point(52, 374);
            this.checkBoxCW.Name = "checkBoxCW";
            this.checkBoxCW.Size = new System.Drawing.Size(99, 19);
            this.checkBoxCW.TabIndex = 12;
            this.checkBoxCW.Text = "CW Linkshells";
            this.checkBoxCW.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBoxOther
            // 
            this.checkBoxOther.AutoSize = true;
            this.checkBoxOther.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxOther.Location = new System.Drawing.Point(53, 424);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(56, 19);
            this.checkBoxOther.TabIndex = 14;
            this.checkBoxOther.Text = "Other";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmote
            // 
            this.checkBoxEmote.AutoSize = true;
            this.checkBoxEmote.Checked = true;
            this.checkBoxEmote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEmote.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxEmote.Location = new System.Drawing.Point(53, 299);
            this.checkBoxEmote.Name = "checkBoxEmote";
            this.checkBoxEmote.Size = new System.Drawing.Size(60, 19);
            this.checkBoxEmote.TabIndex = 9;
            this.checkBoxEmote.Text = "Emote";
            this.checkBoxEmote.UseVisualStyleBackColor = true;
            // 
            // checkBoxChannel
            // 
            this.checkBoxChannel.AutoSize = true;
            this.checkBoxChannel.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxChannel.Location = new System.Drawing.Point(52, 479);
            this.checkBoxChannel.Name = "checkBoxChannel";
            this.checkBoxChannel.Size = new System.Drawing.Size(106, 19);
            this.checkBoxChannel.TabIndex = 15;
            this.checkBoxChannel.Text = "Channel Labels";
            this.checkBoxChannel.UseVisualStyleBackColor = true;
            // 
            // checkBoxTimeStamps
            // 
            this.checkBoxTimeStamps.AutoSize = true;
            this.checkBoxTimeStamps.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxTimeStamps.Location = new System.Drawing.Point(52, 504);
            this.checkBoxTimeStamps.Name = "checkBoxTimeStamps";
            this.checkBoxTimeStamps.Size = new System.Drawing.Size(90, 19);
            this.checkBoxTimeStamps.TabIndex = 16;
            this.checkBoxTimeStamps.Text = "Timestamps";
            this.checkBoxTimeStamps.UseVisualStyleBackColor = true;
            // 
            // listBoxNames
            // 
            this.listBoxNames.BackColor = System.Drawing.Color.DimGray;
            this.listBoxNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxNames.ForeColor = System.Drawing.Color.White;
            this.listBoxNames.FormattingEnabled = true;
            this.listBoxNames.ItemHeight = 15;
            this.listBoxNames.Location = new System.Drawing.Point(498, 139);
            this.listBoxNames.Name = "listBoxNames";
            this.listBoxNames.Size = new System.Drawing.Size(229, 362);
            this.listBoxNames.TabIndex = 26;
            this.listBoxNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxNames_KeyDown);
            // 
            // buttonAddName
            // 
            this.buttonAddName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAddName.FlatAppearance.BorderSize = 0;
            this.buttonAddName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAddName.Location = new System.Drawing.Point(692, 107);
            this.buttonAddName.Name = "buttonAddName";
            this.buttonAddName.Size = new System.Drawing.Size(35, 23);
            this.buttonAddName.TabIndex = 25;
            this.buttonAddName.Text = "+";
            this.buttonAddName.UseVisualStyleBackColor = false;
            this.buttonAddName.Click += new System.EventHandler(this.buttonAddName_Click);
            // 
            // buttonRemoveName
            // 
            this.buttonRemoveName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRemoveName.FlatAppearance.BorderSize = 0;
            this.buttonRemoveName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRemoveName.Location = new System.Drawing.Point(498, 507);
            this.buttonRemoveName.Name = "buttonRemoveName";
            this.buttonRemoveName.Size = new System.Drawing.Size(44, 44);
            this.buttonRemoveName.TabIndex = 27;
            this.buttonRemoveName.Text = "-";
            this.buttonRemoveName.UseVisualStyleBackColor = false;
            this.buttonRemoveName.Click += new System.EventHandler(this.buttonRemoveName_Click);
            // 
            // checkBoxRolls
            // 
            this.checkBoxRolls.AutoSize = true;
            this.checkBoxRolls.Checked = true;
            this.checkBoxRolls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRolls.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxRolls.Location = new System.Drawing.Point(53, 399);
            this.checkBoxRolls.Name = "checkBoxRolls";
            this.checkBoxRolls.Size = new System.Drawing.Size(51, 19);
            this.checkBoxRolls.TabIndex = 13;
            this.checkBoxRolls.Text = "Rolls";
            this.checkBoxRolls.UseVisualStyleBackColor = true;
            // 
            // textBoxNameInput
            // 
            this.textBoxNameInput.BackColor = System.Drawing.Color.DimGray;
            this.textBoxNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNameInput.ForeColor = System.Drawing.Color.White;
            this.textBoxNameInput.Location = new System.Drawing.Point(498, 108);
            this.textBoxNameInput.Name = "textBoxNameInput";
            this.textBoxNameInput.Size = new System.Drawing.Size(188, 23);
            this.textBoxNameInput.TabIndex = 24;
            this.textBoxNameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNameInput_KeyDown);
            // 
            // textBoxSavedNameInput
            // 
            this.textBoxSavedNameInput.BackColor = System.Drawing.Color.DimGray;
            this.textBoxSavedNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSavedNameInput.ForeColor = System.Drawing.Color.White;
            this.textBoxSavedNameInput.Location = new System.Drawing.Point(222, 107);
            this.textBoxSavedNameInput.Name = "textBoxSavedNameInput";
            this.textBoxSavedNameInput.Size = new System.Drawing.Size(188, 23);
            this.textBoxSavedNameInput.TabIndex = 18;
            this.textBoxSavedNameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSavedNameInput_KeyDown);
            // 
            // buttonRemoveSavedName
            // 
            this.buttonRemoveSavedName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRemoveSavedName.FlatAppearance.BorderSize = 0;
            this.buttonRemoveSavedName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveSavedName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRemoveSavedName.Location = new System.Drawing.Point(222, 507);
            this.buttonRemoveSavedName.Name = "buttonRemoveSavedName";
            this.buttonRemoveSavedName.Size = new System.Drawing.Size(44, 44);
            this.buttonRemoveSavedName.TabIndex = 21;
            this.buttonRemoveSavedName.Text = "-";
            this.buttonRemoveSavedName.UseVisualStyleBackColor = false;
            this.buttonRemoveSavedName.Click += new System.EventHandler(this.buttonRemoveSavedName_Click);
            // 
            // buttonAddSavedName
            // 
            this.buttonAddSavedName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAddSavedName.FlatAppearance.BorderSize = 0;
            this.buttonAddSavedName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSavedName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAddSavedName.Location = new System.Drawing.Point(416, 107);
            this.buttonAddSavedName.Name = "buttonAddSavedName";
            this.buttonAddSavedName.Size = new System.Drawing.Size(35, 23);
            this.buttonAddSavedName.TabIndex = 19;
            this.buttonAddSavedName.Text = "+";
            this.buttonAddSavedName.UseVisualStyleBackColor = false;
            this.buttonAddSavedName.Click += new System.EventHandler(this.buttonAddSavedName_Click);
            // 
            // listBoxSavedNames
            // 
            this.listBoxSavedNames.BackColor = System.Drawing.Color.DimGray;
            this.listBoxSavedNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxSavedNames.ForeColor = System.Drawing.Color.White;
            this.listBoxSavedNames.FormattingEnabled = true;
            this.listBoxSavedNames.ItemHeight = 15;
            this.listBoxSavedNames.Location = new System.Drawing.Point(222, 139);
            this.listBoxSavedNames.Name = "listBoxSavedNames";
            this.listBoxSavedNames.Size = new System.Drawing.Size(229, 362);
            this.listBoxSavedNames.TabIndex = 20;
            this.listBoxSavedNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSavedNames_KeyDown);
            // 
            // buttonAddSavedNameToFilter
            // 
            this.buttonAddSavedNameToFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAddSavedNameToFilter.FlatAppearance.BorderSize = 0;
            this.buttonAddSavedNameToFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSavedNameToFilter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAddSavedNameToFilter.Location = new System.Drawing.Point(457, 399);
            this.buttonAddSavedNameToFilter.Name = "buttonAddSavedNameToFilter";
            this.buttonAddSavedNameToFilter.Size = new System.Drawing.Size(35, 102);
            this.buttonAddSavedNameToFilter.TabIndex = 23;
            this.buttonAddSavedNameToFilter.Text = ">";
            this.buttonAddSavedNameToFilter.UseVisualStyleBackColor = false;
            this.buttonAddSavedNameToFilter.Click += new System.EventHandler(this.buttonAddSavedNameToFilter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ALE.Properties.Resources.ale_smaller;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 40);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // buttonX
            // 
            this.buttonX.BackColor = System.Drawing.Color.Gray;
            this.buttonX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonX.Location = new System.Drawing.Point(723, 12);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(29, 23);
            this.buttonX.TabIndex = 30;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = false;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(222, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Saved Names";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(498, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name Filters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(41, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "ACT Log Extractor";
            // 
            // checkBoxSpaceMessages
            // 
            this.checkBoxSpaceMessages.AutoSize = true;
            this.checkBoxSpaceMessages.Checked = true;
            this.checkBoxSpaceMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpaceMessages.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxSpaceMessages.Location = new System.Drawing.Point(52, 529);
            this.checkBoxSpaceMessages.Name = "checkBoxSpaceMessages";
            this.checkBoxSpaceMessages.Size = new System.Drawing.Size(111, 19);
            this.checkBoxSpaceMessages.TabIndex = 17;
            this.checkBoxSpaceMessages.Text = "Space messages";
            this.checkBoxSpaceMessages.UseVisualStyleBackColor = true;
            // 
            // buttonLogsDir
            // 
            this.buttonLogsDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonLogsDir.FlatAppearance.BorderSize = 0;
            this.buttonLogsDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogsDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogsDir.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLogsDir.Location = new System.Drawing.Point(385, 744);
            this.buttonLogsDir.Name = "buttonLogsDir";
            this.buttonLogsDir.Size = new System.Drawing.Size(367, 50);
            this.buttonLogsDir.TabIndex = 31;
            this.buttonLogsDir.Text = "Open Extracted Logs Directory";
            this.buttonLogsDir.UseVisualStyleBackColor = false;
            this.buttonLogsDir.Click += new System.EventHandler(this.buttonLogsDir_Click);
            // 
            // buttonALEDir
            // 
            this.buttonALEDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonALEDir.FlatAppearance.BorderSize = 0;
            this.buttonALEDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonALEDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonALEDir.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonALEDir.Location = new System.Drawing.Point(12, 744);
            this.buttonALEDir.Name = "buttonALEDir";
            this.buttonALEDir.Size = new System.Drawing.Size(367, 50);
            this.buttonALEDir.TabIndex = 30;
            this.buttonALEDir.Text = "Open ALE Directory";
            this.buttonALEDir.UseVisualStyleBackColor = false;
            this.buttonALEDir.Click += new System.EventHandler(this.buttonALEDir_Click);
            // 
            // buttonGithub
            // 
            this.buttonGithub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonGithub.FlatAppearance.BorderSize = 0;
            this.buttonGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGithub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGithub.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonGithub.Location = new System.Drawing.Point(650, 12);
            this.buttonGithub.Name = "buttonGithub";
            this.buttonGithub.Size = new System.Drawing.Size(56, 23);
            this.buttonGithub.TabIndex = 32;
            this.buttonGithub.Text = "GitHub";
            this.buttonGithub.UseVisualStyleBackColor = false;
            this.buttonGithub.Click += new System.EventHandler(this.buttonGithub_Click);
            // 
            // buttonKOFI
            // 
            this.buttonKOFI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonKOFI.FlatAppearance.BorderSize = 0;
            this.buttonKOFI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKOFI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonKOFI.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonKOFI.Location = new System.Drawing.Point(592, 12);
            this.buttonKOFI.Name = "buttonKOFI";
            this.buttonKOFI.Size = new System.Drawing.Size(52, 23);
            this.buttonKOFI.TabIndex = 0;
            this.buttonKOFI.Text = "Ko-fi";
            this.buttonKOFI.UseVisualStyleBackColor = false;
            this.buttonKOFI.Click += new System.EventHandler(this.buttonKOFI_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClear.Location = new System.Drawing.Point(683, 507);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(44, 44);
            this.buttonClear.TabIndex = 28;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAll.FlatAppearance.BorderSize = 0;
            this.buttonAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAll.Location = new System.Drawing.Point(457, 139);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(35, 254);
            this.buttonAll.TabIndex = 22;
            this.buttonAll.Text = ">>";
            this.buttonAll.UseVisualStyleBackColor = false;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // ALE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(764, 806);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonKOFI);
            this.Controls.Add(this.buttonGithub);
            this.Controls.Add(this.buttonALEDir);
            this.Controls.Add(this.buttonLogsDir);
            this.Controls.Add(this.checkBoxSpaceMessages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonX);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAddSavedNameToFilter);
            this.Controls.Add(this.textBoxSavedNameInput);
            this.Controls.Add(this.buttonRemoveSavedName);
            this.Controls.Add(this.buttonAddSavedName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxSavedNames);
            this.Controls.Add(this.textBoxNameInput);
            this.Controls.Add(this.checkBoxRolls);
            this.Controls.Add(this.buttonRemoveName);
            this.Controls.Add(this.buttonAddName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxNames);
            this.Controls.Add(this.checkBoxTimeStamps);
            this.Controls.Add(this.checkBoxChannel);
            this.Controls.Add(this.checkBoxEmote);
            this.Controls.Add(this.checkBoxOther);
            this.Controls.Add(this.checkBoxCW);
            this.Controls.Add(this.checkBoxParty);
            this.Controls.Add(this.checkBoxLinkshell);
            this.Controls.Add(this.checkBoxFreeCompany);
            this.Controls.Add(this.checkBoxCustomEmote);
            this.Controls.Add(this.checkBoxTellIn);
            this.Controls.Add(this.checkBoxShout);
            this.Controls.Add(this.checkBoxSay);
            this.Controls.Add(this.checkBoxAlliance);
            this.Controls.Add(this.checkBoxYell);
            this.Controls.Add(this.checkBoxTellOut);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.buttonAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ALE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACT Log Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.CheckBox checkBoxTellOut;
        private System.Windows.Forms.CheckBox checkBoxYell;
        private System.Windows.Forms.CheckBox checkBoxAlliance;
        private System.Windows.Forms.CheckBox checkBoxSay;
        private System.Windows.Forms.CheckBox checkBoxShout;
        private System.Windows.Forms.CheckBox checkBoxTellIn;
        private System.Windows.Forms.CheckBox checkBoxCustomEmote;
        private System.Windows.Forms.CheckBox checkBoxFreeCompany;
        private System.Windows.Forms.CheckBox checkBoxLinkshell;
        private System.Windows.Forms.CheckBox checkBoxParty;
        private System.Windows.Forms.CheckBox checkBoxCW;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxOther;
        private System.Windows.Forms.CheckBox checkBoxEmote;
        private System.Windows.Forms.CheckBox checkBoxChannel;
        private System.Windows.Forms.CheckBox checkBoxTimeStamps;
        private System.Windows.Forms.ListBox listBoxNames;
        private System.Windows.Forms.Button buttonAddName;
        private System.Windows.Forms.Button buttonRemoveName;
        private System.Windows.Forms.CheckBox checkBoxRolls;
        private System.Windows.Forms.TextBox textBoxNameInput;
        private System.Windows.Forms.TextBox textBoxSavedNameInput;
        private System.Windows.Forms.Button buttonRemoveSavedName;
        private System.Windows.Forms.Button buttonAddSavedName;
        private System.Windows.Forms.ListBox listBoxSavedNames;
        private System.Windows.Forms.Button buttonAddSavedNameToFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSpaceMessages;
        private System.Windows.Forms.Button buttonLogsDir;
        private System.Windows.Forms.Button buttonALEDir;
        private System.Windows.Forms.Button buttonGithub;
        private System.Windows.Forms.Button buttonKOFI;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAll;
    }
}

