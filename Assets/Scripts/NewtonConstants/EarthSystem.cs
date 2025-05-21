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
        player = new Character { Name = "勇者", HP = 20, MaxHP = 20, Attack = 5 };
        enemy = new Character { Name = "スライム", HP = 15, MaxHP = 15, Attack = 3 };
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
                Debug.Log($"{enemy.Name}を倒した！ プレイヤーの勝利！");
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
                Debug.Log($"{player.Name}は倒れた…… 敗北。");
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
