using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Filters
{
    public class GlobalPerformanceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Executing LogResourceFilter.OnResourceExecuting");
            context.HttpContext.Items["timer"] = Stopwatch.StartNew();
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var time = context.HttpContext.Items["timer"] as Stopwatch;
            Console.WriteLine("Executing LogResourceFilter.OnResourceExecuting {0}", time.ElapsedMilliseconds);
        }
    }
}
