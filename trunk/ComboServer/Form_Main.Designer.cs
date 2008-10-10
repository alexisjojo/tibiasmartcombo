namespace ComboServer
{
    partial class Form_Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbSmartCombo = new System.Windows.Forms.CheckBox();
            this.cbRadar = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.ButStartList = new System.Windows.Forms.Button();
            this.CBworld = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nuPort = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbDetectMs = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.nuComboSen = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelHitlist = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelHealed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelAttacked = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButReHitlist = new System.Windows.Forms.Button();
            this.rtHitlist = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butRemoveHit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNameTarget = new System.Windows.Forms.TextBox();
            this.butAddHit = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbEnableKnightCastHeal = new System.Windows.Forms.CheckBox();
            this.cbEnableKnightGetHeal = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nuKnightHeal = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEnableMageCastHeal = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEnableMageGetHeal = new System.Windows.Forms.CheckBox();
            this.nuMageHeal = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbEnablePalCastHeal = new System.Windows.Forms.CheckBox();
            this.cbEnablePalGetHeal = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nuPaladinHeal = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPort)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuComboSen)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuKnightHeal)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuMageHeal)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPaladinHeal)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 354);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbSmartCombo);
            this.tabPage1.Controls.Add(this.cbRadar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.rtLog);
            this.tabPage1.Controls.Add(this.ButStartList);
            this.tabPage1.Controls.Add(this.CBworld);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nuPort);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbSmartCombo
            // 
            this.cbSmartCombo.AutoSize = true;
            this.cbSmartCombo.Checked = true;
            this.cbSmartCombo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSmartCombo.Location = new System.Drawing.Point(208, 40);
            this.cbSmartCombo.Name = "cbSmartCombo";
            this.cbSmartCombo.Size = new System.Drawing.Size(88, 17);
            this.cbSmartCombo.TabIndex = 8;
            this.cbSmartCombo.Text = "Smart combo";
            this.cbSmartCombo.UseVisualStyleBackColor = true;
            this.cbSmartCombo.CheckedChanged += new System.EventHandler(this.cbSmartCombo_CheckedChanged);
            // 
            // cbRadar
            // 
            this.cbRadar.AutoSize = true;
            this.cbRadar.Checked = true;
            this.cbRadar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRadar.Location = new System.Drawing.Point(208, 14);
            this.cbRadar.Name = "cbRadar";
            this.cbRadar.Size = new System.Drawing.Size(95, 17);
            this.cbRadar.TabIndex = 7;
            this.cbRadar.Text = "Support Radar";
            this.cbRadar.UseVisualStyleBackColor = true;
            this.cbRadar.CheckedChanged += new System.EventHandler(this.cbRadar_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "log";
            // 
            // rtLog
            // 
            this.rtLog.Location = new System.Drawing.Point(8, 120);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(325, 207);
            this.rtLog.TabIndex = 5;
            this.rtLog.Text = "";
            // 
            // ButStartList
            // 
            this.ButStartList.Location = new System.Drawing.Point(6, 65);
            this.ButStartList.Name = "ButStartList";
            this.ButStartList.Size = new System.Drawing.Size(330, 36);
            this.ButStartList.TabIndex = 4;
            this.ButStartList.Text = "Start listening";
            this.ButStartList.UseVisualStyleBackColor = true;
            this.ButStartList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButStartList_Click);
            // 
            // CBworld
            // 
            this.CBworld.FormattingEnabled = true;
            this.CBworld.Items.AddRange(new object[] {
            "Aldora",
            "Amera",
            "Antica",
            "Arcania",
            "Askara",
            "Astera",
            "Aurea",
            "Azura",
            "Balera",
            "Berylia",
            "Calmera",
            "Candia",
            "Celesta",
            "Chimera",
            "Danera",
            "Danubia",
            "Dolera",
            "Elera",
            "Elysia",
            "Empera",
            "Eternia",
            "Fortera",
            "Furora",
            "Galana",
            "Grimera",
            "Guardia",
            "Harmonia",
            "Hiberna",
            "Honera",
            "Inferna",
            "Iridia",
            "Isara",
            "Jamera",
            "Julera",
            "Keltera",
            "Kyra",
            "Libera",
            "Lucera",
            "Luminera",
            "Lunara",
            "Malvera",
            "Menera",
            "Morgana",
            "Nythera",
            "Nebula",
            "Neptera",
            "Nerana",
            "Nova",
            "Obsidia",
            "Ocera",
            "Pacera",
            "Pandoria",
            "Premia",
            "Pythera",
            "Refugia",
            "Rubera",
            "Samera",
            "Saphira",
            "Secura",
            "Selena",
            "Shanera",
            "Shivera",
            "Silvera",
            "Solera",
            "Tenebra",
            "Thoria",
            "Titania",
            "Trimera",
            "Unitera",
            "Valoria",
            "Vinera",
            "Xantera",
            "Xerena",
            "Zanera"});
            this.CBworld.Location = new System.Drawing.Point(81, 38);
            this.CBworld.Name = "CBworld";
            this.CBworld.Size = new System.Drawing.Size(105, 21);
            this.CBworld.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "World";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // nuPort
            // 
            this.nuPort.Location = new System.Drawing.Point(81, 14);
            this.nuPort.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nuPort.Name = "nuPort";
            this.nuPort.Size = new System.Drawing.Size(105, 20);
            this.nuPort.TabIndex = 0;
            this.nuPort.Value = new decimal(new int[] {
            5555,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Combo settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbDetectMs);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.nuComboSen);
            this.groupBox7.Location = new System.Drawing.Point(3, 178);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(142, 144);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Advanced";
            // 
            // cbDetectMs
            // 
            this.cbDetectMs.AutoSize = true;
            this.cbDetectMs.Checked = true;
            this.cbDetectMs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDetectMs.Location = new System.Drawing.Point(7, 19);
            this.cbDetectMs.Name = "cbDetectMs";
            this.cbDetectMs.Size = new System.Drawing.Size(114, 17);
            this.cbDetectMs.TabIndex = 10;
            this.cbDetectMs.Text = "Detect manashield";
            this.cbDetectMs.UseVisualStyleBackColor = true;
            this.cbDetectMs.EnabledChanged += new System.EventHandler(this.cbDetectMs_EnabledChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Max # of combos needed:";
            // 
            // nuComboSen
            // 
            this.nuComboSen.DecimalPlaces = 1;
            this.nuComboSen.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuComboSen.Location = new System.Drawing.Point(86, 64);
            this.nuComboSen.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nuComboSen.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuComboSen.Name = "nuComboSen";
            this.nuComboSen.Size = new System.Drawing.Size(44, 20);
            this.nuComboSen.TabIndex = 9;
            this.nuComboSen.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.nuComboSen.ValueChanged += new System.EventHandler(this.nuComboSen_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelHitlist);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelHealed);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelAttacked);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(10, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 101);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "stats";
            // 
            // labelHitlist
            // 
            this.labelHitlist.AutoSize = true;
            this.labelHitlist.Location = new System.Drawing.Point(100, 69);
            this.labelHitlist.Name = "labelHitlist";
            this.labelHitlist.Size = new System.Drawing.Size(13, 13);
            this.labelHitlist.TabIndex = 5;
            this.labelHitlist.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Players in hitlist";
            // 
            // labelHealed
            // 
            this.labelHealed.AutoSize = true;
            this.labelHealed.Location = new System.Drawing.Point(100, 49);
            this.labelHealed.Name = "labelHealed";
            this.labelHealed.Size = new System.Drawing.Size(13, 13);
            this.labelHealed.TabIndex = 3;
            this.labelHealed.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Friends healed:";
            // 
            // labelAttacked
            // 
            this.labelAttacked.AutoSize = true;
            this.labelAttacked.Location = new System.Drawing.Point(100, 28);
            this.labelAttacked.Name = "labelAttacked";
            this.labelAttacked.Size = new System.Drawing.Size(13, 13);
            this.labelAttacked.TabIndex = 1;
            this.labelAttacked.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Combo\'s done:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButReHitlist);
            this.groupBox1.Controls.Add(this.rtHitlist);
            this.groupBox1.Location = new System.Drawing.Point(145, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 268);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hitlist";
            // 
            // ButReHitlist
            // 
            this.ButReHitlist.Location = new System.Drawing.Point(6, 241);
            this.ButReHitlist.Name = "ButReHitlist";
            this.ButReHitlist.Size = new System.Drawing.Size(185, 24);
            this.ButReHitlist.TabIndex = 4;
            this.ButReHitlist.Text = "Reload list";
            this.ButReHitlist.UseVisualStyleBackColor = true;
            this.ButReHitlist.Click += new System.EventHandler(this.ButReHitlist_Click);
            // 
            // rtHitlist
            // 
            this.rtHitlist.Location = new System.Drawing.Point(6, 19);
            this.rtHitlist.Name = "rtHitlist";
            this.rtHitlist.Size = new System.Drawing.Size(185, 216);
            this.rtHitlist.TabIndex = 3;
            this.rtHitlist.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butRemoveHit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbNameTarget);
            this.panel1.Controls.Add(this.butAddHit);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 57);
            this.panel1.TabIndex = 6;
            // 
            // butRemoveHit
            // 
            this.butRemoveHit.Location = new System.Drawing.Point(220, 28);
            this.butRemoveHit.Name = "butRemoveHit";
            this.butRemoveHit.Size = new System.Drawing.Size(111, 23);
            this.butRemoveHit.TabIndex = 5;
            this.butRemoveHit.Text = "Remove from hitlist";
            this.butRemoveHit.UseVisualStyleBackColor = true;
            this.butRemoveHit.Click += new System.EventHandler(this.butRemoveHit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "name:";
            // 
            // tbNameTarget
            // 
            this.tbNameTarget.Location = new System.Drawing.Point(53, 19);
            this.tbNameTarget.Name = "tbNameTarget";
            this.tbNameTarget.Size = new System.Drawing.Size(148, 20);
            this.tbNameTarget.TabIndex = 1;
            // 
            // butAddHit
            // 
            this.butAddHit.Location = new System.Drawing.Point(220, 3);
            this.butAddHit.Name = "butAddHit";
            this.butAddHit.Size = new System.Drawing.Size(111, 22);
            this.butAddHit.TabIndex = 0;
            this.butAddHit.Text = "Add To hitlist";
            this.butAddHit.UseVisualStyleBackColor = true;
            this.butAddHit.Click += new System.EventHandler(this.butAddHit_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(342, 328);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Healing settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbEnableKnightCastHeal);
            this.groupBox3.Controls.Add(this.cbEnableKnightGetHeal);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.nuKnightHeal);
            this.groupBox3.Location = new System.Drawing.Point(5, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 98);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Knight";
            // 
            // cbEnableKnightCastHeal
            // 
            this.cbEnableKnightCastHeal.AutoSize = true;
            this.cbEnableKnightCastHeal.Location = new System.Drawing.Point(192, 37);
            this.cbEnableKnightCastHeal.Name = "cbEnableKnightCastHeal";
            this.cbEnableKnightCastHeal.Size = new System.Drawing.Size(116, 17);
            this.cbEnableKnightCastHeal.TabIndex = 3;
            this.cbEnableKnightCastHeal.Text = "Enable casthealing";
            this.cbEnableKnightCastHeal.UseVisualStyleBackColor = true;
            this.cbEnableKnightCastHeal.CheckedChanged += new System.EventHandler(this.cbEnableKnightCastHeal_CheckedChanged);
            // 
            // cbEnableKnightGetHeal
            // 
            this.cbEnableKnightGetHeal.AutoSize = true;
            this.cbEnableKnightGetHeal.Checked = true;
            this.cbEnableKnightGetHeal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableKnightGetHeal.Location = new System.Drawing.Point(192, 14);
            this.cbEnableKnightGetHeal.Name = "cbEnableKnightGetHeal";
            this.cbEnableKnightGetHeal.Size = new System.Drawing.Size(114, 17);
            this.cbEnableKnightGetHeal.TabIndex = 2;
            this.cbEnableKnightGetHeal.Text = "Enable get healing";
            this.cbEnableKnightGetHeal.UseVisualStyleBackColor = true;
            this.cbEnableKnightGetHeal.CheckedChanged += new System.EventHandler(this.cbEnableKnightGetHeal_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "hp% to start healing:";
            // 
            // nuKnightHeal
            // 
            this.nuKnightHeal.Location = new System.Drawing.Point(120, 14);
            this.nuKnightHeal.Name = "nuKnightHeal";
            this.nuKnightHeal.Size = new System.Drawing.Size(56, 20);
            this.nuKnightHeal.TabIndex = 0;
            this.nuKnightHeal.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nuKnightHeal.ValueChanged += new System.EventHandler(this.nuKnightHeal_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbEnableMageCastHeal);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cbEnableMageGetHeal);
            this.groupBox4.Controls.Add(this.nuMageHeal);
            this.groupBox4.Location = new System.Drawing.Point(3, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 96);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mages";
            // 
            // cbEnableMageCastHeal
            // 
            this.cbEnableMageCastHeal.AutoSize = true;
            this.cbEnableMageCastHeal.Checked = true;
            this.cbEnableMageCastHeal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableMageCastHeal.Location = new System.Drawing.Point(192, 39);
            this.cbEnableMageCastHeal.Name = "cbEnableMageCastHeal";
            this.cbEnableMageCastHeal.Size = new System.Drawing.Size(116, 17);
            this.cbEnableMageCastHeal.TabIndex = 7;
            this.cbEnableMageCastHeal.Text = "Enable casthealing";
            this.cbEnableMageCastHeal.UseVisualStyleBackColor = true;
            this.cbEnableMageCastHeal.CheckedChanged += new System.EventHandler(this.cbEnableMageCastHeal_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "hp% to start healing:";
            // 
            // cbEnableMageGetHeal
            // 
            this.cbEnableMageGetHeal.AutoSize = true;
            this.cbEnableMageGetHeal.Checked = true;
            this.cbEnableMageGetHeal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableMageGetHeal.Location = new System.Drawing.Point(192, 16);
            this.cbEnableMageGetHeal.Name = "cbEnableMageGetHeal";
            this.cbEnableMageGetHeal.Size = new System.Drawing.Size(114, 17);
            this.cbEnableMageGetHeal.TabIndex = 6;
            this.cbEnableMageGetHeal.Text = "Enable get healing";
            this.cbEnableMageGetHeal.UseVisualStyleBackColor = true;
            this.cbEnableMageGetHeal.CheckedChanged += new System.EventHandler(this.cbEnableMageGetHeal_CheckedChanged);
            // 
            // nuMageHeal
            // 
            this.nuMageHeal.Location = new System.Drawing.Point(120, 19);
            this.nuMageHeal.Name = "nuMageHeal";
            this.nuMageHeal.Size = new System.Drawing.Size(56, 20);
            this.nuMageHeal.TabIndex = 4;
            this.nuMageHeal.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nuMageHeal.ValueChanged += new System.EventHandler(this.nuMageHeal_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbEnablePalCastHeal);
            this.groupBox6.Controls.Add(this.cbEnablePalGetHeal);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.nuPaladinHeal);
            this.groupBox6.Location = new System.Drawing.Point(7, 213);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(328, 96);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Paladin";
            // 
            // cbEnablePalCastHeal
            // 
            this.cbEnablePalCastHeal.AutoSize = true;
            this.cbEnablePalCastHeal.Location = new System.Drawing.Point(200, 39);
            this.cbEnablePalCastHeal.Name = "cbEnablePalCastHeal";
            this.cbEnablePalCastHeal.Size = new System.Drawing.Size(116, 17);
            this.cbEnablePalCastHeal.TabIndex = 7;
            this.cbEnablePalCastHeal.Text = "Enable casthealing";
            this.cbEnablePalCastHeal.UseVisualStyleBackColor = true;
            this.cbEnablePalCastHeal.CheckedChanged += new System.EventHandler(this.cbEnablePalCastHeal_CheckedChanged);
            // 
            // cbEnablePalGetHeal
            // 
            this.cbEnablePalGetHeal.AutoSize = true;
            this.cbEnablePalGetHeal.Checked = true;
            this.cbEnablePalGetHeal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnablePalGetHeal.Location = new System.Drawing.Point(200, 16);
            this.cbEnablePalGetHeal.Name = "cbEnablePalGetHeal";
            this.cbEnablePalGetHeal.Size = new System.Drawing.Size(114, 17);
            this.cbEnablePalGetHeal.TabIndex = 6;
            this.cbEnablePalGetHeal.Text = "Enable get healing";
            this.cbEnablePalGetHeal.UseVisualStyleBackColor = true;
            this.cbEnablePalGetHeal.CheckedChanged += new System.EventHandler(this.cbEnablePalGetHeal_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "hp% to start healing:";
            // 
            // nuPaladinHeal
            // 
            this.nuPaladinHeal.Location = new System.Drawing.Point(120, 16);
            this.nuPaladinHeal.Name = "nuPaladinHeal";
            this.nuPaladinHeal.Size = new System.Drawing.Size(56, 20);
            this.nuPaladinHeal.TabIndex = 4;
            this.nuPaladinHeal.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nuPaladinHeal.ValueChanged += new System.EventHandler(this.nuPaladinHeal_ValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.numericUpDown1);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(342, 328);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Radar settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(201, 21);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Below what level is a spy character:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 10;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 378);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_Main";
            this.Text = "Comboserver";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPort)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuComboSen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuKnightHeal)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuMageHeal)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPaladinHeal)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button ButStartList;
        private System.Windows.Forms.ComboBox CBworld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuPort;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNameTarget;
        private System.Windows.Forms.Button butAddHit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButReHitlist;
        private System.Windows.Forms.RichTextBox rtHitlist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butRemoveHit;
        private System.Windows.Forms.Label labelHitlist;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelHealed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelAttacked;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbEnableKnightGetHeal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nuKnightHeal;
        private System.Windows.Forms.CheckBox cbEnableKnightCastHeal;
        private System.Windows.Forms.CheckBox cbEnableMageCastHeal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbEnableMageGetHeal;
        private System.Windows.Forms.NumericUpDown nuMageHeal;
        private System.Windows.Forms.CheckBox cbEnablePalCastHeal;
        private System.Windows.Forms.CheckBox cbEnablePalGetHeal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nuPaladinHeal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nuComboSen;
        private System.Windows.Forms.CheckBox cbDetectMs;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.CheckBox cbRadar;
        private System.Windows.Forms.CheckBox cbSmartCombo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
    }
}