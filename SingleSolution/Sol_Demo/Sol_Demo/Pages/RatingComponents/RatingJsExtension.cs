using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Pages.RatingComponents
{
    public static class RatingJsExtension
    {
        public static async Task RatingBlazorJsAsync(this ElementReference elementReference, IJSRuntime jsRuntime, string ratingJsonData)
        {
            await jsRuntime.InvokeVoidAsync(
                    "ratingBlazorDemo", elementReference, ratingJsonData);
        }
    }
}
