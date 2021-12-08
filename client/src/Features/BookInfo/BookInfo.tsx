import Divider from "@mui/material/Divider";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Book } from "../book";

export default function BookInfo() {
  const { id } = useParams<{id: string}>();
  const [book, setBook] = useState<Book | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get(`http://localhost:5000/yjkbooks/books/${id}`)
      .then((response) => setBook(response.data))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <h3>Loading...</h3>;

  if (!book) return <h3>Product not found.</h3>;

  return (
    <Grid>
      <Grid item xs={6}>
        <img src={book.pictureUrl} alt={book.title} style={{width: '100%'}} />
      </Grid>
      <Grid>
          <Typography variant='h3'>{book.title}</Typography>
          <Divider sx={{mb: 2}} /> 
      </Grid>
    </Grid>
  );
}
