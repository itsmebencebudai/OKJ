function minimumSearch(arr: number[]): [number, number, number] {
    let minValue = arr[0];
    let minIndex = 0;

    for (let i = 1; i < arr.length; i++) {
        if (arr[i] < minValue) {
            minValue = arr[i];
            minIndex = i;
        }
    }

    return [minValue, minIndex, minIndex + 1];
}
2
let numbers = [5, 3, 9, 1, 7];
let [minValue, minIndex, position] = minimumSearch(numbers);
console.log("A legkisebb érték:", minValue);
console.log("Az index:", minIndex);
console.log("A hely:", position);
