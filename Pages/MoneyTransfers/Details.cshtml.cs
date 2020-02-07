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
    //Gets the details of the money transfer
    public class DetailsModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public DetailsModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

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
    }
}
