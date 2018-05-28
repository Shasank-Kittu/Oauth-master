using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oauth.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        public UserManager<ExtendedUser> UserManager => Request.GetOwinContext().Get<UserManager<ExtendedUser>>(); 
        public SignInManager<ExtendedUser, string> SignInManager => Request.GetOwinContext().Get<SignInManager<ExtendedUser, string>>();


        // GET api/values
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Get()
        {
            var result=SignInManager.PasswordSignInAsync("shasank0000@gmail.com", "Shasank@123", true, true);

            HttpClient client = new HttpClient();
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("username", "shasank0000@gmail.com"));
            nvc.Add(new KeyValuePair<string, string>("password", "Shasank@123"));
            nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));
            var req = new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost:57756/token")) { Content = new FormUrlEncodedContent(nvc) };

            var res = await client.SendAsync(req);
            var con = await res.Content.ReadAsStringAsync();
            // return new string[] { "value1", "value2" };
            return res;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
