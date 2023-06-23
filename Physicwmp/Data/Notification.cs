using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physicwmp.Data
{
    public class Notification
    {
        [BsonId] public Guid Id { get; set; }
        public string TeacherName { get; set; }
        public DateTime TimeUpload { get; set; }
        public string Content { get; set; }
    }
}
