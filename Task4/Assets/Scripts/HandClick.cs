using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandClick : MonoBehaviour
{

    public float hand = 0f;
    public Clicker clicker;
    [SerializeField] private TextMeshProUGUI addHand;
    [SerializeField] private TextMeshProUGUI addHeist;
    private int handCost = 100; 
    private int handHeistCost = 400; 
    private float percent = 1.0f;
    public float percentage = 0f;

    public handSpawner handSpawner;
    private int maxhands = 0;


    private void Update()
    {
        if (hand > 0)
        {
            clicker.cookieCount += (hand * percent) * (Time.deltaTime);
            clicker.counterText.text = "Cookies: " + clicker.cookieCount.ToString("0");
            Debug.Log(hand);
        }
    }
    public void AddHands()
    {
        if (clicker.cookieCount >= handCost)
        {
            clicker.cookieCount -= handCost;
            handCost += 300; //300
            
            hand++;


            addHand.text = "Hand + 1" + "\n Cost: " + handCost.ToString();
            clicker.counterText.text = "Cookies: " + clicker.cookieCount.ToString("0");

            if (maxhands < 60) //limits the amount of hands that can appear on the screen
            {
                handSpawner.SpawnHands();
                maxhands++;
                Debug.Log(maxhands);
            }

           
        }
    }
    public void HandsHeist()
    {

        if (clicker.cookieCount >= handHeistCost)
        {
            clicker.cookieCount -= handHeistCost;
            handHeistCost += 400; //400
            percent += 0.1f;
            percentage += 10f;
            addHeist.text = "Hand Haste + 10%\n" + "Cost: " + handHeistCost.ToString();

        }
        
    }
}
