using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVictoryChecker : MonoBehaviour
{
   public GameObject VictoryZone;

    IEnumerator Start()
    {
        while (true)
        {
            VictoryZone.SetActive(LightZone.AllAreLit);
            yield return new WaitForSeconds(1);
        }
    }
}
