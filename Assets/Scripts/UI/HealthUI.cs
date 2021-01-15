using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    float visibleTime = 5f;
    float lastVisible;
    public GameObject uiPrefab;
    public Transform character;
    Transform ui;
    Image healthSlider;
    Transform cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main.transform;
        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break;
            }
        }

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(int maxHealth, int currentHealth)
    {
        if(ui != null)
        {
            ui.gameObject.SetActive(true);
            lastVisible = Time.time;
            float healthPercent = (float)currentHealth / maxHealth;
            healthSlider.fillAmount = healthPercent;
            if(currentHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
        
    }

    void LateUpdate()
    {
        if(ui != null)
        {
            ui.position = character.position;
            ui.rotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);

            if(Time.time - lastVisible > visibleTime)
            {
                ui.gameObject.SetActive(false);
            }
        }
        
    }
}
