export function findUniq(arr: number[]): number {
  // Two different cases to handle:
  // - First two numbers equal: Search the rest of the array for the unique number
  // - First two numbers different: Check the 3rd element, and return the unique number
  if (arr[0] === arr[1]) {
    const nonUniqueNum = arr[0];
    for (let i = 2; i < arr.length; i++) {
      if (arr[i] != nonUniqueNum) {
        return arr[i];
      }
    }

    throw "Could not find unique number in array!";
  }

  // At this point, we know the first three elements form this pattern:
  // - xyx
  // - yxx
  if (arr[0] == arr[2]) {
    return arr[1]; // xyx
  } else {
    return arr[0]; // yxx
  }
}
