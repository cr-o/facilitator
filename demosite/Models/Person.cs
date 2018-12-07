﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demosite.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$")]
        [Required]
        public string Fname { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$")]
        [Required]
        public string LName { get; set; }
        public IList<PersonsBuilding> PersonsBuildings { get; set; }

    }
}
