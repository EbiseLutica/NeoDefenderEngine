using System;
using System.Collections.Generic;
using System.IO;
using DotFeather.Router;

namespace NeoDefenderEngine
{
    public class MapScene : Scene
    {
        public override void OnStart(Router router, Dictionary<string, object> args)
        {
            if (!(args.Get("level") is int level))
                throw new Exception();
            if (!(args.Get("area") is int area))
                area = 1;
            
            File.ReadAllText($"./Resources/Levels/Level {level}/lvldat.json");
        }
    }
}