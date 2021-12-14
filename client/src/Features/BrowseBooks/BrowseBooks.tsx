import { useEffect, useState } from "react";
import { Book } from "../book";
import BookList from "./BookList";

interface Props {
  books: Book[];
}

export default function BrowseBooks() {
  const [books, setBooks] = useState<Book[]>([]);

  useEffect(() => {
    fetch("http://localhost:5000/yjkbooks/Books")
      .then((response) => response.json())
      .then((data) => setBooks(data));
  }, []);

  return (
    <>
      <BookList books={books} />
    </>
  );
}
