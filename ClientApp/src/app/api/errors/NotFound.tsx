import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import React from 'react';

export default function NotFound() {
    return (
        <Container component={Paper} sx={{ height: 520 }}>
            <Typography gutterBottom variant='h3'>Opps - we could not find what you are looking for</Typography>
            <Divider />
            <Button fullWidth component={Link} to='/catalog'>Go back to catalog</Button>
        </Container>
    )
}