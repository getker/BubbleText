using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleTextCtl : MonoBehaviour
{
    private InputField inputField;
    private Image bubbleImg;
    private Text bubbleText;

    // 这里不处理中英文情况
    private int charW = 20; // 一个字宽度
    private int charH = 26; // 一个字高度
    private int maxW = 200; // 最大宽度

    void Awake()
    {
        GameObject bubbleView = GameObject.Find("BubbleView");
        inputField = bubbleView.transform.Find("InputField").GetComponent<InputField>();
        bubbleImg = bubbleView.transform.Find("Icon/BubbleImg").GetComponent<Image>();
        bubbleText = bubbleView.transform.Find("Icon/BubbleImg/BubbleText").GetComponent<Text>();
        Button sendBtn = bubbleView.transform.Find("SendBtn").GetComponent<Button>();
        
        sendBtn.onClick.AddListener(OnSendBtnClick);
    }

    void OnSendBtnClick()
    {
        // 1.把输入框string赋值给气泡string
        string bubbleTextStr = inputField.text;
        // 2.计算bubbleTextStr的文字个数
        int strLen = bubbleTextStr.Length;
        decimal result = (decimal)strLen / 10;
        int num = Mathf.CeilToInt((float)result);

        // 3.清空输入框
        inputField.text = "";

        // 4.计算RectTransform的大小
        int wCount = num;
        int width = wCount > 1 ? maxW : charW * strLen;
        int height = wCount * charH;
        bubbleImg.rectTransform.sizeDelta = new Vector2(width, height);

        // 5.给气泡Text赋值
        bubbleText.text = bubbleTextStr;
    }
}
