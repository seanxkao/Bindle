using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FallTrigger : MonoBehaviour {
    public int fallCount;
    public bool[] fall;
    public Controller[] players;
    public int size;

    void Start(){
        fallCount = 0;
    }

    public void init(int size) {
        this.size = size;
        players = new Controller[size];
        fall = new bool[size];
        for (int i = 0; i < size; i++) {
            fall[i] = false;
        }
    }

    public bool isFinished(){
        return fallCount >= size-1;
    }

    public Controller getWinner() {
        for (int i = 0; i < size; i++) {
            if (!fall[i])
            {
                return players[i];
            }
        }
        return null;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (isFinished()) 
            return;
        if (collider.gameObject.GetComponent<Controller>()) {
            for (int i = 0; i < size; i++)
            {
                if (collider.gameObject == players[i].gameObject)
                {
                    fall[i] = true;
                    fallCount++;
                    break;
                }
            }
        }
    }
}
