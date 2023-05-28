using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;

public class ScoreUIBehaviour : MonoBehaviour
{
    public ScoreBehaviour scoringSystem;
    private TMP_Text scoreTextComponent;

    // Start is called before the first frame update
    void Start()
    {
        scoreTextComponent = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextComponent.text = scoringSystem.getScore().ToString();
    }
}
