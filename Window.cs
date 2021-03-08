using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

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
            new MaterialMessageBox(ColorSchemes.dark_3, "Testbox", new string[1] { "Test text, this is just text ya'll!" }, CallbackTest, this);
        }

        private void CallbackTest(DialogResult result)
        {
            MessageBox.Show("callback!");
        }

        private void InitializeMaterialSkin()
        {
            materialSkin.AddFormToManage(this);
            materialSkin.Theme = MaterialSkinManager.Themes.DARK;
            materialSkin.ColorScheme = ColorSchemes.dark_3;
        }
    }
 }
