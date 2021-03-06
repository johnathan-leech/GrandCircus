﻿using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApplication.Models
{
    public class UserInfo
    {
        [Required] // attributes 
        [RegularExpression(@"^[a-zA-Z]{2,}$")]
        public string FirstName { set; get; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$")]
        public string LastName { set; get; }

        [Required]
        [RegularExpression(@"^[A-z0-9]{4,}@[A-z0-9]{2,}\.[A-z0-9]{1,}$")]
        public string Email { set; get; }

        [Required]
        [RegularExpression(@"^(\+?1?[0-9]{10})$|([0-9]{3}[- ][0-9]{3}[- ][0-9]{4})$|(\(\d{3}\)\d{3}[- ]\d{4})$")]
        public string Phone { set; get; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]\w{3,14}$")]
        //TODO: change the regex to match password stuffs
        public string Password { set; get; }

        public UserInfo()
        {
            FirstName = ""; LastName = ""; Email = ""; Phone = ""; Password = "";
        }

        public UserInfo(string firstN, string lastN, string email, string phone, string password)
        {
            FirstName = firstN;
            LastName = lastN;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}