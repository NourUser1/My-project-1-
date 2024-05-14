using UnityEngine;
using UnityEngine.UI;

public class ButtonDestroyHiddenObject : MonoBehaviour
{
    public GameObject hiddenObject; // Reference to the hidden object

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DestroyHiddenObject);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(DestroyHiddenObject);
    }

    private void DestroyHiddenObject()
    {
        if (hiddenObject != null)
        {
            Destroy(hiddenObject);
        }
    }
}
