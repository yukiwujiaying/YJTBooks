import Book from '../../app/models/book';
import React, { useEffect, useState } from 'react';
import BookList from "./BookList";
import { Container } from '@mui/material';
import agent from '../../app/api/agent';
import LoadingComponent from '../../app/layout/LoadingComponent';

export default function Catalog() {
    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        agent.Catalog.list()
            .then(books => setBooks(books))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, [])

    if(loading) return <LoadingComponent message ="Loading books.."/> 


    return (
        <>
            <Container>
                   <BookList books={books} />
            </Container>
        </>
    );
}