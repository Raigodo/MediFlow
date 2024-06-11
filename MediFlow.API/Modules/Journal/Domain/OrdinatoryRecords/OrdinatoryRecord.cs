using MediFlow.API.Modules.Journal.Domain.Persons;

namespace MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;

public class OrdinatoryRecord
{
    public string Id { get; set; }
    public string MedicineName { get; set; }

    public string TargetPersonId { get; set; }
    public Person TargetPerson { get; set; }
}
