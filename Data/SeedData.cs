using DecisionCloud.Areas.Identity.Data;
using DecisionCloud.Model;

namespace DecisionCloud.Data;

public static class SeedData
{
    public static void Initialize(ApplicationDbContext db)
    {
        var b = new BrandModel[]
        {
            new BrandModel()
            {
                BrandId = Guid.NewGuid(),
                BrandLink = "https://www.google.com",
                BrandName = "Google",
                BrandImage = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png",
                Channel_Alpha = "https://www.google.com",
                Channel_Beta = "https://www.google.com",
                Channel_Gamma = "https://www.google.com",
                Status = "Active",
                Cnt_Max = 100,
                Cnt_Reg = 0,
            },
        };
        db.Brands.AddRange(b);
        db.SaveChanges();
    }
}
