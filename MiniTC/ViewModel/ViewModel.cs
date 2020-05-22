using MiniTC.Model;
using MiniTC.ViewModel.BaseClass;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiniTC.ViewModel
{
    using R = Properties.Resources;
    class ViewModel : ViewModelBase
    {
        private Model.Model mainModel = new Model.Model();

        public string PathContent 
        { 
            get { 
                return R.PathContent; 
            } 
        }
        public string DriveContent 
        { 
            get { 
                return R.DriveContent; 
            } 
        }
        public string CopyButtonContent 
        { 
            get { 
                return R.CopyButtonContent; 
            } 
        }
        public string PanelLPath
        {
            get { 
                return mainModel.PanelL.Path; 
            }
        }
        public string[] PanelLDrives
        {
            get { 
                return mainModel.PanelL.Drives; 
            }
        }
        public ObservableCollection<string> PanelLItems
        {
            get { 
                return new ObservableCollection<string>(mainModel.PanelL.Items); 
            }
        }
        public int PanelLSelectedDriveIndex
        {
            set {
                mainModel.PanelL.SelectedDriveIndex = value;
                OnPropertyChanged(nameof(PanelLPath));
                OnPropertyChanged(nameof(PanelLItems));
            }
        }
        public int panelLSelectedItemIndex = -1;
        public int PanelLSelectedItemIndex
        {
            get { 
                return panelLSelectedItemIndex; 
            }
            set {
                panelLSelectedItemIndex = value; 
            }
        }
        public string PanelRPath
        {
            get { 
                return mainModel.PanelR.Path; 
            }
        }
        public string[] PanelRDrives
        {
            get { 
                return mainModel.PanelR.Drives; 
            }
        }
        public ObservableCollection<string> PanelRItems
        {
            get { 
                return new ObservableCollection<string>(mainModel.PanelR.Items); 
            }
        }
        public int PanelRSelectedDriveIndex
        {
            set {
                mainModel.PanelR.SelectedDriveIndex = value;
                OnPropertyChanged(nameof(PanelRPath));
                OnPropertyChanged(nameof(PanelRItems));
            }
        }
        public int panelRSelectedItemIndex = -1;
        public int PanelRSelectedItemIndex
        {
            set {
                panelRSelectedItemIndex = value;
            }
            get {
                return panelLSelectedItemIndex;
            }
        }
        private ICommand panelLSelectItem = null;
        public ICommand PanelLSelectItem
        {
            get {
                if (panelLSelectItem == null)
                {
                    panelLSelectItem = new RelayCommand(PanelLSelectItemExecute, PanelLSelectItemCanExecute);
                }
                return panelLSelectItem;
            }
        }
        private void PanelLSelectItemExecute(object arg)
        {
            mainModel.PanelL.SelectedItemIndex = PanelLSelectedItemIndex;
            OnPropertyChanged(nameof(PanelLPath));
            OnPropertyChanged(nameof(PanelLItems));
        }
        private bool PanelLSelectItemCanExecute(object arg)
        {
            return true;
        }
        private ICommand panelRSelectItem = null;
        public ICommand PanelRSelectItem
        {
            get {
                if (panelRSelectItem == null)
                {
                    panelRSelectItem = new RelayCommand(PanelRSelectItemExecute, PanelRSelectItemCanExecute);
                }

                return panelRSelectItem;
            }
        }
        private void PanelRSelectItemExecute(object arg)
        {
            mainModel.PanelR.SelectedItemIndex = panelRSelectedItemIndex;
            OnPropertyChanged(nameof(PanelRPath));
            OnPropertyChanged(nameof(PanelRItems));
        }
        private bool PanelRSelectItemCanExecute(object arg)
        {
            return true;
        }
        private ICommand copy = null;
        public ICommand Copy
        {
            get {
                if (copy == null)
                    copy = new RelayCommand(CopyExecute, CopyCanExecute);
                return copy;
            }
        }
        private void CopyExecute(object arg)
        {
            try
            {
                int tmp;
                if (mainModel.PanelL.Path.Length > 3)
                    tmp = 1;
                else
                    tmp = 0;
                string source = mainModel.PanelL.Files[mainModel.PanelL.SelectedItemIndex - mainModel.PanelL.Directories.Length - tmp];
                string destination = $"{mainModel.PanelR.Path}{source.Substring(source.LastIndexOf('\\'))}";
                File.Copy(source, destination);
            }
            catch (Exception)
            {
                MessageBox.Show(R.CopyingError, R.ProgramName, MessageBoxButtons.OK);
            }
            OnPropertyChanged(nameof(PanelRItems));
        }
        private bool CopyCanExecute(object arg)
        {
            if (mainModel.PanelL.SelectedItemIndex > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
