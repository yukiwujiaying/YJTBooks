import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { FieldValues } from "react-hook-form";
import agent from "../../app/api/agent";
import { Book, Reviews } from "../../app/layout/models/book";

interface BookState {
    book: Book | null
    status: string;
 
   
}


const initialState: BookState={
 
    book: null,
    status: 'idle'
}

export const fetchBookAsync= createAsyncThunk<Book, number>(
    'book/fetchBookAsync',
    async(bookId, thunkAPI) =>{
        try
        {
            console.log("slice bookId", bookId);
            return await agent.Catalog.details(bookId);
        } 
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error:error.data});
        }
    }
)
export const AddReview = createAsyncThunk<Reviews, FieldValues>(
    'book/addReview',
    async({data,bookId,userId}, thunkAPI)=>{

        console.log("book/addReview called");

        try{
            return await agent.Review.addReview(data,bookId,userId);
        }
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error:error.data});
        }
    }
)


export const bookSlice = createSlice({
    name: 'book',
    initialState,
    reducers:{
        ClearState: (state) => {
            state.book = null;
        },
      
    },
    
    extraReducers:(builder=>{
    
        //fetch single book
        builder.addCase(fetchBookAsync.pending,(state)=>{
            state.status ='pendingFetchBook';
        });
        builder.addCase(fetchBookAsync.fulfilled, (state,action)=>{
            console.log("reducer", action);
            console.log("reducer state", state);
            state.book=action.payload;
            state.status ='success';
        })
        builder.addCase(fetchBookAsync.rejected,(state,action)=>{
            console.log(action);
            state.status = 'idle';
        });
        //add review
        builder.addCase(AddReview.pending, (state)=>{
            state.status ='pendingAddReviews'
        });
        builder.addCase(AddReview.fulfilled,(state, action)=>{
            if(state.book){
                const book = { ...state.book };
                book.bookReviews.push(action.payload);
                console.log("bookslice", action.payload);
                state.book = book;  
            } 
            
             state.status = 'idle';    
        });
        builder.addCase(AddReview.rejected, (state,action)=>{
            state.status = 'idle';
            console.log("AddReview Slice",action.payload);
        });
       

    })
})
export const { ClearState } = bookSlice.actions;

