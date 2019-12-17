using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Section2.Models
{
   
    /// <summary>
    /// Genre model - corresponds to Genres table in database
    /// </summary>
    public class Genre
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public string Description { get; set; }

    }

    /// <summary>
    /// Author model - corresponds to Authors table in database
    /// </summary>
    public class Author
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(35,MinimumLength =1,ErrorMessage ="First name must be 1-35 characters")]
        [Display(Name ="First\nName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength =1)]
        [Display(Name ="Last\nName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        [RegularExpression("[A-Z][A-Z]")]
        public string Province { get; set; }

        [Required]
        [Display(Name ="Postal\nCode")]
        public string PostalCode { get; set; }

        public string Notes { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }


        public string FullAddress
        {
            get
            {
                return String.Format("{0} {1}, {2} {3}", Address, City, Province, PostalCode);
            }
        }

        //navigation properties - make all nav. props virtual
        //use Icollection when you see a * on class diagram
        public virtual ICollection<Book> Book { get; set; }

    }

    public class Book
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }


        //fk name must match nav. prop. name
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Date\nPublished")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime DatePublished { get; set; }


        public string Notes { get; set; }

        public int PageCounter { get; set; }
        public int ChapterCount { get; set; }


        //navigation property
        //make virtual to be able to use dot notation to
        //navigate through related tables
        //and for populating drop downs 
        //code this way when you see a 1 on the nav. line
        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }
    }





}