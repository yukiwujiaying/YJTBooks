import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { FavouriteBookList } from "../../app/layout/models/favouritebooklist";
import { getCookie } from "../../app/layout/util/util";



interface FavouriteBookListState{
    favouriteBookList: FavouriteBookList | null
    status: string
}

const initialState: FavouriteBookListState={
    favouriteBookList: null,
    status: 'idle'
}

export const fetchFavouriteBookListAsync = createAsyncThunk<FavouriteBookList>(
    'favouriteBookList/fetchfavouriteBookListAsync',
    async(_, thunkAPI) => {
        try
        {
            return await agent.FavouriteBookList.get();
        }
        catch(error: any)
        {
            return thunkAPI.rejectWithValue({error: error.data})

        }
    },
    {
        condition :() =>{
            if (!getCookie('userId')) return false;
        }
    }
)

export const addFavouriteBookListItemAsync = createAsyncThunk<FavouriteBookList,{bookId:number, quantity?:number}>(
    'favouriteBookList/addfavouriteBookListItemAsync',
    async({bookId}, thunkAPI)=>{
        try
        {
            return await agent.FavouriteBookList.addItem(bookId);
        }
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)

export const removeFavouriteBookListItemAsync = createAsyncThunk<void, { bookId: number, quantity: number, name?: string }>(
   'favouriteBookList/removefavouriteBookListItemAsync',
   async({bookId,quantity}, thunkAPI)=>{
       try
       {
           await agent.FavouriteBookList.removeItem(bookId,quantity);
       }
       catch(error:any){
           return thunkAPI.rejectWithValue({error: error.data});
       }
   }

)

export const FavouriteBookListSlice = createSlice({
    name:'favouriteBookList',
    initialState,
    reducers:{
        setFavouriteBookList:(state, action)=>{
            console.log("action:",action);
            state.favouriteBookList= action.payload;

        },
        clearFavouriteBookList:(state) => {
            state.favouriteBookList = null;
        }
    },
    extraReducers: (builder=>{
        builder.addCase(addFavouriteBookListItemAsync.pending,(state, action)=>{
            state.status = 'pendingAddItem'+ action.meta.arg.bookId;
            console.log(action);
        });
        builder.addCase(removeFavouriteBookListItemAsync.pending,(state,action)=>{
            state.status = 'pendingRemoveItem' +action.meta.arg.bookId +action.meta.arg.name;
        });
        builder.addCase(removeFavouriteBookListItemAsync.fulfilled,(state,action)=>{
            const{bookId, quantity} = action.meta.arg;
            const itemIndex = state.favouriteBookList?.items.findIndex(i=>i.bookId===bookId);

            //if findindex do not find an element in the array it will return -1
            if (itemIndex === -1 || itemIndex===undefined) return;
            state.favouriteBookList!.items.splice(itemIndex,1);            
            state.status ='idle';
        });
        builder.addCase(removeFavouriteBookListItemAsync.rejected,(state,action)=>{
            state.status ='idle';
            console.log(action.payload);
        });
        builder.addMatcher(isAnyOf(addFavouriteBookListItemAsync.fulfilled, fetchFavouriteBookListAsync.fulfilled), (state,action)=>{
            state.favouriteBookList = action.payload;
            state.status = 'idle';
        });
        builder.addMatcher(isAnyOf(addFavouriteBookListItemAsync.rejected,fetchFavouriteBookListAsync.rejected), (state,action)=>{
            console.log(action.payload);
            state.status = 'idle';
        });
    })

})

export const {setFavouriteBookList, clearFavouriteBookList} = FavouriteBookListSlice.actions;