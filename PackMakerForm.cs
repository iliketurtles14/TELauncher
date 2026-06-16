using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace TELauncher
{
    public partial class PackMakerForm : Form
    {
        private string currentFileName;
        private int currentFilePackItem = -1;
        private List<List<string>> filePackList = new List<List<string>>();
        public PackMakerForm()
        {
            InitializeComponent();
        }

        private void SelectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFileName = SelectListBox.SelectedItem.ToString();
        }

        private void AddFileButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(currentFileName))
            {
                return;
            }

            string path = "";
            if (currentFileName.Contains("Folder"))
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderDialog.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "Select a file";
                string filter = "Data Files (*.dat)|*.dat";
                if (currentFileName.Contains("Texture"))
                {
                    filter = "Gif Files (*.gif)|*.gif";
                }
                fileDialog.Filter = filter;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = fileDialog.FileName;
                }
            }

            //add to list
            if (path != "")
            {
                List<string> list = new List<string> { path, currentFileName };
                filePackList.Add(list);
                AddedListBox.Items.Add(Path.GetFileName(path));
            }
        }
        private void AddedListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            currentFilePackItem = AddedListBox.SelectedIndex;
        }

        private void RemoveFileButton_Click(object sender, EventArgs e)
        {
            if (currentFilePackItem != -1)
            {
                filePackList.RemoveAt(currentFilePackItem);
                AddedListBox.Items.RemoveAt(currentFilePackItem);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string packsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TELauncher", "Packs");
            string tempPath = Path.Combine(packsPath, "temp");
            string dataPath = Path.Combine(tempPath, "Data");
            string docsPath = Path.Combine(tempPath, "The Escapists");
            string imgPath = Path.Combine(dataPath, "images", "custom");
            string musicPath = Path.Combine(tempPath, "Music");
            Directory.CreateDirectory(tempPath);
            Directory.CreateDirectory(dataPath);
            Directory.CreateDirectory(docsPath);
            Directory.CreateDirectory(Path.Combine(dataPath, "images"));
            Directory.CreateDirectory(imgPath);
            Directory.CreateDirectory(musicPath);
            foreach(List<string> list in filePackList)
            {
                string pathToGo = "";
                bool isFolder = false;
                switch (list[1])
                {
                    case "Custom Tileset Texture":
                    case "Custom Ground Texture":
                        pathToGo = imgPath;
                        break;
                    case "save1 Folder":
                    case "save2 Folder":
                    case "save3 Folder":
                    case "global.dat File":
                        if (list[1].Contains("Folder"))
                        {
                            isFolder = true;
                        }
                        pathToGo = docsPath;
                        break;
                    case "Music Folder":
                        isFolder = true;
                        pathToGo = tempPath;
                        break;
                    case "Custom Speech File":
                    case "items_eng.dat File":
                    case "data_eng.dat File":
                    case "val.dat File":
                        pathToGo = dataPath;
                        break;
                }
                if (!isFolder)
                {
                    File.WriteAllBytes(Path.Combine(pathToGo, Path.GetFileName(list[0])), File.ReadAllBytes(list[0]));
                }
                else
                {
                    CopyDirectory(list[0], pathToGo);
                }
            }

            ZipFile.CreateFromDirectory(tempPath, Path.Combine(packsPath, NameTextBox.Text + ".zip"));
            Directory.Delete(tempPath, true);

            Close();
        }
        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            Directory.CreateDirectory(destinationDir);
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));

                File.Copy(file, destFile, true);
            }
            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string destDirectory = Path.Combine(destinationDir, Path.GetFileName(directory));

                CopyDirectory(directory, destDirectory);
            }
        }
    }
}
