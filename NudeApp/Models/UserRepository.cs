using NudeApp.Models;
using System;
using System.Collections.Generic;

namespace NudeApp.Models
{
    public class UserRepository
    {
        private List<HighValueItem> items = new List<HighValueItem>();

        public UserRepository()
        {
            Add(new HighValueItem { Id = new Guid(), Name = "first1", Value = "last1", Category = "email1@gmail.com" });
            Add(new HighValueItem { Id = new Guid(), Name = "first2", Value = "last2", Category = "email2@gmail.com" });
            Add(new HighValueItem { Id = new Guid(), Name = "first3", Value = "last3", Category = "email3@gmail.com" });
        }

        public IEnumerable<HighValueItem> GetAll()
        {
            return items;
        }

        public HighValueItem Add(HighValueItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = new Guid();
            items.Add(item);
            return item;
        }
    }
}