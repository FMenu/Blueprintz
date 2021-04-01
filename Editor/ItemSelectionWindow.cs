using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class ItemSelectionWindow : MaterialForm
    {
        private readonly MaterialSkinManager materialSkin;
        private readonly ColorScheme colorScheme;
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkButton darkButton2;
        private DarkUI.Controls.DarkButton darkButton3;
        private DarkUI.Controls.DarkButton darkButton4;
        private bool canClose = false;

        public ItemSelectionWindow(Blueprintz window)
        {
            InitializeComponent();
            materialSkin = window.SkinManager;
            colorScheme = window.SkinManager.ColorScheme;
        }

        public void ForceClose()
        {
            canClose = true;
            Close();
        }

        #region Form
        private void InitializeComponent()
        {
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton3 = new DarkUI.Controls.DarkButton();
            this.darkButton4 = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(10, 75);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(75, 75);
            this.darkButton1.TabIndex = 0;
            this.darkButton1.Text = "Label";
            // 
            // darkButton2
            // 
            this.darkButton2.Location = new System.Drawing.Point(91, 75);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(75, 75);
            this.darkButton2.TabIndex = 1;
            this.darkButton2.Text = "Label";
            // 
            // darkButton3
            // 
            this.darkButton3.Location = new System.Drawing.Point(172, 75);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton3.Size = new System.Drawing.Size(75, 75);
            this.darkButton3.TabIndex = 2;
            this.darkButton3.Text = "Label";
            // 
            // darkButton4
            // 
            this.darkButton4.Location = new System.Drawing.Point(253, 75);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton4.Size = new System.Drawing.Size(75, 75);
            this.darkButton4.TabIndex = 3;
            this.darkButton4.Text = "Label";
            // 
            // ItemSelectionWindow
            // 
            this.ClientSize = new System.Drawing.Size(338, 455);
            this.Controls.Add(this.darkButton4);
            this.Controls.Add(this.darkButton3);
            this.Controls.Add(this.darkButton2);
            this.Controls.Add(this.darkButton1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(338, 455);
            this.MinimumSize = new System.Drawing.Size(338, 455);
            this.Name = "ItemSelectionWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemSelectionWindow_FormClosing);
            this.Load += new System.EventHandler(this.ItemSelectionWindow_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void ItemSelectionWindow_Load(object sender, EventArgs e)
        {
            // Form Layout
            materialSkin.AddFormToManage(this);
            materialSkin.Theme = MaterialSkinManager.Themes.DARK;
            materialSkin.ColorScheme = colorScheme;
        }

        private void ItemSelectionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose) e.Cancel = true;
        }
    }
}
