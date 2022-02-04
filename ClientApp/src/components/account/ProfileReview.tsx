import { Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Grid, Card, CardContent, Typography, CardMedia, CardActions } from "@mui/material";
import React, { useState } from "react";
import StableRating from "../../app/layout/StableRating";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { DeleteReview } from "./accountSlice";
import ModifyReview from "./ModifyReview";

interface BookReviewProps {
    id:number,
    publishedDate: string,
    title: string,
    username: string,
    description: string,
    rating:number,
    pictureUrl:string,
  
  }
  
  export default function BookReview({id,publishedDate,title,username,description,rating,pictureUrl}: BookReviewProps) {
    const {user,status} =useAppSelector(state=>state.account);
    const dispatch = useAppDispatch();
    const [isModifyVisible, setModifyVisible]=useState(false);
   

    if (!user?.bookReviews) {
      return <Typography variant='h3'>You do not write any review yet</Typography>
    }
    
    if (isModifyVisible) {
      return <ModifyReview 
                id={id} 
                closeReview={()=>setModifyVisible(false)} 
                pictureUrl={pictureUrl} 
                title={title} 
                description={description}
                rating={rating}/> 
    }

    return (
      <Grid item xs={1} md={12}>
  
          <Card sx={{ display: 'flex' }}>
          <CardMedia
                component="img"
                image={pictureUrl}
                
                sx={{ objectFit: 'cover', bgcolor: 'primary.light', width: 180 }}
            />
            <CardContent sx={{ flex: 1 }}>          
              <Typography component="h2" variant="h5">
                {title}
              </Typography>
              <Typography variant="subtitle1" color="text.secondary">
                <StableRating rating={rating}/>
              </Typography>           
              <Typography variant="subtitle1" paragraph>
               {description}
              </Typography>
              <Typography variant="subtitle1" color="text.secondary" >
                <span>From:</span>{username}
              </Typography>
              <Typography variant="subtitle1" color="text.secondary">
                 <span>Published Date:</span>{publishedDate}
              </Typography>
            </CardContent>
            <CardActions>
                <LoadingButton
                    loading={status==='pendingModifyReviews'}
                    onClick={() => setModifyVisible(!isModifyVisible)} >
                    <span>Modify</span>
                </LoadingButton>                
                <LoadingButton
                    loading={status==='pendingDeleteReviews'+ id +'del'}
                    onClick={() =>dispatch(DeleteReview({id}))}
                    color='error'>
                    <Delete />
                </LoadingButton>
            </CardActions>
          </Card>
          
      </Grid>
    );
  }