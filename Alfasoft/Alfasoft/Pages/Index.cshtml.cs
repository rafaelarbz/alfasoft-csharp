using Alfasoft.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Alfasoft.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ContactsContext _contactsContext;
        public List<ContactsEntity> Contacts { get; private set; }
        [TempData]
        public string Message {  get; set; }

        public IndexModel(ContactsContext contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public void OnGet()
        {
            if (_contactsContext.Contacts.Any())
            {
                Contacts = _contactsContext.Contacts.ToList();
            }
        }
        public async Task<IActionResult> OnPostDelete(int? id)
        {
            var contact = await _contactsContext.Contacts.FindAsync(id.Value);

            if (contact != null)
            {
                _contactsContext.Contacts.Remove(contact);
                _contactsContext.Entry(contact).State = EntityState.Deleted;
                await _contactsContext.SaveChangesAsync();
                Message = "Contact deleted!";
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}