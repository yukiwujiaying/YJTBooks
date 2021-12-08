import React from "react";
import { ProductionQuantityLimitsSharp } from "@mui/icons-material";
import { Typography } from "@mui/material";
import { Book } from "../book";
import BookInfo from "./BookCard";
import BookList from "./BookList";


interface Props {
  books: Book[];
}

export default function BrowseBooks({books}: Props) {
  return (
    <>
    <BookList books={books}/>
    </>
  )
}
