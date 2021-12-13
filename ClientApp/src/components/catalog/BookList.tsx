import { Grid } from '@material-ui/core';
import Book from '../../app/models/book';
import React, { Component } from 'react';
import BookCard from "./BookCard";

interface Props {
    books: Book[];
}

export default function BookList({ books } : Props) {

    return (
        <Grid container spacing={ 4 }>
            {books.map(book => (
                <Grid item xs={3} key={book.bookId}>
                    <BookCard books={book} />
                </Grid>
            ))}
        </Grid>
    )
}