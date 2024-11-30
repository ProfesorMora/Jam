using System;
using System.Drawing;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptIntro : MonoBehaviour
{
 public TextMeshProUGUI textComponent;
 public float           fadeTime;
 private float           alphaValue;
 private float          fadeAwayPerSecond;

void Start()
{
    fadeAwayPerSecond = 1 / fadeTime;
    alphaValue = textComponent.color.a;
}
 void Update()
 {
    if (alphaValue < 0)
        SceneManager.LoadScene(1);
    if (fadeTime > 0)
    {
        alphaValue -= fadeAwayPerSecond * Time.deltaTime;
        textComponent.color = new UnityEngine.Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alphaValue);
        fadeTime -= Time.deltaTime;
    }
 }
}
