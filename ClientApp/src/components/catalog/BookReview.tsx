import * as React from 'react';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import StableRating from '../../app/layout/StableRating';


interface BookReviewProps {
  publishedDate: string,
  title: string,
  username: string,
  description: string,
  rating:number,

}

export default function BookReview({publishedDate,title,username,description,rating}: BookReviewProps) {


  return (
    <Grid item xs={1} md={12}>

        <Card sx={{ display: 'flex' }}>
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
        </Card>
        
    </Grid>
  );
}