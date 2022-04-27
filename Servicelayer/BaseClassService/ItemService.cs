using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class ItemService
    {
        private MVCHContext _context;

        public ItemService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Item> GetItems()
        {
            return _context.Items;
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
    }
}
