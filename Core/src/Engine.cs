using System;
using DotFeather;
using DotFeather.Router;

namespace NeoDefenderEngine
{
    public class Engine : GameBase
    {
        public Engine(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
        {
            router = new Router(this);
            router.ChangeScene<SoundTestScene>();
        }

        protected override void OnLoad(object sender, EventArgs e)
        {
            
        }

        protected override void OnUpdate(object sender, DFEventArgs e)
        {
            router?.Update(e);
        }

        private readonly Router router;
    }
}