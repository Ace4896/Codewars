export function manhattanDistance(
  pointA: [number, number],
  pointB: [number, number]
): number {
  return Math.abs(pointA[0] - pointB[0]) + Math.abs(pointA[1] - pointB[1]);
}
