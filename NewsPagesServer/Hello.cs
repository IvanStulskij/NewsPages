using ServiceStack;

namespace NewsPagesServer
{
    [Route("/hello/{Name}")]
    internal class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }
}
