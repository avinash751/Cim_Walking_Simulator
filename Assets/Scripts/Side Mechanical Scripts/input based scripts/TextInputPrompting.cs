using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;

public class TextInputPrompting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextToFade;
    [SerializeField] string textToDisplay;
    [SerializeField] float fadeSpeed;
    [SerializeField] bool onStartTransparentText;
    [Header("Dont touch these variables below")]
    [SerializeField] bool inputTextFadedIn;
    [SerializeField] bool inputTextFadeOut;

    public Func<bool> CheckWhetherInputIsPressed;

    private void Start()
    {
        SetTextTranslucencyOnStart();

    }

    void Update()
    {
        CallAndCheckForPlayerInputAndThenFadeOutText();
        ConditionsToFadeTextInAndOut();
    }
    void SetTextTranslucencyOnStart()
    {
        if (onStartTransparentText)
        {
            TextToFade.alpha = 0;
            return;
        }
        TextToFade.alpha = 1;
    }

    void FadeText(float _fadeTime, float _targetAlpha)
    {
        float _alpha = TextToFade.color.a;
        _alpha = Mathf.Lerp(_alpha, _targetAlpha, _fadeTime * Time.deltaTime);
        TextToFade.color = new Color(TextToFade.color.r, TextToFade.color.g, TextToFade.color.b, _alpha);
    }

    public void FadeInTextAndAllowToCheckForInput()
    {
        TextToFade.text = textToDisplay;
        inputTextFadedIn = true;
        inputTextFadeOut = false;
        Debug.Log(gameObject.name + "now checking if input is pressed");
    }

    void FadeOutText()
    {
        inputTextFadeOut = true;
        inputTextFadedIn = false;
    }
    void CallAndCheckForPlayerInputAndThenFadeOutText()
    {
        if (!inputTextFadedIn) return;
        bool inputPressed = CheckWhetherInputIsPressed();

        if (!inputPressed) return;
        FadeOutText();
        Debug.Log(gameObject.name + "input pressed and event called succesfully");
    }

    void ConditionsToFadeTextInAndOut()
    {
        if (inputTextFadedIn)
        {
            FadeText(fadeSpeed, 1);
        }
        if (inputTextFadeOut)
        {
            FadeText(fadeSpeed, 0);
        }
    }
}





