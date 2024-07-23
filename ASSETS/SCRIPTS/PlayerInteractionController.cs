using TMPro;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public GameObject clickIndicator;

    public CharacterInventoryData playerInventory = new CharacterInventoryData();

    BaseInteractableController interactable;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the mouse is over the GameObject with a collider
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has a specific tag or component
            Debug.Log("Mouse is over: " + hit.collider.name);

            interactable = hit.transform.GetComponent<BaseInteractableController>();

            clickIndicator.gameObject.SetActive(interactable != null);
        }

        if(clickIndicator.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            if (interactable != null)
            {
                playerInventory.items.Add(new ItemData(interactable.itemData));
                Destroy(hit.transform.gameObject);
            }
        }
    }

    // Feel free to remove this once you're done testing how the raycast works
    void OnDrawGizmos()
    {
        // Draw the ray in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction * 100f);

        // Draw a sphere at the hit point if there is a hit
        if (hit.collider != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
    }
}
