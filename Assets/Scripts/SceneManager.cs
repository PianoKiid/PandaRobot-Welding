using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private int SceneCount = 0;

    public GameObject[] Weldables;
    private GameObject Models;
    private GameObject NowWelding;
    private GameObject Startpoint;
    private GameObject Endpoint;
    private GameObject Welded;

    private StartpointTrigger StartpointTrigger;
    private EndpointTrigger EndpointTrigger;

    private MeshRenderer meshRenderer;


    void Start()
    {
        Models = GameObject.Find("Models");

        Models.transform.position = new Vector3(6.474f, -0.859f, 0.8299817f);

        NowWelding = Weldables[0];
        meshRenderer = NowWelding.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        Startpoint = NowWelding.transform.GetChild(0).gameObject;
        Endpoint = NowWelding.transform.GetChild(1).gameObject;
        Welded = NowWelding.transform.GetChild(2).gameObject;

        StartpointTrigger = Startpoint.GetComponent<StartpointTrigger>();
        EndpointTrigger = Endpoint.GetComponent<EndpointTrigger>();

        Startpoint.SetActive(true);
        Endpoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (EndpointTrigger.IsTriggered == true)
        {
            SceneCountSetting();
        }

        MoveModels();
    }

    void SceneCountSetting()
    {
        Startpoint.SetActive(false);
        Endpoint.SetActive(false);

        Welded.SetActive(true);

        if (SceneCount == 7)
        {
            Application.Quit();
        }

        meshRenderer.enabled = false;

        SceneCount++;

        NowWelding = Weldables[SceneCount];
        meshRenderer = NowWelding.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        Startpoint = NowWelding.transform.GetChild(0).gameObject;
        Endpoint = NowWelding.transform.GetChild(1).gameObject;
        Welded = NowWelding.transform.GetChild(2).gameObject;

        StartpointTrigger = Startpoint.GetComponent<StartpointTrigger>();
        EndpointTrigger = Endpoint.GetComponent<EndpointTrigger>();

        Startpoint.SetActive(true);
        Endpoint.SetActive(false);


    }

    void MoveModels()
    {
        if (SceneCount == 2)
        {
            Models.transform.position = Vector3.Lerp(Models.transform.position, new Vector3(6.474f, -0.531f, 0.8299817f), Time.deltaTime*0.2f);
        }

        if (SceneCount == 4)
        {
            Models.transform.position = Vector3.Lerp(Models.transform.position, new Vector3(5.901f, -0.859f, 0.8299817f), Time.deltaTime*0.2f);
        }

        if (SceneCount == 6)
        {
            Models.transform.position = Vector3.Lerp(Models.transform.position, new Vector3(5.901f, -0.531f, 0.8299817f), Time.deltaTime*0.2f);
        }
    }

}
