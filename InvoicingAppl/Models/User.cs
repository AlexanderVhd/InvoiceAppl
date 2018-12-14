using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoicingAppl.Models
{
    /// <summary>
    /// the enum user role (a user can either be a normal user or manager)
    /// </summary>
    public enum UserRole
    {
        User,
        Manager
    }

    public class User
    {
        //the credentials and the user role attributes of the user 
        [Required(ErrorMessage = "Please Enter a username.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter a password.")]
        public string Password { get; set; }
        public UserRole Role { get; set; }

        /// <summary>
        /// Checks if password is valid for user
        /// </summary>
        public bool Check()
        {
            return true;
        }
    }
}