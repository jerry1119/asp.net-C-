using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest01
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateDateTime { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    
        public override string ToString() =>
            string.Format("ID={0}Name={1}Age={2}CreateTime={3}", Id, Name, Age, CreateDateTime);
    }
}
