using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //There is no kitchenobject here
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player is not carrying anything;
            }
        }
        else
        {
            //there is a kitchenObject here;
            if(player.HasKitchenObject())
            {
                //Player is carrying something;
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding plate
                    
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        KitchenObject.DestoryKitchenObject(GetKitchenObject());
                    }

                }
                else
                {
                    //Player is not carrying plate but something else;
                    if(GetKitchenObject().TryGetPlate(out  plateKitchenObject))
                    {
                        //Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            KitchenObject.DestoryKitchenObject(player.GetKitchenObject());
                        }
                    }
                }
                

            }
            else 
            {
                //Player is not carrying anything;
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
       
    }

   
}
