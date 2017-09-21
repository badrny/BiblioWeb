namespace BiblioWebApplicationCore.Models
{
    public interface IMedia
    {
        long Key { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        System.DateTime Date { get; set; }
    }
}