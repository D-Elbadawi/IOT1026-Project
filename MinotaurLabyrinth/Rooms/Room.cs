/*namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a generic MyMosterRoom in the labyrinth.
    /// </summary>
    public class Room : IActivatable
    {
        static Room()
        {
            MyMosterRoomFactory.Instance.Register(MyMosterRoomType.MyMosterRoom, () => new MyMosterRoom());
        }

        private Monster? _monster;

        /// <summary>
        /// Gets the MyMosterRoom type.
        /// </summary>
        public virtual MyMosterRoomType Type { get; } = MyMosterRoomType.MyMosterRoom;

        /// <summary>
        /// Gets a value indicating whether the MyMosterRoom is currently contains a monster or an event.
        /// </summary>
        public virtual bool IsActive { get; protected set; }

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
        /// Displays sensory information about the MyMosterRoom, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the MyMosterRoom.</param>
        /// <param name="heroDistance">The distance between the hero and the MyMosterRoom.</param>
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
        /// Activates the MyMosterRoom, triggering interactions with the hero.
        /// </summary>
        /// <param name="hero">The hero entering the MyMosterRoom.</param>
        /// <param name="map">The current game map.</param>
        public virtual void Activate(Hero hero, Map map)
        {
            _monster?.Activate(hero, map);
        }

        /// <summary>
        /// Displays the current state of the MyMosterRoom.
        /// </summary>
        /// <returns>Returns a DisplayDetails object containing the MyMosterRoom's display information.</returns>
        public virtual DisplayDetails Display()
        {
            if (_monster != null)
                return _monster.Display();
            else
                return new DisplayDetails("[ ]", ConsoleColor.Gray);
        }
    }
}
*/