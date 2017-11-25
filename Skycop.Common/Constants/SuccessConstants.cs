using System.Collections.Generic;

namespace Skycop.Common.Constants
{
    public static class SuccessConstants
    {
        private static Dictionary<string, string> SUCCESS_MAP = new Dictionary<string, string>();
        public static string IS_ALIVE = "100";
        public static string SAVE_SUCCESSFULLY = "101";
        public static string LOGIN_SUCCESSFULLY = "102";
        public static string EMAIL_SEND_SUCCESSFULLY = "103";
        public static string PASSWORD_UPDATED_SUCCESSFULLY = "104";

        static SuccessConstants()
        {
            SUCCESS_MAP.Add(IS_ALIVE, "Yes, I am Alive");
            SUCCESS_MAP.Add(SAVE_SUCCESSFULLY, "Data saved successfully");
            SUCCESS_MAP.Add(LOGIN_SUCCESSFULLY, "Login successfully");
            SUCCESS_MAP.Add(EMAIL_SEND_SUCCESSFULLY, "Please check your register email for resetting the password");
            SUCCESS_MAP.Add(PASSWORD_UPDATED_SUCCESSFULLY, "Password updated successfully");
        }

        public static Dictionary<string, string> GetSuccessMap()
        {
            return SUCCESS_MAP;
        }

        public static string GetSuccessMessage(string code)
        {
            return SUCCESS_MAP[code];
        }
    }
}
