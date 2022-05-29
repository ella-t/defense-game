using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class RadialTimer : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private float minAngle;
    [SerializeField]
    private float maxAngle;

    // Public info
    public float maxTime;
    public bool timing = true;
    public float currentTime = 0.0f;
    public UnityEvent OnTimerComplete;

    // Memory
    private Image _image;


    // Start is called before the first frame update
    void Start()
    {
       _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timing && currentTime <= maxTime)
        {
            currentTime += Time.deltaTime;
        }
        else if (timing && currentTime >= maxTime)
        {
            timing = false;
            OnTimerComplete.Invoke();
        }

        float minFillAmount = minAngle / 360;
        float maxFillAmount = maxAngle / 360;
        float fillRange = maxFillAmount - minFillAmount;

        _image.fillAmount = maxFillAmount - ((currentTime / maxTime) * fillRange);

    }
}
