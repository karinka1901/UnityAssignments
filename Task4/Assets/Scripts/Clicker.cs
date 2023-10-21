using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{
    
    [SerializeField] public TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI addCookie;
    [SerializeField] private TextMeshProUGUI debugText;
    private int cookieCost = 40;
    private int extraClickCount;
    public HandClick handclick;
    public float cookieCount;
    public AudioControl audioControl;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            cookieCount += 10000;
            counterText.text = "Cookies: " + cookieCount.ToString("0");
        }
        debugText.text = "Added Clicks: " + extraClickCount.ToString() + "\n Hands: " + handclick.hand.ToString("0") + "\n Total Clicks: " + ((extraClickCount + 1) + handclick.hand).ToString("0") + "\n Haste: +" + handclick.percentage.ToString() + "%";
    }
    public void Cookie() // basic cookie click
    {
        audioControl.CookieSound();
        cookieCount += (extraClickCount + 1); 
        counterText.text = "Cookies: " + cookieCount.ToString();
        

    }

    public void extraCookie() //added click
    {
        if (cookieCount >= cookieCost)
        {
            extraClickCount++;
            cookieCount -= cookieCost; 
            cookieCost += 30;
           
            addCookie.text = "Cookies Per Click: + 1" + "\n Cost: " + cookieCost.ToString();
            
            counterText.text = "Cookies: " + cookieCount.ToString("0");
        }
    }

   
}
