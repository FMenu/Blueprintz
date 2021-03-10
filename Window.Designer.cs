
namespace Blueprintz
{
    partial class Blueprintz
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.MainControl = new MaterialSkin.Controls.MaterialTabControl();
            this.start = new System.Windows.Forms.TabPage();
            this.startBorder = new MaterialSkin.Controls.MaterialCard();
            this.startPanel = new MaterialSkin.Controls.MaterialCard();
            this.quitButton = new MaterialSkin.Controls.MaterialButton();
            this.loadExistingBlueprintButton = new MaterialSkin.Controls.MaterialButton();
            this.createNewBlueprintButton = new MaterialSkin.Controls.MaterialButton();
            this.startLabel = new MaterialSkin.Controls.MaterialLabel();
            this.editor = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainControl.SuspendLayout();
            this.start.SuspendLayout();
            this.startBorder.SuspendLayout();
            this.startPanel.SuspendLayout();
            this.editor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabSelector
            // 
            this.MainTabSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabSelector.BaseTabControl = this.MainControl;
            this.MainTabSelector.Depth = 0;
            this.MainTabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MainTabSelector.Location = new System.Drawing.Point(-48, 64);
            this.MainTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabSelector.Name = "MainTabSelector";
            this.MainTabSelector.Size = new System.Drawing.Size(1249, 48);
            this.MainTabSelector.TabIndex = 0;
            this.MainTabSelector.Text = "MainTabSelector";
            // 
            // MainControl
            // 
            this.MainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainControl.Controls.Add(this.start);
            this.MainControl.Controls.Add(this.editor);
            this.MainControl.Depth = 0;
            this.MainControl.ItemSize = new System.Drawing.Size(50, 18);
            this.MainControl.Location = new System.Drawing.Point(6, 118);
            this.MainControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainControl.Multiline = true;
            this.MainControl.Name = "MainControl";
            this.MainControl.SelectedIndex = 0;
            this.MainControl.Size = new System.Drawing.Size(1188, 626);
            this.MainControl.TabIndex = 1;
            this.MainControl.SelectedIndexChanged += new System.EventHandler(this.MainControl_SelectedIndexChanged);
            // 
            // start
            // 
            this.start.Controls.Add(this.startBorder);
            this.start.Controls.Add(this.startLabel);
            this.start.Location = new System.Drawing.Point(4, 22);
            this.start.Name = "start";
            this.start.Padding = new System.Windows.Forms.Padding(3);
            this.start.Size = new System.Drawing.Size(1180, 600);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            // 
            // startBorder
            // 
            this.startBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startBorder.Controls.Add(this.startPanel);
            this.startBorder.Depth = 0;
            this.startBorder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.startBorder.Location = new System.Drawing.Point(471, 93);
            this.startBorder.Margin = new System.Windows.Forms.Padding(14);
            this.startBorder.MouseState = MaterialSkin.MouseState.HOVER;
            this.startBorder.Name = "startBorder";
            this.startBorder.Padding = new System.Windows.Forms.Padding(14);
            this.startBorder.Size = new System.Drawing.Size(252, 478);
            this.startBorder.TabIndex = 1;
            // 
            // startPanel
            // 
            this.startPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startPanel.Controls.Add(this.quitButton);
            this.startPanel.Controls.Add(this.loadExistingBlueprintButton);
            this.startPanel.Controls.Add(this.createNewBlueprintButton);
            this.startPanel.Depth = 0;
            this.startPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.startPanel.Location = new System.Drawing.Point(2, 2);
            this.startPanel.Margin = new System.Windows.Forms.Padding(14);
            this.startPanel.MouseState = MaterialSkin.MouseState.HOVER;
            this.startPanel.Name = "startPanel";
            this.startPanel.Padding = new System.Windows.Forms.Padding(14);
            this.startPanel.Size = new System.Drawing.Size(248, 474);
            this.startPanel.TabIndex = 0;
            // 
            // quitButton
            // 
            this.quitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quitButton.Depth = 0;
            this.quitButton.DrawShadows = true;
            this.quitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.quitButton.HighEmphasis = false;
            this.quitButton.Icon = null;
            this.quitButton.Location = new System.Drawing.Point(21, 418);
            this.quitButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.quitButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(207, 36);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "                                           Quit                                  " +
    "   \r\n\r\n";
            this.quitButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.quitButton.UseAccentColor = false;
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // loadExistingBlueprintButton
            // 
            this.loadExistingBlueprintButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadExistingBlueprintButton.Depth = 0;
            this.loadExistingBlueprintButton.DrawShadows = true;
            this.loadExistingBlueprintButton.HighEmphasis = true;
            this.loadExistingBlueprintButton.Icon = null;
            this.loadExistingBlueprintButton.Location = new System.Drawing.Point(21, 78);
            this.loadExistingBlueprintButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.loadExistingBlueprintButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.loadExistingBlueprintButton.Name = "loadExistingBlueprintButton";
            this.loadExistingBlueprintButton.Size = new System.Drawing.Size(207, 36);
            this.loadExistingBlueprintButton.TabIndex = 1;
            this.loadExistingBlueprintButton.Text = "       Load Blueprintz File       ";
            this.loadExistingBlueprintButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.loadExistingBlueprintButton.UseAccentColor = false;
            this.loadExistingBlueprintButton.UseVisualStyleBackColor = true;
            this.loadExistingBlueprintButton.Click += new System.EventHandler(this.loadExistingBlueprintButton_Click);
            // 
            // createNewBlueprintButton
            // 
            this.createNewBlueprintButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createNewBlueprintButton.Depth = 0;
            this.createNewBlueprintButton.DrawShadows = true;
            this.createNewBlueprintButton.HighEmphasis = true;
            this.createNewBlueprintButton.Icon = null;
            this.createNewBlueprintButton.Location = new System.Drawing.Point(21, 20);
            this.createNewBlueprintButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.createNewBlueprintButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.createNewBlueprintButton.Name = "createNewBlueprintButton";
            this.createNewBlueprintButton.Size = new System.Drawing.Size(207, 36);
            this.createNewBlueprintButton.TabIndex = 0;
            this.createNewBlueprintButton.Text = "              Import Blueprint              ";
            this.createNewBlueprintButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.createNewBlueprintButton.UseAccentColor = false;
            this.createNewBlueprintButton.UseVisualStyleBackColor = true;
            this.createNewBlueprintButton.Click += new System.EventHandler(this.createNewBlueprintButton_Click);
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startLabel.AutoSize = true;
            this.startLabel.Depth = 0;
            this.startLabel.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.startLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.startLabel.Location = new System.Drawing.Point(560, 35);
            this.startLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(74, 41);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Start";
            // 
            // editor
            // 
            this.editor.Controls.Add(this.pictureBox1);
            this.editor.Location = new System.Drawing.Point(4, 22);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(3);
            this.editor.Size = new System.Drawing.Size(1180, 600);
            this.editor.TabIndex = 1;
            this.editor.Text = "Editor";
            this.editor.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(216, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(763, 587);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Blueprintz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.MainControl);
            this.Controls.Add(this.MainTabSelector);
            this.MinimumSize = new System.Drawing.Size(800, 750);
            this.Name = "Blueprintz";
            this.Text = "Blueprintz by FMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IdiotTest_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.IdiotTest_Resize);
            this.MainControl.ResumeLayout(false);
            this.start.ResumeLayout(false);
            this.start.PerformLayout();
            this.startBorder.ResumeLayout(false);
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            this.editor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector MainTabSelector;
        public MaterialSkin.Controls.MaterialTabControl MainControl;
        private System.Windows.Forms.TabPage start;
        private System.Windows.Forms.TabPage editor;
        private MaterialSkin.Controls.MaterialLabel startLabel;
        private MaterialSkin.Controls.MaterialCard startBorder;
        private MaterialSkin.Controls.MaterialCard startPanel;
        private MaterialSkin.Controls.MaterialButton createNewBlueprintButton;
        private MaterialSkin.Controls.MaterialButton loadExistingBlueprintButton;
        private MaterialSkin.Controls.MaterialButton quitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

