using NewsPagesLib.GlobalConstants;
using System.ComponentModel.DataAnnotations;

namespace NewsPagesLib
{
    public class NewsPageInfo
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = ErrorMessages.NoURL)]
        [StringLength (Sizes.StringsSize, ErrorMessage = )]
        public string URL { get; set; }
    }
}