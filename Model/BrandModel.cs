using System.ComponentModel.DataAnnotations;

namespace DecisionCloud.Model
{
    public class BrandModel 
    {
        [Key]
        public Guid BrandId { get; set; }
        public string? BrandLink { get; set; }
        public string? BrandName { get; set; }
        public string? BrandImage { get; set; }
        public string? Channel_Alpha { get; set; }
        public string? Channel_Beta { get; set; }
        public string? Channel_Gamma { get; set; }
        public string? Status { get; set; }
        public int Cnt_Max { get; set; }
        public int Cnt_Reg { get; set; }
    }
}