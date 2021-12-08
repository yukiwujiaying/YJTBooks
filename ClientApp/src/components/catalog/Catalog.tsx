import React from 'react';
import { useEffect, useState } from "react";
import { Book } from "../../app/layout/models/book";
import BookList from "./BookList";


export default function Catalog() {
    const [books, setbooks] = useState<Book[]>([]);

    useEffect(()=>{
      fetch('https://localhost:44316/api/Books')
      .then(response=>response.json())
      .then(data=>setbooks(data))},
      [])
      
    return (
        <>
            <BookList books={books}/>
        </>

    )
}
