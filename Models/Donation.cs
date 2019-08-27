using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodApple.Models {
    public class Donation {
        [Key]
        public int DonationId {get;set;}

        public decimal Amount {get;set;}
        public int ProjectId {get;set;}
        public Project Project {get;set;}
        public int DonorId {get;set;}
        public Donor Donor {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}