using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance { get; private set; }
    private Text messageText;

    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        messageText = transform.Find("Text").GetComponent<Text>();
        Hide();
    }

    public void Update()
    {
        if (messageText.enabled)
        {
            Color color = messageText.color;
            float alpha = Mathf.Lerp(color.a, 0, Time.deltaTime);
            messageText.color = new Color(color.r, color.g, color.b, alpha);

            if (alpha == 0)
            {
                messageText.enabled = false;
            }
        }
    }

    public void Show(string message)
    {
        messageText.enabled = true;
        messageText.text = message;
        messageText.color = Color.white;
    }
    public void Hide()
    {
        messageText.enabled = false;
    }

}
