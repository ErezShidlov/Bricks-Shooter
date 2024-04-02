using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Arrows
    Vector3 arrowSpawn;
    public Transform greenArrowPos;
    public GameObject arrowPrefab;
    GameObject[] arrowsArr = new GameObject[5];
    public static int score;
    int i;
    public TMP_Text niceShotText;

    //Camera
    public GameObject mainCam;
    Vector3 mainCamSpawnPos;
    Quaternion mainCamSpawnRot;
    public static bool isDestroyed;
    bool isShooting;
    public float cameraSpeed;

    //Audios
    public AudioSource audioSource;
    public AudioClip niceShot;

    void Start()
    {
        mainCamSpawnPos = mainCam.transform.position;
        mainCamSpawnRot = mainCam.transform.rotation;
        i = 0;
        score = 0;
        isDestroyed = false;
        isShooting = false;
        cameraSpeed = 10;
        niceShotText.gameObject.SetActive(false);
    }
    void Update()
    {
        PlayerPressedSpace(); 
    }
    void PlayerPressedSpace()
    {
        arrowSpawn = greenArrowPos.position;
        if (Input.GetKeyDown(KeyCode.Space) && i < arrowsArr.Length && isDestroyed == false)
        {
            arrowsArr[i] = Instantiate(arrowPrefab, arrowSpawn, Quaternion.identity);
            mainCam.transform.position = new Vector3(arrowsArr[i].transform.position.x - 4.5f, arrowsArr[i].transform.position.y, arrowsArr[i].transform.position.z - 2.5f);
            mainCam.transform.rotation = Quaternion.Euler(arrowsArr[i].transform.rotation.x, arrowsArr[i].transform.rotation.y + 50, arrowsArr[i].transform.rotation.z);
            i++;
            isShooting = true;
        }

        if (isShooting)
        {
            mainCam.transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
        }

        if (isDestroyed)
        {
            niceShotText.gameObject.SetActive(true);
            audioSource.PlayOneShot(niceShot);
            StartCoroutine(ReturnCameraToSpawnPoint());
            isDestroyed = false;
            isShooting = false;
        }
    }
    IEnumerator ReturnCameraToSpawnPoint()
    {
        yield return new WaitForSeconds(1.5f);
        niceShotText.gameObject.SetActive(false);
        mainCam.transform.position = mainCamSpawnPos;
        mainCam.transform.rotation = mainCamSpawnRot;
    }
}
