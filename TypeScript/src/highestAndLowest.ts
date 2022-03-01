export class Kata {
  static highAndLow(numbers: string): string {
    const integers = numbers.split(" ").map((str) => parseInt(str));

    // NOTE: Could just use Math.max and Math.min on this array, but I didn't want to scan array twice
    let max = integers[0];
    let min = integers[0];

    if (integers.length > 1) {
      integers.slice(1).forEach((num) => {
        if (num > max) {
          max = num;
        } else if (num < min) {
          min = num;
        }
      });
    }

    return `${max} ${min}`;
  }
}
