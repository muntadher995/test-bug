namespace BugProject.Dtos.Bugs
{
    public class UpdateBugdto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? SystemName { get; set; }

        public string? UserName { get; set; }

        public string? UserAgaint { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
        public string? ActiveState { get; set; }

        public string? Status { get; set; }
    }
}
