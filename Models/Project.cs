using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodApple.Models {
    public class Project {
        [Key]
        public int ProjectId {get;set;}

        public int CreatorId {get;set;}
        public Teacher Creator {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public decimal GoalAmount {get;set;}
        public DateTime EndDate {get;set;}
        List<Donor> Donors {get;set;}
        List<Comment> Comments {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}