using MvvmNew.Commands;
using MvvmNew.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MvvmNew.View;
using jsonlib;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MvvmNew.ViewModel
{
    public class OneCatPageViewModel : ViewModelBase
    {

        private BitmapImage bitmap = new BitmapImage();

        public BitmapImage Bitmap
        {
            get
            {
                if (SelectedCat == null) return bitmap;
                if (SelectedCat.PhotoCat == null) return bitmap;
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(SelectedCat.PhotoCat.Data);
                bitmap.EndInit();
                return bitmap;
            }
            set
            {
                bitmap = value;
                Set(ref bitmap, value);
            }
        }


        private OneCatPage page = new OneCatPage();

        public OneCatPage Page
        {
            get => page;
            set => Set(ref page, value);
        }


        public OneCatPageViewModel()
        {
            Page.DataContext = this;
        }


        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand is null)
                {
                    saveCommand = new RelayCommand(obj => Save());
                }

                return saveCommand;
            }
        }

        private void Save()
        {
            if (isCreated)
            {
                MainWindowViewModel.CreateCat(SelectedCat);
                FileManager.Serialize(MainWindowViewModel.Cats, "Cats");
            }
            else
            {
                MainWindowViewModel.SelectedCat = SelectedCat;
                FileManager.Serialize(MainWindowViewModel.Cats, "Cats");
            }
        }

        private RelayCommand addPhotoCommand;

        public RelayCommand AddPhotoCommand
        {
            get
            {
                if (addPhotoCommand is null)
                {
                    addPhotoCommand = new RelayCommand(obj => AddPhoto());
                }
                return addPhotoCommand;
            }
        }

        private void AddPhoto()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.Title = "Выберите фото";
            dialog.Filters.Add((new CommonFileDialogFilter("Изображения", "*.jpg;*.jpeg;*.png;*.bmp;*.gif")));
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string filePath = dialog.FileName;
                string filename = dialog.DefaultFileName;
                byte[] data = File.ReadAllBytes(filePath);
                Cat.PhotoCat = new MyImageCat(filePath, filename, data);
            }
        }

        private bool isCreated;

        public bool IsCreated
        {
            get => isCreated;
            set
            {
                isCreated = value;
                if (isCreated) Bitmap = new BitmapImage();
                Set(ref isCreated, value);
            }
        }

        private CatViewModel cat;

        public CatViewModel Cat
        {
            get => cat;
            set
            {
                cat = value;
                Set(ref cat, cat);
            }
        }

        private Cat selectedCat;

        public Cat SelectedCat
        {
            get => selectedCat;
            set
            {
                selectedCat = value;
                Cat = new CatViewModel(selectedCat);
                Set(ref selectedCat, selectedCat);
            }
        }
    }
}

