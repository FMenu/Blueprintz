
namespace Blueprintz
{
    partial class IdiotTest
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.startBorder = new MaterialSkin.Controls.MaterialCard();
            this.startLabel = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.startPanel = new MaterialSkin.Controls.MaterialCard();
            this.MainControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.startBorder.SuspendLayout();
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
            this.MainControl.Controls.Add(this.tabPage1);
            this.MainControl.Controls.Add(this.tabPage2);
            this.MainControl.Depth = 0;
            this.MainControl.ItemSize = new System.Drawing.Size(50, 18);
            this.MainControl.Location = new System.Drawing.Point(0, 118);
            this.MainControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainControl.Multiline = true;
            this.MainControl.Name = "MainControl";
            this.MainControl.SelectedIndex = 0;
            this.MainControl.Size = new System.Drawing.Size(1201, 633);
            this.MainControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.startBorder);
            this.tabPage1.Controls.Add(this.startLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1193, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // startBorder
            // 
            this.startBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startBorder.Controls.Add(this.startPanel);
            this.startBorder.Depth = 0;
            this.startBorder.ForeColor = System.Drawing.Color.LightGray;
            this.startBorder.Location = new System.Drawing.Point(463, 118);
            this.startBorder.Margin = new System.Windows.Forms.Padding(14);
            this.startBorder.MouseState = MaterialSkin.MouseState.HOVER;
            this.startBorder.Name = "startBorder";
            this.startBorder.Padding = new System.Windows.Forms.Padding(14);
            this.startBorder.Size = new System.Drawing.Size(250, 450);
            this.startBorder.TabIndex = 1;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Depth = 0;
            this.startLabel.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.startLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.startLabel.Location = new System.Drawing.Point(552, 63);
            this.startLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(74, 41);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Start";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1193, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // startPanel
            // 
            this.startPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startPanel.Depth = 0;
            this.startPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.startPanel.Location = new System.Drawing.Point(2, 2);
            this.startPanel.Margin = new System.Windows.Forms.Padding(14);
            this.startPanel.MouseState = MaterialSkin.MouseState.HOVER;
            this.startPanel.Name = "startPanel";
            this.startPanel.Padding = new System.Windows.Forms.Padding(14);
            this.startPanel.Size = new System.Drawing.Size(246, 446);
            this.startPanel.TabIndex = 0;
            // 
            // IdiotTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.MainControl);
            this.Controls.Add(this.MainTabSelector);
            this.Name = "IdiotTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.startBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector MainTabSelector;
        private MaterialSkin.Controls.MaterialTabControl MainControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialLabel startLabel;
        private MaterialSkin.Controls.MaterialCard startBorder;
        private MaterialSkin.Controls.MaterialCard startPanel;
    }
}

