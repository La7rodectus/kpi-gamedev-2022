using UnityEngine;
using UnityEngine.UI;

public class PlayerItemCollector : MonoBehaviour
{
    [SerializeField] Text coinsText;
    int coins = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>().Has("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
        }
    }
}
