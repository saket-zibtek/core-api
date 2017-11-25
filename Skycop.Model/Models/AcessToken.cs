using System;

namespace Skycop.Model.Models
{
    public class AcessToken
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
