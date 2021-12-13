import { ListItem, ListItemAvatar, ListItemText, List } from '@material-ui/core';
import { Avatar } from '@mui/material';
import React, { Component } from 'react';
import Book from '../../app/models/book';

interface Props {
    //The property is called books, and it's of type Book
    books: Book;
}

export default function BookCard({ books }: Props) {
    return (
                <ListItem key={books.bookId}>
                    <ListItemAvatar>
                        <Avatar src={books.pictureUrl} />
                    </ListItemAvatar>

                    <ListItemText>
                        {books.title} - {books.author} - {books.price}
                    </ListItemText >
                </ListItem>
          )
}