using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.ViewComponents
{
    public class CadastroRegrasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View("CadastroRegras"));
        }
    }
}
