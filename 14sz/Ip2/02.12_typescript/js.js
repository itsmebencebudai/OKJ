function minimumSearch(arr) {
    var minValue = arr[0];
    var minIndex = 0;
    for (var i = 1; i < arr.length; i++) {
        if (arr[i] < minValue) {
            minValue = arr[i];
            minIndex = i;
        }
    }
    return [minValue, minIndex, minIndex + 1];
}
// Példa használat
var numbers = [5, 3, 9, 1, 7];
var _a = minimumSearch(numbers), minValue = _a[0], minIndex = _a[1], position = _a[2];
console.log("A legkisebb érték:", minValue);
console.log("Az index:", minIndex);
console.log("A hely:", position);
