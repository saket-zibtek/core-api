using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skycop.Common.Helpers
{
    public static class Utility
    {
        public static string GetRandomString(int length)
        {
            string[] array = new string[54]
            {
                "0","2","3","4","5","6","8","9",
                "a","b","c","d","e","f","g","h","j","k","m","n","p","q","r","s","t","u","v","w","x","y","z",
                "A","B","C","D","E","F","G","H","J","K","L","M","N","P","R","S","T","U","V","W","X","Y","Z"
            };
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(array[GetRandomNumber(53)]);
            }
            return sb.ToString();
        }

        public static bool DeleteFile(String path)
        {
            bool isDeleted = false;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                isDeleted = true;
            }
            return isDeleted;
        }

        public static int GetRandomNumber(int maxNumber)
        {
            if (maxNumber < 1)
                throw new System.Exception("The maxNumber value should be greater than 1");
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            int seed = (b[0] & 0x7f) << 24 | b[1] << 16 | b[2] << 8 | b[3];
            System.Random r = new System.Random(seed);
            return r.Next(1, maxNumber);
        }

        //public static string GetConfigValue(string key)
        //{
        //    return System.Configuration.ConfigurationManager.AppSettings[key];
        //}

        private static string SanitizedValue(string inputValue)
        {
            string sanitizedValue = inputValue;
            if (string.IsNullOrEmpty(inputValue) || "-1".Equals(inputValue))
            {
                sanitizedValue = null;
            }
            return sanitizedValue;
        }

        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(SanitizedValue(password))) return password;
            string strmsg = string.Empty;
            byte[] encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public static string GetHydratedString(string template, Dictionary<string, string> jsonData)
        {
            var hydratedTemplate = template;
            foreach (var jsonKey in jsonData.Keys)
            {
                hydratedTemplate = hydratedTemplate.Replace(jsonKey, jsonData[jsonKey]);
            }
            return hydratedTemplate;
        }

        public static string GuidString()
        {
            return System.Guid.NewGuid().ToString();
        }

        //public static int GetTokenExpriresOn()
        //{
        //    var expiresOn = SystemConstants.ExpriesOn; // In minutes
        //    var expiresOnFromConfig = GetConfigValue("AuthTokenExpiresOn");
        //    if (!string.IsNullOrEmpty(expiresOnFromConfig))
        //    {
        //        expiresOn = expiresOnFromConfig.ToStringInt();
        //    }
        //    return expiresOn;
        //}

        //public static string GetRootDirectory()
        //{
        //    return GetConfigValue("RootFolder");
        //}

        public static string GenerateAuthToken(int length)
        {
            return Utility.GetRandomString(length);
        }

        public static Dictionary<string, string> GetAPIKeys()
        {
            // For the time being all the API keys hard coded here, Eventually, it would be come from database. 
            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("web", "b64f1a77b1b317d347f5cb79332c86d2");
            keys.Add("android", "b2023820a60123ef4e6869bacaf7d90c");
            keys.Add("ios", "e40f01afbb1b9ae3dd6747ced5bca532");
            return keys;
        }

        //public static DateTimeOffset GetAbsoluteExpirationTime()
        //{
        //    var duration = GetConfigValue("MemoryCacheDuration");
        //    double dateTimeOffset = 30; // Default duration 30 minutes
        //    if (!string.IsNullOrEmpty(duration))
        //    {
        //        dateTimeOffset = Convert.ToDouble(duration);
        //    }
        //    return DateTimeOffset.UtcNow.AddMinutes(dateTimeOffset);
        //}

        public static string GetCacheKey(string prefix, int id)
        {
            return string.Format("{0}_{1}", prefix, id);
        }

        public static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        #region API stubs

        public static List<Object> GetUsers()
        {
            var users = new List<Object>();

            users.Add(new { ID = "1", FirstName = "Bimal", LastName = "Kumar", MiddleName = "", UserName = "bimal_kumar", Email = "bimal.kumar@zibtek.com", Password = "Tudip@123", RoleID = "2" });
            users.Add(new { ID = "2", FirstName = "Sachin", LastName = "Mahapure", MiddleName = "", UserName = "sachin_mahapure", Email = "sachin.mahapure@zibtek.com", Password = "Tudip@123", RoleID = "2" });
            users.Add(new { ID = "3", FirstName = "Pravesh", LastName = "Bansal", MiddleName = "", UserName = "pravesh_bansal", Email = "pravesh.bansal@zibtek.com", Password = "Tudip@123", RoleID = "3" });
            users.Add(new { ID = "4", FirstName = "Saket", LastName = "Tamgadge", MiddleName = "", UserName = "saket_tamgadge", Email = "saket.tamgadge@zibtek.com", Password = "Tudip@123", RoleID = "2" });
            users.Add(new { ID = "5", FirstName = "Dipti", LastName = "Agrawal", MiddleName = "", UserName = "dipti_agrawal", Email = "dipti.agrawal@zibtek.com", Password = "Tudip@123", RoleID = "1" });
            users.Add(new { ID = "6", FirstName = "Tushar", LastName = "Apshankar", MiddleName = "", UserName = "tushar_apshankar", Email = "tushar.apshankar@zibtek.com", Password = "Tudip@123", RoleID = "1" });

            return users;
        }

        public static List<Object> GetRoles()
        {
            var roles = new List<Object>();

            roles.Add(new { ID = "1", Name = "Super Admin", Description = "All Permissions" });
            roles.Add(new { ID = "2", Name = "Admin", Description = "Limited Permissions" });
            roles.Add(new { ID = "3", Name = "Customer", Description = "Restricted Premissions" });

            return roles;
        }

        public static List<Object> GetPolledDevices()
        {
            var devices = new List<Object>();

            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });
            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });
            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });
            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });
            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });
            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });
            devices.Add(new { Name="Bimal Kumar",IP= "192.168.251.106", Port="80",HardDrive="Normal",CameraNumber="2", Recording="2",VideoLoss="0",DateOrTime="11/23/2017 10:18:00",DeviceType="ABC",Verion="1.0",Web="81",DVRTime="11/23/2017" });

            return devices;
        }

        #endregion
    }
}
