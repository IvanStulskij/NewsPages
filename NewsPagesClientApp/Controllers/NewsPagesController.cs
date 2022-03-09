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

        public NewsPagesController(ILogger<NewsPagesController> logger)
        {
            _logger = logger;
            var newsPagesDbBase = new NewsPagesDbBase(new Connection());
            _newsPagesBase = new NewsPagesBase(newsPagesDbBase.SelectAll().ToList());
        }

        [HttpGet( "GetAllPages")]
        public IEnumerable<NewsPagesInfo> Get()
        {
            return _newsPagesBase.NewsPages;
        }

        [HttpGet("Get entites")]
        public ICollection<string> GetByEntities(IEnumerable<string> entities)
        {
            return _newsPagesBase.FindByEntitiesNames(entities);
        }

        [HttpGet("Find by word")]
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

            _newsPagesBase.Remove(newsPage);
        }

        [HttpPost(Name = "Add")]
        public void Add(NewsPagesInfo data)
        {
            _newsPagesBase.Add(data);
        }
    }
}