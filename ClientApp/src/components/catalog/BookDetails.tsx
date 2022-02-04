import React from 'react';
import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { Link } from 'react-router-dom';
import LoadingComponent from '../../app/layout/LoadingComponent';
import NotFound from '../../app/errors/NotFound';
import { LoadingButton } from '@mui/lab';
import { StarBorder } from '@mui/icons-material';
import StarIcon from '@mui/icons-material/Star';
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore';
import { addFavouriteBookListItemAsync, removeFavouriteBookListItemAsync } from '../FavouriteBookList/FavouriteBookListSlice';
import BookReview from './BookReview';
import { fetchBookAsync, ClearState } from './bookSlice';
import AddReview from '../../app/layout/AddReview';

export default function BookDetails() {
    const {favouriteBookList,status} = useAppSelector(state=>state.favouriteBookList);
    const dispatch = useAppDispatch();
    let { Id } = useParams();
    const [isFavourite, setIsFavourite] = useState(false);
    const {user} = useAppSelector(state=>state.account);
    const {book, status:bookStatus} = useAppSelector(state=>state.book);

    useEffect(()=>{
        console.log("useEffect", book);
        if(!book) dispatch(fetchBookAsync(parseInt(Id!)));
        
    },[Id,dispatch, book])

    // useEffect(() => {
    //     console.log("Loaded");

    //     agent.Catalog.details(parseInt(Id!))
    //         .then(response => setBook(response))
    //         .catch(error => console.log(error))
    //         .finally(() => setloading(false));
    // }, [])

    useEffect(() => {
        if (book == null) return;

        console.log("book", book);

        if (favouriteBookList?.items.some(i => i.bookId === book.id)) {
            setIsFavourite(true);
        } else {
            setIsFavourite(false);
        }

    }, [book, favouriteBookList])

    function handleFavouriteClick(bookId: number) {

        setIsFavourite(!isFavourite);

        if (isFavourite) {
            dispatch(removeFavouriteBookListItemAsync({bookId: bookId, quantity:1}));
            return;
        }
        dispatch(addFavouriteBookListItemAsync({bookId: bookId}));

    }
    if (bookStatus.includes('pending')) return <LoadingComponent message='Loading book' />
    if(!book) return <NotFound />
    // function addBookToFavourites(bookId: number) {
    //     setSubmitting(true);
    //     agent.FavouriteBookList.addItem(bookId)
    //         .then(favouriteBookList => setFavouriteBookList(favouriteBookList))
    //         .catch(error => console.log(error))
    //         .finally(() => setSubmitting(false));
    // }

    // function removeBookFromFavourites(bookId: number) {
    //     setSubmitting(true);
    //     agent.FavouriteBookList.removeItem(bookId, 1)
    //         .then(() => removeItem(bookId, 1))
    //         .catch(error => console.log(error))
    //         .finally(() => setSubmitting(false))
    // }

    // if (loading) return <LoadingComponent message="Loading books..." />
    // if (!book) return <NotFound />
    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={book.pictureUrl} alt={book.title} style={{ width: '80%' }} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>
                    {book.title}
                    {
                        user?
                            <LoadingButton 
                                loading={status.includes('pending')}
                                onClick={() => handleFavouriteClick(book.id)}
                                size="small">
                                {isFavourite ? <StarIcon fontSize="large" /> : <StarBorder fontSize="large" />}
                            </LoadingButton>
                            :
                            <LoadingButton 
                                size="small"
                                component={Link} to={`/login`}>                               
                                <StarBorder fontSize="large" />
                            </LoadingButton>
                    }
                    
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
                                <TableCell>{book.genre}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Synopsis</TableCell>
                                <TableCell>{book.synopsis}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    <Button href={book.link} target='_blank' size="small">Buy</Button>
                                </TableCell>
                                <TableCell>
                                    {user?
                                        <Button 
                                        onClick={() => handleFavouriteClick(book.id)} 
                                        size="small">
                                        {isFavourite ? <span>remove from favourite</span> : <span>Add to favourite</span>}
                                    </Button>:
                                         <Button component={Link} to={`/login`} size="small"><span>Add to favourite</span></Button>
                                        }
                                    
                                </TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Button variant="contained" component={Link} to={`/catalog/`} onClick={()=>{dispatch(ClearState())}}>Return</Button>
               
            </Grid>
            {user&&  <AddReview bookId={book.id} userId={user.id}/> }
           
            {book.bookReviews && 
            
                book.bookReviews.map(review=>(
                    <Grid item xs={12} key={review.id} > <BookReview 
                                                            publishedDate={review.publishedDate} 
                                                            title={review.title} description={review.description} 
                                                            username={review.userName} 
                                                            rating={review.rating}/></Grid>
                ))}
            
        </Grid>
        
    )
}