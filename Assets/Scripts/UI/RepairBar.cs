using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private int cogsNeeded = 5;
    private int currentCogs = 0;
    private AudioSource audioSource;

    public int CurrentCogs
    {
        get { return currentCogs; }
        set { currentCogs = value; UpdateSlider(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCogs == cogsNeeded)
        {
            if (audioSource && !GameManager.isOver)
            {
                audioSource.Play();
            }

            GameObject[] tetherLinks = GameObject.FindGameObjectsWithTag("Tether");
            foreach (var link in tetherLinks)
            {
                Tether tether = link.GetComponent<Tether>();
                if (tether)
                {
                    tether.Durability = 10;
                    tether.ResetColour();
                }
            }

            cogsNeeded = (int)(cogsNeeded * 1.5f);
            currentCogs = 0;
            UpdateSlider();
        }
    }

    void UpdateSlider()
    {
        slider.maxValue = cogsNeeded;
        slider.value = currentCogs;
    }
}
