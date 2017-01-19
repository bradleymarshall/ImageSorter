using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ImageSorter
{
    public partial class FormImageSorter : Form
    {
        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex reg = new Regex(":");

        public FormImageSorter()
        {
            InitializeComponent();

            //blank out place-holder text
            labelStatus.Text = "";
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            //query the user for a source path, where we will pull the pictures to be sorted.
            browserDialog.Description = "Please select a source path (with the pictures to be sorted).";
            if (browserDialog.ShowDialog(FormImageSorter.ActiveForm) == DialogResult.OK)
                textSourcePath.Text = browserDialog.SelectedPath;
        }

        private void buttonDest_Click(object sender, EventArgs e)
        {
            //query the user for a destination path, where we will put the sorted pictures.
            browserDialog.Description = "Please select a destination path (where the pictures will go).";
            if (browserDialog.ShowDialog(FormImageSorter.ActiveForm) == DialogResult.OK)
                textDestPath.Text = browserDialog.SelectedPath;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //grab and validate paths
            string sourcePath = textSourcePath.Text;
            string destPath = textDestPath.Text;
            if (!ValidPaths(sourcePath, destPath))
                return;

            //update status
            labelStatus.Text = "Gathering file list...";
            labelStatus.Refresh();

            //grab the paths of all JPG files from the source directory
            string[] filePaths = Directory.GetFiles(sourcePath, "*.jpg", SearchOption.AllDirectories);

            //get the sorted list of files
            Dictionary<string, List<string>> sorted = GetSortedFiles(filePaths, sourcePath);

            //commit the list to a file (this is the test, remember?)
            labelStatus.Text = "Writing sort to file...";
            labelStatus.Refresh();
            using (StreamWriter sw = new StreamWriter(Path.Combine(destPath, "SortedList.txt")))
                foreach (var entry in sorted)
                    sw.WriteLine(string.Format("{0}\r\n   {1}", entry.Key, string.Join("\r\n   ", entry.Value.ToArray())));

            //notify the user that it's complete.
            progressBar.Value = 100;
            labelStatus.Text = "Complete.";
            this.Refresh();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            //grab and validate paths
            string sourcePath = textSourcePath.Text;
            string destPath = textDestPath.Text;
            if (!ValidPaths(sourcePath, destPath))
                return;

            //get the sorted list of files
            Dictionary<string, List<string>> sorted = GetSortedFiles(
                Directory.GetFiles(sourcePath, "*.jpg", SearchOption.AllDirectories), sourcePath);

            //Let's put the sorted list into folders by date
            progressBar.Value = 0;
            labelStatus.Text = "Moving files...";
            this.Refresh();

            //perform the moves
            string fileName, newPath, fullDestPath;
            foreach (KeyValuePair<string, List<string>> imageFolder in sorted)
            {
                //figure and create destination folder for images
                fullDestPath = Path.Combine(destPath, imageFolder.Key);
                if (!Directory.Exists(fullDestPath))
                    Directory.CreateDirectory(fullDestPath);

                //move each image into it
                foreach (string path in imageFolder.Value)
                {
                    //Use static Path methods to extract only the file name from the path.
                    fileName = Path.GetFileName(path);
                    newPath = Path.Combine(fullDestPath, fileName);

                    if (File.Exists(newPath))
                    {
                        string fDir = Path.GetDirectoryName(newPath);
                        string fName = Path.GetFileNameWithoutExtension(newPath);
                        string fExt = Path.GetExtension(newPath);

                        int suffix = 1;
                        do
                        {
                            newPath = Path.Combine(fDir, String.Concat(fName, "-dupe" + (suffix++), fExt));
                        } while (File.Exists(newPath));
                    }
                    File.Move(path, newPath);
                }
            }

            //notify the user that it's complete.
            progressBar.Value = 100;
            labelStatus.Text = "Complete.";
            this.Refresh();
        }

        private void buttonSortVids_Click(object sender, EventArgs e)
        {
            //grab and validate paths
            string sourcePath = textSourcePath.Text;
            string destPath = textDestPath.Text;
            if (!ValidPaths(sourcePath, destPath))
                return;

            //get the sorted list of files
            Dictionary<string, List<string>> sorted = GetSortedFiles(
                Directory.GetFiles(sourcePath, "*.mp4", SearchOption.AllDirectories), sourcePath, true);

            //Let's put the sorted list into folders by date
            progressBar.Value = 0;
            labelStatus.Text = "Moving files...";
            this.Refresh();

            //perform the moves
            string fileName, newPath, fullDestPath;
            foreach (KeyValuePair<string, List<string>> imageFolder in sorted)
            {
                //figure and create destination folder for images
                fullDestPath = Path.Combine(destPath, imageFolder.Key);
                if (!Directory.Exists(fullDestPath))
                    Directory.CreateDirectory(fullDestPath);

                //move each image into it
                foreach (string path in imageFolder.Value)
                {
                    //Use static Path methods to extract only the file name from the path.
                    fileName = Path.GetFileName(path);
                    newPath = Path.Combine(fullDestPath, fileName);

                    if (File.Exists(newPath))
                    {
                        string fDir = Path.GetDirectoryName(newPath);
                        string fName = Path.GetFileNameWithoutExtension(newPath);
                        string fExt = Path.GetExtension(newPath);

                        int suffix = 1;
                        do
                        {
                            newPath = Path.Combine(fDir, String.Concat(fName, "-dupe" + (suffix++), fExt));
                        } while (File.Exists(newPath));
                    }
                    File.Move(path, newPath);
                }
            }

            //notify the user that it's complete.
            progressBar.Value = 100;
            labelStatus.Text = "Complete.";
            this.Refresh();
        }

        private bool ValidPaths(string source, string dest)
        {
            //just make sure both diretories are entered and exist
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(dest) ||
                !Directory.Exists(source) || !Directory.Exists(dest))
            {
                MessageBox.Show("Please enter valid source and destination paths.");
                return false;
            }
            else
                return true;
        }

        private Dictionary<string, List<string>> GetSortedFiles(string[] paths, string source, bool getVids = false)
        {
            progressBar.Value = 0;
            progressBar.Visible = true;

            labelStatus.Text = "Arranging files...";
            labelStatus.Refresh();

            //the string representing the Date Taken for the image, and the sorted Dictionary
            string fileDate;
            Dictionary<string, List<string>> sortedDict = new Dictionary<string, List<string>>();

            int fileCount = paths.Length;
            for (int i = 0; i < fileCount; i++)
            {
                //update progress
                int progress = (int)Math.Round((double)i / (double)fileCount * 100);
                if (progressBar.Value != progress)
                {
                    //only refresh the whole screen when we are modifying the progress bar value.
                    //this allows the image sorting process to have more processor priority.
                    progressBar.Value = progress;
                    this.Refresh();
                }

                if (getVids)
                    fileDate = GetDateModified(paths[i]).ToString("yyyy-MM-dd"); //get last modified date for video
                else
                    fileDate = GetDateTakenFromImage(paths[i]).ToString("yyyy-MM-dd"); //get date this image was taken

                //add to list if it's not there
                if (!sortedDict.ContainsKey(fileDate))
                {
                    //add this date and create an empty list for the image path(s) that will go in this folder
                    sortedDict.Add(fileDate, new List<string>());
                }

                //add this image path!
                sortedDict[fileDate].Add(paths[i]);
            }

            return sortedDict;
        }

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image myImage = Image.FromStream(fs, false, false))
            {
                try
                {
                    //sometimes this property isn't there - like when it's not from a camera
                    PropertyItem propItem = myImage.GetPropertyItem(36867); //Date Taken
                    string dateTaken = reg.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                    return DateTime.Parse(dateTaken);
                }
                catch (Exception)
                {
                    return DateTime.MinValue; //return the min value (translates to string 0001-01-01)
                }
            }
        }

        //retrieves the last modiefied date WITHOUT loading the whole image
        public static DateTime GetDateModified(string path)
        {
            try
            {
                FileInfo file1 = new FileInfo(path);
                if (file1.LastWriteTime != null)
                    return file1.LastWriteTime;
                else
                    return DateTime.MinValue; //return the min value (translates to string 0001-01-01)
            }
            catch (Exception)
            {
                return DateTime.MinValue; //return the min value (translates to string 0001-01-01)
            }
        }
    }
}
