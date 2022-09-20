namespace eShopBE.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string CommnentText { get; set; }

        public DateTime CommnetTime { get; set; }

        public int Like { get; set; }
        public int UnLike { get; set; }

    }
}
