import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { FieldValues } from "react-hook-form";
import { toast } from "react-toastify";
import agent from "../../app/api/agent";
import { User } from "../../app/layout/models/user";
import { myHistory } from "../../history";
import { setFavouriteBookList } from "../FavouriteBookList/FavouriteBookListSlice";


interface AccountState {
    user: User | null;
}

const initialState: AccountState = {
    user: null
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
        })
        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) => {
            state.user = action.payload;
        });
        builder.addMatcher(isAnyOf(signInUser.rejected), (state, action) => {
            throw action.payload;
        })

    })
})

export const { signOut, setUser } = accountSlice.actions;