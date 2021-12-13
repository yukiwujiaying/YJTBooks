import { List } from '@material-ui/core';
import Book from '../../app/models/book';
import React, { Component } from 'react';
import BookCard from "./BookCard";

interface Props {
    books: Book[];
}

export default function BookList({ books } : Props) {

    return (
        <List>
            {books.map(book => (
                <BookCard key={book.bookId} books = {book} />
            ))}
        </List>
    )
}