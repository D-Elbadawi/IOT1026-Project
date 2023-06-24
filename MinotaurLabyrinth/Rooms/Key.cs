using System;

namespace MinotaurLabyrinth
{
    public class KeyMyMosterRoom : ItemMyMosterRoom
    {
        static KeyMyMosterRoom()
        {
            MyMosterRoomFactory.Instance.Register(MyMosterRoomType.Key, () => new KeyMyMosterRoom());
        }

        public override MyMosterRoomType Type { get; } = MyMosterRoomType.Key;

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
                    ConsoleHelper.WriteLine("This is the key MyMosterRoom, but you've already picked up the key!", ConsoleColor.DarkCyan);
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
