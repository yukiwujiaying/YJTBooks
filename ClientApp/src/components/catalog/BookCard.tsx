import { CardMedia, CardContent, Typography, CardActions, Button, Card } from '@material-ui/core';
import React, { Component } from 'react';
import Book from '../../app/models/book';

interface Props {
    //The property is called books, and it's of type Book
    books: Book;
}

export default function BookCard({ books }: Props) {
    return (
        <Card >
            <CardMedia
                component="img"
                image={books.pictureUrl}
                sx={{ objectFit: 'fill', bgcolor: 'primary.light', width: 180 }}
                title={books.title}
            />
            <CardContent>
                <Typography gutterBottom color='secondary' variant="h5">
                    <a href={`/catalog/${books.bookId}`} className="linkOfAmazon">{books.title} </a>
                </Typography>
                <Typography variant="h6">
                    £{(books.price).toFixed(2)}
                </Typography>
                <Typography>
                    {books.bookGenre}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {books.author}
                    <Button href={books.amazonLink} target='_blank' size="small">Buy</Button>
                </Typography>
                <Typography className="synopsis">
                    {books.synopsis}
                </Typography>
            </CardContent>
            <CardActions>
                <Button size="small">Add to favourite</Button>
                <Button size="small">View</Button>
            </CardActions>
        </Card>
          )
}