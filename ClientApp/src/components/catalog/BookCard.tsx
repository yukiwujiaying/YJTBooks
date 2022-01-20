import React, { useEffect, useState } from 'react';
import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { Book } from "../../app/layout/models/book";
import { Link } from 'react-router-dom';
import { LoadingButton } from '@mui/lab';
import { StarBorder } from '@mui/icons-material';
import StarIcon from '@mui/icons-material/Star';
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore';
import { addFavouriteBookListItemAsync, removeFavouriteBookListItemAsync } from '../FavouriteBookList/FavouriteBookListSlice';

interface Props {
    book: Book;
}

export default function BookCard({ book }: Props) {
    const {favouriteBookList,status} = useAppSelector(state=>state.favouriteBookList);
    const dispatch = useAppDispatch();
    const [favourite, setFavourite] = useState(book.isFavourite);
    const {user} = useAppSelector(state=>state.account);


    useEffect(() => {
        if (book == null) return;

        if (favouriteBookList?.items.some(i => i.bookId === book.id)) {
            setFavourite(true);
        } else {
            setFavourite(false);
        }
    }, [book])

    function handleClick(bookId: number){
        setFavourite(!favourite);
        if(favourite){ 
            dispatch(removeFavouriteBookListItemAsync({bookId: bookId, quantity: 1}))
            return;
        }
        dispatch(addFavouriteBookListItemAsync({bookId: bookId}));            
    }
    // const [loading, setloading] = useState(false);
    // const { setFavouriteBookList,removeItem } = useStoreContext();
    // const [toggle, setToggle] = useState(book.isFavourite);

    // function handleAddItem(bookId: number) {
    //     setloading(true);
    //     agent.FavouriteBookList.addItem(bookId)
    //         .then(favouriteBookList => setFavouriteBookList(favouriteBookList))
    //         .catch(error => console.log(error))
    //         .finally(() => setloading(false));
    // }

    // function handleRemoveItem(bookId: number, quantity = 1){
    //     setloading(true);
    //     agent.FavouriteBookList.removeItem(bookId,quantity)
    //          .then(()=>removeItem(bookId,quantity))
    //          .catch(error => console.log(error))
    //          .finally(()=>setloading(false))
    //   }

    //   function handleClick(bookId: number, isFavourite: boolean){
    //       setToggle( isFavourite )
    //       if(isFavourite){ 
    //           handleAddItem(bookId)
    //         }else{
    //             handleRemoveItem(bookId);
    //         }
    //    }
      
    return (
        <Card sx={{ display: 'flex' }}>
            <CardMedia
                component="img"
                //height="140"
                image={book.pictureUrl}
                sx={{ objectFit: 'cover', bgcolor: 'primary.light', width: 180 }}
                title={book.title}
            />
            <CardContent>
                <Typography gutterBottom color='secondary' variant="h5">
                    <Link to={`/catalog/${book.id}`} className="linkOfAmazon">{book.title}</Link>
                    {user?
                        <LoadingButton 
                            loading={status.includes('pending' + book.id)}
                            onClick={() => handleClick(book.id)}
                            size="small"
                            >
                            {favourite ?  <StarIcon/>:<StarBorder/>}
                        </LoadingButton>
                        :
                        <LoadingButton 
                        component={Link} to={`/login`}
                        size="small"
                        >
                        <StarBorder/>
                    </LoadingButton>                
                    }
                </Typography>
                <Typography variant="h6">
                    £{(book.price).toFixed(2)}
                </Typography>
                <Typography>
                    {book.bookGenre}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {book.author}
                    <Button href={book.link} target='_blank' size="small">Buy</Button>
                </Typography>
                <Typography className="synopsis">
                    {book.synopsis}
                </Typography>
            </CardContent>
            <CardActions>               
                <Button component={Link} to={`/catalog/${book.id}`} size="small">View</Button>
            </CardActions>
        </Card>
    );
}