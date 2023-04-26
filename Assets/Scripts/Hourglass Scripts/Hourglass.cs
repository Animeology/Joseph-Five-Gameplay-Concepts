using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Hourglass : MonoBehaviour
{
    public int timeToMove = 1;
    public int timeToStop = 1 ;

    AudioSource m_audioSource;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_audioSource = GetComponent<AudioSource>();
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            m_audioSource.Stop();
            Time.timeScale = 1;
            for(int i = timeToMove; i > 0; i--)
            {
                SetLabel(i);
                yield return new WaitForSecondsRealtime(1);
            }

            Time.timeScale = 0;
            for (int i = timeToStop; i > 0; i--)
            {
                SetLabel(i);
                m_audioSource.Play();
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }

    void SetLabel(int timer)
    {
       // Debug.Log(timer.ToString());
    }
}
