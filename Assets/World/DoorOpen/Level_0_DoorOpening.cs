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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == greenCube)
        {
            GreenCube.SetTrigger("GreenCube");
        }
        if (other.gameObject == redCube)
        {
            RedCube.SetTrigger("RedCube");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject == greenCube) && (other.gameObject == redCube))
        {
            Debug.Log("Doooooor oooopeeeen!");
            RedCube.SetTrigger("RedCube");
            GreenCube.SetTrigger("GreenCube");
        }
    }
}
