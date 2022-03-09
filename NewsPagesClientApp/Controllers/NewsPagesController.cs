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
        public ICollection<string> GetByEntities(IEnumerable<string> entities)
        {
            return _newsPagesBase.FindByEntitiesNames(entities);
        }

        [HttpGet("FindByWord")]
        public IEnumerable<string> FindByWordPart(int newsPageId, string value)
        {
            return _newsPagesBase.NewsPages.Where(newsPage => newsPage.Id == newsPageId)
                .FirstOrDefault().FindByWord(value);
        }

        [HttpDelete(Name = "Delete")]
        public void Delete(int id)
        {
            var newsPage = _newsPagesBase.GetById(id);

            if (newsPage == null)
            {
                return;
            }

            _newsPagesDbBase.Delete(newsPage);
        }

        [HttpPost("AddByEntity")]
        public void Add(NewsPagesInfo data)
        {
            _newsPagesDbBase.Insert(data);
        }

        [HttpPost("AddByUrl")]
        public void Add(string url)
        {
            _newsPagesDbBase.Insert(url);
        }
    }
}