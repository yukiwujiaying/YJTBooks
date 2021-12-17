import React from 'react';
import { Grid } from "@mui/material";
import { Book } from "../../app/layout/models/book";
import BookCard from "./BookCard";

interface Props {
    books: Book[];
}

export default function BookList({books}:Props){
    return(
        <Grid container spacing={4}>
            {books.map(book => (
                <Grid item xs={12} key={book.id}> 
                    <BookCard book={book}/>  
                </Grid>
            ))}               
        </Grid>
    );
}