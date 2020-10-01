using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RatingControl
{
    public partial class RatingComponent
    {
        #region Public Parameter Property

        [Parameter]
        public int Rating { get; set; }

        [Parameter]
        public int Max { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public int SelectedRating { get; set; }

        [Parameter]
        public EventCallback<int> SelectedRatingChanged { get; set; }

        #endregion Public Parameter Property

        #region Private Property

        private ElementReference RatingElement { get; set; }

        #endregion Private Property

        #region Private Method

        private Task<String> BindRatingJsonDataAsync()
        {
            return Task.Run(() => JsonConvert.SerializeObject(new { rating = Rating, max = Max }));
        }

        private Task BindRatingOnSelectedRatingAsync()
        {
            return Task.Run(() =>
            {
                RatingJsInterlop.GetSelectedRatingValueAction = (item) =>
                {
                    base.InvokeAsync(async () =>
                    {
                        this.SelectedRating = Convert.ToInt32(item);

                        await this.SelectedRatingChanged.InvokeAsync(this.SelectedRating);
                        base.StateHasChanged();
                    });
                };
            });
        }

        #endregion Private Method

        #region Protected Method

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender == true)
            {
                // Get Rating data and convert into Json
                var ratingJson = await this.BindRatingJsonDataAsync();

                // Call javascript function
                await RatingElement.CallRatingJsAsync(JSRuntime, ratingJson);

                // Bind Selected Rating
                await this.BindRatingOnSelectedRatingAsync();

                base.StateHasChanged();
            }
        }

        #endregion Protected Method
    }
}