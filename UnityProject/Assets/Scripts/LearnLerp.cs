
using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public Transform Cube, Sphere;
    public float speed = 5;

    private void Update()
    {
        Vector3 pos = Vector3.Lerp(Cube.position, Sphere.position, 0.5f*Time.deltaTime*speed);
        print(pos);

        Cube.position = pos;
    }
}
