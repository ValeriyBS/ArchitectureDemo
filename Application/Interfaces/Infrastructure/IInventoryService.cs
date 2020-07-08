namespace Application.Interfaces.Infrastructure
{
    public interface IInventoryService
    {
        void NotifyItemSold(int itemId,int amount);
    }
}