using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Blueprintz
{
    public class MaterialMessageBox : MaterialForm
    {
        private MaterialLabel textLine2;
        private MaterialLabel textLine3;
        private MaterialButton okButton;
        private MaterialLabel textLine1;

        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;
        private readonly Action<DialogResult> closeCallback = null;

        private bool closingAlowed = false;

        public MaterialMessageBox(ColorScheme colorScheme, string title, string[] msgLines, Action<DialogResult> closeCallback = null, Form owner = null)
        {
            // Init
            this.closeCallback = closeCallback;
            if (owner != null) Owner = owner;

            // UI
            InitializeComponent();

            // Form Layout
            materialSkin.AddFormToManage(this);
            materialSkin.Theme = MaterialSkinManager.Themes.DARK;
            materialSkin.ColorScheme = colorScheme;

            // Text
            Text = title;
            HandleLines(msgLines);

            // Show
            Show();
            TopLevel = true;
        }

        #region Form
        private void InitializeComponent()
        {
            this.textLine1 = new MaterialSkin.Controls.MaterialLabel();
            this.textLine2 = new MaterialSkin.Controls.MaterialLabel();
            this.textLine3 = new MaterialSkin.Controls.MaterialLabel();
            this.okButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // textLine1
            // 
            this.textLine1.AutoSize = true;
            this.textLine1.Depth = 0;
            this.textLine1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textLine1.Location = new System.Drawing.Point(19, 86);
            this.textLine1.MouseState = MaterialSkin.MouseState.HOVER;
            this.textLine1.Name = "textLine1";
            this.textLine1.Size = new System.Drawing.Size(365, 19);
            this.textLine1.TabIndex = 0;
            this.textLine1.Text = "Lorem ipsum dolor sit amet, ei eum mutat utroque...";
            // 
            // textLine2
            // 
            this.textLine2.AutoSize = true;
            this.textLine2.Depth = 0;
            this.textLine2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textLine2.Location = new System.Drawing.Point(19, 105);
            this.textLine2.MouseState = MaterialSkin.MouseState.HOVER;
            this.textLine2.Name = "textLine2";
            this.textLine2.Size = new System.Drawing.Size(365, 19);
            this.textLine2.TabIndex = 1;
            this.textLine2.Text = "Lorem ipsum dolor sit amet, ei eum mutat utroque...";
            // 
            // textLine3
            // 
            this.textLine3.AutoSize = true;
            this.textLine3.Depth = 0;
            this.textLine3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textLine3.Location = new System.Drawing.Point(19, 124);
            this.textLine3.MouseState = MaterialSkin.MouseState.HOVER;
            this.textLine3.Name = "textLine3";
            this.textLine3.Size = new System.Drawing.Size(376, 19);
            this.textLine3.TabIndex = 2;
            this.textLine3.Text = "Lorem ipsum dolor sit amet, ei eum mutat utroque...\r\n";
            // 
            // okButton
            // 
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Depth = 0;
            this.okButton.DrawShadows = true;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(407, 162);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(59, 36);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "     OK     ";
            this.okButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // MaterialMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(475, 210);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.textLine3);
            this.Controls.Add(this.textLine2);
            this.Controls.Add(this.textLine1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 210);
            this.Name = "MaterialMessageBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialMessageBox_FormClosing);
            this.Load += new System.EventHandler(this.MaterialMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Events
        private void okButton_Click(object sender, EventArgs e)
        {
            closingAlowed = true;
            Close();
        }

        private void MaterialMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeCallback != null)
            {
                if (closingAlowed) closeCallback(DialogResult.OK);
                else closeCallback(DialogResult.None);
            }
        }
        #endregion

        private void HandleLines(string[] lines)
        {
            if (lines.Length > 3)
                throw new ArgumentException("msgLines can't be bigger than 3.");
            else if (lines.Length <= 0)
                throw new ArgumentException("msgLines can't has to contain atleast 1 item.");
            else if (lines.Length == 3)
            {
                textLine1.Text = lines[0];
                textLine2.Text = lines[1];
                textLine3.Text = lines[2];
            }
            else if (lines.Length == 2)
            {
                textLine1.Text = lines[0];
                textLine2.Text = lines[1];
                textLine3.Text = "";
            }
            else if (lines.Length == 1)
            {
                textLine1.Text = lines[0];
                textLine2.Text = "";
                textLine3.Text = "";
            }
        }

        private void MaterialMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
