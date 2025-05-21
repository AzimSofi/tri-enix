// BattleSystem.cs
using trienix.Constants;
using UnityEngine;
using System.Collections;

public class Character
{
    public string Name;
    public int HP;
    public int MaxHP;
    public int Attack;
    // 必要なら防御力など追加
}

public class BattleSystem : MonoBehaviour
{
    // バトルの状態を管理
    private BattleState state = BattleState.Start;
    // プレイヤーと敵のデータ
    private Character player;
    private Character enemy;

    private void Start()
    {
        // 仮データで初期化
        player = new Character { Name = "あなた", HP = 20, MaxHP = 20, Attack = 3 };
        enemy = new Character { Name = "雑魚", HP = 10, MaxHP = 10, Attack = 6};
        // バトル開始
        StartCoroutine(BattleLoop());
    }

    private IEnumerator BattleLoop()
    {
        bool battleOngoing = true;
        while (battleOngoing)
        {
            // プレイヤーターン
            state = BattleState.PlayerTurn;
            Debug.Log($"現在のステート: {state}");
            yield return StartCoroutine(PlayerTurn());
            // 勝敗判定
            if (enemy.HP <= 0)
            {
                Debug.Log($"{enemy.Name}を排除した！ けど調子に乗るなよ！");
                battleOngoing = false;
                break;
            }

            // 敵ターン
            state = BattleState.EnemyTurn;
            Debug.Log($"現在のステート: {state}");
            yield return StartCoroutine(EnemyTurn());
            // 勝敗判定
            if (player.HP <= 0)
            {
                Debug.Log($"{player.Name}の方が雑魚か…… 残念。");
                battleOngoing = false;
                break;
            }
        }
        state = BattleState.End;
        Debug.Log($"現在のステート: {state}");
        EndBattle();
    }

    private IEnumerator PlayerTurn()
    {
        // 仮：攻撃コマンドのみ
        enemy.HP -= player.Attack;
        Debug.Log($"{player.Name}が{enemy.Name}に{player.Attack}ダメージ！ 残りHP:{enemy.HP}");
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator EnemyTurn()
    {
        // 仮：攻撃コマンドのみ
        player.HP -= enemy.Attack;
        Debug.Log($"{enemy.Name}が{player.Name}に{enemy.Attack}ダメージ！ 残りHP:{player.HP}");
        yield return new WaitForSeconds(1f);
    }

    private void EndBattle()
    {
        Debug.Log("バトル終了");
    }
}
