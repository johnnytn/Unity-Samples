﻿using UnityEngine;
using System.Collections.Generic;

public abstract class Node : MonoBehaviour {

    public Transform cameraPosition;

    [HideInInspector]
    public Collider col;

    public List<Node> reachableNodes = new List<Node>();

    void Awake() {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    // On click execute execute an action
    void OnMouseDown() {
        Arrive();
    }

    /**
    * Move the player to the node, updating colliders and reachable nodes
    */
    public virtual void Arrive() {
        // Leave existing currentNode
        Node currentNode = GameManager.gm.currentNote;
        if (currentNode != null) {
            currentNode.Leave();
        }

        // Set current node
        GameManager.gm.currentNote = this;

        // Move the player
        GameManager.gm.player.MoveTo(cameraPosition);

        // Turn off our own collider
        if (col != null) {
            col.enabled = false;
        }

        setReachableNode(true);
    }

    public virtual void Leave() {
        setReachableNode(false);
    }

    /**
    * Turn on/off all reachable node's colliders
    */
    public void setReachableNode(bool set) {
        foreach (Node node in reachableNodes) {
            if (node.col != null) {
                Prerequisite pre = node.GetComponent<Prerequisite>();
                if (pre && pre.nodeAcess) {
                    if (pre.Complete) {
                        node.col.enabled = set;
                    }
                } else {
                    node.col.enabled = set;
                }
            }
        }
    }
}
