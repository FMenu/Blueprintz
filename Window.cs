using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Blueprintz.Style;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blueprintz.Editor;
using System.Drawing;
using System.IO;
using JumpinFrog.Logging;
using Blueprintz.Encoding;
using Blueprintz.JsonStructures;
using System.Numerics;
using System.Linq;

namespace Blueprintz
{
    public partial class Blueprintz : MaterialForm
    {
        private readonly MaterialSkinManager materialSkin = MaterialSkinManager.Instance;
        private readonly EditorTabHandler tabHandler = null;

        public static readonly Logger logger = Logger.defaultLogger;

        public EditorCanvas editorCanvas = null;

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
            Tabs.editorPage = MainControl.TabPages[1];
            MainControl.TabPages.Remove(Tabs.editorPage);


            Firework firework1 = new Firework(Guid.NewGuid(), "Rocket_AmazingGranny_Purple", new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f), true);
            Firework firework2 = new Firework(Guid.NewGuid(), "Cake_2021", new Vector3(15f, 9f, 1f), new Quaternion(0f, 0f, 0f, 0f), true);
            Firework firework3 = new Firework(Guid.NewGuid(), "PreloadedTube_MrBeats", new Vector3(0.0444f, 11f, 02f), new Quaternion(0f, 12f, 0f, 0.1f), true);

            Fireworks fireworks = new Fireworks("", "Blueprintz Generator", Map.Town);

            fireworks.AddFuse(firework1.id, firework2.id, FuseSpeed.Medium);

            fireworks.AddFirework(firework1);
            fireworks.AddFirework(firework2);
            fireworks.AddFirework(firework3);

            BLZJsonStructure jsonStructure = fireworks.ToBLZStructure();
            BlueprintJsonStructure fmJsonStructure = fireworks.ToBlueprintStructure();

            JsonSerializer<BLZJsonStructure> serializer = new JsonSerializer<BLZJsonStructure>();
            JsonSerializer<BlueprintJsonStructure> serializer2 = new JsonSerializer<BlueprintJsonStructure>();

            serializer.Encode(jsonStructure);
            serializer2.Encode(fmJsonStructure);

            string bson = BinaryEncoder.EncodeFromJson(serializer.ToString());

            byte[] zipped = BinaryEncoder.Zip(bson);

            logger.Log(serializer.GetFormatted().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
            Console.WriteLine();

            logger.Log(new string[1] { bson });
            Console.WriteLine();

            logger.Log(new string[1] { System.Text.Encoding.ASCII.GetString(zipped) });
            Console.WriteLine();

            logger.Log(serializer2.GetFormatted().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
            Console.WriteLine();

            // Added custom Methods for displaying and using the FireworkType enum to display the GUI names and to make it easy to get the JSON values.
            var ft = FireworkType.AmazingGranny1;
            // Get the display name of the enum object
            ft.GetDisplayString();
            // Get the Description of the object (in this case the JSON value)
            ft.ToDescriptionString();
            // Get an instance of the object set to every item in the object.
            Utils.GetAllItmesInFireworkTypes().ToEnumerable().ToArray();
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