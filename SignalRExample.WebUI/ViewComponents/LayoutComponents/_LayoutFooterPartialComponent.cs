using Microsoft.AspNetCore.Mvc;

namespace SignalRExample.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
