using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightJitter : MonoBehaviour
{
    public float speed = 1;
    public float minIntensity, maxIntensity;

    float random;
    Light m_light;
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
        random = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time * speed);
        m_light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
