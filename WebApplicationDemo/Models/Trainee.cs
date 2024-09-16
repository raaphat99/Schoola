using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationDemo.CustomValidators;

namespace WebApplicationDemo.Models
{
    public class Trainee
    {
        [Key]
        public int ID { get; set; }


        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long!"), MaxLength(25)]
        public string Name { get; set; }


        // This pattern ensures that:
        //   The email starts with one or more alphanumeric characters or underscores(_).
        //   This is followed by an @ symbol.
        //   After the @, there are one or more alphanumeric characters or underscores(_).
        //   Finally, there is a dot(.) followed by at least two alphabetic characters.
        [Remote("UserEmailIsUnique", "Trainee", ErrorMessage = "This email is already existed!")]
        [RegularExpression(@"^[a-zA-Z0-9_]+@[a-zA-Z0-9_]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please Enter a valid Email! I.E.[JohnDoe@gmail.com]")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        // This pattern allows at least 6 characters of upper or lower case characters, numbers, or symbols.
        [RegularExpression(@"^[a-zA-Z0-9!@#$%^&*()_+]{6,}$", ErrorMessage = "Please Enter a valid Password!")]
        [MinLength(6), MaxLength(32)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Password & Confirmation Password must be the same!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password), NotMapped]
        public string PasswordConfirm { get; set; }


        [Display(Name = "Profile Picture")]
        public string? ImageUrl { get; set; }


        [Required(ErrorMessage = "Address Field is Required!")]
        public string Address { get; set; }


        [Range(0, 5, ErrorMessage = "College Level must be between 0 and 5 !")]
        public int Level { get; set; }

        [GPAValidation]
        public double? GPA { get; set; }

        [Required]
        [Display(Name = "Department")]
        [ForeignKey("Department")]
        public int? DeptID { get; set; }

        public virtual Department? Department { get; set; }

        public ICollection<TraineeCourse>? TraineeCourses { get; set; }
    }


}
