using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoneyView : MonoBehaviour
{
    public UnityEngine.UI.Text money;
    public void LateUpdate()
    {
        money.text = Scope.ScoreValueEnemy.ToString();
    }
}
