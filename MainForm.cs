using System.Diagnostics;
using System.IO.Compression;

namespace TELauncher
{
    public partial class MainForm : Form
    {
        private int packIndex;
        public MainForm()
        {
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(!Directory.Exists(Path.Combine(docsPath, "TELauncher")))
            {
                Directory.CreateDirectory(Path.Combine(docsPath, "TELauncher", "Packs"));
            }
            if (!File.Exists(Path.Combine(docsPath, "TELauncher", "TEPath.txt")))
            {
                File.Create(Path.Combine(docsPath, "TELauncher", "TEPath.txt")).Dispose();
            }
            if(!Directory.Exists(Path.Combine(docsPath, "TELauncher", "Default")))
            {
                MessageBox.Show("You have not yet set up your default Escapists files. It is recommended to verify your Steam Escapists files before continuing.\nPlease select the location of your Steam Escapists folder.");
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                string steamTEPath = "";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    steamTEPath = folderDialog.SelectedPath;
                }
                string docsTEPath = Path.Combine(docsPath, "The Escapists");

                string defaultDir = Path.Combine(docsPath, "TELauncher", "Default");
                Directory.CreateDirectory(defaultDir);
                string dataDir = Path.Combine(defaultDir, "Data");
                string musicDir = Path.Combine(defaultDir, "Music");
                string imgDir = Path.Combine(dataDir, "images", "custom");
                string extraDocsPath = Path.Combine(defaultDir, "The Escapists");
                Directory.CreateDirectory(Path.Combine(extraDocsPath, "save1"));
                Directory.CreateDirectory(Path.Combine(extraDocsPath, "save2"));
                Directory.CreateDirectory(Path.Combine(extraDocsPath, "save3"));
                Directory.CreateDirectory(dataDir);
                Directory.CreateDirectory(musicDir);
                Directory.CreateDirectory(imgDir);
                Directory.CreateDirectory(extraDocsPath);

                List<string> musicFiles = new List<string>();
                List<string> dataFiles = new List<string>();
                List<string> imgFiles = new List<string>();
                List<string> docsFiles = new List<string>();

                foreach(string file in Directory.GetFiles(Path.Combine(steamTEPath, "Music")))
                {
                    musicFiles.Add(file);
                }
                foreach(string file in Directory.GetFiles(Path.Combine(steamTEPath, "Data")))
                {
                    string name = Path.GetFileName(file);
                    switch (name)
                    {
                        case "items_eng.dat":
                        case "data_eng.dat":
                        case "val.dat":
                            dataFiles.Add(file);
                            break;
                    }
                }
                foreach(string file in Directory.GetFiles(Path.Combine(steamTEPath, "Data", "images", "custom")))
                {
                    imgFiles.Add(file);
                }
                foreach(string file in Directory.GetFiles(docsTEPath))
                {
                    if(Path.GetFileName(file) == "global.dat")
                    {
                        docsFiles.Add(file);
                    }
                }
                foreach(string dir in Directory.GetDirectories(docsTEPath))
                {
                    if (Path.GetFileName(dir).Contains("save"))
                    {
                        foreach(string file in Directory.GetFiles(dir))
                        {
                            docsFiles.Add(file);
                        }
                    }
                }

                foreach(string file in musicFiles)
                {
                    File.Copy(file, Path.Combine(musicDir, Path.GetFileName(file)), true);
                }
                foreach(string file in dataFiles)
                {
                    File.Copy(file, Path.Combine(dataDir, Path.GetFileName(file)), true);
                }
                foreach(string file in imgFiles)
                {
                    File.Copy(file, Path.Combine(imgDir, Path.GetFileName(file)), true);
                }
                foreach(string file in docsFiles)
                {
                    string destDir = extraDocsPath;
                    string parentName = Path.GetFileName(Path.GetDirectoryName(file));
                    if (parentName != null && parentName.Contains("save"))
                    {
                        destDir = Path.Combine(extraDocsPath, parentName);
                    }
                    File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)), true);
                }
            }
            InitializeComponent();
            ResetFilePackView();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string tePath = Path.Combine(docsPath, "TELauncher", "TEPath.txt");
            string path = File.ReadAllText(tePath);

            if (!Directory.Exists(path))
            {
                string newPath;
                MessageBox.Show("Please select the location of your Steam Escapists folder (this will be saved so you do not have to do this again).");
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                if(folderDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(tePath, folderDialog.SelectedPath);
                    path = File.ReadAllText(tePath);
                }
            }

            if(packIndex == 0 || packIndex == -1)
            {
                CopyDirectory(Path.Combine(docsPath, "TELauncher", "Default", "Data"), Path.Combine(path, "Data"));
                CopyDirectory(Path.Combine(docsPath, "TELauncher", "Default", "Music"), Path.Combine(path, "Music"));
                CopyDirectory(Path.Combine(docsPath, "TELauncher", "Default", "The Escapists"), Path.Combine(docsPath, "The Escapists"));
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(docsPath, "TELauncher", "temp"));

                List<string> packs = Directory.GetFiles(Path.Combine(docsPath, "TELauncher", "Packs")).ToList();
                ZipFile.ExtractToDirectory(packs[packIndex - 1], Path.Combine(docsPath, "TELauncher", "temp"));
                CopyDirectory(Path.Combine(docsPath, "TELauncher", "temp", "Data"), Path.Combine(path, "Data"));
                CopyDirectory(Path.Combine(docsPath, "TELauncher", "temp", "Music"), Path.Combine(path, "Music"));
                CopyDirectory(Path.Combine(docsPath, "TELauncher", "temp", "The Escapists"), Path.Combine(docsPath, "The Escapists"));
                Directory.Delete(Path.Combine(docsPath, "TELauncher", "temp"), true);
            }

            Process.Start(Path.Combine(path, "TheEscapists_eur.exe"));
            Close();
        }

        private void MapPackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            packIndex = MapPackList.SelectedIndex;

            if(packIndex == -1)
            {
                LaunchButton.Text = "Launch The Escapists\nNo File Pack (Default) Selected";
            }
            else
            {
                LaunchButton.Text = "Launch The Escapists\n" + MapPackList.Items[packIndex].ToString() + " Selected";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            PackMakerForm form = new PackMakerForm();
            form.ShowDialog();
            ResetFilePackView();
        }
        private void ResetFilePackView()
        {
            MapPackList.Items.Clear();

            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string packsPath = Path.Combine(docsPath, "TELauncher", "Packs");

            MapPackList.Items.Add("No File Pack (Default)");
            foreach(string pack in Directory.GetFiles(packsPath))
            {
                MapPackList.Items.Add(Path.GetFileNameWithoutExtension(pack));
            }
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
