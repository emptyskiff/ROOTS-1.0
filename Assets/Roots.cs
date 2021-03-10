using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roots : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private float timeInSeconds;

    [SerializeField] [Range(0f,1f)] private float fadeRange;
    [SerializeField] private float fadeSpeed;
    private Image display;

    // Start is called before the first frame update
    void OnEnable()
    {
        display = GetComponent<Image>();
        StartCoroutine(Flickering());

    }
        
    IEnumerator Flickering()
    {
        yield return new WaitForSeconds(startDelay);
        Color imageColor = display.color;

        float x = transform.position.x;
        float a = 0.0f;

        while(timeInSeconds > 0)
        {
            transform.position = new Vector3(x + Mathf.Sin(Time.time * fadeSpeed) * fadeRange, transform.position.y, transform.position.z);
            a += Mathf.Sin(Time.time * fadeSpeed) * fadeRange ;
            a = Mathf.Clamp(a, 0.0f, 1.0f);
           
            var color = new Color(imageColor.r, imageColor.g, imageColor.b, a);
            display.color = color;

            timeInSeconds -= Time.deltaTime;
            yield return null;

        }

        display.GetComponent<Image>();
        var tempcolor = display.color;
        tempcolor.a = 0;
        display.color = tempcolor;



    }
}
