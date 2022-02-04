import { createContext, PropsWithChildren, useContext, useState } from "react";
import { FavouriteBookList } from "../layout/models/favouritebooklist";
import React from "react";
import { User } from "../layout/models/user";

interface StoreContextValue{
    favouriteBookList: FavouriteBookList | null;
    setFavouriteBookList :(favouriteBookList: FavouriteBookList) => void;
    removeItem: (bookId: number, quantity: number)  => void;
    user: User|null;
    setUser:(user:User)=>void;
    removeReview:(id:number)=>void;
}

export const StoreContext = createContext<StoreContextValue | undefined>(undefined);

// when we use useStoreContext we are able to use the StoreContextValue above
//basket, setBasket, remove item
export function useStoreContext(){
    const context = useContext(StoreContext);

    if (context === undefined){
        throw Error('Oops - we do not seem to be inside the provider');
    }

    return context;
}

export function StoreProvider({children}:PropsWithChildren<any>){
    const [favouriteBookList, setFavouriteBookList] = useState<FavouriteBookList| null>(null);
    const [user,setUser]=  useState<User|null>(null);

    function removeItem(bookId: number, quantity: number){
        if (!favouriteBookList) return;

        //create a new copy of state will replace the prevstate at the end
        const items =[...favouriteBookList.items];

        //e.g want to remove items with index 3 in array, findIndex() return 3
        const itemIndex = items.findIndex(i=>i.bookId===bookId);

        if (itemIndex >=0){

            items.splice(itemIndex,1);
            
            setFavouriteBookList(prevState =>{
                //return favourite booklist inculde the item and replace it with new items array
                //! is just for safty check from typescript
                return{...prevState!,items}});
        }

    }
    function removeReview(id:number){
        if (!user?.bookReviews) return;
        const reviews=[...user.bookReviews]
        const reviewIndex=reviews.findIndex(i=>i.id===id);
      
        if (reviewIndex>=0){
            reviews.splice(reviewIndex,1);
            setUser(preState=>{
                return{...preState!,reviews}
            });
        console.log("StoreContext User",user);
        }
        
    }

    return (
        <StoreContext.Provider value={{favouriteBookList ,setFavouriteBookList, removeItem, user, setUser,removeReview}}>
            {children}
        </StoreContext.Provider>
    )
}