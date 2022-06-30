using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myFirstCore.Controller
{
    //配置路由，请求不同的方法 eg： api/user/方法名称
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public string get1()
        {
            
            return "hello";
        }

        [HttpGet]
        public string get2()
        {

            return "hello，word";
        }
    }
}
