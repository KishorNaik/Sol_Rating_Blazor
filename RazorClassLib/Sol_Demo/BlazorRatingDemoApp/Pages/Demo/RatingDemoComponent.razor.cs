using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRatingDemoApp.Pages.Demo
{
    public partial class RatingDemoComponent
    {
        #region Private Property

        private bool IsLoad { get; set; }

        private int Rating { get; set; }

        private int Max { get; set; }

        #endregion Private Property

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsLoad = true;

                Rating = 2;
                Max = 5;

                StateHasChanged();
            }
        }

        #endregion Protected Method
    }
}