import React, { useEffect, useState } from 'react';
import { Typography } from "@mui/material";
import { useParams } from 'react-router-dom';
import axios from 'axios';
import Book from '../../app/models/book';
import { FetchData } from '../FetchData';


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
        <Typography variant='h2'>
            {books.title}
        </Typography>
    )
}