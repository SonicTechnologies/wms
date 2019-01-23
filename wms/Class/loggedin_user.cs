using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wms.Class
{
    class loggedin_user
    {
        public static int userId;
        public static string userName;
        public static string fistName;
        public static string lastName;
        public static int userTypeId;
        public static string userTypeName;
        private static int x_userId
        {
            get { return userId; }
            set { userId = value; }
        }
        private static string x_userName
        {
            get { return userName; }
            set { userName = value; }
        }
        private static string x_fistName
        {
            get { return fistName; }
            set { fistName = value; }
        }
        private static string x_lastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private static int x_userTypeId
        {
            get { return userTypeId; }
            set { userTypeId = value; }
        }
        private static string x_userTypeName
        {
            get { return userTypeName; }
            set { userTypeName = value; }
        }
    }
}
