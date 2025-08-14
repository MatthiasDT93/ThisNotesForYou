namespace ThisNotesForYou;


public class Note
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Note() { }

    public Note(string title, string text)
    {
        Id = Guid.NewGuid();
        Title = title;
        Text = text;
    }
}


public record NoteDto(Guid Id, string Title, string Text, DateTime CreatedAt);

public record CreateNote(string Title, string Text);