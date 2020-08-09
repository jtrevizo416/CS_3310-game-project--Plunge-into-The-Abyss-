using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerHelper : MonoBehaviour
{
    public EnemyController enemy;

    private void IsReady()
    {
        enemy.IsReady();
    }

    private void IsNotReady()
    {
        enemy.IsNotReady();
    }

    private void DeathAnimationDone()
    {
        enemy.DeathAnimationDone();
    }
}
