using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerMessage : MonoBehaviour
{   
    [SerializeField]
    CountDown countDown;

    public Text Message;
    public Text Email;
    public InputField input;

    public void Starting()
    {
        if(input.text.Length != 0 && countDown.timer <= 0)
        {
            countDown.SetTimer(float.Parse(input.text));
            Message.text = null;
            Email.text = null;

            CountDown.onTimeCompleted += CompleteMessage;
            CountDown.onTimeCompleted += CompleteEmail;
        }

    }

    public void CompleteMessage()
    {
        Debug.Log("Sending text message:.....");
        Message.text = "This is Complete Message";
    }

    public void CompleteEmail()
    {
        Debug.Log("Sending Email:.....");
        Email.text = "This is Complete Email";
    }

    public void ResetBtn()
    {
        countDown.timer = 0.0f;
        input.text = null;
        Message.text = null;
        Email.text = null;
        countDown.text.text = "Time: ";
    }
}
