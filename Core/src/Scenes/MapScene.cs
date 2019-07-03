using System;
using System.Collections.Generic;
using System.IO;
using DotFeather;
using DotFeather.Router;
using Newtonsoft.Json;

namespace NeoDefenderEngine
{
    public class MapScene : Scene
    {
        public override void OnStart(Router router, Dictionary<string, object> args)
        {
            if (!(args.Get("level") is int level))
                throw new Exception();
            var lvldat = Load<LevelData>($"./Resources/Levels/Level {level}/lvldat.json");
            if (!(args.Get("area") is int area))
                area = lvldat.FirstArea;
            var areadat = Load<AreaData>($"./Resources/Levels/Level {level}/Area {1}/area.json");
            Root.Scale = Vector.One * 2;
            Root.Add(Sprite.LoadFrom($"Resources/Graphics/{areadat.BG}"));
        }

        public T Load<T>(string path) => JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
    }
}