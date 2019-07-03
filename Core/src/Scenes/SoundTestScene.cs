using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DotFeather;
using DotFeather.Router;

namespace NeoDefenderEngine
{
    public class SoundTestScene : Scene
    {
        public override void OnStart(Router router, Dictionary<string, object> args)
        {
            aud = new AudioPlayer();
            
            bgmMap = Directory.EnumerateFiles("./Resources/Music/")
                .Select(f => (Path.GetFileName(f), new GroorineAudioSource(File.OpenRead(f)) as IAudioSource))
                .ToArray();
            
            sfxMap = Directory.EnumerateFiles("./Resources/Sounds/")
                .Select(f => ((Sounds)int.Parse(Path.GetFileNameWithoutExtension(f)), new WaveAudioSource(f) as IAudioSource))
                .ToArray();
            
            bgm = new TextDrawable("", new Font(FontFamily.GenericSansSerif, 16), Color.White)
            {
                Location = new Vector(0, 0),
            };
            sfx = new TextDrawable("", new Font(FontFamily.GenericSansSerif, 16), Color.White)
            {
                Location = new Vector(0, 32),
            };

			Root.Add(bgm);
			Root.Add(sfx);
        }
        public override void OnUpdate(Router router, DotFeather.DFEventArgs e)
        {
            bgm.Text = $"BGM: {bgmMap[bgmIndex].Item1}";
            sfx.Text = $"Sfx: {sfxMap[sfxIndex].Item1}";

            bgm.Color = cursor == 0 ? Color.Red : Color.White;
            sfx.Color = cursor == 0 ? Color.White : Color.Red;

            if (Input.Keyboard.Up.IsKeyDown)
                cursor--;
            if (Input.Keyboard.Down.IsKeyDown)
                cursor++;
            if (Input.Keyboard.Left.IsKeyDown)
                if (cursor == 0)
                    bgmIndex--;
                else
                    sfxIndex--;
            if (Input.Keyboard.Right.IsKeyDown)
                if (cursor == 0)
                    bgmIndex++;
                else
                    sfxIndex++;

            if (cursor < 0) cursor = 0;
            if (cursor > 1) cursor = 1;
            if (bgmIndex < 0) bgmIndex = bgmMap.Length - 1;
            if (bgmIndex >= bgmMap.Length) bgmIndex = 0;
            if (sfxIndex < 0) sfxIndex = sfxMap.Length - 1;
            if (sfxIndex >= sfxMap.Length) sfxIndex = 0;

            if (Input.Keyboard.Space.IsKeyDown)
            {
                if (cursor == 0)
                    aud.Play(bgmMap[bgmIndex].Item2);
                else
                    aud.PlayOneShotAsync(sfxMap[sfxIndex].Item2);
            }

			if (Input.Keyboard.BackSpace.IsKeyDown)
            {
				aud.Stop();
            }
        }

        public override void OnDestroy(Router router)
        {
            aud.Dispose();
        }

        private AudioPlayer aud;
        
        private TextDrawable bgm, sfx;

        private (Sounds, IAudioSource)[] sfxMap;

        private (string, IAudioSource)[] bgmMap;

        private int cursor;
        
        private int bgmIndex, sfxIndex;
    }

    public enum Sounds
	{
		/// <summary>
		///     0 コインの音。
		/// </summary>
		GetCoin,

		/// <summary>
		///     1 小さなキャラがジャンプする音。
		/// </summary>
		SmallJump,

		/// <summary>
		///     2 大きなキャラがジャンプする音。
		/// </summary>
		BigJump,

		/// <summary>
		///     3 Citringo のジングル。
		/// </summary>
		Citringo,

		/// <summary>
		///     4 プレイヤーが死んだ音。
		/// </summary>
		PlayerMiss,

		/// <summary>
		///     5 踏み潰す音。
		/// </summary>
		Stepped,

		/// <summary>
		///     6 悲鳴。
		/// </summary>
		Killed,

		/// <summary>
		///     7 矢を射つ音。
		/// </summary>
		ShootArrow,

		/// <summary>
		///     8 矢が刺さる音。
		/// </summary>
		StuckArrow,

		/// <summary>
		///     9 着地音。
		/// </summary>
		Land,

		/// <summary>
		///     10 水飛沫。
		/// </summary>
		WaterSplash,

		/// <summary>
		///     11 破壊音。
		/// </summary>
		Destroy,

		/// <summary>
		///     12 泳ぐ音。
		/// </summary>
		Swim,

		/// <summary>
		///     13 主人公がパワーアップする音。
		/// </summary>
		PowerUp,

		/// <summary>
		///     14 主人公がパワーダウンする音。
		/// </summary>
		PowerDown,

		/// <summary>
		///     15 アイテムが出現する音。
		/// </summary>
		ItemSpawn,

		/// <summary>
		///     16 プレイヤーのライフが上がる音。
		/// </summary>
		Player1Up,

		/// <summary>
		///     17 主人公が武器のあるパワーアップをする音。
		/// </summary>
		GetWeapon,

		/// <summary>
		///     18 ファイアーボールが投げられる音。
		/// </summary>
		ShootFire,

		/// <summary>
		///     19 タイトルロゴが光るときの音。
		/// </summary>
		Flash,

		/// <summary>
		///     20 無敵が終了する警告音。
		/// </summary>
		WarningMuteki,

		/// <summary>
		///     21 食べる音1。
		/// </summary>
		Paku1,

		/// <summary>
		///     22 食べる音2。
		/// </summary>
		Paku2,

		/// <summary>
		///     23 何かが動く音。
		/// </summary>
		Poyo,

		/// <summary>
		///     24 カーソルが確定される音。
		/// </summary>
		Pressed,

		/// <summary>
		///     25 カーソルが移動する音。
		/// </summary>
		Selected,

		/// <summary>
		///     26 しゃべる音。
		/// </summary>
		Speaking,

		/// <summary>
		///     27 シャッターを閉める音。
		/// </summary>
		Shutter,

		/// <summary>
		///     28 レーザーが発射される音。
		/// </summary>
		Razer,

		/// <summary>
		///     29 カメラがオートフォーカスする音。
		/// </summary>
		Focus,

		/// <summary>
		///     30 入力を取り消したときの音。
		/// </summary>
		Back,

		/// <summary>
		///     31 回復したときの音。
		/// </summary>
		LifeUp,

		/// <summary>
		///     32 何かに入るときの音。
		/// </summary>
		Into,
        
		Explode,
		Dumping,
		BalloonBroken
	}
}