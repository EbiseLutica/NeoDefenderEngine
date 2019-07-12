using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

            l = level;
            a = area;

            Root.Scale = Vector.One * 2;
            Root.Add(Sprite.LoadFrom($"Resources/Graphics/{areadat.BG}"));

            backMap = new Tilemap(Vector.One * 16);
            frontMap = new Tilemap(Vector.One * 16);

            var mapdata = MapUtility.Load($"./Resources/Levels/Level {level}/Area {1}/map.citmap");
            textures = Texture2D.LoadAndSplitFrom($"./Resources/Graphics/{areadat.Mpt}.png", 16, 4, new Size(16, 16));

            var mpt = textures.Select(t => new Tile(t)).ToArray();

            var width = mapdata.GetLength(0);
            var height = mapdata.GetLength(1);

            for (var y = 0; y < height; y++)
                for (var x = 0; x < width; x++)
                {
                    backMap[x, y] = mpt[mapdata[x, y, 0]];
                    frontMap[x, y] = mpt[mapdata[x, y, 1]];
                }

            frontMap.Scale = backMap.Scale = Vector.One;

            Root.Add(backMap);
            Root.Add(entityLayer = new Container());
            Root.Add(frontMap);

            player = new AudioPlayer();
            var source = new GroorineAudioSource(File.OpenRead($"./Resources/Music/{areadat.Music}"));
            player.Play(source);
        }

        public override void OnUpdate(Router router, DFEventArgs e)
        {
            var point = Input.Mouse.Position;
            Vector vec = Vector.Zero;
            if (Input.Keyboard.Left)
                vec.X = 1;
            if (Input.Keyboard.Up)
                vec.Y = 1;
            if (Input.Keyboard.Right)
                vec.X = -1;
            if (Input.Keyboard.Down)
                vec.Y = -1;

            if (Input.Mouse.IsLeftClicked)
            {
                var delta = new Vector(point.X - prevPoint.X, point.Y - prevPoint.Y);
                frontMap.Location += delta / 2;
                backMap.Location += delta / 2;
            }

            if (Input.Keyboard.Space.IsKeyDown)
            {
                var d = new Dictionary<string, object>();
                if (l == 5)
                {
                    if (a == 1)
                    {
                        d["level"] = 5;
                        d["area"] = 2;
                    }
                    else
                    {
                        d["level"] = 1;
                        d["area"] = 1;
                    }
                }
                else
                {
                    d["level"] = l + 1;
                    d["area"] = 1;
                }
                router.ChangeScene<MapScene>(d);
            }
            
            frontMap.Location += vec * 128 * (float)e.DeltaTime;
            backMap.Location += vec * 128 * (float)e.DeltaTime;
            prevPoint = point;
        }

        public override void OnDestroy(Router router)
        {
            frontMap.Destroy();
            backMap.Destroy();
            entityLayer.Destroy();
            player.Dispose();
            foreach (var t in textures) t.Dispose();
        }

        public T Load<T>(string path) => JsonConvert.DeserializeObject<T>(File.ReadAllText(path));

        private Tilemap frontMap;
        private Tilemap backMap;
        private Container entityLayer;

        private Texture2D[] textures;

        private Point prevPoint;

        private int l, a;

        private AudioPlayer player;
    }

}