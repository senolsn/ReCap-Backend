using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "The system is in maintenance.";
        public static string ItemAdded = "Added successfully";
        public static string ItemRemoved = "Removed successfully";
        public static string ItemUpdated = "Updated successfully";
        public static string ItemListed = "Item listed successfully.";


        public static string ItemNotAdded = "Item added failed";
        public static string ItemNotRemoved = "Item removed failed";
        public static string ItemNotUpdated = "Item updated failed";
        public static string ItemNotListed = "Item listed failed.";

        public static string CustomerNotFound = "Customer Not Found !";

        public static string? AuthorizationDenied = "Access Denied ";
        public static string UserRegistered = "User Registered !";
        public static string AccessTokenCreated = "Access Token Created Successfully";
        public static string UserAlreadyExists = "User is already exists";
        public static string SuccessfulLogin = "Login Successfully";
        public static string PasswordError = "Password invalid";
        public static string UserNotFound = "User Not Found !";

        public static string CarImageAdded = "Car Image Added !";
    }
}
