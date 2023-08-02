using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactToInputTextPrompt : MonoBehaviour
{
    [SerializeField] TextInputPrompting textInputPrompting;
    [SerializeField] float delayTimeToCallEvent;
    bool inputPressed;
    [SerializeField] UnityEvent WhenInputIsPressed;

    // Start is called before the first frame update
    void Start()
    {
        textInputPrompting.CheckWhetherInputIsPressed += CallEventWhenInputPressedAndFadeOutText;
    }

    bool CallEventWhenInputPressedAndFadeOutText()
    {
        if(Input.GetKeyDown(KeyCode.E) && !inputPressed)
        {
            inputPressed = true;
            Invoke("CallUnityEventAfterDelay", delayTimeToCallEvent);
            return true;
        }
        return false;
    }

    void CallUnityEventAfterDelay()
    {
        WhenInputIsPressed.Invoke();
        Debug.Log(gameObject.name + "Based on Input, Unity Event has been called");
        textInputPrompting.CheckWhetherInputIsPressed -= CallEventWhenInputPressedAndFadeOutText;
    }
}
