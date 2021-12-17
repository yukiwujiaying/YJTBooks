import React from 'react';
import { useEffect, useState } from "react";
import agent from '../../app/api/agent';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { Book } from "../../app/layout/models/book";
import BookList from "./BookList";

export default function Catalog() {
    const [books, setbooks] = useState<Book[]>([]);
    const [loading, setLoading] =  useState(true);

    useEffect(()=>{
      agent.Catalog.list().then(books => setbooks(books))
                          .catch(error => console.log(error))
                          .finally(()=>setLoading(false))
    }, []);

    if (loading) return <LoadingComponent message="Loading products..." />
      
    return (
        <BookList books={books}/>
    );
}
