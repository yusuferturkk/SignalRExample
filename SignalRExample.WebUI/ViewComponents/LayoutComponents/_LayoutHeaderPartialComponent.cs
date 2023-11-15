using Microsoft.AspNetCore.Mvc;

namespace SignalRExample.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
