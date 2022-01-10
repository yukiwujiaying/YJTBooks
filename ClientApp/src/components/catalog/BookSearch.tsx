import { debounce, TextField } from "@mui/material";
import React from "react";
import { useState } from "react";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { setBookParams } from "./catalogSlice";

export default function ProductSearch() {
    const {bookParams} = useAppSelector(state=> state.catalog);
    const [searchTerm, setSearchTerm] = useState(bookParams.searchTerm);
    const dispatch = useAppDispatch();

    const debouncedSearch = debounce((event:any) => {
        dispatch(setBookParams({searchTerm: event.target.value}))
    },1500)

    return (
        <TextField
            label='Search products'
            variant='outlined'
            fullWidth
            value={searchTerm || ''}
            onChange={(event:any)=>{
                setSearchTerm(event.target.value);
                debouncedSearch(event);
            }}
        />
    )
}