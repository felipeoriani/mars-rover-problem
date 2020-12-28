namespace Mars.Tests
{
    using System;

    public class Rover
    {
        public int SizeX { get; }
        public int SizeY { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Orientation { get; private set; }

        public string Position => $"{X} {Y} {Orientation}";

        public Rover(int sizeX, int sizeY, int x, int y, char orientation)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void Move(char m)
        {
            m = char.ToUpper(m);
            if (m == 'M')
            {
                switch (Orientation)
                {
                    case 'N': if (Y < SizeY) Y++; break;
                    case 'S': if (Y > 0) Y--; break;
                    case 'E': if (X < SizeX) X++; break;
                    case 'W': if (X > 0) X--; break;
                }
            }
            else
            {
                Orientation = m switch
                {
                    'L' => Orientation switch
                    {
                        'N' => 'W',
                        'W' => 'S',
                        'S' => 'E',
                        'E' => 'N',
                        _ => throw new ArgumentOutOfRangeException(nameof(m), "The direction must be North, South, East or West following by the N, S, E or W.")
                    },
                    'R' => Orientation switch
                    {
                        'N' => 'E',
                        'E' => 'S',
                        'S' => 'W',
                        'W' => 'N',
                        _ => throw new ArgumentOutOfRangeException(nameof(m), "The direction must be North, South, East or West following by the N, S, E or W.")
                    },
                    _ => Orientation
                };
            }
        }

        public void Move(string movements)
        {
            if (string.IsNullOrEmpty(movements))
                throw new ArgumentNullException(nameof(movements));

            foreach (var c in movements)
                Move(c);
        }
    }
}