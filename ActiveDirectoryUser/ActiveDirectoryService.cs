using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace ActiveDirectoryUser
{
    public class ActiveDirectoryService
    {
        private readonly ILog _log;

        private UserPrincipal _userPrincipal;

        public ActiveDirectoryService(ILog log)
        {
            _log = log;
            SetUserPrinciple();
        }

        public string GetName()
        {
            string name = string.Empty;

            try
            {
                name = _userPrincipal.DisplayName;
            }
            catch (Exception ex)
            {
                _log.Error("Error occurred while retrieving name from active directory.", ex);
            }

            return name;
        }

        public string GetUserName()
        {
            string userName = string.Empty;

            try
            {
                userName = _userPrincipal.SamAccountName;
            }
            catch (Exception ex)
            {
                _log.Error("Error occurred while retrieving username from active directory.", ex);
            }

            return userName;
        }

        public string GetEmailAddress()
        {
            string emailAddress = string.Empty;

            try
            {
                emailAddress = _userPrincipal.EmailAddress;
            }
            catch (Exception ex)
            {
                _log.Error("Error occurred while retrieving email address from active directory.", ex);
            }

            return emailAddress;
        }

        private void SetUserPrinciple()
        {
            try
            {
                _userPrincipal = UserPrincipal.Current; 
            }
            catch (Exception ex)
            {
                _log.Error("Error occured while setting user principle.", ex);
            }
        }

        public string[] GetGroups()
        {
            string[] output = null;
            string username = GetUserName();
            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (var user = UserPrincipal.FindByIdentity(ctx, username))
            {
                if (user != null)
                {
                    output = user.GetGroups() //this returns a collection of principal objects
                        .Select(x => x.SamAccountName) // select the name.  you may change this to choose the display name or whatever you want
                        .ToArray(); // convert to string array
                }
            }

            return output;
        }
    }
}