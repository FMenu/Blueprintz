using Blueprintz.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    class EditorTabHandler
    {
        private Blueprintz window;

        public EditorTabHandler(Blueprintz window)
        {
            this.window = window;
        }

        // TODO: put all of this into it's own file.
        // TODO: Add save dialog where save is in the Editor section.
        #region Editor
        /*
        public void CreateNewEditor()
        {
            if (!Tabs.recentlySaved)
                new MultichoiceMaterialMessageBox(ColorSchemes.dark_3, "Don't forget to save!",
                    new string[2] { "Don't forget to save your work!", "Do you want to save it now?" },
                    true, CreateNewEditorCallback, window);
            else CreateNewEditorCallback(DialogResult.No);
        }*/

        public void LoadEditor(string fileName, string fileExtension)
        {
            if (!Tabs.recentlySaved)
            {
                Tabs.tabName = Utils.MiddleShortenTo(10, fileName) + fileExtension;
                new MultichoiceMaterialMessageBox(ColorSchemes.dark_3, "Don't forget to save!",
                    new string[2] { "Don't forget to save your work!", "Do you want to save it now?" },
                    true, LoadEditorCallback, window);
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
                if (!window.MainControl.TabPages.Contains(Tabs.editorPage))
                    window.MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (window.MainControl.TabPages[1].Text != tabTitle)
                    Tabs.editorPage.Text = tabTitle;

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                window.MainControl.SelectedTab = Tabs.editorPage;
            }
            else if (result == DialogResult.Yes)
            {
                // Save
                // Remove and put in save Method:
                Tabs.recentlySaved = true;

                // Create string to display as Tab name.
                string tabTitle = Tabs.tabName;

                // Add Page if it doesn't already exist
                if (!window.MainControl.TabPages.Contains(Tabs.editorPage))
                    window.MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (window.MainControl.TabPages[1].Text != tabTitle)
                    Tabs.editorPage.Text = tabTitle;

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                window.MainControl.SelectedTab = Tabs.editorPage;
            }
            Tabs.tabName = "";
        }

        /*
        private void CreateNewEditorCallback(DialogResult result)
        {
            if (result == DialogResult.No)
            {
                // Add Page if it doesn't already exist
                if (!window.MainControl.TabPages.Contains(Tabs.editorPage))
                    window.MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (window.MainControl.TabPages[1].Text != "New Blueprint")
                    Tabs.editorPage.Text = "New Blueprint";

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                window.MainControl.SelectedTab = Tabs.editorPage;
            }
            else if (result == DialogResult.Yes)
            {
                // Save
                // Remove and put in save Method:
                Tabs.recentlySaved = true;

                // Add Page if it doesn't already exist
                if (!window.MainControl.TabPages.Contains(Tabs.editorPage))
                    window.MainControl.TabPages.Add(Tabs.editorPage);

                // Change Tab title
                if (window.MainControl.TabPages[1].Text != "New Blueprint")
                    Tabs.editorPage.Text = "New Blueprint";

                // Reset saved variable
                Tabs.recentlySaved = false;

                // Open Tab
                window.MainControl.SelectedTab = Tabs.editorPage;
            }
            Tabs.tabName = "";
        }*/
        #endregion
    }
}
