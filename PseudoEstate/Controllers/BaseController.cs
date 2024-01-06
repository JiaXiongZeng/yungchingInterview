using Microsoft.AspNetCore.Mvc;

namespace PseudoEstate.Controllers
{
    public abstract class BaseController: Controller
    {
        //將DI的部分抽出來 (後面直接繼承就可以用了)
        protected readonly SwaggerClient _api;
        public BaseController(SwaggerClient api)
        {
            _api = api;
        }
    }
}
