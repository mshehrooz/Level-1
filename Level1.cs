using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Level1 : MonoBehaviour
{

    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 500f;

    [SerializeField] int tubeLimit;
  
     bool hasStarted;
     
  
    public GameObject YBall1,YBall2,BBall1,BBall2,Tube,Tube1,Tube2;
    public Stack<GameObject> tube1Stack;
    public Stack<GameObject> tube2Stack;
    public Stack<GameObject> tube3Stack;
    public Stack<GameObject> tempTube;
    public Stack<GameObject> tempBall;
   /* float horizontalSpeed = 1.0f;
    float verticalSpeed = 1.0f;*/

    /* [SerializeField] float right=0f;
     [SerializeField] float left = 0f;
     [SerializeField] float down=0f;*/
    Rigidbody2D myRigidBody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       /* myRigidBody2D = GetComponent<Rigidbody2D>();
        YBall1.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f; */  
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }




      /*  if (Input.GetMouseButtonDown(0))
        {
          Vector3 worldMousePosition  = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            Vector3 direction = worldMousePosition - Camera.main.transform.position;
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.transform.position, direction,  out hit, 100f))
            {
                checkAndMove(hit.transform.parent.gameObject, hit.transform.parent.gameObject);
            }
            hasStarted = true;
            startClick = Input.mousePosition;
            GetComponent<Rigidbody2D>().gravityScale = -1f;


        }*/
    /*    if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            startClick = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                checkAndMove(hit.transform.parent.gameObject, hit.transform.parent.gameObject);
            }
            GetComponent<Rigidbody2D>().gravityScale = -1f;
        }
        *//*  if (hit.collider.tag == "clickableCube"){
              //hit.collider.gameObject now refers to the 
              //cube under the mouse cursor if present
          }*//*
        else if (Input.GetMouseButtonUp(0))
        {
            startClick = SwipeDelta = Vector2.zero;
        }*/
        
    }

    public void setTubeStacks()
    {
        tube1Stack.Push(YBall1);
        tube1Stack.Push(YBall2);
        tube1Stack.Push(BBall1);
        tube1Stack.Push(BBall2);
        tube2Stack.Push(BBall1);
        tube2Stack.Push(BBall2);
        tube2Stack.Push(YBall1);
        tube2Stack.Push(YBall2);
    }
    public void checkAndMove(GameObject parent, GameObject child)
    {
        if(tempTube.Count > 0 && tempBall.Count > 0)
        {
            if(parent.name == "Tube")
            {
                checkAndCompareBallsAndSetStacks(tempTube, tempBall, tube1Stack, parent, child);
                
            } else if(parent.name == "Tube1")
            {
                checkAndCompareBallsAndSetStacks(tempTube, tempBall, tube2Stack, parent, child);
            } else if(parent.name=="Tube2")
            {
                checkAndCompareBallsAndSetStacks(tempTube, tempBall, tube3Stack, parent, child);
            } else
            {
                
            }
        } else
        {
            tempTube.Push(parent);
            tempBall.Push(child);
        }
    }
    public void checkAndCompareBallsAndSetStacks(Stack<GameObject>tempTubeStack, Stack<GameObject> tempBallStack,  Stack<GameObject> SecondTubeStack, GameObject parent, GameObject child)
    {

        //first

        if (SecondTubeStack.Count != 4)
        {
            GameObject tempTubeObject = tempTubeStack.Pop();
            GameObject tempBallObject = tempBallStack.Pop();

            if (tempBallObject.name == child.name)
            {
                Stack<GameObject> firstTube = getFirstTubeStack(tempTubeObject);
                if(firstTube != null)
                {
                    SecondTubeStack.Push(firstTube.Pop());
                  
                }
            }
            else
            {
                tempTube.Push(tempTubeObject);
                tempBall.Push(tempBallObject);
            }
        }
        else
        {

        }

        //second

        if (SecondTubeStack.Count != 4)
        {
            GameObject tempTubeObject = tempTubeStack.Pop();
            GameObject tempBallObject = tempBallStack.Pop();

            if (tempBallObject.name == child.name)
            {
                Stack<GameObject> secondTube = getFirstTubeStack(tempTubeObject);
                if (secondTube != null)
                {
                    SecondTubeStack.Push(secondTube.Pop());

                }
            }
            else
            {
                tempTube.Push(tempTubeObject);
                tempBall.Push(tempBallObject);
            }
        }


        //third

        if (SecondTubeStack.Count != 4)
        {
            GameObject tempTubeObject = tempTubeStack.Pop();
            GameObject tempBallObject = tempBallStack.Pop();

            if (tempBallObject.name == child.name)
            {
                Stack<GameObject> thirdTube = getFirstTubeStack(tempTubeObject);
                if (thirdTube != null)
                {
                    SecondTubeStack.Push(thirdTube.Pop());

                }
            }
            else
            {
                tempTube.Push(tempTubeObject);
                tempBall.Push(tempBallObject);
            }
        }



    }
    public Stack<GameObject> getFirstTubeStack(GameObject tube)
    {
        if(tube.name == "Tube")
        {
            return tube1Stack;
        } else if(tube.name == "Tube1")
        {
            return tube2Stack;
        } else if(tube.name == "Tube2")
        {
            return tube3Stack;
        } else
        {
            return null;
        }
    }
    
}







 
 
