using Microsoft.AspNetCore.Mvc;

namespace SignalRExample.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
