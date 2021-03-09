using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprintz
{
    public class MultichoiceMaterialMessageBox : MaterialForm
    {
        private MaterialLabel textLine2;
        private MaterialLabel textLine3;
        private MaterialButton cancelButton;
        private MaterialLabel textLine1;

        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;
        private readonly Action<DialogResult> closeCallback = null;
        private MaterialButton yesButton;
        private MaterialButton noButton;

        private DialogResult result = DialogResult.None;

        public MultichoiceMaterialMessageBox(ColorScheme colorScheme, string title, string[] msgLines, bool hasCancelButton = false, Action<DialogResult> closeCallback = null, Form owner = null)
        {
            // Init
            this.closeCallback = closeCallback;
            if (owner != null) Owner = owner;

            // UI
            InitializeComponent();
            cancelButton.Visible = hasCancelButton;

            // Form Layout
            materialSkin.AddFormToManage(this);
            materialSkin.Theme = MaterialSkinManager.Themes.DARK;
            materialSkin.ColorScheme = colorScheme;

            // Text
            Text = title;
            HandleLines(msgLines);

            // Show
            Show();
            SetTopLevel(true);
        }

        #region Form
        private void InitializeComponent()
        {
            this.textLine1 = new MaterialSkin.Controls.MaterialLabel();
            this.textLine2 = new MaterialSkin.Controls.MaterialLabel();
            this.textLine3 = new MaterialSkin.Controls.MaterialLabel();
            this.cancelButton = new MaterialSkin.Controls.MaterialButton();
            this.yesButton = new MaterialSkin.Controls.MaterialButton();
            this.noButton = new MaterialSkin.Controls.MaterialButton();
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
            // cancelButton
            // 
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Depth = 0;
            this.cancelButton.DrawShadows = true;
            this.cancelButton.HighEmphasis = true;
            this.cancelButton.Icon = null;
            this.cancelButton.Location = new System.Drawing.Point(232, 165);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 36);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "     Cancel     ";
            this.cancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelButton.UseAccentColor = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.yesButton.Depth = 0;
            this.yesButton.DrawShadows = true;
            this.yesButton.HighEmphasis = true;
            this.yesButton.Icon = null;
            this.yesButton.Location = new System.Drawing.Point(403, 165);
            this.yesButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.yesButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(65, 36);
            this.yesButton.TabIndex = 4;
            this.yesButton.Text = "     Yes     ";
            this.yesButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.yesButton.UseAccentColor = false;
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.noButton.Depth = 0;
            this.noButton.DrawShadows = true;
            this.noButton.HighEmphasis = true;
            this.noButton.Icon = null;
            this.noButton.Location = new System.Drawing.Point(335, 165);
            this.noButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.noButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(60, 36);
            this.noButton.TabIndex = 5;
            this.noButton.Text = "     No     ";
            this.noButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.noButton.UseAccentColor = false;
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // MultichoiceMaterialMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(475, 210);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.textLine3);
            this.Controls.Add(this.textLine2);
            this.Controls.Add(this.textLine1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 210);
            this.Name = "MultichoiceMaterialMessageBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialMessageBox_FormClosing);
            this.Load += new System.EventHandler(this.MaterialMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void MaterialMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeCallback != null)
                closeCallback(result);
        }

        private void MaterialMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            CloseDelayed();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            CloseDelayed();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            CloseDelayed();
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

        private async void CloseDelayed()
        {
            await Task.Delay(150);
            Close();
        }
    }
}

