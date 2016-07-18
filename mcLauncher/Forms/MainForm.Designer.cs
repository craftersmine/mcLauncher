namespace craftersmine.Launcher.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.header = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.headerTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settings = new System.Windows.Forms.Button();
            this.clntlab = new System.Windows.Forms.Label();
            this.site = new System.Windows.Forms.Button();
            this.welcomelab = new System.Windows.Forms.Label();
            this.clients = new System.Windows.Forms.ComboBox();
            this.unlog = new System.Windows.Forms.Button();
            this.run = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.currFile = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.news = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.Transparent;
            this.header.BackgroundImage = global::craftersmine.Launcher.Properties.Resources.header;
            this.header.Controls.Add(this.button3);
            this.header.Controls.Add(this.button2);
            this.header.Controls.Add(this.headerTitle);
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(789, 30);
            this.header.TabIndex = 2;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            this.header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.header_MouseMove);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.BackgroundImage = global::craftersmine.Launcher.Properties.Resources.minimize;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.MediumBlue;
            this.button3.Location = new System.Drawing.Point(698, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 30);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.BackgroundImage = global::craftersmine.Launcher.Properties.Resources.close;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(735, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 30);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // headerTitle
            // 
            this.headerTitle.AutoSize = true;
            this.headerTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerTitle.ForeColor = System.Drawing.Color.Red;
            this.headerTitle.Location = new System.Drawing.Point(3, 4);
            this.headerTitle.Name = "headerTitle";
            this.headerTitle.Size = new System.Drawing.Size(555, 20);
            this.headerTitle.TabIndex = 0;
            this.headerTitle.Text = "craftersmine Launcher ( Not Configured or title is null! Check Core/Settings.cs f" +
    "ile! )";
            this.headerTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            this.headerTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.header_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.settings);
            this.panel1.Controls.Add(this.clntlab);
            this.panel1.Controls.Add(this.site);
            this.panel1.Controls.Add(this.welcomelab);
            this.panel1.Controls.Add(this.clients);
            this.panel1.Controls.Add(this.unlog);
            this.panel1.Controls.Add(this.run);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.currFile);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Location = new System.Drawing.Point(534, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 438);
            this.panel1.TabIndex = 3;
            // 
            // settings
            // 
            this.settings.Image = global::craftersmine.Launcher.Properties.Resources.settings;
            this.settings.Location = new System.Drawing.Point(200, 394);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(38, 39);
            this.settings.TabIndex = 9;
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // clntlab
            // 
            this.clntlab.AutoSize = true;
            this.clntlab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clntlab.ForeColor = System.Drawing.Color.White;
            this.clntlab.Location = new System.Drawing.Point(4, 305);
            this.clntlab.Name = "clntlab";
            this.clntlab.Size = new System.Drawing.Size(47, 13);
            this.clntlab.TabIndex = 8;
            this.clntlab.Text = "Клиент:";
            // 
            // site
            // 
            this.site.Image = global::craftersmine.Launcher.Properties.Resources.site;
            this.site.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.site.Location = new System.Drawing.Point(4, 41);
            this.site.Name = "site";
            this.site.Size = new System.Drawing.Size(234, 23);
            this.site.TabIndex = 7;
            this.site.Text = "Сайт";
            this.site.UseVisualStyleBackColor = true;
            this.site.Click += new System.EventHandler(this.site_Click);
            // 
            // welcomelab
            // 
            this.welcomelab.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomelab.ForeColor = System.Drawing.Color.White;
            this.welcomelab.Location = new System.Drawing.Point(3, 4);
            this.welcomelab.Name = "welcomelab";
            this.welcomelab.Size = new System.Drawing.Size(235, 23);
            this.welcomelab.TabIndex = 6;
            this.welcomelab.Text = "Здравствуй, ";
            // 
            // clients
            // 
            this.clients.BackColor = System.Drawing.SystemColors.Window;
            this.clients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clients.FormattingEnabled = true;
            this.clients.Location = new System.Drawing.Point(4, 321);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(234, 21);
            this.clients.TabIndex = 5;
            this.clients.SelectedIndexChanged += new System.EventHandler(this.clients_MouseUp);
            this.clients.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clients_MouseUp);
            // 
            // unlog
            // 
            this.unlog.Image = global::craftersmine.Launcher.Properties.Resources.unlog;
            this.unlog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unlog.Location = new System.Drawing.Point(4, 365);
            this.unlog.Name = "unlog";
            this.unlog.Size = new System.Drawing.Size(234, 23);
            this.unlog.TabIndex = 4;
            this.unlog.Text = "Выйти";
            this.unlog.UseVisualStyleBackColor = true;
            this.unlog.Click += new System.EventHandler(this.unlog_Click);
            // 
            // run
            // 
            this.run.Enabled = false;
            this.run.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.run.Image = global::craftersmine.Launcher.Properties.Resources.run;
            this.run.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.run.Location = new System.Drawing.Point(4, 394);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(190, 39);
            this.run.TabIndex = 2;
            this.run.Text = "Запустить";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 420);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 13);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // currFile
            // 
            this.currFile.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currFile.ForeColor = System.Drawing.Color.White;
            this.currFile.Location = new System.Drawing.Point(3, 382);
            this.currFile.Name = "currFile";
            this.currFile.Size = new System.Drawing.Size(235, 23);
            this.currFile.TabIndex = 1;
            this.currFile.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 408);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(234, 13);
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.news);
            this.panel2.Location = new System.Drawing.Point(12, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 438);
            this.panel2.TabIndex = 4;
            // 
            // news
            // 
            this.news.AutoSize = true;
            this.news.BackColor = System.Drawing.Color.Transparent;
            this.news.ForeColor = System.Drawing.Color.White;
            this.news.Location = new System.Drawing.Point(3, 4);
            this.news.Name = "news";
            this.news.Size = new System.Drawing.Size(0, 13);
            this.news.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::craftersmine.Launcher.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(789, 487);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label currFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button site;
        private System.Windows.Forms.Label welcomelab;
        private System.Windows.Forms.ComboBox clients;
        private System.Windows.Forms.Button unlog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label news;
        private System.Windows.Forms.Label headerTitle;
        private System.Windows.Forms.Label clntlab;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

