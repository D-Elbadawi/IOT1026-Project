﻿using System;

namespace MinotaurLabyrinth
{
    public class Key : MyMosterRoom
    {
        static Key()
        {
            MyMosterRoomFactory.Instance.Register(MyMosterRoomType.Key, () => new Key());
        }

        public override MyMosterRoomType Type { get; } = MyMosterRoomType.Key;

        public override DisplayDetails Key.Display()
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
