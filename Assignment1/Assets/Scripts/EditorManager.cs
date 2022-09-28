using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    PlayerAction playerAction;

    public Camera mainCamera;
    public Camera editorCamera;

    public bool editorMode = false;
    bool instantiated = false;

    public GameObject prefab1;
    public GameObject prefab2;
    GameObject item;

    private void OnEnable()
    {
        playerAction.Enable();
    }

    private void OnDisable()
    {
        playerAction.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();
        playerAction.Editor.AddItem1.performed += cntxt => AddItem(1);
        playerAction.Editor.AddItem2.performed += cntxt => AddItem(2);
        playerAction.Editor.DropItem.performed += cntxt => DropItem();

        mainCamera.enabled = true;
        editorCamera.enabled = false;
    }

    public void SwitchCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        editorCamera.enabled = !editorCamera.enabled;
    }

    public void AddItem(int itemID)
    {
        if (editorMode && !instantiated)
        {
            switch (itemID)
            {
                case 1:
                    item = Instantiate(prefab1);
                    break;
                case 2:
                    item = Instantiate(prefab2);
                    break;
                default:
                    break;
            }

            instantiated = true;
        }
    }

    private void DropItem()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.enabled == false && editorCamera.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
