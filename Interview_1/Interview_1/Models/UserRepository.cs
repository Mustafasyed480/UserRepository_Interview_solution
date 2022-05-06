using Interview_1.Models;

namespace Interview_1.Models
{
    public class UserRepository : IUserRepository
    {
        
        private readonly DatabaseContext _databaseContext;
       
        
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext=databaseContext;

            /* Test Data Test Data Test Data Test Data Test Data Test Data Test Data Test Data */
            _databaseContext.Users = new List<User>()
            {
                new User() { Id="1",FirstName="Tom",LastName="ward",DateofBirth=new DateOnly(1993,06,12)},
                new User() {Id="2",FirstName="Bhanu",LastName="karla",DateofBirth=new DateOnly(1994,07,14) },
                new User(){Id="3",FirstName="karla",LastName="preethi",DateofBirth=new DateOnly(1995,10,15) },
                new User(){Id="4",FirstName="ward",LastName="john",DateofBirth=new DateOnly(1996,11,12) },
                new User(){Id="5",FirstName="Renate",LastName="karla",DateofBirth=new DateOnly(1993,1,12) },
                 new User(){Id="6",FirstName="preethi",LastName="Bhanu",DateofBirth=new DateOnly(1992,10,12) }
            };
            _databaseContext.Transactions = new List<Transaction>()
            {
                new Transaction(){Id="1",UserId="1",TransactionDate=new DateTime(2022,4,4),AmountBilled=1000,DatePaid=null},
                new Transaction(){Id="2",UserId="2",TransactionDate=new DateTime(2022,4,2),AmountBilled=2000,DatePaid=new DateTime(2022,4,3)},
                new Transaction(){Id="3",UserId="1",TransactionDate=new DateTime(2022,4,3),AmountBilled=5000,DatePaid=null},
                new Transaction(){Id="4",UserId="3",TransactionDate=new DateTime(2022,4,5),AmountBilled=8000,DatePaid=new DateTime(2022,4,6)},
                new Transaction(){Id="5",UserId="2",TransactionDate=new DateTime(2022,4,7),AmountBilled=10000,DatePaid=null},
                new Transaction(){Id="6",UserId="3",TransactionDate=new DateTime(2022,4,11),AmountBilled=3000,DatePaid=null},
                new Transaction(){Id="7",UserId="2",TransactionDate=new DateTime(2022,4,10),AmountBilled=3000,DatePaid=null},
                new Transaction(){Id="8",UserId="3",TransactionDate=new DateTime(2022,4,1),AmountBilled=3000,DatePaid=null},
                new Transaction(){Id="9",UserId="1",TransactionDate=new DateTime(2022,4,9),AmountBilled=3000,DatePaid=null},
                new Transaction(){Id="10",UserId="3",TransactionDate=new DateTime(2022,4,6),AmountBilled=3000,DatePaid=null},
            };
        }
        
        public IEnumerable<User> GetAllUsers()
        {
           
            return _databaseContext.Users.ToList();
        }

        public int GetTransactionCountByUser(string userId)
        {
           
            return _databaseContext.Transactions.Where(t => t.UserId == userId).Count();
        }

        public decimal GetUnpaidAmountByUser(string userId)
        {
           
            return _databaseContext.Transactions.Where(t => t.DatePaid == null&&t.UserId==userId).Sum(t => t.AmountBilled);
        }

        public User GetUserById(string? id)
        {

            var user = _databaseContext.Users.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName)
        {
           
            return _databaseContext.Users.Where(u => u.FirstName == firstName || u.LastName == lastName).ToList();
        }
        
        public List<User> GetUsersByIdInParallel( List<string> ids)
        {
           return _databaseContext.Users.Where(u=>ids.Contains(u.Id)).AsParallel().ToList();
           
        }

        public IEnumerable<User> GetUsersOlderThanGivenAge(int age)
        {
            //Test Test//
           //int result= UserRepository.CalculateAge(new DateOnly(1990, 06, 12));

            return _databaseContext.Users.Where(u => u.CalculateAge(u.DateofBirth) > age);
        }

        //Test function 
        //private static int CalculateAge(DateOnly dateOfBirth)
        //{
        //    int age = 0;
        //    age = DateTime.Now.Year - dateOfBirth.Year;
        //    if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
        //        age = age - 1;

        //    return age;
        //}
    }
}
