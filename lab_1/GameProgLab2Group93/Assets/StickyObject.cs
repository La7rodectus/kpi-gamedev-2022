using UnityEngine;

public class StickyObject : MonoBehaviour
{
    [SerializeField] string StickWithTag;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tags>().Has(StickWithTag))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tags>().Has(StickWithTag))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}