
using Alfasoft.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfasoft.EntityModels
{
    public class ContactsEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "This field must have minimum of 5 characteres."), Required]
        public string Name { get; set; }

        [Precision(9), ContactUnique, Required, RegularExpression("^[0-9,-]*$")]
        public string Contact { get; set; }

        [EmailUnique, Required]
        public string Email { get; set; }

    }
}
