using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Vdmt_Lap8.Models
{
    public class VdmtAccount
    {
        [Key]
        public int VdmtId { get; set; }
        [
             Required(ErrorMessage = "Full name is required."),
             StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters."),
             RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full name can only contain letters and spaces."),
             Display(Name = "Full Name"),
        ]
        public string VdmtFullName { get; set; }
        [
             Required(ErrorMessage = "Email is required."),
             EmailAddress(ErrorMessage = "Invalid email format."),
             StringLength(100, ErrorMessage = "Email cannot exceed 100 characters."),
             Display(Name = "Email Address"),
        ]
        public string VdmtEmail { get; set; }
        [
             Required(ErrorMessage = "Phone number is required."),
             DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone number format."),
             StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters."),
             Remote(action:"VerifyPhone", controller:"VdmtAccount", ErrorMessage = "Phone number already exists."),
             Display(Name = "Phone Number"),
        ]
        public string VdmtPhone { get; set; }
        [
             Required(ErrorMessage = "Address is required."),
             StringLength(200, ErrorMessage = "Address cannot exceed 200 characters."),
             Display(Name = "Address"),
        ]
        public string VdmtAddress { get; set; }
        [
             Required(ErrorMessage = "Avatar URL is required."),
             StringLength(500, ErrorMessage = "Avatar URL cannot exceed 500 characters."),
             Display(Name = "Avatar URL"),
        ]
        public string VdmtAvatar { get; set; }
        [
             Required(ErrorMessage = "Birthday is required."),
             DataType(DataType.Date, ErrorMessage = "Invalid date format."),
             Display(Name = "Birthday"),
        ]
        public DateTime VdmtBirthday { get; set; }

        [   
             Display(Name = "Gender")
        ]
        public string VdmtGender { get; set; }
        [
             Required(ErrorMessage = "Password is required."),
             StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6),
             DataType(DataType.Password, ErrorMessage = "Invalid password format."),
             Display(Name = "Password"),
        ]
        public string VdmtPassword { get; set; }
        [
             Required(ErrorMessage = "Link is required."),
             Url(ErrorMessage = "Invalid URL format."),
             StringLength(500, ErrorMessage = "Link cannot exceed 500 characters."),
             Display(Name = "Facebook Link"),
        ]
        public string VdmtFacebook { get; set; }
    }
}
