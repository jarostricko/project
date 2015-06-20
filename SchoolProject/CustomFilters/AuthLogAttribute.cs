using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolProject.DAL;
using SchoolProject.Models;

namespace SchoolProject.CustomFilters
{
    public class AuthLogAttribute : AuthorizeAttribute
    {
        public string View { get; set; }
        public AuthLogAttribute()
        {
            View = "AuthorizeFailed";
        }

        /// <summary>
        /// Check for Authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        /// <summary>
        /// Method to check if the user is Authorized or not
        /// if yes continue to perform the action else redirect to error page
        /// </summary>
        /// <param name="filterContext"></param>
        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            
            var currentUserId = filterContext.HttpContext.User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SchoolProjectContext()));
            if (currentUserId != null)
            {
                var currentUser = manager.FindById(currentUserId);
                if (currentUser != null && currentUser.IsTeacher)
                {
                    filterContext.Result = null;
                }
            }
            
            //toto riesenie z dovodu, ze tieto Authozation metody hladaju Role a Usera v inej tabulke
            //Userov a Role a vztahy medzi nimi su v tabulkach IdentityRole a pod. a tieto metody to hladaju v AspNetRoles apod.
            //Niekolko hodin som hladal riesenie a nenasiel som ho, tak som to spravil takto
            
            // If the Result returns null then the user is Authorized 
            if (filterContext.Result == null)
                return;

            //If the user is Un-Authorized then Navigate to Auth Failed View 
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                // var result = new ViewResult { ViewName = View };
                var vr = new ViewResult();
                vr.ViewName = View;

                ViewDataDictionary dict = new ViewDataDictionary();
                dict.Add("Message", "Sorry you are not Authorized to Perform this Action");

                vr.ViewData = dict;

                var result = vr;

                filterContext.Result = result;
            }
        }
        
    }
}