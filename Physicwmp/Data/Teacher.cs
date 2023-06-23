using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physicwmp.Data
{
    public class Teacher
    {
        [BsonId] public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isMale { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
        public bool isTeacher { get; set; }
    }
}
