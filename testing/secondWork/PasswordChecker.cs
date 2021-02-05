using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace secondWork
{
    public static class PasswordChecker
    {
        public static int GetPasswordStrench(string password)
        {
            int result = 0;

            if (Math.Max(password.Length, 7) > 7) result++;
            if (password.Any(x => Char.IsUpper(x))) result++;
            if (password.Any(x => Char.IsLower(x))) result++;
            if (password.Any(x => "~!@#$%^&*()_+".Contains(x))) result++;
            if (password.Any(x => Char.IsDigit(x))) result++;

            return result;
        }
    }
}
