using Alfasoft.EntityModels;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Alfasoft.Validations
{
    public class ContactUnique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ContactsContext)validationContext.GetService(typeof(ContactsContext));

            var objectId = validationContext.ObjectType.GetProperty("Id").GetValue(validationContext.ObjectInstance);

            var query = context.Contacts.Where(a => a.Contact == value.ToString());

            if (objectId != null && Convert.ToString(objectId) != "0")
            {
               query = context.Contacts.Where(a => a.Contact == value.ToString()).Where(a => a.Id != (int)objectId);
            }

            if (query.Count() <= 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Contact number already exists");
        }
    }
}
