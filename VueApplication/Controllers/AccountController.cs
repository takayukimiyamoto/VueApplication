using Microsoft.AspNetCore.Mvc;
using VueApplication.Models;

namespace VueApplication.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            return RedirectToAction("Account", account);
        }

        [HttpGet]
        public IActionResult Account(Account account)
        {
            return View(account);
        }
    }
}