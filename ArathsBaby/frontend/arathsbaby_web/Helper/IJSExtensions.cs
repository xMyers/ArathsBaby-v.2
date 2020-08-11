using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arathsbaby_web.Helper
{
    public static class IJSExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime js, string title, string message, TypeMessageSweetAler typeMessageSweetAler)
        {
            return js.InvokeAsync<bool>("CustomConfirm", title, message, typeMessageSweetAler.ToString());
        }

        public enum TypeMessageSweetAler
        {
            question, warning, error, success, info
        }
    }
}
