using Aiv.Fast2D;

namespace Infection
{
    class Program
    {
        public static Window Window;
        public static float DeltaTime { get { return Window.DeltaTime; } }

        static void Main(string[] args)
        {
            Window = new Window(1280, 720, "Infection");
            Window.SetVSync(true);

            BallMgr.Init();

            while (Window.IsOpened)
            {
                //INPUT

                //UPDATE
                BallMgr.Update();
                PhysicsMgr.CheckCollision();

                //DRAW
                BallMgr.Draw();

                Window.Update();
            }
        }
    }
}
