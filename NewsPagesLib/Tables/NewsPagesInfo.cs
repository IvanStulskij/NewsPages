using NewsPagesLib.GlobalConstants;
using Pullenti;
using Pullenti.Ner;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NewsPagesLib.Tables
{
    public class NewsPagesInfo : ITableRecord
    {
        [Key]
        public int Id { get; set; }

        [StringLength(Sizes.StringsSize, ErrorMessage = ErrorMessages.BigLengthError)]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoURL)]
        [StringLength(Sizes.StringsSize, ErrorMessage = ErrorMessages.BigLengthError)]
        public string URL { get; set; }

        public DateOnly Date { get; set; }

        public string Text_html { get; set; }

        public string Text { get; set; }

        public void TryMakeOperation(Action action)
        {
            if (this != null)
            {
                action.Invoke();
            }
        }

        public IEnumerable<Referent> GetEntities()
        {
            Sdk.InitializeAll();

            using (Processor processor = ProcessorService.CreateProcessor())
            {
                AnalysisResult analysisResult = processor.Process(new SourceOfAnalysis(Text));
                return analysisResult.Entities;
            }
        }

        /// <summary>
        /// Finds by word or word parts
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<string> FindByWord(string value)
        {
            var regex = new Regex($@"(\w*){value}(\w*)");

            return regex.Matches(Text.ToLower())
                .Select(match => match.Value);
        }
    }
}