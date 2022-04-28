// Tool by Szikaka //
//   31.12.2021    //
//1.1.0 - 5.01.2022//
/////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PlayerModelSwapper {
    public partial class PlayerModelSwapper : Form {

        private class TextureData { //Class used for .json serialization
            public List<string> textureDirectories { get; set; } = new List<string>();
            public List<string> texturePaths { get; set; } = new List<string>();
        }

        private byte[] targetName = Encoding.ASCII.GetBytes("target_silhouette"); //Texture we want to change
        private byte[] endName = Encoding.ASCII.GetBytes("r2_exterior_concrete_grey_normal"); //Name of the next asset
        private const string imageRegex = ".png$|.jpg$|.jpeg$|.bmp$|.gif$|.tiff$";

        private string imagepath = "";
        private string assetPath = "";
        private bool searched = false;
        private bool textureProgress = false;
        private bool assetProgress = false;
        private bool finished = false;

        private Image image = null;
        private TextureData textureData;

        private List<byte> textureFile;
        private List<byte> assetFile;

        public PlayerModelSwapper() { InitializeComponent(); }

        private string locateGameDirectory() {
            List<string> paths = new List<string>();

            List<string> steamDirectories = new List<string>();

            if (!Directory.Exists("C:/Program Files (x86)/Steam/")) throw new DirectoryNotFoundException("Couldn't locate Steam directory");

            steamDirectories.Add("C:/Program Files (x86)/Steam");

            foreach (string line in File.ReadLines("C:/Program Files (x86)/Steam/config/config.vdf")) {
                if (line.Contains("BaseInstallFolder")) steamDirectories.Add(line.Split("\"\t\t\"".ToCharArray())[9]); //Steam directories
            }

            foreach (string path in steamDirectories) {
                if (Directory.Exists(path + "/steamapps/common/Receiver 2")) paths.Add(path + "/steamapps/common/Receiver 2");
            }

            if (paths.Count == 0) throw new DirectoryNotFoundException("Couldn't locate game directory");

            return paths[0];
        }

        private void popUpError(string message) { MessageBox.Show(message, "Error occured"); }

        private void emplaceBytes(List<Byte> list, int start, int value) {
            list[start] = (byte) value;
            list[start + 1] = (byte) (value >> 8);
            list[start + 2] = (byte) (value >> 16);
            list[start + 3] = (byte) (value >> 24);
        }
        private int retrieveBytes(List<Byte> list, int start) {
            int result = 0;

            result = (result | list[start]);
            result = (result | ((int) list[start + 1] << 8));
            result = (result | ((int) list[start + 2] << 16));
            result = (result | ((int) list[start + 3] << 24));

            return result;
        }

        private async void textureButton_Click(object sender, EventArgs args) {

            if (image == null) { //If the user hasn't dragged an image
                textureDialog.InitialDirectory = "../textures"; //Doesn't work lol
                textureDialog.Filter = "Image Files | *.BMP; *.GIF *.JPG; *.PNG; *.TIFF | All files(*.*) | *.*";

                if (textureDialog.ShowDialog() != DialogResult.OK) return;

                try {
                    image = new Bitmap(textureDialog.FileName);
                } catch (ArgumentException e) {
                    popUpError("Invalid image file");
                    updateLabel.Text += "Invalid image file\n";
                    Console.WriteLine(e.StackTrace);
                    return;
                }

                imagepath = textureDialog.FileName; //Path to the bitmap

                pictureBox1.Image = image;
            }

            if (!textureData.texturePaths.Contains(imagepath)) textureData.texturePaths.Add(imagepath);

            try { //I'm using crunch and piping it's output into a file, which I then open
                Process crunch = new Process();
                crunch.StartInfo.WorkingDirectory = "Crunch/bin";
                crunch.StartInfo.FileName = "crunch.exe";
                crunch.StartInfo.Arguments = "\"" + imagepath + "\" -DXT5 -yflip -fileformat dds -out out\\plik.dds";
                crunch.Start();

                crunch.WaitForExit();

                imagepath = Directory.GetCurrentDirectory() + "\\Crunch\\bin\\out\\plik.dds"; //Changed to path to the processed file
            } catch (Exception) {
                popUpError("Cannot parse the image file");
                updateLabel.Text += "ERROR: Cannot parse the image file\n";

                return;
            }

            Stream fileStream = File.Open(imagepath, FileMode.Open);
            updateLabel.Text += "Preparing file...\n";
            await Task.Run(() => { //Weird hacks from StackOverflow, turn the stream into a list of bytes
                MemoryStream ms = new MemoryStream();
                fileStream.CopyTo(ms);

                textureFile = new List<byte>(ms.ToArray());
            });
            updateLabel.Text += "Texture file prepared\n";

            fileStream.Close();

            //File.Delete(imagepath);

            textureProgress = true;

            if (textureProgress && assetProgress) {
                workButton.Enabled = true;
            }

            TextureIndicator.Image = imageList.Images[1];
            textureButton.Enabled = false;

            fileStream.Close();
        }

        private async void directoryButton_Click(object sender, EventArgs args) {

            if (!searched) { //Searching for a Steam directory
                try {
                    assetPath = locateGameDirectory() + "/Receiver2_Data/sharedassets2.assets";

                    updateLabel.Text += "Located game directory\n";
                } catch (DirectoryNotFoundException e) {
                    popUpError(e.Message);
                    updateLabel.Text += e.Message + "\n";

                    directoryButton.Text = "Select Game Directory";

                    searched = true;

                    return;
                }
            } else {
                if (directoryDialog.ShowDialog() != DialogResult.OK) return;

                assetPath = directoryDialog.SelectedPath + "/Receiver2_Data/sharedassets2.assets";
            }

            if (!File.Exists(assetPath)) { //Searching for sharedassets2.assets
                popUpError("Wrong game directory");
                updateLabel.Text += "ERROR: Wrong game directory\n";
                return;
            }

            if (!File.Exists(assetPath + ".old")) { //Making a backup file if needed
                updateLabel.Text += "Creating backup file...\n";
                File.Copy(assetPath, assetPath + ".old");
                updateLabel.Text += "Backup file created\n";
            }

            Stream fileStream = File.Open(assetPath, FileMode.Open);

            updateLabel.Text += "Preparing file...\n";

            await Task.Run(() => { //Weird hacks from StackOverflow part 2
                MemoryStream ms = new MemoryStream();
                fileStream.CopyTo(ms);

                assetFile = new List<byte>(ms.ToArray());
            });

            updateLabel.Text += "File prepared\n";

            assetProgress = true;

            if (textureProgress && assetProgress) {
                workButton.Enabled = true;
            }

            fileStream.Close();

            directoryIndicator.Image = imageList.Images[1];

            directoryButton.Enabled = false;
        }

        private async void workButton_Click(object sender, EventArgs args) {

            if (finished) this.Close();

            updateLabel.Text += "Preparing to mod...\n";
            updateLabel.Text += "Preparing texture file\n";

            var textureData = textureFile.GetRange(128, textureFile.Count - 128); //Strip the header off the image file

            int textureMipCount = retrieveBytes(textureFile, 28); //It's related to the compression method, I think

            updateLabel.Text += "Texture file prepared\n";

            int startIndex = 0;
            int endIndex = 0;

            updateLabel.Text += "Preparing modded file\n";

            await Task.Run(() => { //Search for the right offset in the asset file using the predicate
                for (; startIndex < assetFile.Count - 17; startIndex++) { 
                    if (
                        new Predicate<int>((int index) => {
                            for (int i = 0; i < targetName.Length; i++) {
                                if (assetFile[index + i] != targetName[i]) return false;
                            }
                            return true;
                        })(startIndex)
                    ) break;
                }
            });

            await Task.Run(() => { //Search for the next asset after the one we're changing
                for (endIndex = startIndex; endIndex < assetFile.Count - 32; endIndex++) {
                    if (
                        new Predicate<int>((int index) => {
                            for (int i = 0; i < endName.Length; i++) {
                                if (assetFile[index + i] != endName[i]) return false;
                            }
                            return true;
                        })(endIndex)
                    ) break;
                }
            });

            if (endIndex == assetFile.Count - 33) { //Search if we hit the end of a file
                updateLabel.Text += "Asset file is invalid\n";
                return;
            }

            List<byte> moddedFileData = new List<byte>(assetFile.Take(startIndex + 100)); //Take the contents of a file up to the place where we want to emplace the texture data

            emplaceBytes(moddedFileData, startIndex + 28, image.Width); //Bitsetting image width into the asset file
            emplaceBytes(moddedFileData, startIndex + 32, image.Height); //Bitsetting image height into the asset file
            emplaceBytes(moddedFileData, startIndex + 36, textureData.Count); //Bitsetting image size into the asset file
            emplaceBytes(moddedFileData, startIndex + 44, textureMipCount); //Bitsetting the amount of mipmaps in the image (idk)
            emplaceBytes(moddedFileData, startIndex + 96, textureData.Count); //Bitsetting image size into the asset file (again)

            moddedFileData.AddRange(textureData);

            moddedFileData.AddRange(new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}); //Some other data

            moddedFileData.AddRange(assetFile.Skip(endIndex - 4)); //Add the rest of the original file into a new one

            moddedFileData[4] = (byte) (moddedFileData.Count >> 24); //Bitsetting the size of a file in its header
            moddedFileData[5] = (byte) (moddedFileData.Count >> 16); //Unlike other values, it's big endian
            moddedFileData[6] = (byte) (moddedFileData.Count >> 8);
            moddedFileData[7] = (byte) (moddedFileData.Count);

            int assetsCount = retrieveBytes(moddedFileData, 1432); //Get the amount of the assets in a file

            int difference = moddedFileData.Count - assetFile.Count; //Difference in file sizes
            
            for (int assetNum = 0; assetNum < assetsCount; assetNum += 1) { //Loop through the table of content and change the offsets
                if (assetNum == 16) //Change the size of the texture asset
                    emplaceBytes(moddedFileData, 1436 + (assetNum * 20) + 12, textureData.Count + 116); 

                if (assetNum > 16) //Add the size difference into other entries
                    emplaceBytes(moddedFileData, 1436 + (assetNum * 20) + 8, retrieveBytes(moddedFileData, 1436 + (assetNum * 20) + 8) + difference);
            }

            updateLabel.Text += "Modded file prepared\n";

            Stream moddedAssetFile = File.Open(assetPath, FileMode.Create); //Save the file and we're golden
            moddedAssetFile.Write(moddedFileData.ToArray(), 0, moddedFileData.Count);
            moddedAssetFile.Close();

            updateLabel.Text += "Modded file finished\n";

            finished = true;
            finishedIndicator.Image = imageList.Images[1];
            workButton.Text = "Close";
        }

        private void box2_dragDrop(object sender, DragEventArgs args) { //Put the dragged image into the pictureBox
            imagepath = (args.Data.GetData(DataFormats.FileDrop) as string[]).First();

            try {
                image = new Bitmap(imagepath);
            } catch (ArgumentException e) {
                updateLabel.Text += "Invalid image file\n";
                Console.WriteLine(e.StackTrace);
                return;
            }

            pictureBox1.Image = image;
        }

        private void box2_dragEnter(object sender, DragEventArgs args) { //Allow copying files if they are images
            if (
                args.Data.GetDataPresent(DataFormats.FileDrop) 
                && !textureProgress
                && Regex.IsMatch((args.Data.GetData(DataFormats.FileDrop) as string[]).First(), imageRegex)
            ) {
                args.Effect = DragDropEffects.Copy;
            } else {
                args.Effect = DragDropEffects.None;
            }
        }

        private void PlayerModelSwapper_Load(object sender, EventArgs args) {
            if (File.Exists("config.json")) { //Load texture paths from a .json file
                try {
                    textureData = JsonSerializer.Deserialize<TextureData>(File.ReadAllText("config.json"));
                } catch (JsonException) {
                    textureData = new TextureData();
                    textureData.textureDirectories.Add("textures");
                }
            } else {
                textureData = new TextureData();
                textureData.textureDirectories.Add("textures");
            }

            foreach (string dir in textureData.textureDirectories) { //Get the textures from the directories specified in the .json file
                if (!Directory.Exists(dir)) continue;
                foreach (string path in Directory.GetFiles(dir)) {
                    if (
                        !textureData.texturePaths.Contains(path) 
                        && File.Exists(path) 
                        && Regex.IsMatch(path, imageRegex)
                    ) textureData.texturePaths.Add(path);
                }
            }

            foreach (string path in textureData.texturePaths) { //Creates menu entries from paths
                if (!Regex.IsMatch(path, imageRegex) || !File.Exists(path)) continue;
                ToolStripItem item = new ToolStripButton(path);
                item.Click += textureOptionClick;
                ((ToolStripDropDownItem)menu.Items[0]).DropDownItems.Add(path, null, textureOptionClick);
            }
        }

        private void PlayerModelSwapper_FormClosing(object sender, FormClosingEventArgs args) { //Writes the texture paths to a .json file
            string json = JsonSerializer.Serialize(textureData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("config.json",json);
        }

        private void textureOptionClick(object sender, EventArgs args) { //Selects a texture from a clicked option
            imagepath = Path.GetFullPath(sender.ToString());

            try {
                image = new Bitmap(sender.ToString());

                pictureBox1.Image = image;
            } catch (ArgumentException e) {
                popUpError("Invalid image file");
                updateLabel.Text += "ERROR: Invalid image file\n";
            }
        }

        private void restoreFromBackupToolStripMenuItem_Click(object sender, EventArgs args) { //Restoring the asset file from a .old backup
            if (!File.Exists(assetPath)) {
                MessageBox.Show("Select the game directory first!", "");
                return;
            }

            if (
                MessageBox.Show("Restore the asset file from a backup?", "Restore", MessageBoxButtons.YesNo) == DialogResult.Yes
            ) {
                if (!File.Exists(assetPath + ".old")) {
                    popUpError("There is no backup file");
                    return;
                }

                File.Delete(assetPath);
                File.Copy(assetPath + ".old", assetPath);
                File.Delete(assetPath + ".old");

                MessageBox.Show("Asset File restored", "");
                this.Close();
            }
        }
    }
}
