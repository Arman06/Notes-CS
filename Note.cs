using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
namespace NotesApp
{
    [Table("Items")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Contents { get; set; }
    }

    
    
}
