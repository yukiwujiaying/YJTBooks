import React, { useEffect, useState } from 'react';
import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useParams } from 'react-router-dom';
import axios from 'axios';
import Book from '../../app/models/book';


export default function BookDetails() {
    const { id } = useParams();
    const [books, setBook] = useState<Book | null>(null);
       

    useEffect(() => {
        axios.get(`http://localhost:5000/api/Books/${id}`)
            .then(response => setBook(response.data))
            .catch(error => console.log(error))
    }, [id])

    
    if (!books) return <h1>"Book not found..." </h1>

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