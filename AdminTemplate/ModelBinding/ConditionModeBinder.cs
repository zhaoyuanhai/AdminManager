﻿using AdminModels.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.ModelBinding
{
    public class ConditionModeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ConditionModel model = (ConditionModel)bindingContext.Model ?? new ConditionModel();
            model.Field = GetValue(bindingContext, "Field");
            //model.Op = GetValue(bindingContext, "Op");
            model.Value = GetValue(bindingContext, "Value");
            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ValueProviderResult result = context.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")
                return "<Not Specified>";
            else
                return (string)result.AttemptedValue;
        }
    }
}