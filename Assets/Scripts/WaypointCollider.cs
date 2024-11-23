using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class WaypointCollider : MonoBehaviour
{

    public int ID;

    PlayerOptionSelector pos;


   [SerializeField] TextMeshProUGUI relevantText;


    [SerializeField] PlayerInput input;

    // values to get to upgrade

    [SerializeField] PlayerHealth health;
    [SerializeField] PlayerWallet wallet;

    [SerializeField] int secondShieldPrice = 250;
    [SerializeField] int healthPrice = 50;
    [SerializeField] int shieldSpeedPrice = 100;
    [SerializeField] int domeSizePrice = 150;


    [SerializeField] GameObject secondShield;

    private void Start()
    {
        pos = FindFirstObjectByType<PlayerOptionSelector>();
        PlayerHealth health = FindFirstObjectByType<PlayerHealth>();
        secondShield.gameObject.SetActive(false);   



        if(ID == 0)
        {
            relevantText.text = $"2nd Shield C: {secondShieldPrice }";
        }
        if (ID == 1)
        {
            relevantText.text = $"Health C: {healthPrice}";
        }
        if (ID == 2)
        {
            relevantText.text = $"S Speed C: {shieldSpeedPrice}";
        }
        if (ID == 3)
        {
            relevantText.text = $"Dome Size C: {domeSizePrice}";
        }

    }



    private void Update()
    {
        if (SliderIsConnected()) 
        {
            relevantText.color = Color.red;

            if (Input.GetKeyDown(KeyCode.H))
            {
                print($"upgrade the {name}");


                if (ID == 0)
                {
                    if(wallet.cash < secondShieldPrice)
                    {
                        print("not enough funds");
                        return;
                    }

                    if (secondShield.gameObject.activeSelf)
                    {
                        float currentX = secondShield.transform.localScale.x;

                        
                        secondShield.gameObject.transform.localScale = new Vector3(currentX * 1.1f, .234f);
                        if(currentX > 2.268975f)
                        {
                            currentX = 2.268975f;
                            secondShield.gameObject.transform.localScale = new Vector3(currentX, .234f);

                        }

                        
                    }
                    else
                    {
                        secondShield.gameObject.SetActive(true);
                    }
                    

                    wallet.cash -= secondShieldPrice;
                }
                if (ID == 1) // health
                {
                    if (wallet.cash < healthPrice)
                    {
                        print("not enough funds");
                        return;
                    }
                    
                        health.TakeDamage(-15);
                        wallet.cash -= healthPrice;
                   
                    
                }
                if (ID == 2) // shield speed
                {
                    if (wallet.cash < shieldSpeedPrice)
                    {
                        print("not enough funds");
                        return;
                    }

                    input.angularSpeed *= 1.01f;
                    wallet.cash -= shieldSpeedPrice;
                }
                if (ID == 3)
                {

                }


               
            }

           
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pos.currentUpgradeID = -1;
        relevantText.color = Color.white;
    }

    bool SliderIsConnected()
    {
        if (ID == pos.currentUpgradeID)
        {
            return true;
        }
        return false;
    }

    

}
