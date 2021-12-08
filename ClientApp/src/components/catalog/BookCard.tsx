import React from 'react';
import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import { Book } from "../../app/layout/models/book";


interface Props {
    book: Book;
}

export default function BookCard({ book }: Props) {
    return (
        <Card>
            <CardMedia
                component="img"
                height="140"
                image={book.pictureUrl}
                sx={{ objectFit: 'contain', bgcolor: 'primary.light' }}
                title={book.title}
            />
            <CardContent>
                <Typography gutterBottom color='secondary' variant="h5">
                    £{(book.price).toFixed(2)}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {book.author}
                    <Button href={book.link} target='_blank' size="small">Buy</Button>
                </Typography>
                <Typography className="synopsis">
                    {book.synopsis}
                </Typography>
            </CardContent>
            <CardActions> 
                <Button size="small">Add to favourite</Button>
                <Button component={Link} to={`/catalog/${book.id}`} size="small">View</Button>
            </CardActions>
        </Card>
    )
}