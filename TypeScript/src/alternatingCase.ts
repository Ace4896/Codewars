export function toAlternatingCase(s: string): string {
  return s
    .split("")
    .map((char) => {
      if (char === char.toUpperCase()) {
        return char.toLowerCase();
      } else if (char === char.toLowerCase()) {
        return char.toUpperCase();
      } else {
        return char;
      }
    })
    .join("");
}
