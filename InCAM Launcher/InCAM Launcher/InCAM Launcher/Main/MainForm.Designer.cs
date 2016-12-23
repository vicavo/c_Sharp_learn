namespace InCAM_Launcher
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLaunch = new System.Windows.Forms.Button();
            this.dgJobList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuJobManage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIncamDir = new System.Windows.Forms.ComboBox();
            this.btnBrw1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbdbDir = new System.Windows.Forms.TextBox();
            this.btnBrw2 = new System.Windows.Forms.Button();
            this.cbStep = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLayer = new System.Windows.Forms.ComboBox();
            this.cbChecklist = new System.Windows.Forms.ComboBox();
            this.ckAutoRun = new System.Windows.Forms.CheckBox();
            this.tbFilterPattern = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckFlex = new System.Windows.Forms.CheckBox();
            this.rdGroup1b2 = new System.Windows.Forms.RadioButton();
            this.rdGroup1b1 = new System.Windows.Forms.RadioButton();
            this.ckGuiless = new System.Windows.Forms.CheckBox();
            this.ckUnitst = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbJobCnt = new System.Windows.Forms.Label();
            this.ckRegex = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSession = new System.Windows.Forms.TextBox();
            this.cbSession = new System.Windows.Forms.ComboBox();
            this.btnSaveToFile = new System.Windows.Forms.PictureBox();
            this.btnDelSession = new System.Windows.Forms.PictureBox();
            this.btnSaveToAutotest = new System.Windows.Forms.PictureBox();
            this.btnArchiveSession = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuSessionList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnQuickLaunch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobList)).BeginInit();
            this.menuJobManage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveToFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveToAutotest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnArchiveSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickLaunch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(662, 427);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(121, 39);
            this.btnLaunch.TabIndex = 7;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // dgJobList
            // 
            this.dgJobList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.dgJobList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgJobList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJobList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgJobList.ContextMenuStrip = this.menuJobManage;
            this.dgJobList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgJobList.EnableHeadersVisualStyles = false;
            this.dgJobList.Location = new System.Drawing.Point(3, 53);
            this.dgJobList.MultiSelect = false;
            this.dgJobList.Name = "dgJobList";
            this.dgJobList.ReadOnly = true;
            this.dgJobList.RowHeadersWidth = 25;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(183)))), ((int)(((byte)(192)))));
            this.dgJobList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgJobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgJobList.Size = new System.Drawing.Size(497, 324);
            this.dgJobList.TabIndex = 2;
            this.dgJobList.SelectionChanged += new System.EventHandler(this.dgJobList_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Job Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Create Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Save Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // menuJobManage
            // 
            this.menuJobManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator3,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.duplicateToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.menuJobManage.Name = "contextMenuStrip1";
            this.menuJobManage.Size = new System.Drawing.Size(141, 154);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Enabled = false;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.ShowShortcutKeys = false;
            this.importToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Enabled = false;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate As";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Enabled = false;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "DFM Directory:";
            // 
            // tbIncamDir
            // 
            this.tbIncamDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIncamDir.FormattingEnabled = true;
            this.tbIncamDir.Location = new System.Drawing.Point(118, 16);
            this.tbIncamDir.Name = "tbIncamDir";
            this.tbIncamDir.Size = new System.Drawing.Size(555, 24);
            this.tbIncamDir.TabIndex = 0;
            this.tbIncamDir.DropDown += new System.EventHandler(this.tbIncamDir_DropDown);
            this.tbIncamDir.TextChanged += new System.EventHandler(this.tbIncamDir_TextChanged);
            // 
            // btnBrw1
            // 
            this.btnBrw1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrw1.Location = new System.Drawing.Point(683, 14);
            this.btnBrw1.Name = "btnBrw1";
            this.btnBrw1.Size = new System.Drawing.Size(67, 27);
            this.btnBrw1.TabIndex = 1;
            this.btnBrw1.Text = "Browse";
            this.btnBrw1.UseVisualStyleBackColor = true;
            this.btnBrw1.Click += new System.EventHandler(this.btnBrw1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "DB Directory:";
            // 
            // tbdbDir
            // 
            this.tbdbDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbdbDir.Location = new System.Drawing.Point(118, 50);
            this.tbdbDir.Name = "tbdbDir";
            this.tbdbDir.Size = new System.Drawing.Size(555, 22);
            this.tbdbDir.TabIndex = 2;
            this.tbdbDir.TextChanged += new System.EventHandler(this.tbdbDir_TextChanged);
            this.tbdbDir.DoubleClick += new System.EventHandler(this.tbdbDir_DoubleClick);
            // 
            // btnBrw2
            // 
            this.btnBrw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrw2.Location = new System.Drawing.Point(683, 48);
            this.btnBrw2.Name = "btnBrw2";
            this.btnBrw2.Size = new System.Drawing.Size(100, 27);
            this.btnBrw2.TabIndex = 3;
            this.btnBrw2.Text = "Browse";
            this.btnBrw2.UseVisualStyleBackColor = true;
            this.btnBrw2.Click += new System.EventHandler(this.btnBrw2_Click);
            // 
            // cbStep
            // 
            this.cbStep.FormattingEnabled = true;
            this.cbStep.Location = new System.Drawing.Point(66, 58);
            this.cbStep.Name = "cbStep";
            this.cbStep.Size = new System.Drawing.Size(173, 23);
            this.cbStep.TabIndex = 3;
            this.cbStep.SelectedIndexChanged += new System.EventHandler(this.cbStep_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Steps:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Checklist:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Layer:";
            // 
            // cbLayer
            // 
            this.cbLayer.FormattingEnabled = true;
            this.cbLayer.Location = new System.Drawing.Point(66, 96);
            this.cbLayer.Name = "cbLayer";
            this.cbLayer.Size = new System.Drawing.Size(173, 23);
            this.cbLayer.TabIndex = 4;
            // 
            // cbChecklist
            // 
            this.cbChecklist.FormattingEnabled = true;
            this.cbChecklist.Location = new System.Drawing.Point(66, 134);
            this.cbChecklist.Name = "cbChecklist";
            this.cbChecklist.Size = new System.Drawing.Size(173, 23);
            this.cbChecklist.TabIndex = 5;
            // 
            // ckAutoRun
            // 
            this.ckAutoRun.AutoSize = true;
            this.ckAutoRun.Location = new System.Drawing.Point(47, 172);
            this.ckAutoRun.Name = "ckAutoRun";
            this.ckAutoRun.Size = new System.Drawing.Size(172, 19);
            this.ckAutoRun.TabIndex = 5;
            this.ckAutoRun.Text = "Run Checklist Atfer Launch";
            this.ckAutoRun.UseVisualStyleBackColor = true;
            // 
            // tbFilterPattern
            // 
            this.tbFilterPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterPattern.Location = new System.Drawing.Point(253, 14);
            this.tbFilterPattern.Name = "tbFilterPattern";
            this.tbFilterPattern.Size = new System.Drawing.Size(174, 22);
            this.tbFilterPattern.TabIndex = 0;
            this.tbFilterPattern.Text = "*";
            this.tbFilterPattern.TextChanged += new System.EventHandler(this.tbFilterPattern_TextChanged);
            this.tbFilterPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilterPattern_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckFlex);
            this.groupBox1.Controls.Add(this.rdGroup1b2);
            this.groupBox1.Controls.Add(this.rdGroup1b1);
            this.groupBox1.Controls.Add(this.cbChecklist);
            this.groupBox1.Controls.Add(this.ckGuiless);
            this.groupBox1.Controls.Add(this.ckUnitst);
            this.groupBox1.Controls.Add(this.ckAutoRun);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbStep);
            this.groupBox1.Controls.Add(this.cbLayer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(531, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 226);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // ckFlex
            // 
            this.ckFlex.AutoSize = true;
            this.ckFlex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckFlex.ForeColor = System.Drawing.Color.Teal;
            this.ckFlex.Location = new System.Drawing.Point(194, 25);
            this.ckFlex.Name = "ckFlex";
            this.ckFlex.Size = new System.Drawing.Size(49, 19);
            this.ckFlex.TabIndex = 6;
            this.ckFlex.Text = "Flex";
            this.ckFlex.UseVisualStyleBackColor = true;
            // 
            // rdGroup1b2
            // 
            this.rdGroup1b2.AutoSize = true;
            this.rdGroup1b2.Location = new System.Drawing.Point(133, 24);
            this.rdGroup1b2.Name = "rdGroup1b2";
            this.rdGroup1b2.Size = new System.Drawing.Size(48, 19);
            this.rdGroup1b2.TabIndex = 1;
            this.rdGroup1b2.Text = "Gen";
            this.rdGroup1b2.UseVisualStyleBackColor = true;
            this.rdGroup1b2.CheckedChanged += new System.EventHandler(this.rdDFMTool_CheckChanged);
            // 
            // rdGroup1b1
            // 
            this.rdGroup1b1.AutoSize = true;
            this.rdGroup1b1.Checked = true;
            this.rdGroup1b1.Location = new System.Drawing.Point(67, 24);
            this.rdGroup1b1.Name = "rdGroup1b1";
            this.rdGroup1b1.Size = new System.Drawing.Size(61, 19);
            this.rdGroup1b1.TabIndex = 0;
            this.rdGroup1b1.TabStop = true;
            this.rdGroup1b1.Text = "InCAM";
            this.rdGroup1b1.UseVisualStyleBackColor = true;
            this.rdGroup1b1.CheckedChanged += new System.EventHandler(this.rdDFMTool_CheckChanged);
            // 
            // ckGuiless
            // 
            this.ckGuiless.AutoSize = true;
            this.ckGuiless.Enabled = false;
            this.ckGuiless.Location = new System.Drawing.Point(170, 197);
            this.ckGuiless.Name = "ckGuiless";
            this.ckGuiless.Size = new System.Drawing.Size(67, 19);
            this.ckGuiless.TabIndex = 5;
            this.ckGuiless.Text = "Guiless";
            this.ckGuiless.UseVisualStyleBackColor = true;
            this.ckGuiless.CheckedChanged += new System.EventHandler(this.ckGuiless_CheckedChanged);
            // 
            // ckUnitst
            // 
            this.ckUnitst.AutoSize = true;
            this.ckUnitst.Location = new System.Drawing.Point(47, 197);
            this.ckUnitst.Name = "ckUnitst";
            this.ckUnitst.Size = new System.Drawing.Size(113, 19);
            this.ckUnitst.TabIndex = 5;
            this.ckUnitst.Text = "InCAM Unit Test";
            this.ckUnitst.UseVisualStyleBackColor = true;
            this.ckUnitst.CheckedChanged += new System.EventHandler(this.ckUnitst_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "DFM:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbJobCnt);
            this.groupBox2.Controls.Add(this.tbFilterPattern);
            this.groupBox2.Controls.Add(this.ckRegex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dgJobList);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 380);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job List";
            // 
            // lbJobCnt
            // 
            this.lbJobCnt.AutoSize = true;
            this.lbJobCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJobCnt.ForeColor = System.Drawing.Color.Teal;
            this.lbJobCnt.Location = new System.Drawing.Point(3, 26);
            this.lbJobCnt.Name = "lbJobCnt";
            this.lbJobCnt.Size = new System.Drawing.Size(67, 13);
            this.lbJobCnt.TabIndex = 6;
            this.lbJobCnt.Text = "0 jobs in DB.";
            // 
            // ckRegex
            // 
            this.ckRegex.AutoSize = true;
            this.ckRegex.Location = new System.Drawing.Point(437, 16);
            this.ckRegex.Name = "ckRegex";
            this.ckRegex.Size = new System.Drawing.Size(57, 19);
            this.ckRegex.TabIndex = 1;
            this.ckRegex.Text = "regex";
            this.ckRegex.UseVisualStyleBackColor = true;
            this.ckRegex.CheckedChanged += new System.EventHandler(this.ckRegex_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Filter:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbSession);
            this.groupBox3.Controls.Add(this.cbSession);
            this.groupBox3.Controls.Add(this.btnSaveToFile);
            this.groupBox3.Controls.Add(this.btnDelSession);
            this.groupBox3.Controls.Add(this.btnSaveToAutotest);
            this.groupBox3.Controls.Add(this.btnArchiveSession);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(531, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 102);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sessions";
            // 
            // tbSession
            // 
            this.tbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSession.Location = new System.Drawing.Point(66, 60);
            this.tbSession.Name = "tbSession";
            this.tbSession.Size = new System.Drawing.Size(132, 22);
            this.tbSession.TabIndex = 1;
            this.tbSession.Text = "default";
            this.tbSession.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSession_KeyDown);
            // 
            // cbSession
            // 
            this.cbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSession.FormattingEnabled = true;
            this.cbSession.Location = new System.Drawing.Point(66, 22);
            this.cbSession.Name = "cbSession";
            this.cbSession.Size = new System.Drawing.Size(132, 23);
            this.cbSession.TabIndex = 0;
            this.cbSession.SelectedIndexChanged += new System.EventHandler(this.cbSession_SelectedIndexChanged);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveToFile.Image = global::InCAM_Launcher.Properties.Resources.save;
            this.btnSaveToFile.Location = new System.Drawing.Point(203, 61);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(19, 19);
            this.btnSaveToFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSaveToFile.TabIndex = 9;
            this.btnSaveToFile.TabStop = false;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            this.btnSaveToFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnDelSession_MouseDoubleClick);
            this.btnSaveToFile.MouseEnter += new System.EventHandler(this.btnDelSession_MouseEnter);
            this.btnSaveToFile.MouseLeave += new System.EventHandler(this.btnDelSession_MouseLeave);
            // 
            // btnDelSession
            // 
            this.btnDelSession.BackColor = System.Drawing.Color.Transparent;
            this.btnDelSession.Image = global::InCAM_Launcher.Properties.Resources.del;
            this.btnDelSession.Location = new System.Drawing.Point(200, 19);
            this.btnDelSession.Name = "btnDelSession";
            this.btnDelSession.Size = new System.Drawing.Size(24, 24);
            this.btnDelSession.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelSession.TabIndex = 9;
            this.btnDelSession.TabStop = false;
            this.btnDelSession.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnDelSession_MouseDoubleClick);
            this.btnDelSession.MouseEnter += new System.EventHandler(this.btnDelSession_MouseEnter);
            this.btnDelSession.MouseLeave += new System.EventHandler(this.btnDelSession_MouseLeave);
            // 
            // btnSaveToAutotest
            // 
            this.btnSaveToAutotest.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveToAutotest.ErrorImage = global::InCAM_Launcher.Properties.Resources.script;
            this.btnSaveToAutotest.Image = global::InCAM_Launcher.Properties.Resources.script;
            this.btnSaveToAutotest.Location = new System.Drawing.Point(226, 58);
            this.btnSaveToAutotest.Name = "btnSaveToAutotest";
            this.btnSaveToAutotest.Size = new System.Drawing.Size(22, 22);
            this.btnSaveToAutotest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSaveToAutotest.TabIndex = 9;
            this.btnSaveToAutotest.TabStop = false;
            this.btnSaveToAutotest.Click += new System.EventHandler(this.btnSaveToSession_Click);
            this.btnSaveToAutotest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnArchiveSession_MouseDoubleClick);
            this.btnSaveToAutotest.MouseEnter += new System.EventHandler(this.btnDelSession_MouseEnter);
            this.btnSaveToAutotest.MouseLeave += new System.EventHandler(this.btnDelSession_MouseLeave);
            // 
            // btnArchiveSession
            // 
            this.btnArchiveSession.BackColor = System.Drawing.Color.Transparent;
            this.btnArchiveSession.Image = global::InCAM_Launcher.Properties.Resources.archive;
            this.btnArchiveSession.Location = new System.Drawing.Point(223, 22);
            this.btnArchiveSession.Name = "btnArchiveSession";
            this.btnArchiveSession.Size = new System.Drawing.Size(26, 26);
            this.btnArchiveSession.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnArchiveSession.TabIndex = 9;
            this.btnArchiveSession.TabStop = false;
            this.btnArchiveSession.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnArchiveSession_MouseDoubleClick);
            this.btnArchiveSession.MouseEnter += new System.EventHandler(this.btnDelSession_MouseEnter);
            this.btnArchiveSession.MouseLeave += new System.EventHandler(this.btnDelSession_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Saved:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.menuSessionList;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DFMQL";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuSessionList
            // 
            this.menuSessionList.Name = "menuSessionList";
            this.menuSessionList.Size = new System.Drawing.Size(61, 4);
            this.menuSessionList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuSessionList_ItemClicked);
            // 
            // btnQuickLaunch
            // 
            this.btnQuickLaunch.BackColor = System.Drawing.Color.Transparent;
            this.btnQuickLaunch.Image = global::InCAM_Launcher.Properties.Resources.quicklaunch;
            this.btnQuickLaunch.Location = new System.Drawing.Point(756, 14);
            this.btnQuickLaunch.Name = "btnQuickLaunch";
            this.btnQuickLaunch.Size = new System.Drawing.Size(26, 26);
            this.btnQuickLaunch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnQuickLaunch.TabIndex = 9;
            this.btnQuickLaunch.TabStop = false;
            this.btnQuickLaunch.Click += new System.EventHandler(this.btnQuickLaunch_Click);
            this.btnQuickLaunch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btnArchiveSession_MouseDoubleClick);
            this.btnQuickLaunch.MouseEnter += new System.EventHandler(this.btnDelSession_MouseEnter);
            this.btnQuickLaunch.MouseLeave += new System.EventHandler(this.btnDelSession_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 480);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbdbDir);
            this.Controls.Add(this.tbIncamDir);
            this.Controls.Add(this.btnQuickLaunch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrw2);
            this.Controls.Add(this.btnBrw1);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DFM Quick Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgJobList)).EndInit();
            this.menuJobManage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveToFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveToAutotest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnArchiveSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickLaunch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DataGridView dgJobList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tbIncamDir;
        private System.Windows.Forms.Button btnBrw1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbdbDir;
        private System.Windows.Forms.Button btnBrw2;
        private System.Windows.Forms.ComboBox cbStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLayer;
        private System.Windows.Forms.ComboBox cbChecklist;
        private System.Windows.Forms.CheckBox ckAutoRun;
        private System.Windows.Forms.TextBox tbFilterPattern;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckRegex;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbSession;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSession;
        private System.Windows.Forms.PictureBox btnDelSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.RadioButton rdGroup1b2;
        private System.Windows.Forms.RadioButton rdGroup1b1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip menuJobManage;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox btnArchiveSession;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip menuSessionList;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lbJobCnt;
        private System.Windows.Forms.CheckBox ckUnitst;
        private System.Windows.Forms.CheckBox ckGuiless;
        private System.Windows.Forms.CheckBox ckFlex;
        private System.Windows.Forms.PictureBox btnQuickLaunch;
        private System.Windows.Forms.PictureBox btnSaveToFile;
        private System.Windows.Forms.PictureBox btnSaveToAutotest;
        private System.Windows.Forms.Label label9;
    }
}

