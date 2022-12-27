using Microsoft.AspNetCore.Identity;

namespace DecisionCloud.Areas.Identity.Data;

public class DecisionCloudUser : IdentityUser
{
    [PersonalData]
    public string ? Name { get; set; }
}