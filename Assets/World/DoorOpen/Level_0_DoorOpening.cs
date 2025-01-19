using System.Linq;
using UnityEngine;

public class Level_0_DoorOpening : MonoBehaviour
{
    [SerializeField] private Collider redTube;
    [SerializeField] private Collider greenTube;

    [SerializeField] private bool greenCubeIn = false;
    [SerializeField] private bool redCubeIn = false;

    [SerializeField] private GameObject greenCube;
    [SerializeField] private GameObject redCube;

    [SerializeField] private Animator RedCube;
    [SerializeField] private Animator GreenCube;

    public string[] cubesArray;

    private void OnTriggerEnter(Collider other)
    {
        //foreach (string cubes in cubesArray)
        //{
        //    if ()
        //    {
        //        Debug.Log("enter");
        //        RedCube.SetTrigger("GreenCube");
        //    }
        //    if ((other.gameObject.name == "redCube") && other.gameObject.CompareTag("SecondCube").Equals("SecondTube"))
        //    {
        //        Debug.Log("enter");
        //        GreenCube.SetTrigger("RedCube");
        //    }
        //}
    }

    
}
