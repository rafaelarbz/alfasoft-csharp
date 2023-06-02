using Alfasoft.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.Pages
{
    public class NewContactModel : PageModel
    {
        private readonly ContactsContext _contactsContext;
        [BindProperty]
        public ContactsEntity ContactsModel { get; set; }
        public NewContactModel(ContactsContext contactsContext)
        {
            _contactsContext = contactsContext;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contactsContext.Contacts.Add(ContactsModel);
            _contactsContext.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
