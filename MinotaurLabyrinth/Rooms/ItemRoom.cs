using System;

namespace MinotaurLabyrinth
{
    public class ItemMyMosterRoom : MyMosterRoom
    {
        // Register the ItemMyMosterRoom type in the MyMosterRoomFactory
        static ItemMyMosterRoom()
        {
            MyMosterRoomFactory.Instance.Register(MyMosterRoomType.Item, () => new ItemMyMosterRoom());
        }

        public override MyMosterRoomType Type { get; } = MyMosterRoomType.Item;

        public override DisplayDetails ItemMyMosterRoom.Display()
        {
            return new DisplayDetails("[I]", ConsoleColor.Magenta);
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 0)
            {
                ConsoleHelper.WriteLine("This is an item MyMosterRoom. You found something valuable!", ConsoleColor.DarkCyan);
                return true;
            }
            return false;
        }
    }
}
