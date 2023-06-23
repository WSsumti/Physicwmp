using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physicwmp.Data
{
    public class HomeworkModel
    {
        [BsonId]public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public List<char> Answer { get; set; }
        public DateTime Deadline { get; set; }
    }
}
