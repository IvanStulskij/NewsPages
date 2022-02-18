using NewsPagesLib.GlobalConstants;
using System.ComponentModel.DataAnnotations;

namespace NewsPagesLib
{
    public class NewsPageInfo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(Sizes.StringsSize, ErrorMessage = ErrorMessages.BigLengthError)]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoURL)]
        [StringLength(Sizes.StringsSize, ErrorMessage = ErrorMessages.BigLengthError)]
        public string URL { get; set; }

        public DateOnly Date { get; set; }

        public string TextHTML { get; set; }

        public string Text { get; set; }
    }
}