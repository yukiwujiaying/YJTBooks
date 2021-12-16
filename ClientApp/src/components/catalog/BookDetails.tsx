import React, { useEffect, useState } from 'react';
import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useParams } from 'react-router-dom';
import Book from '../../app/models/book';
import agent from '../../app/api/agent';
import LoadingComponent from '../../app/layout/LoadingComponent';
import NotFound from '../../app/api/errors/NotFound';


export default function BookDetails() {
    const { id } = useParams();
    const [books, setBook] = useState<Book | null>(null);
    const [loading, setLoading] = useState(true);
       

    useEffect(() => {
       agent.Catalog.details(parseInt(id))
           .then(response => setBook(response))
           //this is catching our error and print caught in the console
            .catch(error => console.log(error))
           .finally(() => setLoading(false))
    }, [id])


    if (loading) return <LoadingComponent message='Loading book..' />
    if (!books) return <NotFound />

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={books.pictureUrl} alt={books.title} style={{ width: '60%'}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{books.title}</Typography>
                <Divider variant="middle" sx={{ mb: 2 }} />
                <Typography variant='h4' color='secondary'>£{(books.price).toFixed(2)}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Title</TableCell>
                                <TableCell>{books.title}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Author</TableCell>
                                <TableCell>{books.author}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Genre</TableCell>
                                <TableCell>{books.bookGenre}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Synopsis</TableCell>
                                <TableCell>{books.synopsis}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell><Button size="small">Add to favourite</Button></TableCell>
                                <TableCell><Button href={books.amazonLink} target='_blank' size="small">Buy</Button></TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid> 
        </Grid>
    )
}