namespace Mars.Tests
{
    using System;
    using System.Linq;

    public class Rover
    {
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Orientation { get; private set; }

        public string Position => $"{X} {Y} {Orientation}";

        public Rover(string size, string position)
        {
            if (string.IsNullOrEmpty(size))
                throw new ArgumentNullException(nameof(size));

            if (string.IsNullOrEmpty(position))
                throw new ArgumentNullException(nameof(position));

            var sizes = size.Split(' ');
            if (sizes.Length != 2)
                throw new ArgumentException("The size must contain 2 number separeted by a single space.");

            var sizeX = int.Parse(sizes[0]);
            var sizeY = int.Parse(sizes[1]);

            var positions = position.Split(' ');

            if (positions.Length != 3)
                throw new ArgumentException("The position must contain 3 elements separeted by a single space.");

            var x = int.Parse(positions[0]);
            var y = int.Parse(positions[1]);
            var o = char.Parse(positions[2]);

            Init(sizeX, sizeY, x, y, o);
        }

        public Rover(int sizeX, int sizeY, int x, int y, char orientation)
        {
            Init(sizeX, sizeY, x, y, orientation);
        }

        private void Init(int sizeX, int sizeY, int x, int y, char orientation)
        {
            if (X > sizeX) throw new ArgumentException("The X position cannot be greater then X size.", nameof(x));
            if (Y > sizeY) throw new ArgumentException("The Y position cannot be greater then Y size.", nameof(y));            

            SizeX = sizeX;
            SizeY = sizeY;
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public char Move(char m)
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

            return Orientation;
        }

        public string Move(string movements)
        {
            if (string.IsNullOrEmpty(movements))
                throw new ArgumentNullException(nameof(movements));

            foreach (var c in movements)
                Move(c);

            return Position;
        }
    }
}