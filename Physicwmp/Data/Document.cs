using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physicwmp.Data
{
    public class Document
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public bool IsVideo { get; set; }
    }
}
