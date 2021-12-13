import Book from '../../app/models/book';
import React, { useEffect, useState } from 'react';
import BookList from "./BookList";
import Header from '../../app/layout/Header';
import { CssBaseline } from '@material-ui/core';
import { Container } from '@mui/material';

export default function Catalog() {
    // const { id } = useParams()
    const [books, setBooks] = useState<Book[]>([]);
    // const url = `http://localhost:5000/api/books/${id}`

    useEffect(() => {

        //this function fetches our books from the API
        fetch('http://localhost:5000/api/books')
            //the fetch returns a promise(response) which we turn into  a json object 
            .then(response => response.json())
            .then(data => setBooks(data))
        //we use the empty array dependency [] which makes sure that we only call useEffect() once. 
    }, [])


    return (
        <>
            <CssBaseline />
            <Header />
            <Container>
                   <BookList books={books} />
            </Container>
        </>
    );
}