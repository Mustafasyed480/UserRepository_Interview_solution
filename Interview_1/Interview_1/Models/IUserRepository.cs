using System.Collections.Generic;

namespace Interview_1.Models
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns all users from the database.
        /// </summary>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Gets the total number of transaction for a given user ID.
        /// </summary>
        int GetTransactionCountByUser(string userId);

        /// <summary>
        /// Gets the total unpaid amount by userID
        /// </summary>
        decimal GetUnpaidAmountByUser(string userId);

        /// <summary>
        /// Returns a user with the given ID.
        /// </summary>
        User GetUserById(string id);

        /// <summary>
        /// Gets users with given first and last name.
        /// </summary>
        IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName);

        /// <summary>
        /// Assuming the mock database is CPU bound,
        /// write code that gets multiple users by Id
        /// in parallel from the database.
        /// </summary>
        List<User> GetUsersByIdInParallel(List<string> ids);

        /// <summary>
        /// Gets users older than given age.
        /// </summary>
        IEnumerable<User> GetUsersOlderThanGivenAge(int age);
    }
}
