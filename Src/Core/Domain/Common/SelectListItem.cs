namespace Domain.Common
{
    public class SelectListItem
    {
        public SelectListItem(int _Id, string _ItemName)
        {
            ItemId = _Id;
            ItemName = _ItemName;
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }

    }
}
