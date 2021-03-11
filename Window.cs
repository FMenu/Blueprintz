using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Blueprintz.Style;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blueprintz.Editor;
using System.Drawing;
using Blueprintz.Debugging;
using Blueprintz.Encoding;
using Blueprintz.Json;

namespace Blueprintz
{
    public partial class Blueprintz : MaterialForm
    {
        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;
        private readonly EditorTabHandler tabHandler = null;

        public static readonly Logger logger = Logger.defaultLogger;

        public EditorCanvas editorCancas = null;

        public Blueprintz()
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
            // Load Json File

            // This is just for testing purposes
            string fileName = "coolest show ever";
            string fileExtension = ".json";

            // Load Tab
            tabHandler.LoadEditor(fileName, fileExtension);
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

        private void quitButton_Click(object sender, EventArgs e) => CloseDelayed();

        private void IdiotTest_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void IdiotTest_Resize(object sender, EventArgs e)
        {
            // Resize Start panel
            Size size = Utils.SubstractSize(Utils.DivideSize(Size, 2), Utils.DivideSize(startBorder.Size, 2));
            startBorder.Location = new Point(size.Width, size.Height - 40);

            // Resize Start label
            Size size_ = Utils.SubstractSize(Utils.DivideSize(Size, 2), Utils.DivideSize(startLabel.Size, 2));
            startLabel.Location = new Point(size_.Width, size_.Height - 320);
        }
        #endregion

        #region Close
        // Wait for animation to finish, because it looks better.
        private async void CloseDelayed()
        {
            // Delay
            await Task.Delay(250);

            // "Don't forget to save" message
            if (!Tabs.recentlySaved)
                new MultichoiceMaterialMessageBox(ColorSchemes.dark_3, "Don't forget to save!",
                    new string[2] { "Don't forget to save your work!", "Do you want to save it now?" },
                    true, CloseCallback, this);
            else Close();
        }

        private void CloseCallback(DialogResult result)
        {
            if (result == DialogResult.No)
            {
                Tabs.recentlySaved = true;
                CloseDelayed();
            }
            else if (result == DialogResult.Yes)
            {
                // Save
                Tabs.recentlySaved = true;

                CloseDelayed();
            }
        }
        #endregion
    }
}