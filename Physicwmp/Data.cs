using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;


namespace Physicwmp
{
    public class Student
    {
        [BsonId] public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isMale { get; set; }
        public int Grade { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public List<Test> Test { get; set; }
        public Account Account { get; set; }
        public Permission Permission { get; set; }
    }
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Permission
    {
        public bool IsStudent { get; set; }
        public bool IsAdvance { get; set; }
    }
    public class Test
    {
        public string NameTest { get; set; }
        public DateTime TimeStart { get; set; }
        public double Score { get; set; }
        public DateTime TimeEnd { get; set; }
        public int RightAns { get; set; }
        public int SumofQuestion { get; set; }

    }
}
