import React, { Component } from 'react';
import { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import  Book  from '../app/models/book';
import  Catalog  from "./catalog/Catalog";

export function Home() {
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
        <div className='home'>
            <h1>TS IS WORKING, FINALLY!!!</h1>
            <Catalog books={books} />
        </div>
    );
}
