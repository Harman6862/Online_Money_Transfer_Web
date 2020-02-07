using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Money_Transfer_Web.BusinessLayer;
using Online_Money_Transfer_Web.Models;

namespace Online_Money_Transfer_Web.Pages.MoneyReceivers
{
    //Updates the receiver.
    public class EditModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public EditModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MoneyReceiver MoneyReceiver { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoneyReceiver = await _context.MoneyReceiver.FirstOrDefaultAsync(m => m.Id == id);

            if (MoneyReceiver == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MoneyReceiver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyReceiverExists(MoneyReceiver.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MoneyReceiverExists(int id)
        {
            return _context.MoneyReceiver.Any(e => e.Id == id);
        }
    }
}
