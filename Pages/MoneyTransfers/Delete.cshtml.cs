using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Money_Transfer_Web.BusinessLayer;
using Online_Money_Transfer_Web.Models;

namespace Online_Money_Transfer_Web.Pages.MoneyTransfers
{
    //Deletss the money transfer
    public class DeleteModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public DeleteModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoneyTransfer = await _context.MoneyTransfer.FindAsync(id);

            if (MoneyTransfer != null)
            {
                _context.MoneyTransfer.Remove(MoneyTransfer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
