using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsometricController : MonoBehaviour
{
    public Grid grid;
    [SerializeField] private float speed = 5f;
    private Vector3Int _targetCell;
    private Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        // get initial grid location
        _targetCell = grid.WorldToCell(transform.position);
 
        // snap to the current cell
        transform.position = grid.CellToWorld(_targetCell);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        MoveToward(_targetPosition);
    }

    void ReadInput()
    {
        Vector3Int gridMovement = new Vector3Int();
        gridMovement.z = 0;

        if(!MultipleKeysPressed()){
            if(Input.GetKey(KeyCode.W))
            {
                gridMovement.x = 1;
            }
    
            if(Input.GetKey(KeyCode.S))
            {
                gridMovement.x = -1;
            }
    
            if(Input.GetKey(KeyCode.A))
            {
                gridMovement.y = 1;
            }
    
            if(Input.GetKey(KeyCode.D))
            {
                gridMovement.y = -1;
            }
        }
        

        if(gridMovement != Vector3Int.zero)
        {
            _targetCell = gridMovement;
            _targetPosition = grid.CellToWorld(_targetCell);
        }else {
            _targetPosition = grid.CellToWorld(Vector3Int.zero);
        }
    }

    private void MoveToward(Vector3 target)
    {
        // transform.position = Vector3.MoveToward(transform.position, target, moveSpeed * Time.deltaTime);
        transform.position += target * Time.deltaTime * speed;
    }

    private bool MultipleKeysPressed()
    {   
        // UP AND PLUS
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            return true;
        }

        // DOWN AND PLUS
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            return true;
        }

        // RIGHT AND PLUS
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            return true;
        }

        // LEFT AND PLUS
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            return true;
        }

        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            return true;
        }

        return false;
    }
}
