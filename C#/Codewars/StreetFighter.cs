namespace Codewars
{
    using System;

    public class StreetFighter
    {
        // Position is (row, column)
        public string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves)
        {
            int[] currentPosition = position;
            int rows = fighters.Length;
            int columns = fighters[0].Length;
            string[] hovered = new string[moves.Length];

            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case "up":
                        currentPosition[0] = Math.Max(0, currentPosition[0] - 1);
                        break;
                    case "down":
                        currentPosition[0] = Math.Min(rows - 1, currentPosition[0] + 1);
                        break;
                    case "left":
                        currentPosition[1] = currentPosition[1] == 0
                            ? columns - 1
                            : currentPosition[1] - 1;
                        break;
                    case "right":
                        currentPosition[1] = (currentPosition[1] + 1) % columns;
                        break;
                }

                hovered[i] = fighters[currentPosition[0]][currentPosition[1]];
            }

            return hovered;
        }
    }
}
