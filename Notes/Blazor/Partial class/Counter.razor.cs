using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        // one way binding
        private string fontsFamily = "Sitka Display";
        [Parameter]
        public int Incr { get; set; } = 1;
        private void IncrementCount()
        {
            currentCount += Incr;
        }
    }
}
