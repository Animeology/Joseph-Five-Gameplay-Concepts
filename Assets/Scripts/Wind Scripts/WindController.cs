using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class WindController : MonoBehaviour
{
    public float WindOnSeconds = 0.01f;
    public float WindOffSeconds = 0.01f;

    public Vector2 WindOnAmount;
    public Vector2 WindOffAmount = Vector2.zero;

    AudioSource m_audioSource;

    public static Vector2 currentWindAmount { get; private set; }

    // Start is called before the first frame update
    void OnEnable()
    {
        m_audioSource = GetComponent<AudioSource>();
        StartCoroutine(WindCoroutine());
    }

    IEnumerator WindCoroutine()
    {
        while(true)
        {
            currentWindAmount = WindOffAmount;
            m_audioSource.Stop();
            WriteWindAmount();
            yield return new WaitForSecondsRealtime(WindOffSeconds);

            currentWindAmount = WindOnAmount;
            m_audioSource.Play();
            WriteWindAmount();
            yield return new WaitForSecondsRealtime(WindOnSeconds);
        }
    }

    void WriteWindAmount()
    {
        //Debug.Log($"The current wind amount is {currentWindAmount}");
    }
}
