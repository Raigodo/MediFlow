using Journal.Domain.Persons;

namespace Journal.Domain.OrdinatoryRecords;

public sealed class OrdinatoryRecord
{
    private OrdinatoryRecord(
        Guid id,
        Guid targetPersonId,
        string medicineName)
    {
        Id = id;
        TargetPersonId = targetPersonId;
        MedicineName = medicineName;
    }

    public Guid Id { get; init; }
    public string MedicineName { get; private set; }

    public Guid TargetPersonId { get; init; }
    public Person TargetPerson { get; init; }

    public static OrdinatoryRecord Create(Guid targetPersonId, string medicineName)
    {
        var record = new OrdinatoryRecord(
            id: Guid.NewGuid(),
            targetPersonId: targetPersonId,
            medicineName: medicineName);
        return record;
    }
}
