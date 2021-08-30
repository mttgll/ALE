
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
            this.SuspendLayout();
            // 
            // buttonExtract
            // 
            this.buttonExtract.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonExtract.Location = new System.Drawing.Point(57, 116);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(275, 157);
            this.buttonExtract.TabIndex = 0;
            this.buttonExtract.Text = "Select File and Extract";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // checkBoxTellOut
            // 
            this.checkBoxTellOut.AutoSize = true;
            this.checkBoxTellOut.Checked = true;
            this.checkBoxTellOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTellOut.Location = new System.Drawing.Point(397, 129);
            this.checkBoxTellOut.Name = "checkBoxTellOut";
            this.checkBoxTellOut.Size = new System.Drawing.Size(105, 19);
            this.checkBoxTellOut.TabIndex = 2;
            this.checkBoxTellOut.Text = "Tell (Outgoing)";
            this.checkBoxTellOut.UseVisualStyleBackColor = true;
            // 
            // checkBoxYell
            // 
            this.checkBoxYell.AutoSize = true;
            this.checkBoxYell.Location = new System.Drawing.Point(397, 204);
            this.checkBoxYell.Name = "checkBoxYell";
            this.checkBoxYell.Size = new System.Drawing.Size(44, 19);
            this.checkBoxYell.TabIndex = 3;
            this.checkBoxYell.Text = "Yell";
            this.checkBoxYell.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlliance
            // 
            this.checkBoxAlliance.AutoSize = true;
            this.checkBoxAlliance.Location = new System.Drawing.Point(397, 179);
            this.checkBoxAlliance.Name = "checkBoxAlliance";
            this.checkBoxAlliance.Size = new System.Drawing.Size(68, 19);
            this.checkBoxAlliance.TabIndex = 4;
            this.checkBoxAlliance.Text = "Alliance";
            this.checkBoxAlliance.UseVisualStyleBackColor = true;
            // 
            // checkBoxSay
            // 
            this.checkBoxSay.AutoSize = true;
            this.checkBoxSay.Checked = true;
            this.checkBoxSay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSay.Location = new System.Drawing.Point(397, 54);
            this.checkBoxSay.Name = "checkBoxSay";
            this.checkBoxSay.Size = new System.Drawing.Size(44, 19);
            this.checkBoxSay.TabIndex = 5;
            this.checkBoxSay.Text = "Say";
            this.checkBoxSay.UseVisualStyleBackColor = true;
            // 
            // checkBoxShout
            // 
            this.checkBoxShout.AutoSize = true;
            this.checkBoxShout.Location = new System.Drawing.Point(397, 79);
            this.checkBoxShout.Name = "checkBoxShout";
            this.checkBoxShout.Size = new System.Drawing.Size(57, 19);
            this.checkBoxShout.TabIndex = 6;
            this.checkBoxShout.Text = "Shout";
            this.checkBoxShout.UseVisualStyleBackColor = true;
            // 
            // checkBoxTellIn
            // 
            this.checkBoxTellIn.AutoSize = true;
            this.checkBoxTellIn.Checked = true;
            this.checkBoxTellIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTellIn.Location = new System.Drawing.Point(397, 104);
            this.checkBoxTellIn.Name = "checkBoxTellIn";
            this.checkBoxTellIn.Size = new System.Drawing.Size(105, 19);
            this.checkBoxTellIn.TabIndex = 7;
            this.checkBoxTellIn.Text = "Tell (Incoming)";
            this.checkBoxTellIn.UseVisualStyleBackColor = true;
            // 
            // checkBoxCustomEmote
            // 
            this.checkBoxCustomEmote.AutoSize = true;
            this.checkBoxCustomEmote.Checked = true;
            this.checkBoxCustomEmote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCustomEmote.Location = new System.Drawing.Point(397, 229);
            this.checkBoxCustomEmote.Name = "checkBoxCustomEmote";
            this.checkBoxCustomEmote.Size = new System.Drawing.Size(105, 19);
            this.checkBoxCustomEmote.TabIndex = 8;
            this.checkBoxCustomEmote.Text = "Custom Emote";
            this.checkBoxCustomEmote.UseVisualStyleBackColor = true;
            // 
            // checkBoxFreeCompany
            // 
            this.checkBoxFreeCompany.AutoSize = true;
            this.checkBoxFreeCompany.Location = new System.Drawing.Point(397, 254);
            this.checkBoxFreeCompany.Name = "checkBoxFreeCompany";
            this.checkBoxFreeCompany.Size = new System.Drawing.Size(103, 19);
            this.checkBoxFreeCompany.TabIndex = 9;
            this.checkBoxFreeCompany.Text = "Free Company";
            this.checkBoxFreeCompany.UseVisualStyleBackColor = true;
            // 
            // checkBoxLinkshell
            // 
            this.checkBoxLinkshell.AutoSize = true;
            this.checkBoxLinkshell.Location = new System.Drawing.Point(397, 279);
            this.checkBoxLinkshell.Name = "checkBoxLinkshell";
            this.checkBoxLinkshell.Size = new System.Drawing.Size(72, 19);
            this.checkBoxLinkshell.TabIndex = 10;
            this.checkBoxLinkshell.Text = "Linkshell";
            this.checkBoxLinkshell.UseVisualStyleBackColor = true;
            // 
            // checkBoxParty
            // 
            this.checkBoxParty.AutoSize = true;
            this.checkBoxParty.Checked = true;
            this.checkBoxParty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxParty.Location = new System.Drawing.Point(397, 154);
            this.checkBoxParty.Name = "checkBoxParty";
            this.checkBoxParty.Size = new System.Drawing.Size(53, 19);
            this.checkBoxParty.TabIndex = 11;
            this.checkBoxParty.Text = "Party";
            this.checkBoxParty.UseVisualStyleBackColor = true;
            // 
            // checkBoxCW
            // 
            this.checkBoxCW.AutoSize = true;
            this.checkBoxCW.Location = new System.Drawing.Point(397, 304);
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
            this.checkBoxOther.Location = new System.Drawing.Point(397, 329);
            this.checkBoxOther.Name = "checkBoxOther";
            this.checkBoxOther.Size = new System.Drawing.Size(56, 19);
            this.checkBoxOther.TabIndex = 13;
            this.checkBoxOther.Text = "Other";
            this.checkBoxOther.UseVisualStyleBackColor = true;
            // 
            // ALE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(568, 392);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ALE";
            this.Text = "ACT Log Extractor";
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
    }
}

