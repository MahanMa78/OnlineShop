using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OnlineShop.Pages
{
    [Authorize] 
    public class Privacy : PageModel
    {
        private readonly ILogger<Privacy> _logger;

        public Privacy(ILogger<Privacy> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}