using System.Collections.Generic;

namespace Skycop.Common.Constants
{
    public static class ErrorConstants
    {
        private static Dictionary<string, string> ERROR_MAP = new Dictionary<string, string>();
        public static string API_INTERNAL_ERROR = "-100";
        public static string API_KEY_ERROR = "-101";
        public static string INVALID_VERSION_ERROR = "-102";
        public static string INVALID_AUTH_TOKEN_ERROR = "-106";
        public static string INVALID_EMAIL_ADDRESS = "-107";
        public static string DATA_NOT_FOUND = "-108";
        public static string DATA_NOT_SAVED = "-109";
        public static string DATA_NOT_DELETED = "-110";

        static ErrorConstants()
        {
            ERROR_MAP.Add(API_INTERNAL_ERROR, "Internal server error");
            ERROR_MAP.Add(API_KEY_ERROR, "Invalid API key");
            ERROR_MAP.Add(INVALID_VERSION_ERROR, "Invalid API version");
            ERROR_MAP.Add(INVALID_AUTH_TOKEN_ERROR, "Invalid Authtoken error");
            ERROR_MAP.Add(INVALID_EMAIL_ADDRESS, "Please enter email address");
            ERROR_MAP.Add(DATA_NOT_FOUND, "No data found");
            ERROR_MAP.Add(DATA_NOT_SAVED, "There was an error while saving the data");
            ERROR_MAP.Add(DATA_NOT_DELETED, "There was an error while deleting record");
        }

        public static Dictionary<string, string> GetErrorMap()
        {
            return ERROR_MAP;
        }

        public static string GetErrorMessage(string code)
        {
            var errorMessage = string.Empty;
            if (ERROR_MAP.ContainsKey(code))
            {
                errorMessage = ERROR_MAP[code];
            }
            else
            {
                errorMessage = ERROR_MAP[API_INTERNAL_ERROR];
            }
            return errorMessage;
        }
    }
}
