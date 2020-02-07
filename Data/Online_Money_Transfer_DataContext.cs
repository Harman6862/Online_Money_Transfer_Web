using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Money_Transfer_Web.BusinessLayer;

namespace Online_Money_Transfer_Web.Models
{
    //Connects to the database linking the business layer 
    public class Online_Money_Transfer_DataContext : DbContext
    {
        public Online_Money_Transfer_DataContext (DbContextOptions<Online_Money_Transfer_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Money_Transfer_Web.BusinessLayer.MoneySender> MoneySender { get; set; }

        public DbSet<Online_Money_Transfer_Web.BusinessLayer.MoneyReceiver> MoneyReceiver { get; set; }

        public DbSet<Online_Money_Transfer_Web.BusinessLayer.MoneyTransfer> MoneyTransfer { get; set; }

        public DbSet<Online_Money_Transfer_Web.BusinessLayer.Provider> Provider { get; set; }
    }
}
