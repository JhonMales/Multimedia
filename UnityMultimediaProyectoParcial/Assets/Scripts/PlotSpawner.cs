using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initAmount = 7;
    private float plotSize = 94f;
    private float xPosLeft = -9f;
    private float xPosRight = 9f;
    private float lastZpos = 0f;
    public List<GameObject> plots;

    private Camera mainCamera;
    private float destroyThreshold = -372f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndDestroyPlots();
    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];

        float zPos = lastZpos + plotSize;

        Instantiate(plotLeft, new Vector3(xPosLeft, 0.025f, zPos - 188f), plotLeft.transform.rotation);
        Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0));

        lastZpos += plotSize;
    }

   // Comprueba y elimina los plots que están completamente fuera de la vista de la cámara
    private void CheckAndDestroyPlots()
    {
        GameObject[] allPlots = GameObject.FindGameObjectsWithTag("Plot");

        foreach (GameObject plot in allPlots)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(plot.transform.position);

            if (screenPos.z < destroyThreshold)
            {
                Destroy(plot);
            }
        }
    }
}