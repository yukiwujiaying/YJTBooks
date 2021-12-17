import React from 'react';
import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { Book } from "../../app/layout/models/book";
import { Link } from 'react-router-dom';
import LoadingComponent from '../../app/layout/LoadingComponent';
import agent from '../../app/api/agent';
import NotFound from '../../app/errors/NotFound';
import { useStoreContext } from '../../app/context/StoreContext';
import { LoadingButton } from '@mui/lab';
import { StarBorder } from '@mui/icons-material';
import StarIcon from '@mui/icons-material/Star';

export default function BookDetails() {

    const { favouriteBookList, setFavouriteBookList, removeItem } = useStoreContext();
    let { Id } = useParams();
    const [book, setBook] = useState<Book | null>(null);
    const [loading, setloading] = useState(true);
    const [submitting, setSubmitting] = useState(false);
    const [isFavourite, setIsFavourite] = useState(false);

    // useEffect(() => {   
    //     console.log("favouriteBookList", favouriteBookList);
    //     console.log("id", Id);        
    // }, [])

    useEffect(() => {   
        console.log("Loaded");

        agent.Catalog.details(parseInt(Id!))
            .then(response => setBook(response))
            .catch(error => console.log(error))
            .finally(() => setloading(false));
    }, [])

    useEffect(() => {   
        if (book == null) return;
        
        console.log("book", book);
        //console.log("Id", id);
        
        if(favouriteBookList?.items.some(i => i.bookId === book.id)){
            setIsFavourite(true);
        } else {
            setIsFavourite(false);
        }
        
    }, [book])


    function addBookToFavourites(bookId: number) {
        setSubmitting(true);
        agent.FavouriteBookList.addItem(bookId)
            .then(favouriteBookList => setFavouriteBookList(favouriteBookList))
            .catch(error => console.log(error))
            .finally(() => setSubmitting(false));
    }

    function removeBookFromFavourites(bookId: number) {
        setSubmitting(true);
        agent.FavouriteBookList.removeItem(bookId, 1)
            .then(() => removeItem(bookId, 1))
            .catch(error => console.log(error))
            .finally(() => setSubmitting(false))
    }

    function handleFavouriteClick(bookId: number){
        
         setIsFavourite(!isFavourite);
        
        if (isFavourite) { 
            removeBookFromFavourites(bookId);
            return;            
        }
        addBookToFavourites(bookId);
        
    }

    if (loading) return <LoadingComponent message="Loading books..." />

    if (!book) return <NotFound />
    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={book.pictureUrl} alt={book.title} style={{ width: '80%' }} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>
                    {book.title}
                    <LoadingButton loading={submitting}
                                    onClick={() => handleFavouriteClick(book.id)}
                                    size="small">
                        {isFavourite ? <StarIcon fontSize="large"/> : <StarBorder fontSize="large" />}
                    </LoadingButton>
                </Typography>
                
                <Divider sx={{ mb: 2 }} />
                <Typography variant='h4' color='secondary'>£{(book.price).toFixed(2)}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Title</TableCell>
                                <TableCell>{book.title}</TableCell>
                                
                            </TableRow>

                            <TableRow>
                                <TableCell>Author</TableCell>
                                <TableCell>{book.author}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Genre</TableCell>
                                <TableCell>{book.bookGenre}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Synopsis</TableCell>
                                <TableCell>{book.synopsis}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell><Button size="small">Add to favourite</Button></TableCell>
                                <TableCell>  <Button href={book.link} target='_blank' size="small">Buy</Button></TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Button variant="contained" component={Link} to={`/catalog/`}>Return</Button>
            </Grid>
        </Grid>
    )
}