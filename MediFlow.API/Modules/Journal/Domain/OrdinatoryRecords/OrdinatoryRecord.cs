using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords.Values;
using MediFlow.API.Modules.Journal.Domain.Persons;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;

namespace MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;

public class OrdinatoryRecord
{
    public OrdinatoryRecordId Id { get; set; }
    public string MedicineName { get; set; } = string.Empty;

    public PersonId TargetPersonId { get; set; }
    public Person TargetPerson { get; set; } = default;
}
