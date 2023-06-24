using System;

namespace MinotaurLabyrinth
{
    public enum MyMosterRoomType
    {
        Empty,
        Wall,
        Entrance,
        Exit,
        Key,
        Monster,
        Item,
        Pit,
        MyMosterMyMosterRoom,
        Sword,
        MyMosterRoom
    }

    public class SwordMyMosterRoom : MyMosterRoom
    {
        static SwordMyMosterRoom()
        {
            MyMosterRoomFactory.Instance.Register(MyMosterRoomType.Sword, () => new SwordMyMosterRoom());
        }

        public override MyMosterRoomType Type { get; } = MyMosterRoomType.Sword;

        public override DisplayDetails Display()
        {
            return new DisplayDetails("[S]", ConsoleColor.DarkYellow);
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 0)
            {
                ConsoleHelper.WriteLine("This is a MyMosterRoom with a sword!", ConsoleColor.DarkCyan);
                return true;
            }
            return false;
        }
    }
}
