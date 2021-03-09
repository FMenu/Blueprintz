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
            CreateNewEditor();
        }

        private void loadExistingBlueprintButton_Click(object sender, EventArgs e)
        {
            string fileName = "coolest show ever";
            string fileExtension = ".blz";
            LoadEditor(fileName, fileExtension);
        }

        private void MainControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quitButton_Click(object sender, EventArgs e)
            => CloseDelayed();
        #endregion

        #region Editor
        private void CreateNewEditor()
        {
            // Add Page if it doesn't already exist
            if (!MainControl.TabPages.Contains(Tabs.editorPage))
                MainControl.TabPages.Add(Tabs.editorPage);

            // Change Tab title
            if (MainControl.TabPages[1].Text != "New Blueprint")
                Tabs.editorPage.Text = "New Blueprint";

            // Open Tab
            MainControl.SelectedTab = Tabs.editorPage;
        }

        private void LoadEditor(string fileName, string fileExtension)
        {
            // Create string to display as Tab name.
            string tabTitle = Utils.MiddleShortenTo(10, fileName) + fileExtension;

            // Add Page if it doesn't already exist
            if (!MainControl.TabPages.Contains(Tabs.editorPage))
                MainControl.TabPages.Add(Tabs.editorPage);

            // Change Tab title
            if (MainControl.TabPages[1].Text != tabTitle)
                Tabs.editorPage.Text = tabTitle;

            // Open Tab
            MainControl.SelectedTab = Tabs.editorPage;
        }
        #endregion

        private async void CloseDelayed()
        {
            await Task.Delay(250);
            Close();
        }
    }
 }
