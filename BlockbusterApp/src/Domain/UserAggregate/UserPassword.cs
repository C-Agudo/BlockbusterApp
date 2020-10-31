using BlockbusterApp.src.Domain.UserAggregate.Exception;
using BlockbusterApp.src.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Domain.UserAggregate
{
    public class UserPassword : StringValueObject
    {
        private const string PASSWORD_PATTERN = "/^([a-zA-Z0-9]{8,15})s/";
        private const string MIN_MAYUS_PATTERN = "/^([A-Z]{2,*})s/";
        private const string MIN_NUMBER_PATTERN = "/^([0-9]{2,*})s/";


        public UserPassword(string value) : base(value)
        {
            if (this.Is(value))
            {
                throw InvalidUserAttributeException.FromValue("password", value);
            }
        }

        private bool Is(string value)
        {
            
            Match passwordMatch = this.SearchMatch(value, PASSWORD_PATTERN);

            Match minMayusMatch = this.SearchMatch(value, MIN_MAYUS_PATTERN);
            Match minNumberMatch = this.SearchMatch(value, MIN_NUMBER_PATTERN);

            if (passwordMatch.Success && minMayusMatch.Success && minNumberMatch.Success)
            {
                return true;
            }

            return false;
        }

        private Match SearchMatch(string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(value);
            return match;
        }

        public static void ValidateIsSamePassword(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                throw InvalidUserAttributeException.FromText("Password must be equal than repeat password");
            }
        }
    }
}
