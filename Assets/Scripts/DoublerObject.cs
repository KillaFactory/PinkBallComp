using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublerObject : MonoBehaviour
{
    private Player player;
    [SerializeField] private Animator animation;
    private bool isDefead;

    private EnemyBrain enemyBrain;
    public bool isPlus;
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
            GameManager gamer = FindObjectOfType<GameManager>();

            if (isPlus)
            {
                gamer.gameObject.SetActive(true);
                scope.Facor += 1;
                gamer.BallEffect.color = gamer.green_color;
            }
            else if (scope.Facor > 1)
            {
                gamer.gameObject.SetActive(false);
                scope.Facor -= 1;
                gamer.BallEffect.color = gamer.red_color;
            }

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

            StartCoroutine(timer4());
            IEnumerator timer4()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);

            }
        }
    }
}
