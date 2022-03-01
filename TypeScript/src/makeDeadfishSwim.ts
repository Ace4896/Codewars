export function parse(data: string): number[] {
  const output = [];
  let value = 0;

  for (const command of data) {
    switch (command) {
      case "i":
        value++;
        break;

      case "d":
        value--;
        break;

      case "s":
        value *= value;
        break;

      case "o":
        output.push(value);
        break;

      default:
        break;
    }
  }

  return output;
}
