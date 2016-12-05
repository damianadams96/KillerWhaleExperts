using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ORCAExpertServices.Models
{

    public class Expertise
    {
        [Key]
        public int ExpertiseID { get; set; }

        public string nameOfExpertise { get; set; }

        [ForeignKey ("Expert")]
        public string ExpertID { get; set; }


        public virtual ICollection<ApplicationUser> Expert { get; set; }



    }


}