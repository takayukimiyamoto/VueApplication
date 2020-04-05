using System;

namespace VueApplication.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTimeOffset Date { get; set; }
        public Phone Phone { get; set; }
    }
}
