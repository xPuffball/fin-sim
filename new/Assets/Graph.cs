using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Graph1 : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Transform pointPrefab;
    
    [SerializeField]
    GameObject parent;

    [SerializeField]
    Transform anchor1;


    [SerializeField]
    LineRenderer linePrefab;

    [SerializeField]
    LineRenderer linePrefabGreen;

    public float delayBetweenInstantiations = 0.1f; // Delay between instantiations in seconds
    public int maxY = 4;

    public void deleteChild(GameObject g){
        for (var i = g.transform.childCount - 1; i >= 0; i--)
        {
          Destroy(g.transform.GetChild(i).gameObject);
        }
    }

    public void createCrypto () {
        List<int> values = new List<int>() { 837, 1793, 2731, 3426, 4305, 5218, 6076, 6800, 7460, 8769, 9971, 10528, 10887, 11295, 12007, 7905, 8507, 9296, 10409, 10822, 11723, 12822, 13443, 14548, 13407, 14434, 15115, 15589, 15988, 16973, 17699, 18387, 19038, 19861, 20183, 21575, 22507, 23733, 14058, 14394, 14740, 15120, 15546, 15676, 16028, 16485, 16956, 17178, 17445, 17842, 18122, 18364, 18810, -877, -625, -178, 171, 554, 1018, 1455, 1772, 2165, -7499, -7052, -6875, -6491, -6058, -5853, -5429, -5012, -4610, -4415, -4107, -3862, -3586, -3087, -2884, -2626, -2284, -2157, -1685, -1547, -1117, -804, -486, -350, 109, 465, 608, 814, -3782, -3804, -3822, -3846, -3865, -3875, -3900, -3925, -3947, -3963, -3972, -3986, -3996, -4015, -4032, -4041, -4066, -4074, -4099, -4113, -4121, -4148, -4173, -4196, -4221, -4238, -4254, -4280, -4288, -4317 };
        createWrapper(values, linePrefab);
    }

    public void createETF() {
        List<int> values = new List<int>() { 1987, 4432, 6485, 8587, 9797, 11025, 14128, 16860, 18041, 19362, 21436, 22502, 24174, 25770, 27539, 23682, 25986, 27630, 29184, 30705, 32061, 32720, 34132, 35857, 34554, 35515, 38084, 39789, 40514, 42410, 43230, 45171, 46432, 48933, 51381, 53587, 56007, 57481, 50692, 52651, 54590, 55322, 57342, 58029, 60165, 61361, 63505, 64223, 66449, 67596, 68999, 70787, 72805, 54948, 55614, 57163, 59454, 60297, 61657, 63356, 64346, 66817, 68259, 70546, 72323, 73046, 74879, 75527, 78000, 79118, 80690, 81341, 83321, 84878, 86965, 89307, 90743, 92184, 93890, 95515, 98088, 99679, 101670, 102501, 103361, 104966, 106955, 108226, 109254, 111182, 107289, 108818, 109945, 110729, 111643, 112781, 113802, 114482, 116258, 116817, 118080, 118919, 120211, 120863, 122471, 124144, 124654, 126336, 126868, 127648, 129568, 131382, 132484, 133524, 135559, 137140, 137858, 139192, 139712, 140675 };
        createWrapper(values, linePrefabGreen);
    }

    public void createWrapper (List<int> values, LineRenderer line) {
        // List<int> values = new List<int>() { 837, 1793, 2731, 3426, 4305, 5218, 6076, 6800, 7460, 8769, 9971, 10528, 10887, 11295, 12007, 7905, 8507, 9296, 10409, 10822, 11723, 12822, 13443, 14548, 13407, 14434, 15115, 15589, 15988, 16973, 17699, 18387, 19038, 19861, 20183, 21575, 22507, 23733, 14058, 14394, 14740, 15120, 15546, 15676, 16028, 16485, 16956, 17178, 17445, 17842, 18122, 18364, 18810, -877, -625, -178, 171, 554, 1018, 1455, 1772, 2165, -7499, -7052, -6875, -6491, -6058, -5853, -5429, -5012, -4610, -4415, -4107, -3862, -3586, -3087, -2884, -2626, -2284, -2157, -1685, -1547, -1117, -804, -486, -350, 109, 465, 608, 814, -3782, -3804, -3822, -3846, -3865, -3875, -3900, -3925, -3947, -3963, -3972, -3986, -3996, -4015, -4032, -4041, -4066, -4074, -4099, -4113, -4121, -4148, -4173, -4196, -4221, -4238, -4254, -4280, -4288, -4317 };
        int maxVal = 0;
        int minVal = 100000;
        for (int i=0; i<values.Count; ++i) {
            if (values[i] > maxVal) {
                maxVal = values[i];
            }
            if (values[i] < minVal) {
                minVal = values[i];
            }
        }
        int range = maxVal - minVal;
        List<float> newValues = new List<float>();
        for (int i=0; i<values.Count; ++i) {
            newValues.Add(((float) (values[i] - minVal) / range * maxY));
        }
        StartCoroutine(createGraph(newValues, line));
    }

    IEnumerator createGraph(List<float> values, LineRenderer line) {
        Vector3 last = new Vector3(0, 0, 0);

        for (int i=0; i<values.Count; ++i) {
            Vector3 pos = new Vector3(anchor1.position.x, anchor1.position.y + values[i], anchor1.position.z-(i*(4.0f)/values.Count));
            createCircle(pos);
            if (i > 0) {
                createLine(last, pos, line);
            }
            last = pos;
            yield return new WaitForSeconds(delayBetweenInstantiations);
        }
        // animator.SetTrigger("startRotate");
    }


    void createCircle(Vector3 pos) {
        var obj = Instantiate(pointPrefab, pos, Quaternion.identity);
        obj.transform.parent = parent.transform;
        
    }

    void createLine(Vector3 x, Vector3 y, LineRenderer linePrefab) {
        LineRenderer lineRenderer = Instantiate(linePrefab);
        lineRenderer.transform.parent = parent.transform;

        lineRenderer.SetPosition(0, x);
        lineRenderer.SetPosition(1, y);
    }
}
