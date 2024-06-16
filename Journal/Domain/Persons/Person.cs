using Journal.Domain.Notes;
using Journal.Domain.OrdinatoryRecords;

namespace Journal.Domain.Persons;

public class Person
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } = string.Empty;

    public IEnumerable<Note> Notes { get; set; } = [];
    public IEnumerable<OrdinatoryRecord> OrdinatoryRecords { get; set; } = [];
}
