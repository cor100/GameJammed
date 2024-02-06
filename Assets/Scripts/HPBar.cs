using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Gradient gradient;
    public Image HealthFill;
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        HealthFill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update(){
        HealthFill.color = gradient.Evaluate(_slider.normalizedValue);

    }
    // called from Player [method name] everytime player takes damage
    public void TakeDamage(int health){
        _slider.value -= health;
        HealthFill.color = gradient.Evaluate(_slider.normalizedValue);
    }
}
