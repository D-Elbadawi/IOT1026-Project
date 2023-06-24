using System;

namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a generic MyMosterRoom in the labyrinth.
    /// </summary>
    public class MyMosterRoom : Room
    {
        private Monster? _monster;
        private bool _isLocked;
        private bool _hasKey;

        /// <summary>
        /// Gets the MyMosterRoom type.
        /// </summary>
        public override MyMosterRoomType Type { get; } = MyMosterRoomType.MyMosterRoom;

        /// <summary>
        /// Gets a value indicating whether the MyMosterRoom currently contains a monster or an event.
        /// </summary>
        public override bool IsActive { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the MyMosterRoom is locked.
        /// </summary>
        public bool IsLocked
        {
            get { return _isLocked; }
            set { _isLocked = value; }
        }

        /// <summary>
        /// Adds a monster to the MyMosterRoom.
        /// </summary>
        /// <param name="monster">The monster to be added.</param>
        public void AddMonster(Monster monster)
        {
            IsActive = true;
            _monster = monster;
        }

        /// <summary>
        /// Removes a monster from the MyMosterRoom.
        /// </summary>
        public void RemoveMonster()
        {
            IsActive = false;
            _monster = null;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the MyMosterRoom has a key.
        /// </summary>
        public bool HasKey
        {
            get { return _hasKey; }
            set { _hasKey = value; }
        }

        /// <summary>
        /// Displays sensory information about the MyMosterRoom, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the MyMosterRoom.</param>
        /// <param name="heroDistance">The distance between the hero and the MyMosterRoom.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (_monster != null)
            {
                return _monster.DisplaySense(hero, heroDistance);
            }
            return false;
        }

        /// <summary>
        /// Activates the MyMosterRoom, triggering interactions with the hero.
        /// </summary>
        /// <param name="hero">The hero entering the MyMosterRoom.</param>
        /// <param name="map">The current game map.</param>
        public override void Activate(Hero hero, Map map)
        {
            if (IsLocked && !HasKey)
            {
                Console.WriteLine("The MyMosterRoom is locked. You need a key to unlock it.");
                return;
            }

            _monster?.Activate(hero, map);
        }

        /// <inheritdoc/>
        public override string Display()
        {
            return IsActive ? $"[{Type.ToString()[0]}]" : base.Display();
        }

        /// <summary>
        /// Displays sensory information about the MyMosterRoom, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the MyMosterRoom.</param>
        /// <param name="heroDistance">The distance between the hero and the MyMosterRoom.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You shudder as you recall your near-death experience with the now-defunct pit in this MyMosterRoom.", ConsoleColor.DarkGray);
                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "You feel a draft. There is a pit in a nearby MyMosterRoom!" : "Your intuition tells you that something dangerous is nearby.", ConsoleColor.DarkGray);
                return true;
            }
            return false;
        }
    }
}
