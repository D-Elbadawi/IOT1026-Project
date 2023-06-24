namespace MinotaurLabyrinth
{
    public class Wall : MyMosterRoom
    {
        static Wall()
        {
            MyMosterRoomFactory.Instance.Register(MyMosterRoomType.Wall, () => new Wall());
        }
        public override MyMosterRoomType Type { get; } = MyMosterRoomType.Wall;

        // No need to override the Activate method here
        public override DisplayDetails Wall.Display()
        {
            return new DisplayDetails("[ ]", ConsoleColor.Black);
        }
    }
}
