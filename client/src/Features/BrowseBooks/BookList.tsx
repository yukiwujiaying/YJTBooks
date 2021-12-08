import Grid from "@mui/material/Grid";
import { Book } from "../book";
import BookInfo from "./BookCard";

interface Props {
  books: Book[];
}

export default function BookList({ books }: Props) {
  return (
    <Grid container spacing={4}>
      {books.map((book) => (
        <Grid item xs={3} key={book.id}>
          <BookInfo key={book.id} book={book} />
        </Grid>
      ))}
    </Grid>
  );
}
