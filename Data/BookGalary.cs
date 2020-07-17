namespace BookStore.Data
{
    public class BookGalary
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Books Book { get; set; }
    }
}