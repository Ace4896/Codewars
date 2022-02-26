namespace Codewars
{
    using System;

    public class Triangular
    {
        public bool isTriangular(int T)
        {
            // Re-arrange to solve for n (positive solution only):
            // n = (-1 + sqrt(1 + 8T)) / 2
            // So this is triangular if (1 + 8T) is a square number
            // The discriminant can get very large, so need to convert to long
            var discriminant = 1 + 8L * T;
            var sqrt = Math.Sqrt(discriminant);
            return Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) < double.Epsilon;
        }
    }
}
