using System.ComponentModel.DataAnnotations;

namespace webapidotnet.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int Age { get; set; }
    }
}