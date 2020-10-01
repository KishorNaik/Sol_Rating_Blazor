function ratingBlazorDemo(ratingElement, ratingJsonData) {
    console.log(ratingJsonData);

    // Parse Json Data
    let ratingObject = JSON.parse(ratingJsonData);
    console.log(ratingObject);

    $('.starrr').starrr({
        rating: ratingObject.rating,
        max: ratingObject.max,
        change: function (e, value) {
            console.log('new rating is ' + value);

            DotNet.invokeMethodAsync('RatingControl', 'OnSelectedRatingJs', String(value));
        }
    });
}