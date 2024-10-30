using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyObject : MonoBehaviour
{
    private Player player;
    private EnemyBrain enemyBrain;
    [SerializeField] private Animator animation;
    private bool isDefead;
    private void Awake()
    {
        enemyBrain = FindObjectOfType<EnemyBrain>();
        player = FindObjectOfType<Player>();
    }
    private void LateUpdate()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 0.4f && !isDefead)
        {
            isDefead = true;
            Scope scope = FindObjectOfType<Scope>();
            Scope.ScoreValue += 1 * scope.Facor;
            scope.playerScore.text = $"{Scope.ScoreValue}";

            StartCoroutine(timer());
            IEnumerator timer()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);
                Destroy(this.gameObject);
            }
        }
        if (Vector2.Distance(this.transform.position, enemyBrain.transform.position) < 0.4f && !isDefead)
        {
            isDefead = true;

            Scope.ScoreValueEnemy += 1;
            FindObjectOfType<Scope>().enemyScore.text = Scope.ScoreValueEnemy.ToString();

            StartCoroutine(timer2());
            IEnumerator timer2()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);
                Destroy(this.gameObject);
            }
        }
    }
}
