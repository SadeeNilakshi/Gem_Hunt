using UnityEngine;

public class GemDoorLinker : MonoBehaviour
{
    public GameObject linkedDoor;
    public GameObject gemEffectPrefab; 

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("Player"))
        {
            
            GemCollector collector = other.GetComponent<GemCollector>();
            if (collector != null)
            {
                collector.AddGem();
            }

            if (gemEffectPrefab != null)
            {
                Instantiate(gemEffectPrefab, transform.position, Quaternion.identity);
            }

          
            if (linkedDoor != null)
            {
                Destroy(linkedDoor); 
            }

           
            Destroy(gameObject);
        }
    }
}

