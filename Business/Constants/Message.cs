using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Message
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
    }
}
