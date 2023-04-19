using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject player;
    public GameObject freeLookCamera;
    public GameObject castPoint;


    [SerializeField] private Transform restartPoint;
    [SerializeField] private GameObject playerRestartPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Vector3 playerPos = player.transform.position;

        player.transform.rotation = Quaternion.identity;
        player.transform.position = playerRestartPoint.transform.position;

        player.GetComponent<CombatMovementPlayer>().enabled = false;
        player.GetComponent<PlayerCardSystem>().enabled = false;
        player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;

        freeLookCamera = GameObject.Find("FreeLook Camera");
        castPoint = GameObject.Find("CastPoint (1)");
        freeLookCamera.SetActive(true);
        castPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}