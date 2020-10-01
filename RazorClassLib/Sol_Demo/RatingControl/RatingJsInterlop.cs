using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RatingControl
{
    public static class RatingJsInterlop
    {
        #region Property

        public static Action<String> GetSelectedRatingValueAction { get; set; }

        #endregion Property

        #region Public Method

        // Call Javascript function from C#
        public static async Task CallRatingJsAsync(this ElementReference elementReference, IJSRuntime jSRuntime, string ratingJsonData)
        {
            // Call ratingBlazorDemo function
            await jSRuntime.InvokeVoidAsync(identifier: "ratingBlazorDemo", elementReference, ratingJsonData);
        }

        //// Call C# function from Javascript
        [JSInvokable]
        public static Task OnSelectedRatingJs(string item)
        {
            return Task.Run(() => GetSelectedRatingValueAction.Invoke(item));
        }

        #endregion Public Method
    }
}