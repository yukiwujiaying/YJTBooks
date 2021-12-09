import React from 'react';
import { useEffect, useState } from "react";
import LoadingComponent from '../../app/layout/LoadingComponent';
import { Book } from "../../app/layout/models/book";
import BookList from "./BookList";


export default function Catalog() {
    const [books, setbooks] = useState<Book[]>([]);
    const [loading, setLoading] =  useState(true);

    useEffect(()=>{
      fetch('https://localhost:44316/api/Books')
      .then(response=>response.json())
      .then(data=>setbooks(data))
      .finally(()=>setLoading(false))},
      [])
    if (loading) return <LoadingComponent message="Loading products..." />
      
    return (
        <>
            <BookList books={books}/>
        </>

    )
}
