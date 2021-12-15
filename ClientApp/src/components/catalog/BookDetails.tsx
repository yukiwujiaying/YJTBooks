import React from 'react';
import { Button, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { Book } from "../../app/layout/models/book";
import { Link } from 'react-router-dom';
import LoadingComponent from '../../app/layout/LoadingComponent';
import agent from '../../app/api/agent';
import NotFound from '../../app/errors/NotFound';

export default function BookDetails() {
    let { Id } = useParams();
    const [Book, setBook]= useState<Book | null>(null);
    const [loading, setloading]= useState(true);

    useEffect(()=>{
        agent.Catalog.details(parseInt(Id!))
             .then(response => setBook(response))
             .catch(error=> console.log(error))
             .finally(()=>setloading(false));
    },[Id])

    if (loading) return <LoadingComponent message="Loading products..." />
    
    if(!Book) return <NotFound />
    return(
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={Book.pictureUrl} alt={Book.title} style={{width:'80%'}}/>
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{Book.title}</Typography>
                <Divider sx={{mb:2}}/>
                <Typography variant='h4' color='secondary'>£{(Book.price).toFixed(2)}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Title</TableCell>
                                <TableCell>{Book.title}</TableCell>
                            </TableRow>
                           
                            <TableRow>
                                <TableCell>Author</TableCell>
                                <TableCell>{Book.author}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Genre</TableCell>
                                <TableCell>{Book.bookGenre}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Synopsis</TableCell>
                                <TableCell>{Book.synopsis}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell><Button size="small">Add to favourite</Button></TableCell>
                                <TableCell>  <Button href={Book.link} target='_blank' size="small">Buy</Button></TableCell>
                            </TableRow>                         
                        </TableBody>
                    </Table>
                </TableContainer>
                <Button variant="contained" component={Link} to={`/catalog/`}>Return</Button>
            </Grid>
        </Grid>
    )
}