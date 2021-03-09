using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Blueprintz.Style;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprintz
{
    public partial class IdiotTest : MaterialForm
    {
        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;

        public IdiotTest()
        {
            //Init UI
            InitializeComponent();
            InitializeMaterialSkin();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Save Page an Remove it.
            Tabs.editorPage = MainControl.TabPages[1];
            MainControl.TabPages.Remove(Tabs.editorPage);
        }

        #region Other
        // Initialize the look of the Form.
        private void InitializeMaterialSkin()
        {
            materialSkin.AddFormToManage(this);
            materialSkin.Theme = MaterialSkinManager.Themes.DARK;
            materialSkin.ColorScheme = ColorSchemes.dark_3;
        }

        // Show Material Messagebox
        private void ShowMsg(string title, string[] lines)
        {
            new MaterialMessageBox(ColorSchemes.dark_3, title, lines, owner: this);
        }

        #endregion

        #region Events
        private void createNewBlueprintButton_Click(object sender, EventArgs e)
        {
            // Create a new Editor.
            CreateNewEditor();
        }

        private void loadExistingBlueprintButton_Click(object sender, EventArgs e)
        {
            // This is just for testing purposes
            string fileName = "coolest show ever";
            string fileExtension = ".blz";

            // Load Tab
            LoadEditor(fileName, fileExtension);
        }

        private void MainControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quitButton_Click(object sender, EventArgs e)
            => CloseDelayed();
        #endregion

        // TODO: put all of this into it's own file.
        // TODO: Add save dialog where save is in the Editor section.
        #region Editor
        private void CreateNewEditor()
        {
            if (!Tabs.recentlySaved)
                new MultichoiceMaterialMessageBox(ColorSchemes.dark_3, "Don't forget to save!",
                    new string[2] { "Don't forget to save your work!", "Do you want to save it now?" },
                    true, CreateNewEditorCallback, this);
            else CreateNewEditorCallback(DialogResult.No);
        }

        private void LoadEditor(string fileName, string fileExtension)
        {
            if (!Tabs.recentlySaved)
            {
                Tabs.tabName = Utils.MiddleShortenTo(10, fileName) + fileExtension;
                new MultichoiceMaterialMessageBox(ColorSchemes.dark_3, "Don't forget to save!",
                    new string[2] { "Don't forget to save your work!", "Do you want to save it now?" },
                    true, LoadEditorCallback, this);
            }
            else
            {
                Tabs.tabName = Utils.MiddleShortenTo(10, fileName) + fileExtension;
                LoadEditorCallback(DialogResult.No);
            }
        }

        private void LoadEditorCallback(DialogResult result)
        {
            if (result == DialogResult.No)
            {
                // Create string to display as Tab name.
                string tabTitle = Tabs.tabName;

                // Add Page if it doesn't already exist
                if (!MainControl.TabPages.Contains(Tabs.editorPage))
                    MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (MainControl.TabPages[1].Text != tabTitle)
                    Tabs.editorPage.Text = tabTitle;

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                MainControl.SelectedTab = Tabs.editorPage;
            }
            else if (result == DialogResult.Yes)
            {
                // Save

                // Create string to display as Tab name.
                string tabTitle = Tabs.tabName;

                // Add Page if it doesn't already exist
                if (!MainControl.TabPages.Contains(Tabs.editorPage))
                    MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (MainControl.TabPages[1].Text != tabTitle)
                    Tabs.editorPage.Text = tabTitle;

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                MainControl.SelectedTab = Tabs.editorPage;
            }
            Tabs.tabName = "";
        }

        private void CreateNewEditorCallback(DialogResult result)
        {
            if (result == DialogResult.No)
            {
                // Add Page if it doesn't already exist
                if (!MainControl.TabPages.Contains(Tabs.editorPage))
                    MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (MainControl.TabPages[1].Text != "New Blueprint")
                    Tabs.editorPage.Text = "New Blueprint";

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                MainControl.SelectedTab = Tabs.editorPage;
            }
            else if (result == DialogResult.Yes)
            {
                // Save

                // Add Page if it doesn't already exist
                if (!MainControl.TabPages.Contains(Tabs.editorPage))
                    MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (MainControl.TabPages[1].Text != "New Blueprint")
                    Tabs.editorPage.Text = "New Blueprint";

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                MainControl.SelectedTab = Tabs.editorPage;
            }
            Tabs.tabName = "";
        }
        #endregion

        // Wait for animation to finish, because it looks better.
        private async void CloseDelayed()
        {
            await Task.Delay(250);
            Close();
        }
    }
 }
