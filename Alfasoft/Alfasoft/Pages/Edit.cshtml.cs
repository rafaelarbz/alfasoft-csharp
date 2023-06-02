using Alfasoft.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.Pages
{
    public class EditModel : PageModel
    {
        private readonly ContactsContext _contactsContext;
        [BindProperty]
        public ContactsEntity ContactsModel { get; set; }
        public EditModel(ContactsContext contactsContext)
        {
            _contactsContext = contactsContext;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            ContactsModel = _contactsContext.Contacts.Find(id.Value);

            if (ContactsModel == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var contact = await _contactsContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactsContext.Contacts.Update(contact);
            await _contactsContext.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
