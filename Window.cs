using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Blueprintz.Style;
using System.Threading.Tasks;

namespace Blueprintz
{
    public partial class IdiotTest : MaterialForm
    {
        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;
        public IdiotTest()
        {
            InitializeComponent();
            InitializeMaterialSkin();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tabs.editorPage = MainControl.TabPages[1];
            MainControl.TabPages.Remove(Tabs.editorPage);
        }

        #region Other
        private void InitializeMaterialSkin()
        {
            materialSkin.AddFormToManage(this);
            materialSkin.Theme = MaterialSkinManager.Themes.DARK;
            materialSkin.ColorScheme = ColorSchemes.dark_3;
        }

        private void ShowMsg(string title, string[] lines)
        {
            new MaterialMessageBox(ColorSchemes.dark_3, title, lines, owner: this);
        }
        #endregion

        #region Events
        private void createNewBlueprintButton_Click(object sender, EventArgs e)
        {
            if (!MainControl.TabPages.Contains(Tabs.editorPage))
                MainControl.TabPages.Add(Tabs.editorPage);
            if (MainControl.TabPages[1].Text != "New Blueprint")
                Tabs.editorPage.Text = "New Blueprint";
            MainControl.SelectedTab = Tabs.editorPage;
        }

        private void loadExistingBlueprintButton_Click(object sender, EventArgs e)
        {
            //TODO: Shorten filenames.
            string tabTitle = "[FILENAME].[FILETYPE]";
            if (!MainControl.TabPages.Contains(Tabs.editorPage))
                MainControl.TabPages.Add(Tabs.editorPage);
            if (MainControl.TabPages[1].Text != tabTitle)
                Tabs.editorPage.Text = tabTitle;
            MainControl.SelectedTab = Tabs.editorPage;
        }
        #endregion

        private void MainControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }
