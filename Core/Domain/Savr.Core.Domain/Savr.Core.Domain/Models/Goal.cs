using System.ComponentModel.DataAnnotations;

namespace Savr.Core.Domain.Models
{
    public class Goal : ModelBase
    {
        public Guid GoalId { get; set; }
        public required string Name { get; set; }
        public required decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDeleted { get; set; }
    }
}
