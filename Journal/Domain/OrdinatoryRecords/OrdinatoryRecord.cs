using Journal.Domain.Persons;

namespace Journal.Domain.OrdinatoryRecords;

public class OrdinatoryRecord
{
    public Guid Id { get; set; }
    public string MedicineName { get; set; }

    public Guid TargetPersonId { get; set; }
    public Person TargetPerson { get; set; }
}
