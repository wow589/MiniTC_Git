using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    using R = Properties.Resources;
    class Panel
    {
        public Panel()
        {
            SelectedDriveIndex = 0;
            SelectedItemIndex = -1;
        }

        public string Path { get; set; }
        public string[] Drives 
        { 
            get { 
                return Directory.GetLogicalDrives(); 
            } 
        }
        public string[] Directories 
        { 
            get { 
                return Directory.GetDirectories(Path); 
            } 
        }
        public string[] Files 
        { 
            get { 
                return Directory.GetFiles(Path); 
            } 
        }
        public int SelectedDriveIndex 
        { 
            set { 
                Path = Drives[value]; 
            } 
        }

        private int selectedItemIndex;
        public int SelectedItemIndex
        {
            get { 
                return selectedItemIndex; 
            }
            set {
                int tmp;
                if (Path.Length > 3)
                    tmp = 1;
                else
                    tmp = 0;

                if (value > Directories.Length - 1 + tmp)
                {
                    selectedItemIndex = value;
                }
                else if (value > -1 + tmp)
                {
                    try
                    {
                        Directory.GetDirectories(Directories[value - tmp]);
                        Path = Directories[value - tmp];
                        selectedItemIndex = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(R.AccesError, R.ProgramName, MessageBoxButton.OK);
                    }
                }
                else if (value > -1)
                {
                    Path = Directory.GetParent(Path).FullName;
                    selectedItemIndex = -1;
                }
                else
                {
                    selectedItemIndex = value;
                }
            }
        }
        public string[] Items
        {
            get {
                List<string> tmp = new List<string>();
                if (Path.Length > 3)
                {
                    tmp.Add("..");
                }

                string[] DirectoriesList = Directories;
                for (int i = 0; i < DirectoriesList.Length; i++)
                {
                    tmp.Add($"<D>{ DirectoriesList[i].Substring(DirectoriesList[i].LastIndexOf('\\') + 1)}");
                }
                string[] FilesArray = Files;
                for (int i = 0; i < FilesArray.Length; i++)
                {
                    tmp.Add($"{ FilesArray[i].Substring(FilesArray[i].LastIndexOf('\\') + 1)}");
                }

                return tmp.ToArray();
            }
        }
    }
}
