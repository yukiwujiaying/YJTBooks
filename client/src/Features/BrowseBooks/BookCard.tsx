import { Book } from "../book";
import Card from "@mui/material/Card";
import CardMedia from "@mui/material/CardMedia";
import Button from "@mui/material/Button";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";
import Typography from "@mui/material/Typography";
import { Link } from "react-router-dom";

interface Props {
  book: Book;
}

export default function BookCard({ book }: Props) {
  return (
    <>
    <Card sx={{ maxWidth: 345, backgroundSize: "contain" }}>
      <CardMedia component="img" height="140" image={book.pictureUrl} />
      <CardContent sx={{ bgcolor: "AliceBlue" }}>
        <Typography
          gutterBottom
          variant="h5"
          component={Link}
          to={`/browsebooks/${book.id}`}
          sx={{textDecoration: 'none'}}
        >
          {book.title}
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {book.author}
        </Typography>
      </CardContent>
      <CardActions sx={{ bgcolor: "AliceBlue" }}>
        <Button size="small">Share</Button>
        <Button size="small" component={Link} to={`/browsebooks/${book.id}`}>
          View Book
        </Button>
      </CardActions>
    </Card>
    </>
  );
}
