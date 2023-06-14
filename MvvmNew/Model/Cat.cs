using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNew.Model
{
    public class Cat
    {
        private string name;
        private string description;
        private DateTime dateOfBirth;
        private MyImageCat photoCat;


        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth; set => dateOfBirth = value;
        }

        public MyImageCat PhotoCat
        {
            get => photoCat;
            set => photoCat = value;
        }

        public Cat(string name = null, string description = null, DateTime dateOfBirth = default, MyImageCat photoCat = null)
        {
            Name = name;
            Description = description;
            DateOfBirth = dateOfBirth;
            PhotoCat = photoCat;
        }
    }
}
