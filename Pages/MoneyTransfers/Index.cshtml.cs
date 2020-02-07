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
    //Gets all money transfers
    public class IndexModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public IndexModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

        public IList<MoneyTransfer> MoneyTransfer { get;set; }

        public async Task OnGetAsync()
        {
            MoneyTransfer = await _context.MoneyTransfer
                .Include(m => m.MoneyReceiver)
                .Include(m => m.MoneySender)
                .Include(m => m.Provider).ToListAsync();
        }
    }
}
