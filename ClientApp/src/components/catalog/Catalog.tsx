import Book from '../../app/models/book';
import React, { Component } from 'react';



//we use this to specify which attributes are required to be passed from Home to Catalog
interface Props {
    books: Book[];
}

export default function Catalog({books}: Props) {
    return (
        <>
              <ul>
                    {books.map((item, index) => (
                          <li key={index}>{item.bookId} - {item.title} - {item.author} - {item.price} - {item.amazonLink} - {item.synopsis} - {item.pictureUrl}</li>
                     ))}
              </ul>
        </>
            )
}