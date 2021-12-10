import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import React from 'react';

export default function NotFound(){
    return(
        <Container component={Paper} sx={{height:600}}>
            <Typography variant='h3'>Opps - we could mot find what you are looking for</Typography>
            <Divider />
            <img src="https://www.relationshipcoachinginstitute.com/wp-content/uploads/question-fi.jpg" alt="NotFound" className="center"  />
            <Button fullWidth component = {Link} to='/catalog'>Go back to shop</Button>
        </Container>
    )
}