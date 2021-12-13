import React, { Component } from 'react';
import { AppBar, Typography } from "@material-ui/core"
import { Toolbar } from "@mui/material"


export default function Header() {
    return (
        <AppBar position='static' sx={{ mb: 4 }}>
             <Toolbar>
                <Typography variant='h6' >
                      YJK BookStore
                </Typography>
            </Toolbar>
        </AppBar>
        
        )
}