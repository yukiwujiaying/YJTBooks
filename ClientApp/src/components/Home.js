import React, { Component } from 'react';
import { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';

export function Home() {
    // const { id } = useParams()
    const [books, setBooks] = useState([]);
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

            <ul>
                {books.map((item, index) => (
                    <li key={index}>{item.bookId} - {item.title} - {item.author} - {item.price} - {item.amazonLink} - {item.synopsis} - {item.pictureUrl}</li>
                ))}
            </ul>

        </div>
    );
}
