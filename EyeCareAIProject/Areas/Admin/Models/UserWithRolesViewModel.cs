namespace EyeCareAIProject.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
