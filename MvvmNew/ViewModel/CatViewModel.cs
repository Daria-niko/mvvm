using MvvmNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNew.ViewModel
{
        public class CatViewModel : ViewModelBase
        {
            private Cat cat;

            public CatViewModel(Cat c)
            {
                cat = c;
            }

            public string Name
            {
                get => cat.Name;
                set
                {
                    cat.Name = value;
                    Set(ref cat, cat, "Name");
                }
            }

            public string Description
            {
                get => cat.Description;
                set
                {
                    cat.Description = value;
                    Set(ref cat, cat, "Description");
                }
            }

            public DateTime DateOfBirth
            {
                get => cat.DateOfBirth = DateTime.Today;
                set
                {
                    cat.DateOfBirth = value;
                    Set(ref cat, cat, "DateOfBirth");
                }
            }

            public MyImageCat PhotoCat
            {
                get => cat.PhotoCat; set
                {
                    cat.PhotoCat = value;
                    Set(ref cat, cat, "PhotoCat");
                }
            }

        }
    }

