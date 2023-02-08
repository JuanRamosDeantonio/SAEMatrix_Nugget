﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SaeMatrix.Common.Entities;
using SaeMatrix.Common.Entities.Enum;

namespace SaeMatrix.Common.Filter
{
    public class CustomValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                .ToList();


                var Response = new ResponseBase<string>((int)EnumCodeResponse.BadRequest, String.Join('|', errors));

                context.Result = new JsonResult(Response)
                {
                    StatusCode = Response.Code
                };
            }
        }
    }
}
