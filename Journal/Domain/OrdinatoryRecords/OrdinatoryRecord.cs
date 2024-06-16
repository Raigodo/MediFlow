using Journal.Domain.OrdinatoryRecords.Values;
using Journal.Domain.Persons;
using Journal.Domain.Persons.Values;

namespace Journal.Domain.OrdinatoryRecords;

public class OrdinatoryRecord
{
    public OrdinatoryRecordId Id { get; set; }
    public string MedicineName { get; set; } = string.Empty;

    public PersonId TargetPersonId { get; set; }
    public Person TargetPerson { get; set; } = default;
}
