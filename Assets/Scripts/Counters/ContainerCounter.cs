using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.HasKitchenObject())
        {
            // Player doesn't have a KitchenObject
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, playerController);


            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
