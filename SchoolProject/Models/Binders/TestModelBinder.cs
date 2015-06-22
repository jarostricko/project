using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject.DAL;
using SchoolProject.Migrations;
using SchoolProject.ViewModels;

namespace SchoolProject.Models.Binders
{
    public class TestModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var httpRequestBase = controllerContext.HttpContext.Request;
            SchoolProjectContext context = new SchoolProjectContext();
            var questions = context.Questions.Where(q => httpRequestBase.Form.AllKeys.Contains(q.QuestionID.ToString()));
            var model = new TestViewModel();
            model.Questions = questions.ToList();
            return model;
        }
    }
}