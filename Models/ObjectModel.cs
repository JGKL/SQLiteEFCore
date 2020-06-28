using System;
using System.ComponentModel.DataAnnotations;

namespace EFSQLite.Models
{
    public class ObjectModel
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String PreviewImage { get; set; }
        public String TagName { get; set; }

        // Foreign keys---
        public int TypeId { get; set; }
        public ObjectTypeModel TypeModel { get; set; }
        //---
    }
}
