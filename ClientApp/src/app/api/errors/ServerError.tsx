import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { useLocation } from "react-router-dom";
import { myHistory } from "../../../history";
import React from 'react';

export default function ServerError() {
    const history = myHistory;
    const { state } = useLocation();
    return (
        <Container component={Paper}>
            {state?.error ? (
                <>
                    <Typography variant='h3' color='error' gutterBottom>{state.error.title}</Typography>
                    <Divider />
                    <Typography>{state.error.detaill || 'internal server error'}</Typography>
                </>
            ) : (
                <Typography variant='h5' gutterBottom>Server error</Typography>
            )}
            <Button onClick={() => history.push('/catalog')}>Go back to the store</Button>
        </Container>

    )
}