using System;
using System.Drawing;
using System.Threading.Tasks;
using DotFeather;
using DotFeather.Router;

namespace NeoDefenderEngine
{
    public class TitleScene : Scene
    {
        
    }

    public class SplashScene : Scene
    {
        public override void OnStart(Router router, System.Collections.Generic.Dictionary<string, object> args)
        {
            RunAsync(router);
        }

        async Task RunAsync(Router router)
        {
            ui = new Graphic();
            statText = new TextDrawable("", new Font(FontFamily.GenericMonospace, 16), Color.White);

            Root.Add(ui);
            Root.Add(statText);
            var prog = new Progress<InitializeStatus>((stat) => 
            {
                statusText = stat.Message;
                ratio = stat.ProgressPercentage / 100.0;
                Console.WriteLine(stat.Message);
            });

            await Resources.I.LoadAllMusic(prog);
            await Resources.I.LoadAllSfx(prog);
            await Resources.I.LoadAllText(prog);
            await Task.Delay(500);
            router.ChangeScene<SoundTestScene>();

        }

        public override void OnUpdate(Router router, DFEventArgs e)
        {
            statText.Text = statusText;
            statText.Location = new Vector(router.Game.Width / 2 - statText.Texture.Size.Width / 2, router.Game.Height - 32);
            DrawBar(router.Game);
        }

        public void DrawBar(GameBase game)
        {
            ui.Clear();
            var barWidth = 256;
            var start = new Vector(game.Width / 2 - barWidth / 2, game.Height / 2 + 64);
            var end = start + new Vector(barWidth, 64);
            var mid = start + new Vector((int)(barWidth * ratio), 64);

            ui.Rect((int)start.X, (int)start.Y, (int)mid.X, (int)mid.Y, Color.White);
            ui.Rect((int)start.X, (int)start.Y, (int)end.X, (int)end.Y, Color.Transparent, 4, Color.White);
        }

        string statusText;
        double ratio;
        Graphic ui;
        TextDrawable statText;
    }
}