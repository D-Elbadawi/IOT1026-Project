
using System;

namespace MinotaurLabyrinth
{


    /// <summary>
    /// Represents a generic room in the labyrinth.
    /// </summary>
    public class Room : IActivatable
    {
        static Room()
        {
            RoomFactory.Instance.Register(RoomType.key, () => new Key());
        }

        private Monster? _monster;
        private bool _isLocked;
        private bool _hasKey;

        /// <summary>
        /// Gets the room type.
        /// </summary>
        public virtual RoomType Type { get; } = RoomType.Room;

        /// <summary>
        /// Gets a value indicating whether the room currently contains a monster or an event.
        /// </summary>
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room is locked.
        /// </summary>
        public bool IsLocked
        {
            get { return _isLocked; }
            set { _isLocked = value; }
        }

        /// <summary>
        /// Adds a monster to the room.
        /// </summary>
        /// <param name="monster">The monster to be added.</param>
        public void AddMonster(Monster monster)
        {
            IsActive = true;
            _monster = monster;
        }

        /// <summary>
        /// Removes a monster from the room.
        /// </summary>
        public void RemoveMonster()
        {
            IsActive = false;
            _monster = null;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the room has a key.
        /// </summary>
        public bool HasKey
        {
            get { return _hasKey; }
            set { _hasKey = value; }
        }

        /// <summary>
        /// Displays sensory information about the room, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the room.</param>
        /// <param name="heroDistance">The distance between the hero and the room.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public virtual bool DisplaySense(Hero hero, int heroDistance)
        {
            if (_monster != null)
            {
                return _monster.DisplaySense(hero, heroDistance);
            }
            return false;
        }

        /// <summary>
        /// Activates the room, triggering interactions with the hero.
        /// </summary>
        /// <param name="hero">The hero entering the room.</param>
        /// <param name="map">The current game map.</param>
        public virtual void Activate(Hero hero, Map map)
        {
            if (IsLocked && !HasKey)
            {
                Console.WriteLine("The room is locked. You need a key to unlock it.");
                return;
            }

            _monster?.Activate(hero, map);
        }

        /// <summary>
        /// Displays the current state of the room.
        /// </summary>
        /// <returns>Returns a DisplayDetails object containing the room's display information.</returns>
        public virtual DisplayDetails Display()
        {
            if (_monster != null)
                return _monster.Display();
            else if (IsLocked)
                return new DisplayDetails("[X]", ConsoleColor.Gray); // Display a locked room
            else if (Type == RoomType.Sword) //

                return new DisplayDetails("[K]", ConsoleColor.Yellow); // Display the sword room as [K]
            else
                return new DisplayDetails("[ ]", ConsoleColor.Gray);
        }
    }
}
