import { configureStore } from "@reduxjs/toolkit";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { accountSlice } from "../../components/account/accountSlice";
import { catalogSlice } from "../../components/catalog/catalogSlice";
import { FavouriteBookListSlice } from "../../components/FavouriteBookList/FavouriteBookListSlice";
import { bookSlice } from "../../components/catalog/bookSlice";




export const store = configureStore({
    reducer:{
        catalog: catalogSlice.reducer,
        account: accountSlice.reducer,
        favouriteBookList : FavouriteBookListSlice.reducer,
        book : bookSlice.reducer,

    }
})
export type RootState =  ReturnType<typeof store.getState>;
export type AppDispatch =  typeof store.dispatch;

export const useAppDispatch =()=> useDispatch<AppDispatch>();
export const useAppSelector : TypedUseSelectorHook<RootState> = useSelector;