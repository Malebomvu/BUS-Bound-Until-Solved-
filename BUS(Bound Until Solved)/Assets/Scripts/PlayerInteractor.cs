using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    [SerializeField, Min(0.5f)]
    private float interactDistance = 3f;
    [SerializeField]
    private KeyCode interactKey = KeyCode.E;
    [SerializeField]
    private LayerMask interactLayers = ~0;

    private NPCInteractable focusedNpc;

    private void Awake()
    {
        if(playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>();

        if (playerCamera == null)
            Debug.LogError("PlayerInteractor needds a Camera assigned on the player", this);
    }

    private void Update()
    {
        focusedNpc = null;
        if (playerCamera == null) return;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayers, QueryTriggerInteraction.Ignore))
        { focusedNpc = hit.collider.GetComponentInParent<NPCInteractable>(); }

        if (focusedNpc != null && Input.GetKeyDown(interactKey))
            focusedNpc.Interact();
    }

    private void OnGUI()
    {
        if (focusedNpc == null) return;
        GUI.skin.box.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;

        if (!focusedNpc.IsTalking)
        {
            GUI.Box(new Rect(Screen.width * 0.5f - 120f, Screen.height * 0.68f, 240f, 38f), $"E Talk to {focusedNpc.NpcName}");
        
       }

        GUI.Box(new Rect(Screen.width * 0.5f - 220f, Screen.height - 150f, 440f, 110f), "");
        GUI.Label(new Rect(Screen.width * 0.5f - 200f, Screen.height - 140f, 400f, 24f), focusedNpc.NpcName);
        GUI.Label(new Rect(Screen.width * 0.5f - 200f, Screen.height - 112f, 400f, 50f), focusedNpc.CurrentDialogue);
        GUI.Label(new Rect(Screen.width * 0.5f - 200f, Screen.height - 64f, 400f, 20f), "Press E to continue");
    }
}

