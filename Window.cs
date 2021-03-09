using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Blueprintz.Style;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blueprintz.Editor;

namespace Blueprintz
{
    public partial class IdiotTest : MaterialForm
    {
        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;
        private readonly EditorTabHandler tabHandler = null;

        public IdiotTest()
        {
            //Init UI
            InitializeComponent();
            InitializeMaterialSkin();

            //Init
            tabHandler = new EditorTabHandler(this);
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
            tabHandler.CreateNewEditor();
        }

        private void loadExistingBlueprintButton_Click(object sender, EventArgs e)
        {
            // This is just for testing purposes
            string fileName = "coolest show ever";
            string fileExtension = ".blz";

            // Load Tab
            tabHandler.LoadEditor(fileName, fileExtension);
        }

        private void MainControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quitButton_Click(object sender, EventArgs e)
            => CloseDelayed();
        #endregion

        // Wait for animation to finish, because it looks better.
        private async void CloseDelayed()
        {
            await Task.Delay(250);
            if (!Tabs.recentlySaved)
                new MultichoiceMaterialMessageBox(ColorSchemes.dark_3, "Don't forget to save!",
                    new string[2] { "Don't forget to save your work!", "Do you want to save it now?" },
                    true, CloseCallback, this);
            else Close();
        }

        private void CloseCallback(DialogResult result)
        {
            if (result == DialogResult.No) Close();
            else if (result == DialogResult.Yes)
            {
                // Save
                Tabs.recentlySaved = true;

                Close();
            }
        }

        private void IdiotTest_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
 }
