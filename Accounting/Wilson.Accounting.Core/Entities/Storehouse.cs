﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Wilson.Accounting.Core.Entities
{
    public class Storehouse : Entity
    {
        public string Name { get; private set; }

        public string ProjectId { get; private set; }

        public virtual Project Project { get; private set; }

        public virtual ICollection<StorehouseItem> StorehouseItems { get; set; }

        public static Storehouse Create(string name, Project project)
        {
            return new Storehouse() { Name = name, ProjectId = project.Id };
        }

        public void AddItem(int quantity, InvoiceItem item)
        {
            if (quantity > item.Quantity)
            {
                throw new ArgumentOutOfRangeException("quantity", "Not enough quantity available of the selected item.");
            }

            var storehouseItem = StorehouseItem.Create(quantity, this, item);
            var itemToUpdate = this.StorehouseItems.FirstOrDefault(x => x.Equals(storehouseItem));
            if (itemToUpdate == null)
            {
                this.StorehouseItems.Add(storehouseItem);
            }
            else
            {                
                itemToUpdate.AddQiantity(quantity);
            }
        }
    }
}
