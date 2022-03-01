export function joust(
  listField: string[],
  vKnightLeft: number,
  vKnightRight: number
): string[] {
  if (vKnightLeft == 0 && vKnightRight == 0) {
    return listField;
  }

  const [leftKnight, rightKnight] = listField;
  const fieldLength = leftKnight.length;
  let leftPos = leftKnight.indexOf(">");
  let rightPos = rightKnight.indexOf("<");

  while (leftPos < rightPos) {
    leftPos = Math.min(fieldLength - 1, leftPos + vKnightLeft);
    rightPos = Math.max(0, rightPos - vKnightRight);
  }

  const leftFinal =
    " ".repeat(Math.max(leftPos - 2, 0)) +
    "$->" +
    " ".repeat(Math.max(fieldLength - leftPos - 1, 0));

  const rightFinal =
    " ".repeat(Math.min(rightPos, fieldLength - 2)) +
    "<-P" +
    " ".repeat(Math.max(fieldLength - rightPos - 3, 0));

  return [leftFinal, rightFinal];
}
