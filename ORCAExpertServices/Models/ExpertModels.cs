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

        public virtual ICollection<ListExpertise> ListExpertise { get; set; }



    }

    public class ListExpertise
    {

        [Key]
        [ForeignKey("ApplicationUser")]
        public string ExpertID { get; set; }


        [ForeignKey("Expertise")]
        public int ExpertiseID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Expertise> Expertise { get; set; }
    }
}