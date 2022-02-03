import { Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Grid, Typography, Divider, TableContainer, Table, TableBody, TableRow, TableCell, Button, Box, Paper, TableHead } from "@mui/material";
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { ClearState } from "../catalog/bookSlice";
import { removeFavouriteBookListItemAsync } from "../FavouriteBookList/FavouriteBookListSlice";
import { fetchCurrentUser } from "./accountSlice";
import ProfileReview from "./ProfileReview";

export default function Profile(){
    const {favouriteBookList,status} = useAppSelector(state=>state.favouriteBookList);
    const dispatch = useAppDispatch();
    const {user} = useAppSelector(state=>state.account);

    useEffect(()=>{
        console.log("loaded");
        dispatch(fetchCurrentUser());    
    },[dispatch])
    console.log("user bookreview", user?.bookReviews);
    return(
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img alt="userProfileImage" src={"https://static.vecteezy.com/system/resources/previews/000/573/503/original/vector-sign-of-user-icon.jpg"} style={{ width: '80%' }} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>
                    {user?.userName}              
                </Typography>

                <Divider sx={{ mb: 2 }} />
                <Typography variant='h4' color='secondary'>{user?.email}</Typography>
                <TableContainer component={Paper}>
                    {favouriteBookList?
                        <Table sx={{ minWidth: 500 }}>
                        <TableHead>
                            <TableRow>
                                <TableCell>Book</TableCell>
                                <TableCell align="right">Details</TableCell>
                                <TableCell align="right"></TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {favouriteBookList.items.map(item => (
                                <TableRow
                                    key={item.bookId}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell component="th" scope="row">
                                        <Box display='flex' alignItems='center'>
                                            <img src={item.pictureUrl} alt={item.title} style={{ height: 50, marginRight: 20 }} />
                                            <span>{item.title}</span>
                                        </Box>
                                    </TableCell>
                                    <TableCell  align="right">
                                        <Button component={Link} to={`/catalog/${item.bookId}`} size="small">View</Button>
                                    </TableCell>
                                    <TableCell align="right">
                                        <LoadingButton
                                            loading={status==='pendingRemoveItem'+ item.bookId +'del'} 
                                            onClick={()=>dispatch(removeFavouriteBookListItemAsync({
                                                bookId: item.bookId, 
                                                quantity: 1,
                                                name: 'del'
                                            }))} 
                                            color='error'>
                                            <Delete />
                                        </LoadingButton>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>: <Typography variant='h3'>Your Favourite Book List is empty</Typography>
                    }
                   
                </TableContainer>
                <Button variant="contained" component={Link} to={`/catalog/`} onClick={()=>{dispatch(ClearState())}}>Return</Button>
               
            </Grid>
            {user?.bookReviews && 
            
            user?.bookReviews.map(review=>(
                <Grid item xs={12} key={review.id} > <ProfileReview
                                                        id={review.id}
                                                        publishedDate={review.publishedDate} 
                                                        title={review.title} description={review.description} 
                                                        username={user.userName}
                                                        rating={review.rating}
                                                        pictureUrl={review.pictureUrl}
                                                        /></Grid>
            ))}
        
            
        </Grid>
    );
}