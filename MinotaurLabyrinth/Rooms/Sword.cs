using System;

namespace MinotaurLabyrinth
{
    public class Key : Room
    {
        static Key()
        {
            RoomFactory.Instance.Register(RoomType.Key, () => new Key());
        }

        public override RoomType Type { get; } = RoomType.Key;

        public override DisplayDetails Display()
        {
            return new DisplayDetails("[K]", ConsoleColor.Yellow);
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 0)
            {
                if (hero.HasKey)
                {
                    ConsoleHelper.WriteLine("This is the key room, but you've already picked up the key!", ConsoleColor.DarkCyan);
                }
                else
                {
                    ConsoleHelper.WriteLine("You can sense that the key is nearby!", ConsoleColor.DarkCyan);
                }
                return true;
            }
            return false;
        }
    }


}
