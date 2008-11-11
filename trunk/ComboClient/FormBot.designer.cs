namespace ComboClient
{
    partial class FormBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerProgram = new System.Windows.Forms.Timer(this.components);
            this.timerManashield = new System.Windows.Forms.Timer(this.components);
            this.timerHealingSpell = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelHp = new System.Windows.Forms.Label();
            this.labelMana = new System.Windows.Forms.Label();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.butMinimap = new System.Windows.Forms.Button();
            this.cbEnableXray = new System.Windows.Forms.CheckBox();
            this.cbEnableLvlSpy = new System.Windows.Forms.CheckBox();
            this.tabMagic = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbHpAlways = new System.Windows.Forms.CheckBox();
            this.cbManashield = new System.Windows.Forms.CheckBox();
            this.nuBelowHpMShield = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nuManaManashield = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbListManaPotions = new System.Windows.Forms.CheckedListBox();
            this.cbManaRestore = new System.Windows.Forms.CheckBox();
            this.nuRestoreMana = new System.Windows.Forms.NumericUpDown();
            this.tabHealing = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nuHpPerHealParty = new System.Windows.Forms.NumericUpDown();
            this.cbHealPary = new System.Windows.Forms.CheckBox();
            this.cbHealFriend = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCombineSpellPotion = new System.Windows.Forms.CheckBox();
            this.cbEnableSpellHeal = new System.Windows.Forms.CheckBox();
            this.tbSpell = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEnablPotionsRuneHeal = new System.Windows.Forms.CheckBox();
            this.cbListPotionsHeal = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nuHealAtHp = new System.Windows.Forms.NumericUpDown();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.nuServerPort = new System.Windows.Forms.NumericUpDown();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOther.SuspendLayout();
            this.tabMagic.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuBelowHpMShield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuManaManashield)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuRestoreMana)).BeginInit();
            this.tabHealing.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHpPerHealParty)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHealAtHp)).BeginInit();
            this.tabServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuServerPort)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerProgram
            // 
            this.timerProgram.Tick += new System.EventHandler(this.timerProgram_Tick);
            // 
            // timerManashield
            // 
            this.timerManashield.Tick += new System.EventHandler(this.timerManashield_Tick);
            // 
            // timerHealingSpell
            // 
            this.timerHealingSpell.Tick += new System.EventHandler(this.timerHealingSpell_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Status:";
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Location = new System.Drawing.Point(85, 281);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(75, 13);
            this.labelPlayer.TabIndex = 2;
            this.labelPlayer.Text = "Not Logged In";
            // 
            // labelHp
            // 
            this.labelHp.AutoSize = true;
            this.labelHp.Location = new System.Drawing.Point(85, 294);
            this.labelHp.Name = "labelHp";
            this.labelHp.Size = new System.Drawing.Size(41, 13);
            this.labelHp.TabIndex = 3;
            this.labelHp.Text = "0/0 Hp";
            // 
            // labelMana
            // 
            this.labelMana.AutoSize = true;
            this.labelMana.Location = new System.Drawing.Point(85, 307);
            this.labelMana.Name = "labelMana";
            this.labelMana.Size = new System.Drawing.Size(54, 13);
            this.labelMana.TabIndex = 4;
            this.labelMana.Text = "0/0 Mana";
            // 
            // rtLog
            // 
            this.rtLog.Location = new System.Drawing.Point(16, 347);
            this.rtLog.Name = "rtLog";
            this.rtLog.ReadOnly = true;
            this.rtLog.Size = new System.Drawing.Size(264, 110);
            this.rtLog.TabIndex = 0;
            this.rtLog.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Log:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 24);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabOther
            // 
            this.tabOther.Controls.Add(this.butMinimap);
            this.tabOther.Controls.Add(this.cbEnableXray);
            this.tabOther.Controls.Add(this.cbEnableLvlSpy);
            this.tabOther.Location = new System.Drawing.Point(4, 22);
            this.tabOther.Name = "tabOther";
            this.tabOther.Size = new System.Drawing.Size(260, 240);
            this.tabOther.TabIndex = 4;
            this.tabOther.Text = "Other";
            this.tabOther.UseVisualStyleBackColor = true;
            // 
            // butMinimap
            // 
            this.butMinimap.Location = new System.Drawing.Point(15, 37);
            this.butMinimap.Name = "butMinimap";
            this.butMinimap.Size = new System.Drawing.Size(92, 26);
            this.butMinimap.TabIndex = 2;
            this.butMinimap.Text = "Open Minimap";
            this.butMinimap.UseVisualStyleBackColor = true;
            this.butMinimap.Click += new System.EventHandler(this.butMinimap_Click);
            // 
            // cbEnableXray
            // 
            this.cbEnableXray.AutoSize = true;
            this.cbEnableXray.Location = new System.Drawing.Point(144, 14);
            this.cbEnableXray.Name = "cbEnableXray";
            this.cbEnableXray.Size = new System.Drawing.Size(83, 17);
            this.cbEnableXray.TabIndex = 1;
            this.cbEnableXray.Text = "Enable Xray";
            this.cbEnableXray.UseVisualStyleBackColor = true;
            // 
            // cbEnableLvlSpy
            // 
            this.cbEnableLvlSpy.AutoSize = true;
            this.cbEnableLvlSpy.Location = new System.Drawing.Point(15, 14);
            this.cbEnableLvlSpy.Name = "cbEnableLvlSpy";
            this.cbEnableLvlSpy.Size = new System.Drawing.Size(109, 17);
            this.cbEnableLvlSpy.TabIndex = 0;
            this.cbEnableLvlSpy.Text = "Enable Level Spy";
            this.cbEnableLvlSpy.UseVisualStyleBackColor = true;
            // 
            // tabMagic
            // 
            this.tabMagic.Controls.Add(this.groupBox5);
            this.tabMagic.Controls.Add(this.groupBox4);
            this.tabMagic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabMagic.Location = new System.Drawing.Point(4, 22);
            this.tabMagic.Name = "tabMagic";
            this.tabMagic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabMagic.Size = new System.Drawing.Size(260, 240);
            this.tabMagic.TabIndex = 2;
            this.tabMagic.Text = "Magic";
            this.tabMagic.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbHpAlways);
            this.groupBox5.Controls.Add(this.cbManashield);
            this.groupBox5.Controls.Add(this.nuBelowHpMShield);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.nuManaManashield);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(3, 84);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(254, 83);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Manashield";
            // 
            // cbHpAlways
            // 
            this.cbHpAlways.AutoSize = true;
            this.cbHpAlways.Location = new System.Drawing.Point(168, 38);
            this.cbHpAlways.Name = "cbHpAlways";
            this.cbHpAlways.Size = new System.Drawing.Size(59, 17);
            this.cbHpAlways.TabIndex = 5;
            this.cbHpAlways.Text = "Always";
            this.cbHpAlways.UseVisualStyleBackColor = true;
            // 
            // cbManashield
            // 
            this.cbManashield.AutoSize = true;
            this.cbManashield.Location = new System.Drawing.Point(9, 58);
            this.cbManashield.Name = "cbManashield";
            this.cbManashield.Size = new System.Drawing.Size(59, 17);
            this.cbManashield.TabIndex = 4;
            this.cbManashield.Text = "Enable";
            this.cbManashield.UseVisualStyleBackColor = true;
            // 
            // nuBelowHpMShield
            // 
            this.nuBelowHpMShield.Location = new System.Drawing.Point(83, 37);
            this.nuBelowHpMShield.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nuBelowHpMShield.Name = "nuBelowHpMShield";
            this.nuBelowHpMShield.Size = new System.Drawing.Size(74, 20);
            this.nuBelowHpMShield.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Hp needed";
            // 
            // nuManaManashield
            // 
            this.nuManaManashield.Location = new System.Drawing.Point(83, 9);
            this.nuManaManashield.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nuManaManashield.Name = "nuManaManashield";
            this.nuManaManashield.Size = new System.Drawing.Size(74, 20);
            this.nuManaManashield.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mana needed: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbListManaPotions);
            this.groupBox4.Controls.Add(this.cbManaRestore);
            this.groupBox4.Controls.Add(this.nuRestoreMana);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 75);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Restore Mana";
            // 
            // cbListManaPotions
            // 
            this.cbListManaPotions.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbListManaPotions.FormattingEnabled = true;
            this.cbListManaPotions.Items.AddRange(new object[] {
            "Great",
            "Strong",
            "Normal"});
            this.cbListManaPotions.Location = new System.Drawing.Point(5, 16);
            this.cbListManaPotions.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.cbListManaPotions.Name = "cbListManaPotions";
            this.cbListManaPotions.Size = new System.Drawing.Size(63, 49);
            this.cbListManaPotions.TabIndex = 2;
            // 
            // cbManaRestore
            // 
            this.cbManaRestore.AutoSize = true;
            this.cbManaRestore.Location = new System.Drawing.Point(139, 42);
            this.cbManaRestore.Name = "cbManaRestore";
            this.cbManaRestore.Size = new System.Drawing.Size(59, 17);
            this.cbManaRestore.TabIndex = 1;
            this.cbManaRestore.Text = "Enable";
            this.cbManaRestore.UseVisualStyleBackColor = true;
            // 
            // nuRestoreMana
            // 
            this.nuRestoreMana.Location = new System.Drawing.Point(139, 16);
            this.nuRestoreMana.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nuRestoreMana.Name = "nuRestoreMana";
            this.nuRestoreMana.Size = new System.Drawing.Size(96, 20);
            this.nuRestoreMana.TabIndex = 0;
            // 
            // tabHealing
            // 
            this.tabHealing.Controls.Add(this.label4);
            this.tabHealing.Controls.Add(this.groupBox3);
            this.tabHealing.Controls.Add(this.groupBox2);
            this.tabHealing.Controls.Add(this.groupBox1);
            this.tabHealing.Controls.Add(this.label3);
            this.tabHealing.Controls.Add(this.nuHealAtHp);
            this.tabHealing.Location = new System.Drawing.Point(4, 22);
            this.tabHealing.Name = "tabHealing";
            this.tabHealing.Padding = new System.Windows.Forms.Padding(3);
            this.tabHealing.Size = new System.Drawing.Size(260, 240);
            this.tabHealing.TabIndex = 1;
            this.tabHealing.Text = "Healing";
            this.tabHealing.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "hp";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nuHpPerHealParty);
            this.groupBox3.Controls.Add(this.cbHealPary);
            this.groupBox3.Controls.Add(this.cbHealFriend);
            this.groupBox3.Location = new System.Drawing.Point(150, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(104, 126);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Heal Friend";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(5, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Use uh\'s";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "%";
            this.label8.Visible = false;
            // 
            // nuHpPerHealParty
            // 
            this.nuHpPerHealParty.Location = new System.Drawing.Point(24, 37);
            this.nuHpPerHealParty.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nuHpPerHealParty.Name = "nuHpPerHealParty";
            this.nuHpPerHealParty.Size = new System.Drawing.Size(56, 20);
            this.nuHpPerHealParty.TabIndex = 2;
            this.nuHpPerHealParty.Visible = false;
            // 
            // cbHealPary
            // 
            this.cbHealPary.AutoSize = true;
            this.cbHealPary.Location = new System.Drawing.Point(6, 19);
            this.cbHealPary.Name = "cbHealPary";
            this.cbHealPary.Size = new System.Drawing.Size(74, 17);
            this.cbHealPary.TabIndex = 1;
            this.cbHealPary.Text = "Heal party";
            this.cbHealPary.UseVisualStyleBackColor = true;
            this.cbHealPary.Visible = false;
            // 
            // cbHealFriend
            // 
            this.cbHealFriend.AutoSize = true;
            this.cbHealFriend.Checked = true;
            this.cbHealFriend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHealFriend.Location = new System.Drawing.Point(6, 63);
            this.cbHealFriend.Name = "cbHealFriend";
            this.cbHealFriend.Size = new System.Drawing.Size(80, 17);
            this.cbHealFriend.TabIndex = 0;
            this.cbHealFriend.Text = "Heal server";
            this.cbHealFriend.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCombineSpellPotion);
            this.groupBox2.Controls.Add(this.cbEnableSpellHeal);
            this.groupBox2.Controls.Add(this.tbSpell);
            this.groupBox2.Location = new System.Drawing.Point(9, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 70);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spell";
            // 
            // cbCombineSpellPotion
            // 
            this.cbCombineSpellPotion.AutoSize = true;
            this.cbCombineSpellPotion.Checked = true;
            this.cbCombineSpellPotion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCombineSpellPotion.Location = new System.Drawing.Point(80, 47);
            this.cbCombineSpellPotion.Name = "cbCombineSpellPotion";
            this.cbCombineSpellPotion.Size = new System.Drawing.Size(146, 17);
            this.cbCombineSpellPotion.TabIndex = 2;
            this.cbCombineSpellPotion.Text = "Combine Spell and potion";
            this.cbCombineSpellPotion.UseVisualStyleBackColor = true;
            // 
            // cbEnableSpellHeal
            // 
            this.cbEnableSpellHeal.AutoSize = true;
            this.cbEnableSpellHeal.Location = new System.Drawing.Point(8, 47);
            this.cbEnableSpellHeal.Name = "cbEnableSpellHeal";
            this.cbEnableSpellHeal.Size = new System.Drawing.Size(59, 17);
            this.cbEnableSpellHeal.TabIndex = 1;
            this.cbEnableSpellHeal.Text = "Enable";
            this.cbEnableSpellHeal.UseVisualStyleBackColor = true;
            // 
            // tbSpell
            // 
            this.tbSpell.Location = new System.Drawing.Point(8, 22);
            this.tbSpell.Name = "tbSpell";
            this.tbSpell.Size = new System.Drawing.Size(218, 20);
            this.tbSpell.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEnablPotionsRuneHeal);
            this.groupBox1.Controls.Add(this.cbListPotionsHeal);
            this.groupBox1.Location = new System.Drawing.Point(9, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Potions / runes";
            // 
            // cbEnablPotionsRuneHeal
            // 
            this.cbEnablPotionsRuneHeal.AutoSize = true;
            this.cbEnablPotionsRuneHeal.Location = new System.Drawing.Point(70, 53);
            this.cbEnablPotionsRuneHeal.Name = "cbEnablPotionsRuneHeal";
            this.cbEnablPotionsRuneHeal.Size = new System.Drawing.Size(59, 17);
            this.cbEnablPotionsRuneHeal.TabIndex = 1;
            this.cbEnablPotionsRuneHeal.Text = "Enable";
            this.cbEnablPotionsRuneHeal.UseVisualStyleBackColor = true;
            // 
            // cbListPotionsHeal
            // 
            this.cbListPotionsHeal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbListPotionsHeal.Items.AddRange(new object[] {
            "Ultimate",
            "Great",
            "Strong",
            "Normal",
            "Uh",
            "Ih"});
            this.cbListPotionsHeal.Location = new System.Drawing.Point(6, 19);
            this.cbListPotionsHeal.Name = "cbListPotionsHeal";
            this.cbListPotionsHeal.Size = new System.Drawing.Size(61, 94);
            this.cbListPotionsHeal.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Heal below:";
            // 
            // nuHealAtHp
            // 
            this.nuHealAtHp.Location = new System.Drawing.Point(84, 6);
            this.nuHealAtHp.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nuHealAtHp.Name = "nuHealAtHp";
            this.nuHealAtHp.Size = new System.Drawing.Size(79, 20);
            this.nuHealAtHp.TabIndex = 9;
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.nuServerPort);
            this.tabServer.Controls.Add(this.tbServerIp);
            this.tabServer.Controls.Add(this.label2);
            this.tabServer.Controls.Add(this.label1);
            this.tabServer.Controls.Add(this.butStop);
            this.tabServer.Controls.Add(this.butStart);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(260, 240);
            this.tabServer.TabIndex = 0;
            this.tabServer.Text = "Server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // nuServerPort
            // 
            this.nuServerPort.Location = new System.Drawing.Point(64, 36);
            this.nuServerPort.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.nuServerPort.Name = "nuServerPort";
            this.nuServerPort.Size = new System.Drawing.Size(189, 20);
            this.nuServerPort.TabIndex = 11;
            this.nuServerPort.Value = new decimal(new int[] {
            5555,
            0,
            0,
            0});
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(64, 10);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(189, 20);
            this.tbServerIp.TabIndex = 10;
            this.tbServerIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Serverip :";
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(6, 107);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(247, 27);
            this.butStop.TabIndex = 7;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(6, 74);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(247, 27);
            this.butStart.TabIndex = 6;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabServer);
            this.tabControl1.Controls.Add(this.tabHealing);
            this.tabControl1.Controls.Add(this.tabMagic);
            this.tabControl1.Controls.Add(this.tabOther);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(268, 266);
            this.tabControl1.TabIndex = 0;
            // 
            // FormBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 469);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rtLog);
            this.Controls.Add(this.labelMana);
            this.Controls.Add(this.labelHp);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormBot";
            this.Text = "Hippophagous Zeta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBot_FormClosed);
            this.tabOther.ResumeLayout(false);
            this.tabOther.PerformLayout();
            this.tabMagic.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuBelowHpMShield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuManaManashield)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuRestoreMana)).EndInit();
            this.tabHealing.ResumeLayout(false);
            this.tabHealing.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHpPerHealParty)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHealAtHp)).EndInit();
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuServerPort)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerProgram;
        private System.Windows.Forms.Timer timerManashield;
        private System.Windows.Forms.Timer timerHealingSpell;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label labelHp;
        private System.Windows.Forms.Label labelMana;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabOther;
        private System.Windows.Forms.Button butMinimap;
        private System.Windows.Forms.CheckBox cbEnableXray;
        private System.Windows.Forms.CheckBox cbEnableLvlSpy;
        private System.Windows.Forms.TabPage tabMagic;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbHpAlways;
        private System.Windows.Forms.CheckBox cbManashield;
        private System.Windows.Forms.NumericUpDown nuBelowHpMShield;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuManaManashield;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox cbListManaPotions;
        private System.Windows.Forms.CheckBox cbManaRestore;
        private System.Windows.Forms.NumericUpDown nuRestoreMana;
        private System.Windows.Forms.TabPage tabHealing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nuHpPerHealParty;
        private System.Windows.Forms.CheckBox cbHealPary;
        private System.Windows.Forms.CheckBox cbHealFriend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbCombineSpellPotion;
        private System.Windows.Forms.CheckBox cbEnableSpellHeal;
        private System.Windows.Forms.TextBox tbSpell;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbEnablPotionsRuneHeal;
        private System.Windows.Forms.CheckedListBox cbListPotionsHeal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nuHealAtHp;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.NumericUpDown nuServerPort;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.TabControl tabControl1;

    }
}