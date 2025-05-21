// BattleState.cs
// BattleSystem で使う全ステートをここに定義

namespace trienix.Constants
{
    /// <summary>
    /// 戦闘の進行状態を管理するための列挙型
    /// </summary>
    public enum BattleState
    {
        /// <summary>バトル開始前の初期設定</summary>
        Start,
        /// <summary>プレイヤーの行動ターン</summary>
        PlayerTurn,
        /// <summary>敵の行動ターン</summary>
        EnemyTurn,
        /// <summary>行動中やアニメーション再生中など、入力受付停止</summary>
        Busy,
        /// <summary>バトル終了後の終了処理</summary>
        End
    }
}
