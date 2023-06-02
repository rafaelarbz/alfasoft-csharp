using Alfasoft.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace Alfasoft.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ContactsContext _contactsContext;
        [BindProperty]
        public ContactsEntity ContactsModel { get; set; }
        public DetailsModel(ContactsContext contactsContext)
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
        [ValidateInput(false)]
        public async Task<IActionResult> OnGetDelete(int? id)
        {
            var contact = await _contactsContext.Contacts.FindAsync(id.Value);

            if (contact != null)
            {
                _contactsContext.Contacts.Remove(contact);
                _contactsContext.Entry(contact).State = EntityState.Deleted;
                await _contactsContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}
