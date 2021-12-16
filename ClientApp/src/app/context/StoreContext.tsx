import { createContext, PropsWithChildren, useContext, useState } from "react";
import { FavouriteBookList } from "../layout/models/favouritebooklist";
import React from "react";

interface StoreContextValue{
    favouriteBookList: FavouriteBookList | null;
    setFavouriteBookList :(favouriteBookList: FavouriteBookList) => void;
    removeItem: (bookId: number, quantity: number)  => void;
}

export const StoreContext = createContext<StoreContextValue | undefined>(undefined);

// when we use useStoreContext we are able to use the StoreContextValue above
//basket, setBasket, remove item
export function useStoreContext(){
    const context = useContext(StoreContext);

    if (context == undefined){
        throw Error('Oops - we do not seem to be inside the provider');
    }

    return context;
}

export function StoreProvider({children}:PropsWithChildren<any>){
    const [favouriteBookList, setFavouriteBookList] = useState<FavouriteBookList| null>(null);

    function removeItem(bookId: number, quantity: number){
        if (!favouriteBookList) return;

        //create a new copy of state will replace the prevstate at the end
        const items =[...favouriteBookList.items];

        //e.g want to remove items with index 3 in array, findIndex() return 3
        const itemIndex = items.findIndex(i=>i.bookId==bookId);

        if (itemIndex >=0){
            items[itemIndex].quantity-=quantity;

            //if quantity=0, At position 3, remove 1 items(items with index 3) 
            if(items[itemIndex].quantity===0) items.splice(itemIndex,1);

            setFavouriteBookList(prevState =>{
                //return basket inculde the item and replace it with new items array
                //! is just for safty check from typescript
                return{...prevState!,items}
            })
        }
    }

    return (
        <StoreContext.Provider value={{favouriteBookList ,setFavouriteBookList, removeItem}}>
            {children}
        </StoreContext.Provider>
    )
}