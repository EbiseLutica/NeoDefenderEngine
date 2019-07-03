namespace NeoDefenderEngine
{
    /// <summary>
    /// lvldat.json を表現します。
    /// </summary>
    public class LevelData
    {
        /// <summary>
        /// はじめに入るエリアの番号を取得または設定します。
        /// </summary>
        public int FirstArea { get; set; }

        /// <summary>
        /// 制限時間を取得または設定します。
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// レベルの説明を取得または設定します。
        /// </summary>
        public string Desc { get; set; }
    }
}