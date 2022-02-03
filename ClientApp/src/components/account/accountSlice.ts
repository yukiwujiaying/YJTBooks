import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { FieldValues } from "react-hook-form";
import { toast } from "react-toastify";
import agent from "../../app/api/agent";
import { Reviews, User } from "../../app/layout/models/user";
import { myHistory } from "../../history";
import { setFavouriteBookList } from "../FavouriteBookList/FavouriteBookListSlice";


interface AccountState {
    user: User | null,
    status: string,
}

const initialState: AccountState = {
    user: null,
    status:'idle',
}

export const signInUser = createAsyncThunk<User, FieldValues>(
    'account/signInUser',
    async (data, thunkAPI) => {
        try {
         
            const userDto = await agent.Account.login(data);
            console.log("UserDto", userDto);
            const{ favouriteBooks, ...user}= userDto;      
               
            if (favouriteBooks) thunkAPI.dispatch(setFavouriteBookList(favouriteBooks));
            console.log("favouriteBookList In AcoountSlice", favouriteBooks)
            localStorage.setItem('user', JSON.stringify(user));
            return user;
        }
        catch (error: any) {
            return thunkAPI.rejectWithValue({ error: error.data });
        }
    }
)

export const fetchCurrentUser = createAsyncThunk<User>(
    'account/fetchCurrentUser',
    async (_, thunkAPI) => {
        thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem('user')!)))
        try {
           
            const userDto = await agent.Account.currentUser();
            const{ favouriteBooks, ...user}= userDto;
            if (favouriteBooks)  thunkAPI.dispatch(setFavouriteBookList(favouriteBooks));       
            localStorage.setItem('user', JSON.stringify(user));
            return user;
        }
        catch (error: any) {
            return thunkAPI.rejectWithValue({ error: error.data });
        }
    },
    {
        condition:()=>{
            if(!localStorage.getItem('user')) return false
        }
    }
)
export const DeleteReview = createAsyncThunk<User,{id:number}>(
    'account/deleteReview',
    async({id},thunkAPI)=>{
        try{
            return await agent.Review.deleteReview(id);
        }
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error:error.data});
        }
    }
)

export const ModifyReview = createAsyncThunk<Reviews, FieldValues>(
    'account/modifyReview',
    async({data,id}, thunkAPI)=>{
        console.log("account/modifyReview called");
        try{
            return await agent.Review.modifyReview(data,id);
        }
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error:error.data});
        }
    }
)
export const accountSlice = createSlice({
    name: 'account',
    initialState,
    reducers: {
        signOut: (state) => {
            state.user = null;
            localStorage.removeItem('user');
            myHistory.push('/');
        },
        setUser:(state, action)=> {
            state.user=action.payload;
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchCurrentUser.rejected, (state) =>{
            state.user = null;
            localStorage.removeItem('user');
            toast.error('Session expired - please login again');
            myHistory.push('/')
        });
        
              
        builder.addCase(DeleteReview.pending, (state,action)=>{
            state.status ='pendingDeleteReviews'+ action.meta.arg.id;
        });
        builder.addCase(DeleteReview.fulfilled,(state, action)=>{
            const {id} = action.meta.arg;
            const reviewIndex=state.user?.bookReviews.findIndex(i=>i.id===id);    
            if (reviewIndex===-1|| reviewIndex===undefined) return;
            state.user!.bookReviews.splice(reviewIndex,1);
            state.status='idle';
            console.log("Delete Review slice",action.payload);        
        });
        builder.addCase(DeleteReview.rejected, (state,action)=>{
            state.status = 'idle';
            console.log("rejected delete", action.payload);
        });
        builder.addCase(ModifyReview.pending, (state)=>{
            state.status ='pendingModifyReviews'
        });
        builder.addCase(ModifyReview.fulfilled,(state, action)=>{
            if (state.user){    
                const{id}=action.meta.arg;
                const newUser={...state.user };
                const reviewIndex=newUser.bookReviews.findIndex(i=>i.id===id); 
                newUser.bookReviews[reviewIndex]=action.payload;
                state.user=newUser;        
            } 
            state.status = 'idle';            
            console.log("Modify Review slice",action.payload);        
        });
        builder.addCase(ModifyReview.rejected, (state,action)=>{
            state.status = 'idle';
            console.log("rejected modify", action.payload);
        });



        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) => {
            state.user = action.payload;
        });
        builder.addMatcher(isAnyOf(signInUser.rejected), (state, action) => {
            throw action.payload;
        });
        
    })
})

export const { signOut, setUser } = accountSlice.actions;