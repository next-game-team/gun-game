using System.Collections.Generic;
using UnityEngine;

public class TouchManager : Singleton<TouchManager>
{
    public enum TouchState 
    {
        Touch,
        TouchEnd,
        Idle
    }
    
    public TouchState AttackTouchState { get; set; }
    public TouchState MoveTouchState { get; set; }
    public DirectionEnum MoveDirection { get; set; }

    [SerializeField, Range(0, 1)]
    private float _swipeDistanceConst = 0.2f;
    
    private float _dragDistance;  
    private Touch _firstSwipeTouch;
    private Vector3 _firstSwipeTouchPosition;
    private Touch _firstAttackTouch; 

    private void Start()
    {
        _dragDistance = Screen.height * _swipeDistanceConst;
        AttackTouchState = TouchState.Idle;
        MoveTouchState = TouchState.Idle;
        MoveDirection = DirectionEnum.NONE;
    }
    
    private void Update() 
    {
        foreach (var touch in Input.touches)
        {
            var isSwipeTouch = InSwipeZone(touch);
            
            if (touch.phase == TouchPhase.Began)
            {
                if (isSwipeTouch && MoveTouchState == TouchState.Idle)
                {
                    _firstSwipeTouch = touch;
                    _firstSwipeTouchPosition = touch.position;
                    MoveTouchState = TouchState.Touch;
                }
                else if (!isSwipeTouch && AttackTouchState == TouchState.Idle)
                {
                    _firstAttackTouch = touch;
                    AttackTouchState = TouchState.Touch;
                }
            }
         
            if (touch.phase == TouchPhase.Ended)
            {
                if (MoveTouchState == TouchState.Touch && touch.fingerId == _firstSwipeTouch.fingerId)
                {
                    // Check if swipe size was more than dragDistance
                    if (Mathf.Abs(touch.position.x - _firstSwipeTouchPosition.x) > _dragDistance 
                        || Mathf.Abs(touch.position.y - _firstSwipeTouchPosition.y) > _dragDistance)
                    {
                        // Check swipe orientation
                        if (Mathf.Abs(touch.position.x - _firstSwipeTouchPosition.x) 
                            > Mathf.Abs(touch.position.y - _firstSwipeTouchPosition.y))
                        {
                            // Horizontal swipe
                            if (touch.position.x > _firstSwipeTouchPosition.x)  
                            {   
                                // Right swipe
                                Debug.Log("Right Swipe");
                                MoveDirection = DirectionEnum.RIGHT;
                            }
                            else
                            {   
                                // Left swipe
                                Debug.Log("Left Swipe");
                                MoveDirection = DirectionEnum.LEFT;
                            }
                        }
                        else
                        {   
                            // Vertical swipe
                            if (touch.position.y > _firstSwipeTouchPosition.y)  
                            {
                                // Up swipe
                                Debug.Log("Up Swipe"); 
                                MoveDirection = DirectionEnum.UP;
                            }
                            else
                            {   
                                // Down swipe
                                Debug.Log("Down Swipe");
                                MoveDirection = DirectionEnum.DOWN;
                            }
                        }
                    }

                    MoveTouchState = TouchState.TouchEnd;
                }
                else if (AttackTouchState == TouchState.Touch && touch.fingerId == _firstAttackTouch.fingerId)
                {
                    Debug.Log("Touch");
                    AttackTouchState = TouchState.TouchEnd;
                }
            }
       }
    }

    private bool InSwipeZone(Touch touch)
    {
        return touch.position.x < Screen.width / 2f;
    }
}