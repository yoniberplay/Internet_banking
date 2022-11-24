using Microsoft.AspNetCore.Mvc;

namespace Internet_banking.Controllers
{
    public class ClientUsersController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Recipient()
        {
            return View();
        }

        public IActionResult MoneyAdvance()
        {
            return View();
        }

        public IActionResult AccountTransfer()
        {
            return View();
        }

        public IActionResult ConfirmFee()
        {
            return View();
        }

        public IActionResult CreditCardFee()
        {
            return View();
        }

        public IActionResult ExpressFee()
        {
            return View();
        }

        public IActionResult LoanFee()
        {
            return View();
        }

        public IActionResult RecipientFee()
        {
            return View();
        }

    }
}
