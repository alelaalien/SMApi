using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace SM.Infraestructure.Filters
{
    internal class BadRequesObjetResult : IActionResult
    {
        private ModelStateDictionary modelState;

        public BadRequesObjetResult(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new Exception("Hay datos para corregir");
        }
    }
}