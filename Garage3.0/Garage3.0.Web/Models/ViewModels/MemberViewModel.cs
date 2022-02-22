using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels;

public class MemberViewModel
{
    [Required]
    public int Id { get; set; }
    public string? Name { get; set; }

}
