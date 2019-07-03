namespace NeoDefenderEngine
{
    /// <summary>
    /// area.json を表現します。
    /// </summary>
    public class AreaData
    {
        /// <summary>
        /// マップチップへのパスを取得または設定します。
        /// </summary>
        public string Mpt { get; set; }

        /// <summary>
        /// BGM ファイルへのパスを取得または設定します。
        /// </summary>
        public string Music { get; set; }

        /// <summary>
        /// 背景画像へのパスを取得または設定します。
        /// </summary>
        /// <value></value>
        public string BG { get; set; }

        /// <summary>
        /// 背景画像のスクロール速度を取得または設定します。
        /// </summary>
        /// <value></value>
        public double ScrollSpeed { get; set; }
    }
}