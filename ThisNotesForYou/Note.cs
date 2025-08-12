namespace ThisNotesForYou;


public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Note() { }

    public Note(int id, string title, string text)
    {
        Id = id;
        Title = title;
        Text = text;
    }
}