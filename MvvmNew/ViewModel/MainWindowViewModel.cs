using MvvmNew.Commands;
using MvvmNew.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmNew.Commands;
using MvvmNew.Model;
using MvvmNew.View;
using jsonlib;

namespace MvvmNew.ViewModel
{
        public class MainWindowViewModel : ViewModelBase
        {

            public MainWindowViewModel()
            {
                Cats = new ObservableCollection<Cat>();
                Cats = FileManager.Deserialization<Cat>("Cats");
            }

            private bool isSelected;
            public bool IsSelected
            {
                get => isSelected;
                set
                {
                    isSelected = value;
                    Set(ref isSelected, value);
                }
            }
            private ObservableCollection<Cat> cats = new ObservableCollection<Cat>();

            public ObservableCollection<Cat> Cats
            {
                get => cats;
                set
                {
                    cats = value;
                    Set(ref cats, value);
                }
            }

            private RelayCommand addCommand;
            public RelayCommand AddCommand
            {
                get
                {
                    if (addCommand is null)
                    {
                        addCommand = new RelayCommand(obj => AddCat());

                    }
                    return addCommand;
                }
            }

            private void AddCat()
            {
                OneCatPageViewModel.IsCreated = true;
                OneCatPageViewModel.Page = new OneCatPage()
                {
                    DataContext = OneCatPageViewModel
                };
                OneCatPageViewModel.SelectedCat = new Cat();
            }

            private RelayCommand removeCommand;
            public RelayCommand RemoveCommand
            {
                get
                {
                    if (removeCommand is null)
                    {
                        removeCommand = new RelayCommand(obj => DeleteCat());
                    }
                    return removeCommand;
                }
            }
            private RelayCommand selectedCommand;
            public RelayCommand SelectedCommand
            {
                get
                {
                    if (selectedCat is null)
                    {
                        selectedCommand = new RelayCommand(obj => OnSelected());
                    }
                    return selectedCommand;
                }
            }

            private Cat selectedCat;

            public Cat SelectedCat
            {
                get => selectedCat;
                set
                {
                    selectedCat = value;
                    Set(ref selectedCat, value);
                    if (selectedCat != null)
                    {
                        OnSelected();
                    }
                    else
                    {
                        IsSelected = false;
                    }
                }
            }

            private void OnSelected()
            {
                IsSelected = true;
                OneCatPageViewModel.IsCreated = false;
                OneCatPageViewModel.Page = new OneCatPage()
                {
                    DataContext = OneCatPageViewModel
                };
                OneCatPageViewModel.SelectedCat = SelectedCat;

            }

            public void CreateCat(Cat cat)
            {
                Cats.Add(cat);
            }

            public void DeleteCat()
            {
                Cats.Remove(SelectedCat);
                FileManager.Serialize(MainWindowViewModel.Cats, "Cats");
            }


        }
    }

