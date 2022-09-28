using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    Slider healthSlider;
    public Enemy enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = 100;
        healthSlider.wholeNumbers = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = enemyHealth.GetHealth();
    }
}
