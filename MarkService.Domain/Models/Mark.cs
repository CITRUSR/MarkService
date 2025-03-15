using MarkService.Domain.Enums;

namespace MarkService.Domain.Models;

public class Mark : BaseModel
{
    public Guid Id { get; set; }
    public int SpecialityTeacherSubjectId { get; set; }
    public Guid UserId { get; set; }
    public MarkTypes MarkTypeId { get; set; }
    public int? MarkValue { get; set; }
    public DateTime ReceiveAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
