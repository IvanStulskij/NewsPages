using Microsoft.AspNetCore.Mvc;
using NewsPagesLib.Bases;
using NewsPagesLib.Tables;
using NewsPagesServerLib;
using NewsPagesServerLib.Bases;

namespace NewsPagesClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsPagesController : ControllerBase
    {
        private readonly ILogger<NewsPagesController> _logger;
        private readonly NewsPagesBase _newsPagesBase;
        private readonly NewsPagesDbBase _newsPagesDbBase;

        public NewsPagesController(ILogger<NewsPagesController> logger)
        {
            _logger = logger;
            _newsPagesDbBase = new NewsPagesDbBase(new Connection());
            _newsPagesBase = new NewsPagesBase(_newsPagesDbBase.SelectAll().ToList());
        }

        [HttpGet("GetAllPages")]
        public IEnumerable<NewsPagesInfo> Get()
        {
            
            return _newsPagesBase.NewsPages;
        }

        [HttpGet("GetEntites")]
        public ICollection<string> GetByEntities(string url, string entity)
        {
            return _newsPagesBase.FindByEntitiesNames(_newsPagesBase.GetByUrl(url), entity);
        }

        [HttpGet("FindByWord")]
        public IEnumerable<string> FindByWordPart(string url, string value)
        {
            return _newsPagesBase.GetByUrl(url).FindByWord(value);
        }

        [HttpDelete("DeleteById")]
        public void Delete(int id)
        {
            var newsPage = _newsPagesBase.GetById(id);

            if (newsPage == null)
            {
                return;
            }

            _newsPagesDbBase.Delete(newsPage);
        }

        [HttpDelete("DeleteByUrl")]
        public void DeleteByUrl(string url)
        {
            var newsPage = _newsPagesBase.GetByUrl(url);

            if (newsPage == null)
            {
                return;
            }

            _newsPagesDbBase.Delete(newsPage);
        }

        [HttpPost("AddByUrl")]
        public void Add(string url)
        {
            _newsPagesDbBase.Insert(url);
        }
    }
}