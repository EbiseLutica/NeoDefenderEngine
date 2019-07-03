using System;
using System.IO;

namespace NeoDefenderEngine
{
    /// <summary>
    /// マップの保存・読み込み機能を提供します。
    /// </summary>
    public static class MapUtility
	{
        /// <summary>
        /// マップを保存します。
        /// </summary>
		public static void Save(byte[,,] array, string path)
		{
			var w = array.GetLength(0);
			var h = array.GetLength(1);

			using(var bw = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                bw.Write("CITCHIP".AsSpan());
                bw.Write(w);
                bw.Write(h);

                for (var z = 0; z < 2; z++)
                    for (var y = 0; y < h; y++)
                        for (var x = 0; x < w; x++)
                            bw.Write(array[x, y, z]);
            }
		}

        /// <summary>
        /// マップを読み込みます。
        /// </summary>
		public static byte[,,] Load(string path)
		{
			using (var br = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                if (new string(br.ReadChars(7)) != "CITCHIP")
                {
                    br.Close();
                    throw new Exception("指定したファイルは、有効な Defender Story マップファイルではありません。");
                }
                var w = br.ReadInt32();
                var h = br.ReadInt32();

                var array = new byte[w, h, 2];

                for (var z = 0; z < 2; z++)
                    for (var y = 0; y < h; y++)
                        for (var x = 0; x < w; x++)
                            array[x, y, z] = br.ReadByte();
                return array;
            }
		}
	}

}