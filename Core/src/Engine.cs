using System;
using System.Collections.Generic;
using DotFeather;
using DotFeather.Router;

namespace NeoDefenderEngine
{
    public class Engine : GameBase
    {
        public Engine(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
        {
            router = new Router(this);
            router.ChangeScene<SoundTestScene>(new Dictionary<string, object>
            {
                { "level", 1 },
                { "area", 1 }, 
            });
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