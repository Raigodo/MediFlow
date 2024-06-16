namespace Journal.Domain.Notes.Contracts;

public interface INoteRepository
{
    Task AddAsync(Note note);
    Task DeleteAsync(Note note);
    Task<Note> GetAsync(string noteId);
    Task<IEnumerable<Note>> GetForPersonAsync(string personId);
}
