using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoSynchronizer : MonoBehaviour
{
     //set these in the inspector!
    public AudioSource master;
    public AudioSource[] slaves;
    private bool masterSet = false;

    void Update() {
        if(masterSet) {
        UpdateMaster();
        } else {
        SyncSlaves();
        }
    }

    private void UpdateMaster() {
        for(int i=0; i<slaves.Length; i++) {
            this.slaves[i].timeSamples = this.master.timeSamples;
        }
    }

    private void SyncSlaves() {
        for(int i=0; i<slaves.Length; i++) {
                if(slaves[i].enabled) {
                    this.master = slaves[i];
                    break;
                }
            }
    }

    public void SetMaster(AudioSource source) {
    this.master = source;
    this.masterSet = true;
    }

    public void RemoveMaster() {
        this.master = null;
        this.masterSet = false;
    }
}
