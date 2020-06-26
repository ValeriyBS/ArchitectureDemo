using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Persistence;

namespace Application.ShoppingCartItems.Commands.ClearShoppingCart
{
    public class ClearShoppingCartCommand
    {
        public ClearShoppingCartCommand(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            
        }

        public void Execute(string cartId)
        {

        }
    }
}
