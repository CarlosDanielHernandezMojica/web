using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryNoteRepository: INoteRespository
{
    private readonly List<Note> _notes;

    public InMemoryNoteRepository()
    {
        _notes = new List<Note>();
    }

    public async Task<Note> SaveAsync(Note note)
    {
        note.Id = _notes.Count + 1;
        _notes.Add(note);

        return note;
    }

    public async Task<Note> UpdateAsync(Note note)
    {
        var index = _notes.FindIndex(x => x.Id == note.Id);

        if (index != -1)
        {
            _notes[index] = note;
        }

        return await Task.FromResult(note);
    }

    public async Task<List<Note>> GetAllAsync()
    {
        return _notes;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _notes.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Note> GetById(int id)
    {
        var note = _notes.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(note);
    }
}