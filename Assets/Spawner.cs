using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float nCubes = 10f;
    public float fillProbability = 0.9f;

    public Gradient CubeGradient;
    public float ColorSpeed = 1;

    public Transform Mama;
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
            SpawnInPlane();
    }
    void SpawnInPlane()
    {
        for (int i = 0; i < nCubes; i++)
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-20,20);     
            pos.z += Random.Range(-20, 20);
            Quaternion rot = Random.rotation;
            rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
            SpawnOne(pos, rot);
        }
    }
    void SpawnMany()
    {
        for (int j = 0; j < nCubes; j++)
        {
            for (int i = 0; i < nCubes; i++)
            {
                Vector3 pos = transform.position;
                pos.x += i;
                pos.y += j;

                //if (Random.value < fillProbability) //Treure això si no es vol random
                    //SpawnOne(pos);
            }
        }
    }
    void SpawnOne()
    {
        Instantiate(Prefab, transform.position, transform.rotation);
    }
    void SpawnOne(Vector3 pos, Quaternion rot)
    {
        GameObject go = Instantiate(Prefab, pos, rot);
        go.transform.localScale *= Random.Range(0.1f, 1f);

        float rdm = Mathf.Sin(Time.time * ColorSpeed)/2+0.5f;
        //Color color = new Color(Random.value, Random.value, Random.value);
        Color color = CubeGradient.Evaluate(rdm);
        //color = new Color(rdm, rdm, rdm); //Para hacer con escala de grises
        go.GetComponent<MeshRenderer>().material.color = color;

        go.transform.SetParent(Mama);
    }
}
