using MarkService.Domain.Enums;

namespace MarkService.Domain.Models;

public class Absence : BaseModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public int ClassId { get; set; }
    public AbsenceTypes AbsenceTypeId { get; set; }
    public AbsenceReasons AbsenceReasonId { get; set; }
}
