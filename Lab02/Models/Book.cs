using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Book()
        {

        }

        public Book(int id, string title, string author, string image_cover)
        {
            this.ID = id;
            this.Title = title;
            this.Author = author;
            this.Image_Cover = image_cover;
        }

        [Required(ErrorMessage = "Tieu de khong duoc trong")]
        [StringLength(250, ErrorMessage = "Tieu de khong vuot qua 250 ky tu")]
        [Display(Name = "Tieu de")]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Image_Cover
        {
            get
            {
                return image_cover;
            }

            set
            {
                image_cover = value;
            }
        }

    }
}

