using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [System.Serializable]
    public struct Audio
    {
        public AudioSource audio;
        public string name;
    }
    public Audio[] Sounds;

    private Dictionary<string, AudioSource> collection = new Dictionary<string, AudioSource>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (var sound in Sounds)
        {
            if (collection.ContainsKey(sound.name) == false)
                collection.Add(sound.name, sound.audio);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource GetSound (string givenName)
    {
        AudioSource currentSound = collection[givenName];
        return currentSound;
    }

    public void PlaySound (string givenName, float startVolume, float targetVolume)
    {
        AudioSource currentSound = collection[givenName];
        currentSound.Play();
        StartCoroutine(FadeIn(currentSound, 1, targetVolume, startVolume));
    }
    
    public void StopSound (string givenName)
    {
        AudioSource currentSound = collection[givenName];
        StartCoroutine(FadeOut(currentSound, 1));
    }



    static IEnumerator FadeIn(AudioSource audioSource, float duration, float targetVolume, float startVolume)
    {
        float currentTime = 0;
        //float targetVolume = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }

    static IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }

        if (currentTime == duration)
        {
            audioSource.Stop();
            //audioSource.volume = start;
        }

        yield break;
    }
}
