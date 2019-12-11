using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnAPI : MonoBehaviour
{
    public Transform test1;
    public Transform test2;

    private void Start()
    {
        print(test1.position);
        test1.localScale = new Vector3(5, 5, 5);
        test2.localScale = Vector3.one * 10;
    }

}
