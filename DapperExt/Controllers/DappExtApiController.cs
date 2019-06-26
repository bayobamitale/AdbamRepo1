using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace DapperExt.Controllers
{
    public class DappExtApiController : ApiController
    {
        // GET: api/DappExtApi
        public string Get()
        {
            var text = new StringBuilder();
            text.Append("{");
            text.Append("'name':'John',");
            text.Append(" 'age':31, ");
            text.Append(" 'pets':[ ");
            text.Append("{ 'animal':'dog', 'name':'Fido' },");
            text.Append("{ 'animal':'cat', 'name':'Felix' },");
            text.Append(" { 'animal':'hamster', 'name':'Lightning' }");
            text.Append(" ]");
            text.Append("}");

            return text.ToString();
    }

        // GET: api/DappExtApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DappExtApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DappExtApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DappExtApi/5
        public void Delete(int id)
        {
        }
    }
}
