using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace VitecProjekt.Models
{
    public class User
    {
        private int _UserId;
        public int UserId { get => _UserId; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(20, MinimumLength = 8)]
        [Required]
        public string UserName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30 ,MinimumLength = 8)]
        [Required]
        public SecureString Password { get; set; }

        [EmailAddress]
        [Required]
        public MailAddress Email { get; set; }
    }
}
