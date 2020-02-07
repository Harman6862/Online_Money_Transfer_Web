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

namespace Online_Money_Transfer_Web.Pages.MoneyTransfers
{
    //Updates the money transfer
    public class EditModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public EditModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MoneyTransfer MoneyTransfer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoneyTransfer = await _context.MoneyTransfer
                .Include(m => m.MoneyReceiver)
                .Include(m => m.MoneySender)
                .Include(m => m.Provider).FirstOrDefaultAsync(m => m.Id == id);

            if (MoneyTransfer == null)
            {
                return NotFound();
            }
           ViewData["MoneyReceiverId"] = new SelectList(_context.MoneyReceiver, "Id", "ReceiverName");
           ViewData["MoneySenderId"] = new SelectList(_context.MoneySender, "Id", "SenderName");
           ViewData["ProviderId"] = new SelectList(_context.Set<Provider>(), "Id", "ProviderName");
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

            _context.Attach(MoneyTransfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyTransferExists(MoneyTransfer.Id))
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

        private bool MoneyTransferExists(int id)
        {
            return _context.MoneyTransfer.Any(e => e.Id == id);
        }
    }
}
