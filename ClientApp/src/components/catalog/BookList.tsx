import React from 'react';
import { Grid } from "@mui/material";
import { Book } from "../../app/layout/models/book";
import ProductCard from "./BookCard";

interface Props{
    books: Book[];
}
export default function ProductList({books}:Props){
    return(
        <Grid container spacing={4}>
            {books.map(book => (
                <Grid item xs={3} key={book.id}> 
                    <ProductCard  book={book}/>  
                </Grid>
            ))}               
        </Grid>
    )
}