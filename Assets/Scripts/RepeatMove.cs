using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    void Start()
    {
        
    }

    void Update()
    {
        var pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
        if(transform.position.x < endPos.position.x) transform.position = startPos.position;
    }
}
