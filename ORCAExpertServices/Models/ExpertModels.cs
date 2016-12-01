using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ORCAExpertServices.Models
{
    public class Expert : ApplicationUser
    {
        public bool IsAnExpert { get; set; }

        public bool Validated { get; set; }

        public virtual ListExpertise ListExpertise { get; set; }

        public virtual ICollection<MessageThread> MessageThread { get; set; }

    }

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
        [ForeignKey("Expert")]
        public string ExpertID { get; set; }


        [ForeignKey("Expertise")]
        public int ExpertiseID { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual ICollection<Expertise> Expertise { get; set; }
    }
}