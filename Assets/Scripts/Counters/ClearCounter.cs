using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(PlayerController playerController)
    {
        if (!HasKitchenObject())
        {
            // There is not kitchenObject here
            if (playerController.HasKitchenObject())
            {
                // Player is carrying something
                playerController.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player is not carrying something
            }
        }
        else
        {
            // There is kitchenObject here
            if (playerController.HasKitchenObject())
            {
                // Player has a kitchenObject

                // If player is carrying a plate
                if (playerController.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding something
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                } 
                else
                {
                    // Player is not carrying a plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter is holding a plate
                       if(plateKitchenObject.TryAddIngredient(playerController.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            playerController.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                // Player doesn't have a kitchenObject
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }
}
