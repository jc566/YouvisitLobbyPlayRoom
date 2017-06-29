/************************************************************
 * This script was created by :                             *
 * Joseph Choi / Jacob Maher / Shannon Hargrove / Lin Chen  *
 ***********************************************************/
using UnityEngine;

using System.Collections;

[RequireComponent(typeof(Collider))]
public class VRInteractable : MonoBehaviour
{
    //saves the original spin speed of an object with the spinScript attached
    public float savedSpinSpeed;

    //Material used when the object is not being gazed at
    public Material inactiveMaterial;

    //Material used when the object is being gazed at
    public Material activeMaterial;

    private Vector3 startingPosition;

    //The amount to scale an object with SizeChangeScript.cs attached
    private const float ScaleAmount = 0.07f;

    public GameObject player; //reference to the player
    void Start()
    {
        //startingPosition = transform.localPosition;
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        /*if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;*/

        //Debug.Log(gazedAt);
        printMessage();

    }

    public void Reset()
    {
        transform.localPosition = startingPosition;
    }


    /************************
     * Teleportation Logic  *
     ***********************/
    public void teleportToLocation()
    {
        player.transform.position = this.transform.position;
    }

    //Print a Debug.log message
    public void printMessage()
    {
        Debug.Log("This is Working");
    }

    public void Recenter()
    {
#if !UNITY_EDITOR
    GvrCardboardHelpers.Recenter();
#else
        GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
        if (emulator == null)
        {
            return;
        }
        emulator.Recenter();
#endif  // !UNITY_EDITOR
    }


}
