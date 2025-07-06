namespace EyeCareAIProject.Areas.Admin.Models
{
    public class AppUserRoleViewModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public List<string>? Roles { get; set; }
    }
}
