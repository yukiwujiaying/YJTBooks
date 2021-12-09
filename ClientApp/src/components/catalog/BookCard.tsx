import React from 'react';
import { Button, Card, CardActions, CardContent, CardMedia, Typography} from "@mui/material";
import { Book } from "../../app/layout/models/book";
import { Link } from 'react-router-dom';



interface Props {
    book: Book;
}

export default function BookCard({ book }: Props) {
    return (
        <Card sx={{ display: 'flex' }}>
            <CardMedia
                component="img"
                //height="140"
                image={book.pictureUrl}
                sx={{ objectFit: 'cover', bgcolor: 'primary.light',width: 180 }}
                title={book.title}
            />
            <CardContent>
                <Typography gutterBottom color='secondary' variant="h5">
                    <a href={`/catalog/${book.id}`}  className="linkOfAmazon">{book.title} </a>
                </Typography>
                <Typography variant="h6">
                    £{(book.price).toFixed(2)}
                </Typography>
                <Typography>
                   {book.bookGenre}
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