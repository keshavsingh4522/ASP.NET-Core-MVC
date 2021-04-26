using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages
{
    public class CounterBase : ComponentBase
    {
        // change private to protected or public
        protected int currentCount = 0;
        // one way binding
        protected string fontsFamily = "Sitka Display";
        [Parameter]
        public int Incr { get; set; } = 1;
        protected void IncrementCount()
        {
            currentCount += Incr;
        }
    }
}
