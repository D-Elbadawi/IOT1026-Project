namespace MinotaurLabyrinth
{
    /// <summary>
    /// A factory class for creating MyMosterRoom instances based on MyMosterRoomType.
    /// </summary>
    public sealed class MyMosterRoomFactory
    {
        private MyMosterRoomFactory() { }
        private static readonly Lazy<MyMosterRoomFactory> _lazy = new(() => new MyMosterRoomFactory());

        /// <summary>
        /// Singleton instance of MyMosterRoomFactory.
        /// </summary>
        public static MyMosterRoomFactory Instance => _lazy.Value;

        private readonly Dictionary<MyMosterRoomType, Func<MyMosterRoom>> _callbacks = new();

        /// <summary>
        /// Registers a MyMosterRoomType with a function that creates a MyMosterRoom instance.
        /// </summary>
        /// <param name="type">The MyMosterRoomType to register.</param>
        /// <param name="createFn">The function that creates the MyMosterRoom instance.</param>
        /// <returns>True if the MyMosterRoomType was registered successfully, false otherwise.</returns>
        public bool Register(MyMosterRoomType type, Func<MyMosterRoom> createFn)
        {
            if (_callbacks.ContainsKey(type))
            {
                return false;
            }

            _callbacks.Add(type, createFn);
            return true;
        }

        /// <summary>
        /// Creates a MyMosterRoom instance based on the given MyMosterRoomType.
        /// </summary>
        /// <param name="type">The MyMosterRoomType of the MyMosterRoom to be created.</param>
        /// <returns>A MyMosterRoom instance of the specified MyMosterRoomType.</returns>
        public MyMosterRoom BuildMyMosterRoom(MyMosterRoomType type)
        {
            if (_callbacks.TryGetValue(type, out Func<MyMosterRoom>? function))
            {
                return function();
            }

            var atype = Type.GetType($"MinotaurLabyrinth.{type}") ?? throw new Exception($"Could not find type {type}");
            var MyMosterRoom = (MyMosterRoom)Activator.CreateInstance(atype)!;
            Register(type, () => (MyMosterRoom)Activator.CreateInstance(atype)!);
            return MyMosterRoom;
        }
    }
}
