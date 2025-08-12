using LiteDB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThisNotesForYou;

namespace ThisNotesForYou;

public static class Endpoints
{


    public static Task<Ok<List<NoteDto>>> GetNotes(int? pagesize, ILiteCollection<Note> col)
    {
        // Use pagesize if given, otherwise default to all (or some default number)
        var size = pagesize ?? int.MaxValue;

        var result = col.Find(Query.All(), 0, size)
                        .Select(n => new NoteDto(n.Title, n.Text))
                        .ToList();
        return Task.FromResult(TypedResults.Ok(result));
    }

    public static IResult CreateNote(CreateNote input, ILiteCollection<Note> col)
    {
        if (input.Title == "") { return Results.BadRequest("Title cannot be empty"); }
        col.Insert(new Note(input.Title, input.Text));
        return Results.Ok();
    }

    public static IResult DeleteNote(Guid id, ILiteCollection<Note> col)
    {
        if (col.FindById(id) != null)
        {
            col.Delete(id);
            return Results.NoContent();
        }
        return Results.NotFound();
    }
}