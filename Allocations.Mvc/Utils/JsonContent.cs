using Newtonsoft.Json;
using System.Text;

namespace Allocations.Mvc.Utils
{
    public class JsonContent : StringContent
    {
        public JsonContent(object item) : base(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json")
        {

        }
    }
}
