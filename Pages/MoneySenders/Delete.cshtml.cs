using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Money_Transfer_Web.BusinessLayer;
using Online_Money_Transfer_Web.Models;

namespace Online_Money_Transfer_Web.Pages.MonerySenders
{
    //Delete the sender from the database 
    public class DeleteModel : PageModel
    {
        private readonly Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext _context;

        public DeleteModel(Online_Money_Transfer_Web.Models.Online_Money_Transfer_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MoneySender MoneySender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoneySender = await _context.MoneySender.FirstOrDefaultAsync(m => m.Id == id);

            if (MoneySender == null)
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

            MoneySender = await _context.MoneySender.FindAsync(id);

            if (MoneySender != null)
            {
                _context.MoneySender.Remove(MoneySender);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
