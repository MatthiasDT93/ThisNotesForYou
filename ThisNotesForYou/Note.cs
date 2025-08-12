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


public class NoteDto
{
    public string Title { get; set; }
    public string Text { get; set; }

    public NoteDto() { }

    public NoteDto(string title, string text)
    {
        Title = title;
        Text = text;
    }
}

public record CreateNote(string Title, string Text);