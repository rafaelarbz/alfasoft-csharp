using Alfasoft.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace Alfasoft.Validations
{
    public class EmailUnique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ContactsContext)validationContext.GetService(typeof(ContactsContext));

            var objectId = validationContext.ObjectType.GetProperty("Id").GetValue(validationContext.ObjectInstance);

            var query = context.Contacts.Where(a => a.Email == value.ToString());

            if (objectId != null && Convert.ToString(objectId) != "0")
            {
                query = context.Contacts.Where(a => a.Email == value.ToString()).Where(a => a.Id != (int)objectId);
            }

            if (query.Count() <= 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email already exists");
        }
    }
}
