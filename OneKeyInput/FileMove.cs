using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace OneKeyInput
{
    class FileMove
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProfileString(string lpszSection, string lpszKeyName, string lpszString);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, // handle to destination window 
        uint Msg, // message 
        int wParam, // first message parameter 
        int lParam // second message parameter 
        );
        [DllImport("gdi32")]
        public static extern int AddFontResource(string lpFileName);
        [DllImport("gdi32")]
        public static extern int RemoveFontResource(string lpFileName);
        public static string ReadAllFontsFile()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            Checkcount = 0;
            Filecount = 0;
            if (result != DialogResult.Cancel)
            {
                return folderBrowser.SelectedPath.Trim();
            }
            return "";
        }
        static int Checkcount = 0;
        public static int CheckDirectories(string FilePath)
        {
            
            FileInfo[] Files = new DirectoryInfo(FilePath).GetFiles();
            Console.WriteLine(FilePath);
            if (Files.Length > 0)
            {
                foreach (FileInfo file in Files)
                {
                    if (file.Extension.ToLower() == ".otf" || file.Extension.ToLower() == ".ttf")
                    {
                        Checkcount++;
                    }
                }
            }
            DirectoryInfo[] directories = new DirectoryInfo(FilePath).GetDirectories();
            if (directories.Length > 0)
            {
                foreach (DirectoryInfo directory in directories)
                {
                    CheckDirectories(directory.FullName);
                }
            }
            return Checkcount;
        }
        static int Filecount = 0;
        public static int MoveFile(string FilePath)
        {
            FileInfo[] Files = new DirectoryInfo(FilePath).GetFiles();
            Console.WriteLine(FilePath);
            if(Files.Length > 0)
            {
                foreach(FileInfo file in Files)
                {
                    if (file.Extension.ToLower() == ".otf" || file.Extension.ToLower() == ".ttf")
                    {
                        if(InstallFont(file) == 1) Filecount++;
                    }
                }
            }
            DirectoryInfo[] directories = new DirectoryInfo(FilePath).GetDirectories();
            if(directories.Length > 0)
            {
                foreach(DirectoryInfo directory in directories)
                {
                    MoveFile(directory.FullName);
                }
            }
            return Filecount;
        }

        private static int InstallFont(FileInfo fontPath)
        {
            PrivateFontCollection fontCol = new PrivateFontCollection();
            fontCol.AddFontFile(fontPath.FullName);
            string fontFileName = fontCol.Families[0].Name;
            string WinFontDir = "C:\\windows\\fonts";
            int Ret = 0;
            int Res;
            string targetPath;
            const int WM_FONTCHANGE = 0x001D;
            const int HWND_BROADCAST = 0xffff;
            targetPath = WinFontDir + "\\" + fontFileName;
            if (!File.Exists(targetPath))
            {
                File.Copy(fontPath.FullName, targetPath);
                Ret = AddFontResource(targetPath);
                Res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0);
                WriteProfileString("fonts", fontPath.Name + "(TrueType)", fontFileName);
                return 1;
            }
            return Ret;
        }

    }
}
