using CsvHelper.Configuration;
using TestApp.Model;

namespace TestApp.UI.Tools
{
    public class EmpoloyeMap : ClassMap<Employe>
    {
        public EmpoloyeMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.FirstName).Name("name");
            Map(m => m.LastName).Name("surename");
            Map(m => m.Email).Name("email");
            Map(m => m.Number).Name("phone");
        }
    }
}
