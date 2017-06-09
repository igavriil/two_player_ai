using System;

namespace TwoPlayerAi.DataStructures
{
    public class Vector : IEquatable<Vector>
    {
        public int X { get; }
        public int Y { get; }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Distance(Vector other)
        {
            double square_distance = Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2);
            return (int)Math.Sqrt(square_distance);
        }

        public int SquareDistance(Vector other)
        {
            return (int)(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
        }

        public int ManhattanDistance(Vector other)
        {
            return (Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y));
        }

        public int DiagonalDistance(Vector other)
        {
            return Math.Min(Math.Abs(this.X - other.X), Math.Abs(this.Y - other.Y));
        }

        public int CrossProductDistance(Vector startVector, Vector endVector)
        {
            int dx1 = this.X - startVector.X;
            int dy1 = this.Y - startVector.Y;
            int dx2 = startVector.X - endVector.X;
            int dy2 = startVector.Y - endVector.Y;
            return Math.Abs(dx1*dy2 - dx2*dy1);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector operator *(int multiplier, Vector vector)
        {
            return new Vector(multiplier * vector.X, multiplier * vector.Y);
        }

        public bool Equals(Vector other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return ((this.X == other.X) && (this.Y == other.Y));
            }
        }

        public override bool Equals(object other)
        {
            Vector vector = other as Vector;
            return this.Equals(vector);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"x:{X},y:{Y}";
        }
    }
}