import React from 'react';
import { Grid } from "@mui/material";
import { Book } from "../../app/layout/models/book";
import BookCard from "./BookCard";
import { useAppSelector } from '../../app/store/configureStore';

interface Props {
    books: Book[];
}

export default function BookList({books}:Props){
    const { booksLoaded } = useAppSelector(state => state.catalog);
    return(
        <Grid container spacing={2}>
            {books.map(book => (
                <Grid item xs={12} key={book.id}> 
                    <BookCard book={book}/>  
                </Grid>
            ))}               
        </Grid>
    );
}