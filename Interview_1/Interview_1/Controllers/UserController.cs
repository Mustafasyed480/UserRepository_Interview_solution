using Microsoft.AspNetCore.Mvc;
using Interview_1.Models;


namespace Interview_1.Controllers
{
    /* Testing Testing Testing Testing Testing*/
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController( IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult Index()
        {
            //Testing Global Exceptions
            //throw new Exception("Error in Index View");
            var users= _userRepository.GetAllUsers().ToList();
            return View(users);
        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult Details(string Id)
        {
         User user=   _userRepository.GetUserById(Id);
            if(user==null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound", Id);
            }
            return View(user);
        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult GetTransactionCountByUserId(string id)
        {
            User user = _userRepository.GetUserById(id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound", id);
            }
            ViewBag.Id = id;
            int count= _userRepository.GetTransactionCountByUser(id);
            return View(count);
        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult GetUnpaidAmountByUser(string id)
        {
            User user = _userRepository.GetUserById(id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound", id);
            }
            ViewBag.Id = id;
            decimal result= _userRepository.GetUnpaidAmountByUser(id);
            return View(result);

        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult GetUsersByFirstAndLastName(string firstName,string lastName)
        {
            var user = _userRepository.GetUsersByFirstAndLastName(firstName, lastName).ToList();
            if (user == null)
            {
                
                return View("UserNotFound");
            }
            return View(user);
        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult GetUsersOlderThanGivenAge(int age)
        {
            var user = _userRepository.GetUsersOlderThanGivenAge(age);
            if (user == null)
            {

                return View("UserNotFound");
            }
            return View(user);
        }
        /* Testing Testing Testing Testing Testing*/
        public IActionResult GetUsersByIdInParallel(List<string> ids)
        {
            var users=_userRepository.GetUsersByIdInParallel(ids).ToList();
            if (users == null)
            {

                return View("UserNotFound");
            }
            return View(users);
        }
    }
}
