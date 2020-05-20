using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuktionsOpgave.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telnr { get; set; }
        public string Password { get; set; }
        [Key]
        public int Id { get; set; }
    }
}