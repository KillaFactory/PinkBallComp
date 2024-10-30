using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyView : MonoBehaviour
{
    public UnityEngine.UI.Text money;
    public void LateUpdate()
    {
        money.text = Scope.ScoreValue.ToString();
    }
}
