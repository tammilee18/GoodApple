using System;
using System.Collections.Generic;

namespace GoodApple.Models {
    public class WrapperModel {
        public User LoggedInUser {get;set;}
        public List<Project> AllProjects {get;set;}
        
    }
}