using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Blueprintz.Style;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blueprintz.Editor;
using System.Drawing;
using JumpinFrog.Logging;
using Blueprintz.Encoding;
using Blueprintz.JsonStructures;
using System.Numerics;

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

            // Json Test
            JsonSerializer<BLZJsonStructure> serializer = new JsonSerializer<BLZJsonStructure>();
            // Values
            string[] ids = new string[3] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            string[] names = new string[3] { "Slammer", "Slammer", "Viper" };
            Vector3[] positions = new Vector3[] { new Vector3(0, 20, 0), new Vector3(0, 20, 0), new Vector3(0, 20, 0) };
            Quaternion[] rotations = new Quaternion[] { new Quaternion(0, 0, 0, 0), new Quaternion(0, 0, 0, 0), new Quaternion(0, 0, 0, 0) };
            bool[] kinematic = new bool[] { false, false, true };
            // Encode
            BLZJsonStructure structure = new BLZJsonStructure("town", 3, 0, false, ids, names, positions, rotations, kinematic, new int[0], new string[0][]);
            serializer.Encode(structure);
            // Format
            string[] lines = serializer.GetFormatted().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            // Log
            logger.Log(lines);
            Console.WriteLine();

            // Bson
            string bson = BinaryEncoder.EncodeFromJson(serializer.ToString());
            // Log
            logger.Log(new string[1] { bson });
            Console.WriteLine();

            // Zip
            byte[] zipped = BinaryEncoder.Zip(bson);
            // Log
            logger.Log(new string[1] { System.Text.Encoding.ASCII.GetString(zipped)});
            Console.WriteLine();
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