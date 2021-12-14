import Divider from "@mui/material/Divider";
import Grid from "@mui/material/Grid";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableRow from "@mui/material/TableRow";
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
    axios.get(`http://localhost:5000/yjkbooks/Books/${id}`)
      .then((response) => setBook(response.data))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <h3>Loading...</h3>;

  if (!book) return <h3>Product not found.</h3>;

  return (
    <Grid container spacing={6}>
      <Grid item xs={6}>
        <img src={book.pictureUrl} alt={book.title} style={{width: '80%'}} />
      </Grid>
      <Grid item xs={6}>
          <Typography variant='h4'>{book.title}</Typography>
          <Divider sx={{mb: 2}} /> 
          <Typography variant='h6'color="gray">{book.author}</Typography>
          <TableContainer>
            <Table>
              <TableBody>
                <TableRow>
                  <TableCell>Title</TableCell>
                  <TableCell>{book.title}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Author</TableCell>
                  <TableCell>{book.author}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Genre</TableCell>
                  <TableCell>{book.genre}</TableCell>
                </TableRow>
                <TableRow>
                  <TableCell>Synopsis</TableCell>
                  <TableCell>{book.synopsis}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
      </Grid>
    </Grid>
  );
}
