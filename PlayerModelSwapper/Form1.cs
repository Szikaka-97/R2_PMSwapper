// Tool by Szikaka //
//   31.12.2021    //
/////////////////////


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace PlayerModelSwapper {
    public partial class PlayerModelSwapper : Form {

        private byte[] targetName = Encoding.ASCII.GetBytes("target_silhouette");
        private byte[] endName = Encoding.ASCII.GetBytes("r2_exterior_concrete_grey_normal");

        private string imagepath = "";
        private string assetPath = "";
        private bool textureProgress = false;
        private bool assetProgress = false;
        private bool finished = false;

        private List<byte> textureFile;
        private List<byte> assetFile;

        public PlayerModelSwapper() {
            InitializeComponent();
        }

        private async void textureButton_Click(object sender, EventArgs e) {
            textureDialog.InitialDirectory = "../textures";
            textureDialog.Filter = "Image Files | *.BMP; *.GIF *.JPG; *.PNG; *.TIFF | All files(*.*) | *.*";

            if (textureDialog.ShowDialog() != DialogResult.OK) return;

            Image image = null;

            try {
                image = new Bitmap(textureDialog.FileName);
            } catch (ArgumentException exception) {
                updateLabel.Text += "Invalid image file\n";
                Console.WriteLine(exception.StackTrace);
                return;
            } 

            if (image.Width != 1024 || image.Height != 2048) {
                updateLabel.Text += "ERROR: Wrong bitmap dimensions\n";
                return;
            }

            pictureBox1.Image = image;
            
            Process crunch = new Process();
            crunch.StartInfo.WorkingDirectory = "Crunch/bin";
            crunch.StartInfo.FileName = "crunch.exe";
            crunch.StartInfo.Arguments = "\"" + textureDialog.FileName + "\" -DXT5 -yflip -fileformat dds -out out\\plik.dds";
            crunch.Start();

            crunch.WaitForExit();

            imagepath = Directory.GetCurrentDirectory() + "\\Crunch\\bin\\out\\plik.dds";

            if (File.Exists(imagepath)) Console.WriteLine("OK");
            else {
                updateLabel.Text += "Texture file error\n";
                return;
            }

            Stream fileStream = File.Open(imagepath, FileMode.Open);
            updateLabel.Text += "Preparing file...\n";
            await Task.Run(() => {
                MemoryStream ms = new MemoryStream();
                fileStream.CopyTo(ms);

                textureFile = new List<byte>(ms.ToArray());
            });
            updateLabel.Text += "Texture file prepared\n";

            fileStream.Close();

            File.Delete(imagepath);

            textureProgress = true;

            if (textureProgress && assetProgress) {
                workButton.Enabled = true;
            }

            TextureIndicator.Image = imageList1.Images[1];
            textureButton.Enabled = false;

            fileStream.Close();
        }

        private async void directoryButton_Click(object sender, EventArgs e) {
            if (directoryDialog.ShowDialog() != DialogResult.OK) return;

            assetPath = directoryDialog.SelectedPath + "/Receiver2_Data/sharedassets2.assets";

            if (!File.Exists(assetPath)) {
                updateLabel.Text += "ERROR: Wrong game directory\n";
                return;
            }

            if (!File.Exists(assetPath + ".old")) {
                updateLabel.Text += "Creating backup file...\n";
                File.Copy(assetPath, assetPath + ".old");
                updateLabel.Text += "Backup file created\n";
            }

            Stream fileStream = File.Open(assetPath, FileMode.Open);

            updateLabel.Text += "Preparing file...\n";

            await Task.Run(() => {
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

            directoryIndicator.Image = imageList1.Images[1];

            directoryButton.Enabled = false;
        }

        private async void workButton_Click(object sender, EventArgs e) {

            if (finished) this.Close();

            updateLabel.Text += "Preparing to mod...\n";
            updateLabel.Text += "Preparing texture file\n";

            var textureData = textureFile.GetRange(128, textureFile.Count - 128);

            updateLabel.Text += "Texture file prepared\n";

            int startIndex = 0;
            int endIndex = 0;

            updateLabel.Text += "Preparing modded file\n";

            Predicate<int> targetFind = (int index) => {
                for (int i = 0; i < targetName.Length; i++) {
                    if (assetFile[index + i] != targetName[i]) return false;
                }
                return true;
            };

            await Task.Run(() => {
                for (; startIndex < assetFile.Count - 17; startIndex++) { 
                    if (targetFind(startIndex)) break;
                }
            });

            Predicate<int> endFind = (int index) => {
                for (int i = 0; i < endName.Length; i++) {
                    if (assetFile[index + i] != endName[i]) return false;
                }
                return true;
            };

            await Task.Run(() => {
                for (endIndex = startIndex; endIndex <= startIndex + 3000000; endIndex++) {
                    if (endFind(endIndex)) break;
                }
            });

            if (endIndex == startIndex + 3000000) {
                updateLabel.Text += "Asset file is invalid\n";
                Console.WriteLine("FAIL");
                return;
            }

            List<byte> moddedFileData = new List<byte>(assetFile.Take(startIndex + 96));

            moddedFileData.AddRange(new byte[] {208, 170, 42, 0});

            moddedFileData.AddRange(textureData);

            moddedFileData.AddRange(new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});

            List<byte> moddedFileend = new List<byte>(assetFile.Skip(endIndex - 4));

            moddedFileData.AddRange(moddedFileend);

            moddedFileData[4] = (byte) (moddedFileData.Count >> 24);
            moddedFileData[5] = (byte) (moddedFileData.Count >> 16);
            moddedFileData[6] = (byte) (moddedFileData.Count >> 8);
            moddedFileData[7] = (byte) (moddedFileData.Count);

            int assetsCount = 0;

            assetsCount = (assetsCount | moddedFileData[1432]);
            assetsCount = (assetsCount | ((int) moddedFileData[1433] << 8));
            assetsCount = (assetsCount | ((int) moddedFileData[1434] << 16));
            assetsCount = (assetsCount | ((int) moddedFileData[1435] << 24));

            int difference = moddedFileData.Count - assetFile.Count;
            
            for (int assetNum = 0; assetNum < assetsCount; assetNum += 1) {

                if (assetNum == 16) {
                    moddedFileData[1436 + (assetNum * 20) + 12] = (byte) (textureData.Count + 116);
                    moddedFileData[1437 + (assetNum * 20) + 12] = (byte) ((textureData.Count + 116) >> 8);
                    moddedFileData[1438 + (assetNum * 20) + 12] = (byte)((textureData.Count + 116) >> 16);
                    moddedFileData[1439 + (assetNum * 20) + 12] = (byte)((textureData.Count + 116) >> 24);
                }

                if (assetNum > 16) {
                    int assetOffset = 0;

                    assetOffset = (assetOffset | moddedFileData[1436 + (assetNum * 20) + 8]);
                    assetOffset = (assetOffset | ((int) moddedFileData[1437 + (assetNum * 20) + 8] << 8));
                    assetOffset = (assetOffset | ((int) moddedFileData[1438 + (assetNum * 20) + 8] << 16));
                    assetOffset = (assetOffset | ((int) moddedFileData[1439 + (assetNum * 20) + 8] << 24));

                    assetOffset += difference;

                    moddedFileData[1436 + (assetNum * 20) + 8] = (byte) (assetOffset & 0xFF);
                    moddedFileData[1437 + (assetNum * 20) + 8] = (byte) ((assetOffset & 0xFF00) >> 8);
                    moddedFileData[1438 + (assetNum * 20) + 8] = (byte) ((assetOffset & 0xFF0000) >> 16);
                    moddedFileData[1439 + (assetNum * 20) + 8] = (byte) ((assetOffset & 0xFF000000) >> 24);
                }
            }

            updateLabel.Text += "Modded file prepared\n";

            Stream moddedAssetFile = File.Open(assetPath, FileMode.Create);
            moddedAssetFile.Write(moddedFileData.ToArray(), 0, moddedFileData.Count);
            moddedAssetFile.Close();

            updateLabel.Text += "Modded file finished\n";

            finished = true;
            finishedIndicator.Image = imageList1.Images[1];
            workButton.Text = "Close";
        }
    }
}
