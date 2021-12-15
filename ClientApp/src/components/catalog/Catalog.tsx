import Book from '../../app/models/book';
import React, { useEffect, useState } from 'react';
import BookList from "./BookList";
import { Container } from '@mui/material';

export default function Catalog() {
    const [books, setBooks] = useState<Book[]>([]);

    useEffect(() => {
        //this function fetches our books from the API
        fetch('http://localhost:5000/api/Books')
            //the fetch returns a promise(response) which we format into a json object 
            .then(response => response.json())
            .then(data => setBooks(data))
        //we use the empty array dependency [] which makes sure that we only call useEffect() once. 
    }, [])


    return (
        <>
            <Container>
                   <BookList books={books} />
            </Container>
        </>
    );
}