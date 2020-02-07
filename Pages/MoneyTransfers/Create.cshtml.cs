using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Money_Transfer_Web.BusinessLayer;
using Online_Money_Transfer_Web.Models;

namespace Online_Money_Transfer_Web.Pages.MoneyTransfers
{
    //Creates the Money Transfer 
    public class CreateModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public CreateModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MoneyReceiverId"] = new SelectList(_context.MoneyReceiver, "Id", "ReceiverName");
        ViewData["MoneySenderId"] = new SelectList(_context.MoneySender, "Id", "SenderName");
        ViewData["ProviderId"] = new SelectList(_context.Set<Provider>(), "Id", "ProviderName");
            return Page();
        }

        [BindProperty]
        public MoneyTransfer MoneyTransfer { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MoneyTransfer.Add(MoneyTransfer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
