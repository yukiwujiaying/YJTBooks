import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Book, BookParams } from "../../app/layout/models/book";
import { MetaData } from "../../app/layout/models/pagination";
import { RootState } from "../../app/store/configureStore";

interface CatalogState {
    booksLoaded: boolean;
    filtersLoaded:boolean;
    status: string;
    genres: string[];
    bookParams: BookParams;
    metaData: MetaData | null;
}
const booksAdapter = createEntityAdapter<Book>();

function getAxiosParams(bookParams: BookParams){
    const params = new URLSearchParams();
    //nedd to pass in name and value of the params, value have to be string
    params.append('pageNumber', bookParams.pageNumber.toString());
    params.append('pageSize', bookParams.pageSize.toString());
    params.append('orderBy', bookParams.orderBy.toString());

    if (bookParams.searchTerm) params.append('searchTerm', bookParams.searchTerm);
    if (bookParams.genres?.length>0) params.append('genres', bookParams.genres.toString());

    return params;
}

export const fetchBooksAsync= createAsyncThunk<Book[], void, {state: RootState}>(
    'catalog/fetchBooksAsync',
    //empty first argument is same as void, thunkAPI canonly be put on second argument
    async(_,thunkAPI) =>{
        const params = getAxiosParams(thunkAPI.getState().catalog.bookParams);
        try
        {
            const response = await agent.Catalog.list(params);
            thunkAPI.dispatch(setMetaData(response.metaData));
            return response.items;
        } 
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error:error.data});
        }
    }
)

export const fetchBookAsync= createAsyncThunk<Book, number>(
    'catalog/fetchBookAsync',
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

export const fetchFilters = createAsyncThunk(
    'catalog/fetchFilters',
    async (_, thunkAPI)=>{
        try
        {
            return agent.Catalog.fetchFilters();
        }
        catch(error:any)
        {
            return thunkAPI.rejectWithValue({error:error.data});
        }
    }
)
function initParams(){
    return{
        pageNumber: 1,
        pageSize: 3,
        orderBy: 'name',
        genres: []
    }
}
export const catalogSlice = createSlice({
    name: 'catalog',
    initialState: booksAdapter.getInitialState<CatalogState>({
       booksLoaded: false,
       filtersLoaded: false,
       status:'idle',
       genres: [], 
       bookParams:initParams(),
       metaData: null,
    }),
    reducers:{
        setBookParams: (state, action)=> {
            state.booksLoaded = false;
            //below code will append new value onto our existing bookparams
            state.bookParams={...state.bookParams, ...action.payload, pageNumber:1};
        },
        resetBookParams: (state) => {
            state.bookParams =initParams();
        },

        setMetaData: (state,action) =>{
            state.metaData = action.payload;
        },

        setPageNumber: (state, action) =>{
            state.booksLoaded = false;
            state.bookParams = {...state.bookParams, ...action.payload};
        }
    },
    extraReducers:(builder=>{
        //fetch all books
        builder.addCase(fetchBooksAsync.pending,(state)=>{
            state.status ='pendingFetchBooks'
        });
        builder.addCase(fetchBooksAsync.fulfilled, (state,action)=>{
            booksAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.booksLoaded = true;
        });
        builder.addCase(fetchBooksAsync.rejected,(state,action)=>{
            console.log(action.payload);
            state.status = 'idle';
        });  

        //fetch single book
        builder.addCase(fetchBookAsync.pending,(state)=>{
            state.status ='pendingFetchBook';
        });
        builder.addCase(fetchBookAsync.fulfilled, (state,action)=>{
            console.log("reducer", action);
            console.log("reducer state", state);
           //add the entity to the collection, updates the existing entity in the store if it's already present
           booksAdapter.upsertOne(state, action.payload);
            state.status ='idle';
        })
        builder.addCase(fetchBookAsync.rejected,(state,action)=>{
            console.log(action);
            state.status = 'idle';
        });

        //fetch filter
        builder.addCase(fetchFilters.pending, (state)=> {
            state.status =' pendingFetchFilters';
        });
        builder.addCase(fetchFilters.fulfilled,(state, action)=>{
            state.genres = action.payload.genres;
            state.filtersLoaded = true;
        });

        builder.addCase(fetchFilters.rejected, (state,action)=>{
            state.status = 'idle';
            console.log(action.payload);
        })
    })
})
export const bookSelectors = booksAdapter.getSelectors((state: RootState )=>state.catalog);

export const {setBookParams, resetBookParams, setPageNumber, setMetaData} = catalogSlice.actions;