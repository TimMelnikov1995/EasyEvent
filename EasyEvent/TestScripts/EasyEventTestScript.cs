using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EasyEventTestScript : MonoBehaviour
{
    public void intTest(int value)
    {
        print(value);
    }
    public void floatTest(float value)
    {
        print(value);
    }
    public void stringTest(string value)
    {
        print(gameObject.name + " " + value);
    }
    public void GoTest(GameObject value)
    {
        print(value);
    }
    public void TransformTest(Transform value)
    {
        print(value);
    }
    public void Vector2Test(Vector2 value)
    {
        print(value);
    }
    public void Vector3Test(Vector3 value)
    {
        print(value);
    }
    public void Vector4Test(Vector4 value)
    {
        print(value);
    }
    public void QuaternionTest(Quaternion value)
    {
        print(value);
    }
}