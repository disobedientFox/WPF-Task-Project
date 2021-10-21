using System.Collections.Generic;

namespace TestApp.UI.Tools
{
    public interface IDataParser
    {
        IEnumerable<TResponse> Parse<TResponse>(string source);
    }
}
