import { Add, Delete, Remove } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import React from "react";
import { useState } from "react";
import { Link } from "react-router-dom";
import agent from "../../app/api/agent";
import { useStoreContext } from "../../app/context/StoreContext";


export default function FavouriteBookListPage() {

    const { favouriteBookList, removeItem } = useStoreContext();
    const [status, setStatus] = useState({
        loading: false,
        name: ''
    });

    function handleRemoveItem(bookId: number, name: string, quantity = 1) {
        setStatus({ loading: true, name: name });
        agent.FavouriteBookList.removeItem(bookId, quantity)
            .then(() => removeItem(bookId, quantity))
            .catch(error => console.log(error))
            .finally(() => setStatus({ loading: false, name: '' }))
    }

    if (!favouriteBookList) return <Typography variant='h3'>Your Favourite Book List is empty</Typography>

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell>Book</TableCell>
                            <TableCell align="right">Genre</TableCell>
                            <TableCell align="right">Author</TableCell>
                            <TableCell align="right">Details</TableCell>
                            <TableCell align="right">Link</TableCell>
                            <TableCell align="right">Price</TableCell>
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
                                <TableCell align="right">{item.genre}</TableCell>
                                <TableCell align="right">
                                    {item.author}
                                </TableCell>
                                <TableCell  align="right">
                                    <Button component={Link} to={`/catalog/${item.bookId}`} size="small">View</Button>
                                </TableCell>
                                <TableCell align="right">
                                    <Button  href={item.link} target='_blank' size="small">Buy</Button>
                                </TableCell>
                                <TableCell align="right">$ {((item.price * item.quantity)).toFixed(2)}</TableCell>
                                <TableCell align="right">
                                    <LoadingButton
                                        loading={status.loading && status.name === 'del' + item.bookId}
                                        onClick={() => handleRemoveItem(item.bookId, 'del' + item.bookId, item.quantity)}
                                        color='error'>
                                        <Delete />
                                    </LoadingButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </>
    )
}