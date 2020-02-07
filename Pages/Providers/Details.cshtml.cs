using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Money_Transfer_Web.BusinessLayer;
using Online_Money_Transfer_Web.Models;

namespace Online_Money_Transfer_Web.Pages.Providers
{
    //Gets the details of the Provider
    public class DetailsModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public DetailsModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

        public Provider Provider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Provider = await _context.Provider.FirstOrDefaultAsync(m => m.Id == id);

            if (Provider == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
